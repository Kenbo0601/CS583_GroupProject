using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public float sphereRadius = 1f; //radius of waypoint spheres
    public Color waypointColor = Color.red; //color for waypoints in the editor
    public Color lineColor = Color.blue; //color for the lines between waypoints in the editor

    private List<Transform> waypointsList = new List<Transform>(); //list to store the waypoints

    private void OnDrawGizmos()
    {
        waypointsList.Clear(); //clear the list of waypoints

        // Check if we are in play mode or edit mode
        if (!Application.isPlaying)
        {
            Gizmos.color = waypointColor; // Set waypoint color in the editor
        }
        else
        {
            Gizmos.color = Color.clear; // Set color to clear during play mode (doesn't draw in play mode)
        }

        // Iterate through each child transform (waypoint)
        foreach (Transform t in transform)
        {
            waypointsList.Add(t); // Add the waypoint to the list
            Gizmos.DrawWireSphere(t.position, sphereRadius); // Draw a sphere at each waypoint's position
        }

        // Only draw lines and waypoints in the editor
        if (!Application.isPlaying)
        {
            Gizmos.color = lineColor; // Set line color in the editor

            // Loop through waypoints to draw lines between them
            for (int i = 0; i < waypointsList.Count - 1; i++)
            {
                Gizmos.DrawLine(waypointsList[i].position, waypointsList[i + 1].position); // Draw line between waypoints
            }
        }
    }
}
