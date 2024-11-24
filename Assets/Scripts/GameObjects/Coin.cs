using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnCollisionEnter(Collision coll) {
        // Find out if the ball hit the coin
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Ball")) {
            Destroy(this.gameObject);
            // Increase the score
            ScoreManager.AddScore(100);
        }
    }
}
