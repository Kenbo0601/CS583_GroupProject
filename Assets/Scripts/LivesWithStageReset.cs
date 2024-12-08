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
        Debug.Log($"Game started with {livesLeft} lives.");

        // Store the original rotation of the path
        if (path != null)
        {
            originalPathRotation = path.rotation;
            Debug.Log($"Original path rotation: {originalPathRotation}");
        }
    }

    public void DecreaseLives()
    {
        if (livesLeft > 0)
        {
            livesLeft--; // Decrease the lives count
            Debug.Log($"Lives decreased. Lives left: {livesLeft}");

            switch (livesLeft)
            {
                case 2:
                    Destroy(life3); // Destroy life3 on first fall
                    Debug.Log("Life 3 destroyed.");
                    break;
                case 1:
                    Destroy(life2); // Destroy life2 on second fall
                    Debug.Log("Life 2 destroyed.");
                    break;
                case 0:
                    Destroy(life1); // Destroy life1 on third fall
                    Debug.Log("Life 1 destroyed. Game over.");
                    GameOver();
                    break;
            }
        }
    }

    void GameOver()
    {
        GameManager.isGameOver = true;
        Debug.Log("GameOver() called. Loading game over scene...");
        SceneManager.LoadScene("GameOver");
    }

    void Update()
    {
        if (transform.position.y < deathYvalue)
        {
            Debug.Log($"Player fell below {deathYvalue}. Resetting position and decreasing lives.");
            DecreaseLives();
            ResetBallAndPath();
        }
    }

    void ResetBallAndPath()
    {
    // Log the ball's reset position
    transform.position = new Vector3(originalXPosition, originalYPosition, originalZPosition);
    GetComponent<Rigidbody>().velocity = Vector3.zero;
    Debug.Log("Ball position reset to original coordinates.");

    // Reset the path's rotation
    if (path != null)
    {
        Debug.Log($"Before resetting rotation: Path rotation = {path.transform.rotation}");

        // Force the path's rotation to reset to (0, 0, 0)
        path.transform.rotation = Quaternion.identity;

        // Log after resetting the rotation
        Debug.Log($"After resetting rotation: Path rotation = {path.transform.rotation}");

        // Get the BoardControllerTemp component and reset its rotation
        LukesBoardController boardController = path.GetComponent<LukesBoardController>();
        if (boardController != null)
        {
            boardController.ResetRotation(); // This will set currentRotation to (0, 0, 0)
            Debug.Log("Board rotation reset to (0, 0, 0).");
        }
    }
    }
}
