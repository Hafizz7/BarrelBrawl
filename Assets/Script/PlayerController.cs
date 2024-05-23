using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private bool Lv2Complate;
    private bool Lv3Complate;
    private bool Lv4Complate;
    private bool Lv5Complate;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Mendapatkan status level yang telah selesai dari PlayerPrefs
        Lv2Complate = PlayerPrefs.GetInt("Lv2Complate", 0) == 1;
        Lv3Complate = PlayerPrefs.GetInt("Lv3Complate", 0) == 1;
        Lv4Complate = PlayerPrefs.GetInt("Lv4Complate", 0) == 1;
        Lv5Complate = PlayerPrefs.GetInt("Lv5Complate", 0) == 1;
    }

    void TogglePause()
    {

        Time.timeScale = 1; // Mengatur timescale menjadi 0 jika di-pause, 1 jika tidak
    }
    public void MainBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Level1()
    {
        TogglePause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Level2()
    {
        if(Lv2Complate)
        {
            TogglePause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }                
    }
    public void Level3()
    {
        if (Lv3Complate)
        {
            TogglePause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
    }
    public void Level4()
    {
        if (Lv4Complate)
        {
            TogglePause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        }
    }
    public void Level5()
    {
        if (Lv5Complate)
        {
            TogglePause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
