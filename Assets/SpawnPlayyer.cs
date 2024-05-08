using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayyer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawnPoint;

    public void Spawn()
    {
        transform.position = spawnPoint.position;
    }
}
