using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int waypointIndex = 0;
    [SerializeField] private float speed = 2f;
    
    void Update()
    {
        if(Vector2.Distance(waypoints[waypointIndex].transform.position, transform.position) < 0.1f)
        {
            waypointIndex++;
            if(waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * speed);
        
    }
}
