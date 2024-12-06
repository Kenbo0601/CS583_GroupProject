using System.Collections;
using UnityEngine;

public class ShiftLockCameraFollow : MonoBehaviour
{
    // smooth camera follow
    public Transform target;
    public float smoothSpeed = 0.125f; 
    public Vector3 offset; 

    // rotating around the target
    public float rotationSpeed = 5f;
    public float distanceFromTarget = 5f;
    public float height = 2f;
    private float currentAngle = 0f;

    // vertical mouse input (Mouse Y)
    public float verticalSpeed = 100f;  // speed of height change with Mouse Y
    private Vector3 lockedOffset;     // stores the full offset w/ y-position

    // maximum allowed distance from the target
    public float maxDistance = 15f;

    void Update()
    {
        // when shift is held down, rotate around the target and adjust height
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            HandleCameraRotation();
            HandleCameraHeight();
        }
        else
        {
            // or else, follow target normally and update offset when shift is released
            FollowTarget();
        }
    }

    void LateUpdate()
    {
        // camera movement depending on shift key status
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            // the camera's position and set lockedOffset 
            lockedOffset = CalculateCameraPosition() - target.position;

            // move camera around target
            Vector3 desiredPosition = CalculateCameraPosition();
            desiredPosition = ClampDistanceToTarget(desiredPosition);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
        else
        {
            // after releasing shift, keep new offset position including y-position
            Vector3 desiredPosition = target.position + lockedOffset;
            desiredPosition = ClampDistanceToTarget(desiredPosition);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
    }

    // camera rotation around the target when shift is held
    void HandleCameraRotation()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        currentAngle += horizontalInput * rotationSpeed;

        if (currentAngle >= 360f) currentAngle -= 360f;
        if (currentAngle < 0f) currentAngle += 360f;
    }

    // camera height adjustment based on Mouse Y input
    void HandleCameraHeight()
    {
        float verticalInput = Input.GetAxis("Mouse Y");
        height -= verticalInput * verticalSpeed * Time.deltaTime * 20;

        // clamp height to prevent it from getting too low or too high
        height = Mathf.Clamp(height, -40f, 100f); // min and max height limits 
    }

    // new camera position around the target based on current angle and height
    Vector3 CalculateCameraPosition()
    {
        // x and z positions based on the current angle around the circle
        float x = target.position.x + Mathf.Cos(currentAngle * Mathf.Deg2Rad) * distanceFromTarget;
        float z = target.position.z + Mathf.Sin(currentAngle * Mathf.Deg2Rad) * distanceFromTarget;

        // return final position with the updated height 
        return new Vector3(x, target.position.y + height, z);
    }

    // smooth follow camera when shift is not pressed
    void FollowTarget()
    {
        // keep regular offset in x, y, and z when shift is not pressed
        Vector3 desiredPosition = target.position + offset;
        desiredPosition = ClampDistanceToTarget(desiredPosition);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

    // ensures the distance from the camera to the target does not exceed maxDistance
    Vector3 ClampDistanceToTarget(Vector3 position)
    {
        Vector3 directionToCamera = position - target.position;
        float distance = directionToCamera.magnitude;

        if (distance > maxDistance)
        {
            position = target.position + directionToCamera.normalized * maxDistance;
        }

        return position;
    }
}
