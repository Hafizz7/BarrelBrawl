using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float countDown;
    public float spedd;
    public Health health;
    private bool isPaused = false;
    private bool isGameOver = false; // Tambahkan variabel untuk menandai status game over

    /*public AudioSource audioSource;*/
    /*public AudioClip audioClip;*/
    private bool isAudioSpeedUp = false;

    /*void Start()
    {
        // Ambil komponen AudioSource jika belum ada
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Tetapkan audioClip jika belum ada
        *//*if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }*//*

        // Mainkan audio secara looping
        audioSource.loop = true;
        audioSource.Play();
    }*/

    void Update()
    {
        if (!isGameOver) // Pastikan bahwa perhitungan waktu hanya dilakukan jika permainan belum berakhir
        {
            countDown -= Time.deltaTime;
            if (countDown < spedd && !isAudioSpeedUp)
            {


                SoundManager.Instance.BackgroundMusic.pitch = 1.2f; // Set pitch menjadi 2x lebih cepat
                isAudioSpeedUp = true; // Tandai bahwa audio sudah dipercepat
            }

            if (countDown <= 0)
            {
                countDown = 0; // Pastikan waktu tidak negatif
                TogglePause(); // Panggil TogglePause sebelum memanggil TakeDamage
                health.TakeDamage(health.currentHealth); // Menghabiskan semua nyawa
                isGameOver = true; // Set isGameOver menjadi true setelah game over
                timerText.text = "00:00"; // Atur teks timer menjadi "00:00"
            }
            else
            {
                int minutes = Mathf.FloorToInt(countDown / 60);
                int seconds = Mathf.FloorToInt(countDown % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }
}
