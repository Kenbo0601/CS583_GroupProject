using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalFlagTemplate : MonoBehaviour
{
    //CHANGE THIS TO WHATEVER SCENE/LEVEL TO BE LOADED AFTER FINISHING THIS ONE
    public string sceneName = "XavBoard";
    public bool gameEndFlag = false; // turn this true if you want to move to game end scene
    
    void OnCollisionEnter(Collision coll) {
        // Find out what hit the goal
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Ball")) {
            // Destroy the ball
            Destroy(collidedWith);
            // Load the next level
            
            /*
             * --- game logic when moving to the next scene --- 
             * you can modify the sceneName in the inspector. ex: sceneName = level2 or GameClear
             * then, if you want to move to GameClear scene, turn gameEndFlag to true
             * so that this tells the GameManager that the game is over,
             * then it will save the current time for displaying it in game clear scene
             */
            if (gameEndFlag)
            {
                GameManager.isGameOver = true;
            }
            
            SceneManager.LoadScene(sceneName);
        }
    }
}
