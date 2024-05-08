using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tombak : MonoBehaviour
{
    // Start is called before the first frame update
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
}
