using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarSelectLevel : MonoBehaviour
{
    public static StarSelectLevel instance;
    public Image[] starsLevel1; // Drag and drop the star Images for level 1 here
    public Image[] starsLevel2; // Drag and drop the star Images for level 2 here
    public Image[] starsLevel3;
    public Image[] starsLevel4;
    public Image[] starsLevel5;
    public Sprite fullStar; // The sprite for a full star
    public Sprite emptyStar; // The sprite for an empty star
    public int maxScore = 100; // Nilai maksimal skor untuk mendapatkan semua bintang

    private int starsLevel1Earned = 0;
    private int starsLevel2Earned = 0;
    private int starsLevel3Earned = 0;
    private int starsLevel4Earned = 0;
    private int starsLevel5Earned = 0;

    private int ScoreSelctLv1 = 0;
    private int ScoreSelctLv2 = 0;
    private int ScoreSelctLv3 = 0;
    private int ScoreSelctLv4 = 0;
    private int ScoreSelctLv5 = 0;

    void Awake()
    {
    /*    if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }*/
        /*ScoreSelctLv1 = Coba_next_levevl.Instance.ScoreLevel11;
        ScoreSelctLv2 = Coba_next_levevl.Instance.ScoreLevel22;
        ScoreSelctLv3 = Coba_next_levevl.Instance.ScoreLevel33;
        ScoreSelctLv4 = Coba_next_levevl.Instance.ScoreLevel44;
        ScoreSelctLv5 = Coba_next_levevl.Instance.ScoreLevel55;*/
        ScoreSelctLv1 = PlayerPrefs.GetInt("ScoreLevel11", 0);
        ScoreSelctLv2 = PlayerPrefs.GetInt("ScoreLevel22", 0);
        ScoreSelctLv3 = PlayerPrefs.GetInt("ScoreLevel33", 0);
        ScoreSelctLv4 = PlayerPrefs.GetInt("ScoreLevel44", 0);
        ScoreSelctLv5 = PlayerPrefs.GetInt("ScoreLevel55", 0);
    }

    void Start()
    {
        UpdateStars();
        /*ScoreSelctLv1 = Coba_next_levevl.Instance.ScoreLevel11;
        ScoreSelctLv2 = Coba_next_levevl.Instance.ScoreLevel22;
        ScoreSelctLv3 = Coba_next_levevl.Instance.ScoreLevel33;
        ScoreSelctLv4 = Coba_next_levevl.Instance.ScoreLevel44;
        ScoreSelctLv5 = Coba_next_levevl.Instance.ScoreLevel55;*/
        ScoreSelctLv1 = PlayerPrefs.GetInt("ScoreLevel11", 0);
        ScoreSelctLv2 = PlayerPrefs.GetInt("ScoreLevel22", 0);
        ScoreSelctLv3 = PlayerPrefs.GetInt("ScoreLevel33", 0);
        ScoreSelctLv4 = PlayerPrefs.GetInt("ScoreLevel44", 0);
        ScoreSelctLv5 = PlayerPrefs.GetInt("ScoreLevel55", 0);
        /*UnityEngine.Debug.Log("Scoreee Level 1: " + Coba_next_levevl.Instance.ScoreLevel11);
        UnityEngine.Debug.Log("Scoreee Level 2: " + Coba_next_levevl.Instance.ScoreLevel22);
        UnityEngine.Debug.Log("Scoreee Level 3: " + ScoreSelctLv3);
        UnityEngine.Debug.Log("Scoreee Level 4: " + ScoreSelctLv4);
        UnityEngine.Debug.Log("Scoreee Level 5: " + ScoreSelctLv5);*/
    }

    public void UpdateStars()
    {        
        float percentage1 = (float)ScoreSelctLv1 / maxScore;
        float percentage2 = (float)ScoreSelctLv2 / maxScore;        
        float percentage3 = (float)ScoreSelctLv3 / maxScore;        
        float percentage4 = (float)ScoreSelctLv4 / maxScore;        
        float percentage5 = (float)ScoreSelctLv5 / maxScore;

        // Calculate stars for level 1
        starsLevel1Earned = CalculateStarsEarned(percentage1);
        starsLevel2Earned = CalculateStarsEarned(percentage2);
        starsLevel3Earned = CalculateStarsEarned(percentage3);
        starsLevel4Earned = CalculateStarsEarned(percentage4);
        starsLevel5Earned = CalculateStarsEarned(percentage5);

        // Calculate stars for level 2
        // In this example, let's assume level 2 requires higher score
        /*if (SceneManager.GetActiveScene().buildIndex == 3) // Assuming level 2 is at buildIndex 3
        {
            starsLevel2Earned = CalculateStarsEarned(percentage);
        }*/

        // Update star visuals
        UpdateStarVisuals(starsLevel1, starsLevel1Earned);
        UpdateStarVisuals(starsLevel2, starsLevel2Earned);
        UpdateStarVisuals(starsLevel3, starsLevel3Earned);
        UpdateStarVisuals(starsLevel4, starsLevel4Earned);
        UpdateStarVisuals(starsLevel5, starsLevel5Earned);
    }

    private int CalculateStarsEarned(float percentage)
    {
        int starsEarned = 0;
        for (int i = 0; i < starsLevel1.Length; i++)
        {
            if (percentage >= (i + 1) / (float)starsLevel1.Length)
            {
                starsEarned++;
            }
        }
        return starsEarned;
    }

    private void UpdateStarVisuals(Image[] stars, int starsEarned)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].sprite = (i < starsEarned) ? fullStar : emptyStar;
        }
    }
}

