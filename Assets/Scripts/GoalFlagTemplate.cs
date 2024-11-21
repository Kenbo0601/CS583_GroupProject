using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalFlagTemplate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision coll) {
        // Find out what hit the goal
        GameObject collidedWith = coll.gameObject;
        // Get a reference to the WhenRatsFly component of the Main Camera
        if (collidedWith.CompareTag("Ball")) {
            // Destroy the ball
            Destroy(collidedWith);
            // Load the next level
            SceneManager.LoadScene("BoardTemplate");
        }
    }
}
