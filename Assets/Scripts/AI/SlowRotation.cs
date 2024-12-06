
using UnityEngine;

public class SlowRotation : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 10, 0); // Rotation speed in degrees per second for X, Y, Z

    void Update()
    {
        // Rotate the object
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
