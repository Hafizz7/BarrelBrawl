using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm;
    public Vector3 initialSpawnPoint;
    


    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        initialSpawnPoint = transform.position;
        transform.position = gm.lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);*/
            ReturnToInitialSpawn();
        }
    }
    public void Restart()
    {
        TogglePause();
        SoundManager.Instance.BackgroundMusic.pitch = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ReturnToInitialSpawn();
        
    }
    void ReturnToInitialSpawn()
    {
        // Mengatur posisi pemain kembali ke titik awal spawn
        transform.position = initialSpawnPoint;
        // Mengatur checkpoint terakhir kembali ke titik awal spawn
        gm.lastCheckPointPos = initialSpawnPoint;
    }
    void TogglePause()
    {

        Time.timeScale = 1; // Mengatur timescale menjadi 0 jika di-pause, 1 jika tidak
    }

}
