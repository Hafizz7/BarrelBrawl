using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarManager : MonoBehaviour
{
    public static StarManager instance;
    public Image[] starsLevel1; // Drag and drop the star Images for level 1 here
    public Image[] starsLevel2; // Drag and drop the star Images for level 2 here
    public Sprite fullStar; // The sprite for a full star
    public Sprite emptyStar; // The sprite for an empty star
    public int maxScore = 100; // Nilai maksimal skor untuk mendapatkan semua bintang

    private int starsLevel1Earned = 0;
    private int starsLevel2Earned = 0;

    void Start()
    {
        UpdateStars();
    }

    public void UpdateStars()
    {
        int score = ScoreManager.instance.GetScore();
        float percentage = (float)score / maxScore;

        // Calculate stars for level 1
        starsLevel1Earned = CalculateStarsEarned(percentage);

        // Calculate stars for level 2
        // In this example, let's assume level 2 requires higher score
        if (SceneManager.GetActiveScene().buildIndex == 3) // Assuming level 2 is at buildIndex 3
        {
            starsLevel2Earned = CalculateStarsEarned(percentage);
        }

        // Update star visuals
        UpdateStarVisuals(starsLevel1, starsLevel1Earned);
        UpdateStarVisuals(starsLevel2, starsLevel2Earned);
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
