using UnityEngine;

public class ObstacleSlider : MonoBehaviour
{
    public Transform board; // Reference to the board (parent object)
    public Vector3 localStartPosition; // Starting position relative to the board
    public Vector3 localEndPosition;   // Ending position relative to the board
    public float moveSpeed = 2f;       // Speed of movement

    private bool movingToEnd = true;   // Direction of movement

    void Start()
    {
        // Initialize the start and end positions relative to the board's local position
        localStartPosition = transform.localPosition;
        localEndPosition = localStartPosition + new Vector3(0, 0, 3f); // Example: Slide 2 units along Z-axis
    }

    void Update()
    {
        // Move the obstacle relative to the board
        if (movingToEnd)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, localEndPosition, moveSpeed * Time.deltaTime);

            // Check if it has reached the end position
            if (Vector3.Distance(transform.localPosition, localEndPosition) < 0.01f)
            {
                movingToEnd = false; // Reverse direction
            }
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, localStartPosition, moveSpeed * Time.deltaTime);

            // Check if it has reached the start position
            if (Vector3.Distance(transform.localPosition, localStartPosition) < 0.01f)
            {
                movingToEnd = true; // Reverse direction
            }
        }
    }
}