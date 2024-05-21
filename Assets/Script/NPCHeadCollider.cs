using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHeadCollider : MonoBehaviour
{
    private BossMovement bossMovement;

    private void Start()
    {
        bossMovement = GetComponentInParent<BossMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Damage the NPC if the player jumps on its head
            bossMovement.TakeDamage(20); // Adjust the damage value as needed

            // Optionally, apply force to the player to simulate bounce
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse); // Adjust force value as needed
            }
        }
    }
}
