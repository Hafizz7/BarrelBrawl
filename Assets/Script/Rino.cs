using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rino : MonoBehaviour
{
    public Transform posisiAwal; // posisi atas lift
    public Transform posisiAkhir; // posisi bawah lift
    public float speed2 = 2f; // kecepatan lift
    



    private bool movingUp = true; 
    void Update()
    {
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, posisiAwal.position, speed2 * Time.deltaTime);

            if (transform.position == posisiAwal.position)
            {
                FlipCharacter();
                movingUp = false;
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
