using UnityEngine;
using UnityEngine.UI; // For displaying score in UI

// Static ScoreManager Class
// 
public static class ScoreManager
{
    public static int score = 0; 

    // Method to increment score
    public static void AddScore(int points)
    {
        Debug.Log("coin collected: add "+points);
        score += points;
        Debug.Log(score);
    }

    public static string DisplayScore()
    {
        return score.ToString("#,0");
    }
}