using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetLevell : MonoBehaviour
{
    // Start is called before the first frame update    
    public GameObject Complete;
    /*public Transform respawnPoint; // Titik respawn    */

    void TogglePause()
    {
        
        Time.timeScale = 1; // Mengatur timescale menjadi 0 jika di-pause, 1 jika tidak
    }
    void Start()
    {
        /*respawnPoint = transform;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLevel()
    {
        TogglePause();        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        

    }
    /*public void Restart()
    {        
        TogglePause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        transform.position = respawnPoint.position;
    }    */
    public void Back()
    {
        /*SceneManager.LoadScene("Level 1");*/
        SceneManager.LoadSceneAsync(1);
    }
    public void Home()
    {
        /*SceneManager.LoadScene("Level 1");*/
        SceneManager.LoadSceneAsync(0);
    }
    public void BackButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
