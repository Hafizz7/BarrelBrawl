using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool jump;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //rotate karakter
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3((float)2.931089, (float)3.234094, 1);
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3((float)-2.931089, (float)3.234094, 1);

        if (Input.GetKey(KeyCode.UpArrow))
            Jump();

        //parameter animation untuk jalan dan idle
        anim.SetBool("run", horizontalInput != 0);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
    }

}
