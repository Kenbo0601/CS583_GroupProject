using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform pointA; //starting point of movement
    public Transform pointB; //ending point of movement
    public float moveSpeed = 3f; //speed of movement
    public Transform ball; //reference to the ball
    public float detectionRange = 5f; //range to detect the ball
    public float knockForce = 10f; //force to knock the ball

    private bool movingToB = true; //direction flag

    void Update()
    {
        MoveBackAndForth();//oscillate from point x to point x
        InteractWithBall(); //chase ball
    }

    void MoveBackAndForth()
    {
        //determine the target point based on direction
        Transform target = movingToB ? pointB : pointA;

        //move toward the target point
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        //check if reached the target point and switch direction
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            movingToB = !movingToB;
        }
    }

    void InteractWithBall()
    {
        //check if the ball is within detection range
        if (Vector3.Distance(transform.position, ball.position) <= detectionRange)
        {
            //apply knock force to the ball for different levels
            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                Vector3 knockDirection = (ball.position - transform.position).normalized;
                ballRb.AddForce(knockDirection * knockForce, ForceMode.Impulse);
            }
        }
    }
}
