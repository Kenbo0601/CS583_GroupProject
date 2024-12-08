using UnityEngine;

public class WindZoneBall : MonoBehaviour
{
    public WindZone windZone; //reference to the wind zone
    public float windMultiplier = 1f; //adjust wind strength effect

    private Rigidbody ballRigidbody;

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();
        if (windZone == null)
        {
            Debug.LogError("Wind Zone not assigned!"); //log error if wind zone is not assigned
        }
    }

    void FixedUpdate()
    {
        if (ballRigidbody != null && windZone != null)
        {
            Vector3 windDirection = windZone.transform.forward; //get wind zone's forward direction
            float windStrength = windZone.windMain; //base wind strength
            float turbulence = windZone.windTurbulence; //additional turbulence

            Vector3 windForce = windDirection * (windStrength + Random.Range(0, turbulence)) * windMultiplier; //calculate total wind force
            ballRigidbody.AddForce(windForce, ForceMode.Force); //apply force to the ball
        }
    }
}
