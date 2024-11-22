using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform pointA; // Starting point of movement
    public Transform pointB; // Ending point of movement
    public float moveSpeed = 3f; // Speed of movement
    public Transform ball; // Reference to the ball
    public float detectionRange = 5f; // Range to detect the ball
    public float knockForce = 10f; // Force to knock the ball

    private bool movingToB = true; // Direction flag

    void Update()
    {
        MoveBackAndForth();
        InteractWithBall();
    }

    void MoveBackAndForth()
    {
        // Determine the target point based on direction
        Transform target = movingToB ? pointB : pointA;

        // Move toward the target point
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        // Check if reached the target point and switch direction
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            movingToB = !movingToB;
        }
    }

    void InteractWithBall()
    {
        // Check if the ball is within detection range
        if (Vector3.Distance(transform.position, ball.position) <= detectionRange)
        {
            // Apply knock force to the ball
            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                Vector3 knockDirection = (ball.position - transform.position).normalized;
                ballRb.AddForce(knockDirection * knockForce, ForceMode.Impulse);
            }
        }
    }
}
