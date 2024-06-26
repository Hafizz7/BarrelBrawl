using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DeteksiLompatan : MonoBehaviour
{
    public Transform barrel;  // Referensi ke objek tong
    public Vector3 offset;    // Offset posisi relatif terhadap tong
    public int score;

    void Update()
    {
        // Menjaga posisi pendeteksi lompat tetap di atas tong
        if (barrel != null)
        {
            transform.position = barrel.position + offset;
            // Reset rotasi pendeteksi lompat agar tidak berputar
            transform.rotation = Quaternion.identity;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(score);
            // Nonaktifkan collider agar tidak bisa digunakan lagi
            GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            UnityEngine.Debug.Log("ScoreManager instance is null");
        }
    }
}
