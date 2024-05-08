using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float speed;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private IEnumerator PassThrough(Collider2D otherCollider, float duration)
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), otherCollider, true);
        yield return new WaitForSeconds(duration);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), otherCollider, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            rigidbody.AddForce(collision.transform.right * speed, ForceMode2D.Impulse);

        }     
        else if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                StartCoroutine(PassThrough(collision.collider, 1f));
                Destroy(gameObject);


            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        // Periksa apakah objek yang bersentuhan adalah tong
        if (other.CompareTag("Obstacle"))
        {
            // Sembunyikan atau hancurkan tong
            Destroy(other.gameObject); // Menghancurkan tong dari hierarki game object
                                       // atau
                                       // other.gameObject.SetActive(false); // Menyembunyikan tong
        }        
    }
    private void Update()
    {

    }
}