using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public class Boss : MonoBehaviour
    {
        public float moveSpeed = 2f;
        public float dashSpeed = 10f;
        public float dashDuration = 1f;
        public float dashCooldown = 5f;
        public Transform[] movePoints;

        private int currentPointIndex = 0;
        private bool isDashing = false;
        private float dashTime = 0f;
        private float dashCooldownTime = 0f;
        private Transform player;

        void Start()
        {
            if (movePoints.Length > 0)
            {
                transform.position = movePoints[0].position;
            }
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Update()
        {
            if (isDashing)
            {
                Dash();
            }
            else
            {
                MoveBackAndForth();
                if (Time.time >= dashCooldownTime)
                {
                    StartDash();
                }
            }
        }

        void MoveBackAndForth()
        {
            if (movePoints.Length == 0) return;

            Transform targetPoint = movePoints[currentPointIndex];
            transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                currentPointIndex = (currentPointIndex + 1) % movePoints.Length;
            }
        }

        void StartDash()
        {
            isDashing = true;
            dashTime = Time.time + dashDuration;
        }

        void Dash()
        {
            if (player == null) return;

            transform.position = Vector2.MoveTowards(transform.position, player.position, dashSpeed * Time.deltaTime);

            if (Time.time >= dashTime)
            {
                isDashing = false;
                dashCooldownTime = Time.time + dashCooldown;
            }
        }
    }
}