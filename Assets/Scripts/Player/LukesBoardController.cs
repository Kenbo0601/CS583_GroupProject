using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LukesBoardController : MonoBehaviour
{
    public float tiltSpeed = 10f; // Speed of rotation
    public float maxTiltAngle = 20f; // Maximum tilt angle in degrees

    public Vector3 currentRotation; // Public to allow modification from other scripts
    private Quaternion initialRotation; // To store the initial rotation 

    void Start()
    {
        // Store the initial rotation of the board
        initialRotation = transform.rotation; // Save the initial rotation of the board
        currentRotation = transform.eulerAngles; // Set initial rotation value
    }

    void FixedUpdate()
    {
        float tiltX = 0f;
        float tiltZ = 0f;

        // Detect key inputs for rotation
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tiltX = -tiltSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            tiltX = tiltSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tiltZ = -tiltSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            tiltZ = tiltSpeed * Time.deltaTime;
        }

        // Update the target rotation
        currentRotation.x = Mathf.Clamp(currentRotation.x + tiltX, -maxTiltAngle, maxTiltAngle);
        currentRotation.z = Mathf.Clamp(currentRotation.z + tiltZ, -maxTiltAngle, maxTiltAngle);

        // Smoothly rotate the board
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(currentRotation), Time.deltaTime * tiltSpeed);
    }

    // Method to reset the rotation to a specific value
    public void ResetRotation()
    {
        currentRotation = Vector3.zero; // Set the rotation to 0, 0, 0
        transform.rotation = Quaternion.Euler(currentRotation); // Apply the reset rotation to the board
    }
}
