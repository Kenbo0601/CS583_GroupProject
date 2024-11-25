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

        if (!Application.isPlaying)
        {
            Gizmos.color = waypointColor; //set waypoint color in the editor
        }
        else
        {
            Gizmos.color = Color.clear; //set color clear when in play mode
        }

       
        foreach (Transform t in transform)
        {
            waypointsList.Add(t); //add waypoint to list
            Gizmos.DrawWireSphere(t.position, sphereRadius); //draw sphere at each waypoint position
        }

        if (!Application.isPlaying)
        {
            Gizmos.color = lineColor; //set line color scene


            for (int i = 0; i < waypointsList.Count - 1; i++)
            {
                Gizmos.DrawLine(waypointsList[i].position, waypointsList[i + 1].position); //draw line between waypoints
            }
        }
    }
}
