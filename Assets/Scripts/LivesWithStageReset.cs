using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesAndStageReset : MonoBehaviour
{
    public string sceneName;
    public float deathYvalue; // Y-value that determines a "fall"
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    private int livesLeft;

    public float originalXPosition;
    public float originalYPosition;
    public float originalZPosition;

    public Transform path; // Assign the path GameObject in the Inspector
    private Quaternion originalPathRotation; // Store the original rotation of the path

    void Start()
    {
        livesLeft = 3; // Start with 3 lives

        // Store the original rotation of the path
        if (path != null)
        {
            originalPathRotation = path.rotation;
        }
    }

    public void DecreaseLives()
    {
        if (livesLeft > 0)
        {
            livesLeft--; // Decrease the lives count

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
        GameManager.isGameOver = true;
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        if (transform.position.y < deathYvalue)
        {
            DecreaseLives();
            ResetBallAndPath();
        }
    }

    void ResetBallAndPath()
    {
        // Reset ball position and velocity
        transform.position = new Vector3(originalXPosition, originalYPosition, originalZPosition);
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        // Reset the path's rotation to its original state
        if (path != null)
        {
            path.rotation = originalPathRotation;
        }
    }
}
