using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class RobotBehaviour : MonoBehaviour
{
    /*
    public enum State
    {
        Idle,
        Chased,
    }
    State state;
    private void Start()
    {
        state = State.Idle;
    }
    private void Update()
    {
        if (state == State.Idle)
        {
            //follow player

        }
        else
        {
            //run away from the direction opposite to the player and a faster speed than the Chaser.
        }
    }*/

    public enum State
    {
        Idle,
        Chased,
    }
    State state;
    Rigidbody2D rb;
    //The point to move to
    public Transform PointofFollow;
    public Transform endofScreen;
    private Seeker seeker;
    //The calculated path
    public Path path;
    //The AI's speed per second
    public float speed = 100;
    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;
    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    public float pathgenerationRate = .5f;
    public float chasedpathgenerationRate = .5f;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        // controller = GetComponent<CharacterController>();
        //Start a new path to the targetPosition, return the result to the OnPathComplete function


        InvokeRepeating("GenerateNewPath", 0f, pathgenerationRate);
    }
    private void GenerateNewPath()
    {
        seeker.StartPath(transform.position, PointofFollow.position, OnPathComplete);
    }
    private void GenerateChasedPath()
    {
        seeker.StartPath(transform.position, endofScreen.position, OnPathComplete);
    }
    public void OnPathComplete(Path p)
    {
        //Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
        if (!p.error)
        {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
        }
    }
    bool changeState = false;
    public void Update()
    {
        if (state == State.Chased && !changeState)
        {
            CancelInvoke("GenerateNewPath");
            InvokeRepeating("GenerateChasedPath", 0f, chasedpathgenerationRate);
            changeState = true;
        }
        if (GameObject.FindGameObjectsWithTag("Chasers") == null && changeState)
        {

            CancelInvoke("GenerateChasedPath");
            InvokeRepeating("GenerateNewPath", 0f, pathgenerationRate);
            changeState = false;
        }
    }
    public void FixedUpdate()
    {
        if (path == null)
        {
            //We have no path to move after yet
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            //    Debug.Log("End Of Path Reached");
            return;
        }
        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.deltaTime;
        rb.AddForce(dir);

        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
}
