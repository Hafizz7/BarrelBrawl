using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coba_next_levevl : MonoBehaviour
{
    public float delayTime = 1.5f;
    // Start is called before the first frame update
    public GameObject Complete;
    /*public AudioSource audioSource;*/
    /*public AudioSource AudioGameWin;*/
    private bool isPaused = false;
    void TogglePause()
    {
        isPaused = !isPaused; // Toggle status pause
        /*audioSource.Pause();*/
        /*SoundManager.Instance.MusicLevel1.Pause();*/
        SoundManager.Instance.PauseMusic();
        Time.timeScale = isPaused ? 0 : 1; // Mengatur timescale menjadi 0 jika di-pause, 1 jika tidak
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Jika objek yang bersentuhan memiliki tag "Player"
        if (collision.CompareTag("Player"))
        {
            /*StartCoroutine(LoadSceneWithDelay());*/
            TogglePause();
            Complete.SetActive(true);
            /*AudioGameWin.PlayOneShot(AudioGameWin.clip);*/
            SoundManager.Instance.GameComplateSound();
            /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);*/

        }
    }
    /*IEnumerator LoadSceneWithDelay()
    {
        // Tunda beberapa detik sebelum memuat scene baru
        yield return new WaitForSeconds(delayTime);

        // Pindah ke scene baru
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }*/
}
