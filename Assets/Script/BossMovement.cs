using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    // Movement settings
    public float moveSpeed = 2f;
    public float dashInterval = 5f;
    public float dashForce = 10f;
    private Rigidbody2D rb;
    private float nextDashTime;

    // Health settings
    public int maxHealth = 100;
    private int currentHealth;

    // Movement direction
    private Vector2 moveDirection = Vector2.right;
    private Animator animator;

    private bool isDashing = false;

    // Player reference
    private Collider2D playerCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        nextDashTime = Time.time + dashInterval;
        animator = GetComponent<Animator>();

        // Find player by tag (assuming there's only one player in the scene)
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }

    private void Update()
    {
        // Regular movement
        if (!isDashing)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
            animator.SetBool("IsWalking", true);
        }

        // Dashing Mechanism
        if (Time.time >= nextDashTime)
        {
            StartCoroutine(Dash());
            nextDashTime = Time.time + dashInterval;
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        animator.SetTrigger("Attacking"); // Trigger attack animation

        // Apply dash force
        rb.velocity = new Vector2(moveDirection.x * dashForce, rb.velocity.y);

        // Wait for the dash duration (adjust as needed)
        yield return new WaitForSeconds(0.5f);

        isDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            // Change direction on wall collision
            moveDirection = -moveDirection;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Revert the NPC back to dynamic to allow movement
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"NPC Health: {currentHealth}");
        if (currentHealth <= 0)
        {
            // Handle NPC death (e.g., play animation, destroy NPC, etc.)
            Destroy(gameObject);
        }

        // Trigger the 'Damaged' animation and stop movement for a while
        animator.SetTrigger("Damaged");
        rb.velocity = Vector2.zero;
        StartCoroutine(StopMovementTemporarily(1f)); // Adjust the duration as needed

        // Temporarily disable collision with the player
        StartCoroutine(DisableCollisionWithPlayer(1f)); // Adjust the duration as needed
    }

    private IEnumerator StopMovementTemporarily(float duration)
    {
        float originalSpeed = moveSpeed;
        moveSpeed = 0;
        yield return new WaitForSeconds(duration);
        moveSpeed = originalSpeed;
    }

    private IEnumerator DisableCollisionWithPlayer(float duration)
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider, true);
        yield return new WaitForSeconds(duration);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider, false);
    }
}