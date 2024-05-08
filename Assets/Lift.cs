using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Transform topPosition; // posisi atas lift
    public Transform bottomPosition; // posisi bawah lift
    public float speed = 2f; // kecepatan lift

    private bool movingUp = true; // lift sedang bergerak naik

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, topPosition.position, speed * Time.deltaTime);

            if (transform.position == topPosition.position)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, bottomPosition.position, speed * Time.deltaTime);

            if (transform.position == bottomPosition.position)
            {
                movingUp = true;
            }
        }
    }
}
