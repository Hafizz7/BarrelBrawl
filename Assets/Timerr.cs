using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    
    public static Timer Instance { get; private set; } 
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float countDown;
    public int bonusScorePerSecond = 2;    
    public float spedd;
    public Health health;
    private bool isPaused = false;
    private bool isGameOver = false; // Tambahkan variabel untuk menandai status game over
    private bool isAudioSpeedUp = false;
    public bool gameAkhir = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            countDown = PlayerPrefs.GetInt("waktuSave", 0);
        }
        bonusScorePerSecond = 2;
        UnityEngine.Debug.Log("Initial Bonus Score per Second: " + bonusScorePerSecond);
    }
    void Update()
    {             
            if (!isGameOver) // Pastikan bahwa perhitungan waktu hanya dilakukan jika permainan belum berakhir
        {            
            countDown -= Time.deltaTime;            
            /*UnityEngine.Debug.Log("CalculateBonusScore called: countDown = " + countDown);*/
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
            /*if(Coba_next_levevl.Instance.GameAkhir == true)
            {
                AddBonusScore();
            }*/
        }
    }    
    void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }
    public void AddBonusScore()
    {
        int bonusScore = Mathf.FloorToInt(countDown * bonusScorePerSecond);
        int waktuSave = Mathf.FloorToInt(countDown);
        PlayerPrefs.SetInt("waktuSave", waktuSave);
        UnityEngine.Debug.Log("Waktu: " + countDown + "Bonus: " + bonusScorePerSecond); 
        ScoreManager.instance.AddScore(bonusScore);
    }
}
