using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScene: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the trigger
        if (other.gameObject.CompareTag("Player"))
        {
            // Load the "Boss_Fight" scen
            // 
            Timer.Instance.SaveWaktu();
            SceneManager.LoadScene(7);
            ScoreManager.instance.UpdateScoreText();            
            PlayerPrefs.SetInt("ScoreLevel55", ScoreManager.instance.GetScore());
        }
    }
}
