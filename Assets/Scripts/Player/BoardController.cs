using UnityEngine;

public class BoardController : MonoBehaviour
{
    public float tiltSpeed = 10f; 

    void Update()
    {
        float tiltX = 0f;
        float tiltZ = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            tiltX = tiltSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            tiltX = -tiltSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tiltZ = tiltSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            tiltZ = -tiltSpeed * Time.deltaTime;
        }

        transform.Rotate(tiltX, 0, tiltZ);
    }
}
