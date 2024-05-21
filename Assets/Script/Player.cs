using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*public AudioSource SoundEffect;*/
    private Rigidbody2D body;
    private new Collider2D collider;
    private Collider2D[] results;
    private Vector2 direction;
    public float moveSpeed = 1f;
    public float jumpStrength = 1f;
    private bool grounded;
    private bool climbing;
    private Animator anim;
    private bool isImmune = false;
    [SerializeField] private float damageBarrel;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        results = new Collider2D[4];
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void CheckCollision()
    {
        grounded = false;
        climbing = false;

        Vector2 size = collider.bounds.size;
        size.y += 0.1f;
        size.x /= 2;

        int amount = Physics2D.OverlapBoxNonAlloc(transform.position, size, 0f, results);

        for (int i = 0; i < amount; i++)
        {
            GameObject hit = results[i].gameObject;

            if (hit.layer == LayerMask.NameToLayer("Ground"))
            {
                grounded = hit.transform.position.y < (transform.position.y - 0.5f);
                //IgnoreCollision
                Physics2D.IgnoreCollision(collider, results[i], !grounded);
            }
            if (hit.layer == LayerMask.NameToLayer("Ground_Left"))
            {
                grounded = hit.transform.position.y < (transform.position.y - 0.5f);
                //IgnoreCollision
                Physics2D.IgnoreCollision(collider, results[i], !grounded);
            }
            else if (hit.layer == LayerMask.NameToLayer("Ladder"))
            {
                climbing = true;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<Health>().TakeDamage(1);
        }
        CheckCollision();
        if (climbing)
        {
            direction.y = Input.GetAxis("Vertical") * moveSpeed;
        }
        else if (grounded && Input.GetButtonDown("Jump"))
        {
            direction = Vector2.up * jumpStrength;
            anim.SetTrigger("jump");
            /*SoundEffect.PlayOneShot(SoundEffect.clip);*/
            /*SoundManager.Instance.SoundJump.PlayOneShot;*/
            /*SoundManager.Instance.SoundJump();*/
            SoundManager.Instance.JumpSoundd();

        }
        else
        {
            direction += Physics2D.gravity * Time.deltaTime;
        }
        direction.x = Input.GetAxis("Horizontal") * moveSpeed;
        //Running Animation If Moved
        if (direction.x != 0)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }

        if (grounded)
        {
            direction.y = Mathf.Max(direction.y, -1f);
        }

        if (direction.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (direction.x < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + direction * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss") && !isImmune)
        {
            GetComponent<Health>().TakeDamageBoss(1);
            StartCoroutine(BecomeImmune());
            StartCoroutine(Blink());
        }
    }

    private IEnumerator BecomeImmune()
    {
        isImmune = true;
        Physics2D.IgnoreCollision(collider, GameObject.FindGameObjectWithTag("Boss").GetComponent<Collider2D>(), true);
        yield return new WaitForSeconds(2);
        Physics2D.IgnoreCollision(collider, GameObject.FindGameObjectWithTag("Boss").GetComponent<Collider2D>(), false);
        isImmune = false;
    }

    private IEnumerator Blink()
    {
        float duration = 1f; // Blinking duration in seconds
        float blinkTime = 0.1f; // Time interval between blinks
        float endTime = Time.time + duration;
        while (Time.time < endTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkTime);
        }
        spriteRenderer.enabled = true; // Ensure sprite is visible when done blinking
    }
}
