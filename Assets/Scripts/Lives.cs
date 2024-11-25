using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// --- Attach this script to ball object, then set SceneName = GameOver ---
public class Lives : MonoBehaviour
{
    // Public references to life objects, set these in the Inspector
    
    public string sceneName;
    //REPLACE WITH WHATEVER Y VALUE IS APPROPRIATE FOR EACH LEVEL/SCENE
    public float deathYvalue;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    private int livesLeft;

    public float originalXPosition;

    public float originalYPosition;
    public float originalZPosition;

    void Start()
    {
        livesLeft = 3; // Start with 3 lives
    }

    // This method will be called when the ball falls off
    public void DecreaseLives()
    {
        if (livesLeft > 0)
        {
            livesLeft--; // Decrease the lives count

            // Remove the life object based on lives left
            switch (livesLeft)
            {
                case 2:
                    Destroy(life3); // Destroy life3 on first fall
                    break;
                case 1:
                    Destroy(life2); // Destroy life2 on second fall
                    break;
                case 0:
                    Destroy(life1); // Destroy life1 on third fall
                    GameOver();
                    break;
            }
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        if (transform.position.y < deathYvalue)
        {
            DecreaseLives();
            ResetBallPosition(); 
        }
    }

    void ResetBallPosition()
    {
        transform.position = new Vector3(originalXPosition, originalYPosition, originalZPosition); // Reset ball to a safe position
        GetComponent<Rigidbody>().velocity = Vector3.zero; // Reset velocity
    }
}
