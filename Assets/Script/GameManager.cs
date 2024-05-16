using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GamePause;
    private bool isPaused = false;
    /*public AudioSource audioSource;*/
    private static GameManager instance;
    public Vector2 lastCheckPointPos;
    void Start()
    {

    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            /*DontDestroyOnLoad(instance);*/
        }
        /*else
        {
            Destroy(gameObject);
        }*/
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GamePause.activeSelf) // Jika game over aktif
            {
                GamePause.SetActive(false); // Matikan layar game over
                TogglePause();
                /*audioSource.Play();*/
                SoundManager.Instance.ResumeMusic();

            }
            else // Jika game over tidak aktif
            {
                /*audioSource.Pause();*/
                SoundManager.Instance.PauseMusic();
                TogglePause();
                GamePause.SetActive(true); // Tampilkan layar game over
            }
        }
    }
    void TogglePause()
    {
        isPaused = !isPaused; // Toggle status pause
        Time.timeScale = isPaused ? 0 : 1; // Mengatur timescale menjadi 0 jika di-pause, 1 jika tidak
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            CheckPoint checkpoint = other.GetComponent<CheckPoint>();
            /*checkpoint.Spawn(transform); // Mengirimkan transform pemain saat memanggil Spawn()*/
        }
    }
}