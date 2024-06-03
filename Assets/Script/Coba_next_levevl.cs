using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coba_next_levevl : MonoBehaviour
{
    public static Coba_next_levevl Instance { get; private set; }    
    /*public Timer timer;*/
    /*public StarManager starManager; // Drag and drop the StarManager object here*/
    /*public int playerScore;
    public int maxScore;*/
    public float delayTime = 1.5f;
    // Start is called before the first frame update
    public GameObject Complete;    
    private bool isPaused = false;
    public bool Lv1Complate = false;
    public bool Lv2Complate = false;
    public bool Lv3Complate = false;
    public bool Lv4Complate = false;
    public bool Lv5Complate = false;
    public int ScoreLevel11 = 0;
    public int ScoreLevel22 = 0;
    public int ScoreLevel33 = 0;
    public int ScoreLevel44 = 0;
    public int ScoreLevel55 = 0;
    private KeyCode[] kombinasi = { KeyCode.Alpha5, KeyCode.Alpha5, KeyCode.Alpha1 };    
    private int currentCombinationIndex = 0;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(kombinasi[currentCombinationIndex]))
            {
                currentCombinationIndex++;
                if (currentCombinationIndex >= kombinasi.Length)
                {
                    // Kombinasi lengkap, panggil fungsi
                    CheatNextLevel();
                    currentCombinationIndex = 0; // Reset indeks setelah kombinasi ditekan                    
                }
            }            
            else
            {
                // Reset indeks jika urutan kombinasi salah
                currentCombinationIndex = 0;
            }            

        }
    }

    void Awake()
    {
        /*if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }*/
        Lv1Complate = IsLevelCompleted(1);
        Lv2Complate = IsLevelCompleted(2);
        Lv3Complate = IsLevelCompleted(3);
        Lv4Complate = IsLevelCompleted(4);
        Lv5Complate = IsLevelCompleted(5);
        ScoreLevel55 = PlayerPrefs.GetInt("ScoreLevel55", 0); // Dapatkan skor dari PlayerPrefs
        UnityEngine.Debug.Log("Awake: Initial ScoreLevel55: " + ScoreLevel55);
    }
    void TogglePause()
    {
        isPaused = !isPaused; // Toggle status pause
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PauseMusic();
        }        
        Time.timeScale = isPaused ? 0 : 1; // Mengatur timescale menjadi 0 jika di-pause, 1 jika tidak
    }
    /*public void ambilTimer(float time)
    {
        waktuku = time;   
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TogglePause();
            Complete.SetActive(true);

            SoundManager.Instance.GameComplateSound();
            //Memanggil bonus score di Timer
            Timer.Instance.AddBonusScore();
            int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (activeSceneIndex == 2)
            {

                Lv2Complate = true;
                int score1 = ScoreManager.instance.GetScore();
                int score2 = PlayerPrefs.GetInt("ScoreLevel11", ScoreManager.instance.GetScore());
                PlayerPrefs.SetInt("Lv2Complate", Lv2Complate ? 1 : 0);
                SaveLevelCompletion(1);
                ScoreManager.instance.ScoreLevel1();
                UnityEngine.Debug.Log("INI LEVEL 1 : Scorenya2: " + ScoreManager.instance.GetScore());
                UnityEngine.Debug.Log("INI LEVEL 1 : Scorenya1: " + PlayerPrefs.GetInt("ScoreLevel11", ScoreManager.instance.GetScore()));
                if (score2 < score1)
                {
                    PlayerPrefs.SetInt("ScoreLevel11", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
                }
                else if (score2 == score1)
                {
                    PlayerPrefs.SetInt("ScoreLevel11", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
                }
                ScoreLevel11 = PlayerPrefs.GetInt("ScoreLevel11", 0); // Dapatkan skor dari PlayerPrefs

            }
            else if (activeSceneIndex == 3)
            {
                Lv3Complate = true;
                int score1 = ScoreManager.instance.GetScore();
                int score2 = PlayerPrefs.GetInt("ScoreLevel22", ScoreManager.instance.GetScore());
                PlayerPrefs.SetInt("Lv3Complate", Lv3Complate ? 1 : 0);
                SaveLevelCompletion(2);
                ScoreManager.instance.ScoreLevel2();
                if (score2 < score1)
                {
                    PlayerPrefs.SetInt("ScoreLevel22", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
                }
                else if (score2 == score1)
                {
                    PlayerPrefs.SetInt("ScoreLevel22", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
                }
                ScoreLevel22 = PlayerPrefs.GetInt("ScoreLevel22", 0); // Dapatkan skor dari PlayerPrefs            
            }
            else if (activeSceneIndex == 4)
            {
                Lv4Complate = true;
                int score1 = ScoreManager.instance.GetScore();
                int score2 = PlayerPrefs.GetInt("ScoreLevel33", ScoreManager.instance.GetScore());
                PlayerPrefs.SetInt("Lv4Complate", Lv4Complate ? 1 : 0);
                SaveLevelCompletion(3);
                if (score2 < score1)
                {
                    PlayerPrefs.SetInt("ScoreLevel33", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
                }
                else if (score2 == score1)
                {
                    PlayerPrefs.SetInt("ScoreLevel33", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
                }
                ScoreLevel33 = PlayerPrefs.GetInt("ScoreLevel33", 0); // Dapatkan skor dari PlayerPrefs            
            }
            else if (activeSceneIndex == 5)
            {
                Lv5Complate = true;
                int score1 = ScoreManager.instance.GetScore();
                int score2 = PlayerPrefs.GetInt("ScoreLevel44", ScoreManager.instance.GetScore());
                PlayerPrefs.SetInt("Lv5Complate", Lv5Complate ? 1 : 0);
                SaveLevelCompletion(4);
                if (score2 < score1)
                {
                    PlayerPrefs.SetInt("ScoreLevel44", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
                }
                else if (score2 == score1)
                {
                    PlayerPrefs.SetInt("ScoreLevel44", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
                }
                ScoreLevel44 = PlayerPrefs.GetInt("ScoreLevel44", 0); // Dapatkan skor dari PlayerPrefs
                UnityEngine.Debug.Log("INI level 4");
            }
            /*else if (activeSceneIndex == 6)
            {
                UnityEngine.Debug.Log("AKITFF OUUU");
                *//*SceneManager.LoadScene(7);
                ScoreManager.instance.UpdateScoreText();
                PlayerPrefs.SetInt("ScoreLevel55", ScoreManager.instance.GetScore());//
                int scoroe1234 = PlayerPrefs.GetInt("ScoreLevel55", 0);
                UnityEngine.Debug.Log("Total Score 1: " + scoroe1234);
            }*/
            else if (activeSceneIndex == 7)
            {
                int scoreku = PlayerPrefs.GetInt("ScoreLevel55", 0);
                /*int scoreBoss = PlayerPrefs.GetInt("ScoreNextBoss", 0);*/
                UnityEngine.Debug.Log("SCOREKUUU: " + ScoreLevel55);
                SaveLevelCompletion(5);
                int totalscore = ScoreLevel44 + ScoreManager.instance.GetScore();
                int scoreAwal = ScoreManager.instance.GetScore();
                PlayerPrefs.SetInt("ScoreNextBoss", totalscore);
                if (totalscore > scoreku)
                {
                    PlayerPrefs.SetInt("ScoreLevel55", totalscore); // Simpan skor ke PlayerPrefs            
                }
                else if (totalscore == scoreku)
                {
                    PlayerPrefs.SetInt("ScoreLevel55", totalscore); // Simpan skor ke PlayerPrefs            
                }
                ScoreLevel55 = PlayerPrefs.GetInt("ScoreLevel55", 0); // Dapatkan skor dari PlayerPrefs
                UnityEngine.Debug.Log("INI level 5");
            }
        }
    }

    /*IEnumerator LoadSceneWithDelay()
    {
        // Tunda beberapa detik sebelum memuat scene baru
        yield return new WaitForSeconds(delayTime);

        // Pindah ke scene baru
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }*/

    private void SaveLevelCompletion(int level)
    {        
        PlayerPrefs.SetInt("Level" + level + "Complete", 1); // 1 means the level is completed
        PlayerPrefs.Save(); // Save changes to disk
    }
    private bool IsLevelCompleted(int level)
    {
        return PlayerPrefs.GetInt("Level" + level + "Complete", 0) == 1; // 0 means not completed
    }
    public void CheatNextLevel()
    {
        TogglePause();
        Complete.SetActive(true);

        SoundManager.Instance.GameComplateSound();        
        Timer.Instance.AddBonusScore();
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (activeSceneIndex == 2)
        {

            Lv2Complate = true;
            int score1 = ScoreManager.instance.GetScore();
            int score2 = PlayerPrefs.GetInt("ScoreLevel11", ScoreManager.instance.GetScore());
            PlayerPrefs.SetInt("Lv2Complate", Lv2Complate ? 1 : 0);
            SaveLevelCompletion(1);
            ScoreManager.instance.ScoreLevel1();
            UnityEngine.Debug.Log("INI LEVEL 1 : Scorenya2: " + ScoreManager.instance.GetScore());
            UnityEngine.Debug.Log("INI LEVEL 1 : Scorenya1: " + PlayerPrefs.GetInt("ScoreLevel11", ScoreManager.instance.GetScore()));
            if (score2 < score1)
            {
                PlayerPrefs.SetInt("ScoreLevel11", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
            }
            else if (score2 == score1)
            {
                PlayerPrefs.SetInt("ScoreLevel11", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
            }
            ScoreLevel11 = PlayerPrefs.GetInt("ScoreLevel11", 0); // Dapatkan skor dari PlayerPrefs

        }
        else if (activeSceneIndex == 3)
        {
            Lv3Complate = true;
            int score1 = ScoreManager.instance.GetScore();
            int score2 = PlayerPrefs.GetInt("ScoreLevel22", ScoreManager.instance.GetScore());
            PlayerPrefs.SetInt("Lv3Complate", Lv3Complate ? 1 : 0);
            SaveLevelCompletion(2);
            ScoreManager.instance.ScoreLevel2();
            if (score2 < score1)
            {
                PlayerPrefs.SetInt("ScoreLevel22", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
            }
            else if (score2 == score1)
            {
                PlayerPrefs.SetInt("ScoreLevel22", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
            }
            ScoreLevel22 = PlayerPrefs.GetInt("ScoreLevel22", 0); // Dapatkan skor dari PlayerPrefs            
        }
        else if (activeSceneIndex == 4)
        {
            Lv4Complate = true;
            int score1 = ScoreManager.instance.GetScore();
            int score2 = PlayerPrefs.GetInt("ScoreLevel33", ScoreManager.instance.GetScore());
            PlayerPrefs.SetInt("Lv4Complate", Lv4Complate ? 1 : 0);
            SaveLevelCompletion(3);
            if (score2 < score1)
            {
                PlayerPrefs.SetInt("ScoreLevel33", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
            }
            else if (score2 == score1)
            {
                PlayerPrefs.SetInt("ScoreLevel33", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
            }
            ScoreLevel33 = PlayerPrefs.GetInt("ScoreLevel33", 0); // Dapatkan skor dari PlayerPrefs            
        }
        else if (activeSceneIndex == 5)
        {
            Lv5Complate = true;
            int score1 = ScoreManager.instance.GetScore();
            int score2 = PlayerPrefs.GetInt("ScoreLevel44", ScoreManager.instance.GetScore());
            PlayerPrefs.SetInt("Lv5Complate", Lv5Complate ? 1 : 0);
            SaveLevelCompletion(4);
            if (score2 < score1)
            {
                PlayerPrefs.SetInt("ScoreLevel44", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
            }
            else if (score2 == score1)
            {
                PlayerPrefs.SetInt("ScoreLevel44", ScoreManager.instance.GetScore()); // Simpan skor ke PlayerPrefs
            }
            ScoreLevel44 = PlayerPrefs.GetInt("ScoreLevel44", 0); // Dapatkan skor dari PlayerPrefs
            UnityEngine.Debug.Log("INI level 4");
        }
        /*else if (activeSceneIndex == 6)
        {
            UnityEngine.Debug.Log("AKITFF OUUU");
            *//*SceneManager.LoadScene(7);
            ScoreManager.instance.UpdateScoreText();
            PlayerPrefs.SetInt("ScoreLevel55", ScoreManager.instance.GetScore());//
            int scoroe1234 = PlayerPrefs.GetInt("ScoreLevel55", 0);
            UnityEngine.Debug.Log("Total Score 1: " + scoroe1234);
        }*/
        else if (activeSceneIndex == 7)
        {            



            int scoreku = PlayerPrefs.GetInt("ScoreLevel55", 0);
            /*int scoreBoss = PlayerPrefs.GetInt("ScoreNextBoss", 0);*/
            UnityEngine.Debug.Log("SCOREKUUU: " + ScoreLevel55);
            SaveLevelCompletion(5);
            int totalscore = ScoreLevel44 + ScoreManager.instance.GetScore();
            int scoreAwal = ScoreManager.instance.GetScore();
            PlayerPrefs.SetInt("ScoreNextBoss", totalscore);           
            if(totalscore > scoreku)
            {                
                PlayerPrefs.SetInt("ScoreLevel55", totalscore); // Simpan skor ke PlayerPrefs            
            }
            else if(totalscore == scoreku)
            {                
                PlayerPrefs.SetInt("ScoreLevel55", totalscore); // Simpan skor ke PlayerPrefs            
            }
            ScoreLevel55 = PlayerPrefs.GetInt("ScoreLevel55", 0); // Dapatkan skor dari PlayerPrefs
            UnityEngine.Debug.Log("INI level 5");
        }
    }

}
