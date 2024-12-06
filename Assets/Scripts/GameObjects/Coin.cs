using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float spinSpeed = 100f; // Speed of rotation in degrees per second
    public AudioClip collectSound; // Coin collect sound

    void Update()
    {
        // Rotate the coin around its Y-axis
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0, Space.World);
    }
    
    void OnCollisionEnter(Collision coll) {
        // Find out if the ball hit the coin
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Ball")) {
            // Play the coin collect sound
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }
            
            Destroy(this.gameObject);
            // Increase the score
            ScoreManager.AddScore(100);
        }
    }
}
