using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game Manager class 
public static class GameManager
{
    public static bool isGameOver = false;
    
    // Initialize the Game - gets called in the Menu script 
    public static void InitializeGame()
    {
        isGameOver = false;
        ScoreManager.score = 0;
        TimeManager.elapsedTime = 0f;
    }
}

