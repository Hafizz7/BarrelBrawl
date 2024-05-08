using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    /*public static Transform lastCheckPointPos;*/
    /*public Vector3 spawnPoint;
    public bool isActivated = false;*/
    private GameManager gm;



    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        /*if (lastCheckPoint == null)
        {
            lastCheckPoint = transform;
        }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;
            other.GetComponent<Health>().SetRespawnPosition(transform.position); // Menetapkan posisi respawn saat pemain masuk ke checkpoint
        }
    }
}
