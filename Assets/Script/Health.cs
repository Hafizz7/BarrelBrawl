using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth = 4f;
    public float currentHealth { get; private set; }    
    /*public Transform spawnPoint;*/
    public GameObject GameOver;
    public GameObject GamePause;
    /*public GameObject GameComplate;*/
    private bool isPaused = false;
    /*private Vector3 spawnPoint;*/

    /*public AudioSource audioSource;*/

    /*public AudioSource AudioGameOver;*/
    /*private CheckPoint lastCheckPoint;*/
    private Vector3 respawnPosition;



    private void Awake()
    {
        /*lastCheckPoint = FindObjectOfType<CheckPoint>();*/
        respawnPosition = transform.position;
        currentHealth = startingHealth;
        /*spawnPoint = transform.position;*/

        /*spawnPoint = transform.position;*/
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth <= 0) 
        {            
            GameOverr();            
        }
        else
        {
            /*transform.position = spawnPoint.position;*/
            Respawn();
        }
    }
    public void GameOverr()
    {
        // Misalnya, pindah ke scene game over
        TogglePause();
        SoundManager.Instance.PauseMusic();
        /*audioSource.Pause();     */
        /*AudioGameOver.PlayOneShot(AudioGameOver.clip);*/
        SoundManager.Instance.GameOverrSound();
        GameOver.SetActive(true);
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);*/
    }
    /*private void GameComplatee()
    {
        // Misalnya, pindah ke scene game over
        TogglePause();
        GameComplate.SetActive(true);
        *//*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);*//*
    }*/

    

    void TogglePause()
    {
        isPaused = !isPaused; // Toggle status pause
        Time.timeScale = isPaused ? 0 : 1; // Mengatur timescale menjadi 0 jika di-pause, 1 jika tidak
    }
    private void Respawn()
    {
        transform.position = respawnPosition;
    }

    public void SetRespawnPosition(Vector3 position)
    {
        respawnPosition = position;
    }

}
