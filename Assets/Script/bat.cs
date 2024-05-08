using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    public Transform posisiAwal; // posisi atas lift
    public Transform posisiAkhir; // posisi bawah lift
    public float speed2 = 2f; // kecepatan lift
    public float delayTime = 5f; // waktu delay sebelum bergerak ke posisi akhir
    /*float distanceThreshold = 0.001f; // Atur ambang jarak yang sesuai*/

    private bool movingUp = true;
    private float timer = 0f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();        
    }

    void Update()
    {
        if (timer <= 0f)
        {
            if (movingUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, posisiAwal.position, speed2 * Time.deltaTime);

                if (transform.position == posisiAwal.position)
                {
                    FlipCharacter();
                    movingUp = false;
                    timer = delayTime; // Atur timer ke waktu delay sebelum bergerak ke posisi akhir
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, posisiAkhir.position, speed2 * Time.deltaTime);

                if (transform.position == posisiAkhir.position)
                {
                    FlipCharacter();
                    movingUp = true;
                }
            }
        }
        else
        {
            timer -= Time.deltaTime; // Kurangi timer
        }

        // Mengatur parameter animator berdasarkan apakah lift sedang bergerak atau tidak
        if (transform.position != posisiAwal.position && transform.position != posisiAkhir.position)
        {
            animator.SetBool("flay", true);
            animator.SetBool("idle", false);
        }
        else
        {
            animator.SetBool("flay", false);
            animator.SetBool("idle", true);
        }
    }

    private IEnumerator PassThrough(Collider2D otherCollider, float duration)
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), otherCollider, true);
        yield return new WaitForSeconds(duration);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), otherCollider, false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                StartCoroutine(PassThrough(collision.collider, 1f));

            }
        }

    }
    // Fungsi untuk membalikkan karakter
    void FlipCharacter()
    {
        // Balikkan skala karakter di sumbu Y
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
