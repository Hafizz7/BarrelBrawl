using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }
    public Timer timer;        
    [SerializeField] TextMeshProUGUI scoreText; // Drag and drop UI Text dari Inspector ke sini
    private int score = 0;
    public int scoreLv1 = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            /*DontDestroyOnLoad(gameObject);*/
            UnityEngine.Debug.Log("ScoreManager instance created");
        }
        else
        {
            Destroy(gameObject);
            UnityEngine.Debug.Log("Duplicate ScoreManager instance destroyed");
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
        if (StarManager.instance != null)
        {
            StarManager.instance.UpdateStars(); // Memperbarui bintang setiap kali skor ditambahkan
        }
        
    }
    public void ScoreLevel1()
    {
        int scoreLev1 = score;
        UnityEngine.Debug.Log("Score Level1: " + scoreLev1);
    }
    public void ScoreLevel2()
    {
        int scoreLev2 = score;
        UnityEngine.Debug.Log("Score Level2: " + scoreLev2);
    }
    /*   public void AddBonusScore(int value)
       {
           score += value;
           UpdateScoreText();
       }*/
    public int GetScore()
    {
        return score;
    }

    public void UpdateScoreText()
    {        
        /*int scoree = Timer.instance.CalculateBonusScore(); // Mengambil skor bonus dari StarManager*/
        scoreText.text = "Score: " + score; // 
        scoreLv1 = score;
    }
    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            score = PlayerPrefs.GetInt("ScoreLevel55", 0);
            UpdateScoreText();
        }
    }
}
