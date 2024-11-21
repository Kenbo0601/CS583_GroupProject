using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    public ScoreCounter scoreCounter;
    void Start()
    {
        // Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision coll) {
        // Find out if the ball hit the coin
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Ball")) {
            // Destroy the object if it has the "Pea" tag
            Destroy(this.gameObject);
            // Increase the score
            scoreCounter.score += 100;
        }
    }
}
