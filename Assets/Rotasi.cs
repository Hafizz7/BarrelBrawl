using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotasi : MonoBehaviour
{
    public float targetRotation = 80f; // Sudut rotasi yang diinginkan
    public float rotationSpeed = 20f; // Kecepatan rotasi dalam derajat per detik
    private bool rotating = true; // Status apakah objek sedang berputar atau tidak

    void Update()
    {
        if (rotating)
        {
            // Menghitung rotasi baru
            float newRotation = transform.rotation.eulerAngles.z + rotationSpeed * Time.deltaTime;

            // Memastikan rotasi tetap di antara 0 dan 360 derajat
            if (newRotation >= 30f)
                newRotation -= 30f;

            // Mengatur rotasi objek
            transform.rotation = Quaternion.Euler(0, 0, newRotation);

            // Memeriksa apakah sudut rotasi telah mencapai target
            if (Mathf.Abs(transform.rotation.eulerAngles.z - targetRotation) <= 0.1f)
            {
                rotating = false; // Menghentikan rotasi
            }
        }
    }
}
