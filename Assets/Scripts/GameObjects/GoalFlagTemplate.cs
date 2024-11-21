using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalFlagTemplate : MonoBehaviour
{
    //CHANGE THIS TO WHATEVER SCENE/LEVEL TO BE LOADED AFTER FINISHING THIS ONE
    public string sceneName = "XavBoard";
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
        if (collidedWith.CompareTag("Ball")) {
            // Destroy the ball
            Destroy(collidedWith);
            // Load the next level
            SceneManager.LoadScene(sceneName);
        }
    }
}
