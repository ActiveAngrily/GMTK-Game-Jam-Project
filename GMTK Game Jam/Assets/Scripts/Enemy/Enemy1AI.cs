using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
/*
     * Okay, so diving the development of this script into three phases, but first
     * What I want the enemy to do -
     *    Wait idle for 3 seconds
     *    Zap to another place(let's oscillate to 2 places)
     *    shoot while idle
*/
public class Enemy1AI : MonoBehaviour
{
    /*
    
    public enum State
    {
        Entering,
        Idle,
        Zap,
    }

   // public Vector2 startingPosition;

    public float enteringSpeed = 3f;
    public float EnteringTime = 3f;

    public float zapSpeed = 20f;
    public float zapDelay = 5f;
    State state; 

    private void Start()
    {
        state = State.Entering;
        nextEnteringTime = EnteringTime + Time.time;
    }
    bool hasEntered = false;
    private void Update()
    {
        switch (state)
        {
            case State.Entering:
                EnemyEntering();
                break;
            case State.Idle:
                EnemyIdle();
                break;
            case State.Zap:
                EnemyZap();
                break;
        }

            if (!hasEntered && Time.time >= nextEnteringTime)
            {
                state = State.Idle;
                hasEntered = true;
            }
        if (state == State.Idle && Time.time >= nextZapTime)
        {
            nextZapTime = Time.time + zapDelay;
            state = State.Zap;
        }
        else if(state == State.Zap)
        {
            state = State.Idle;
        }
    }       

    float nextEnteringTime = 0f;

    /// <summary>
    /// Enters the Level from the top.
    /// </summary>
    private void EnemyEntering()
    {
        transform.Translate(Vector2.down * enteringSpeed);
    }
    
    /// <summary>
    /// Stays Idle and Shoots
    /// </summary>
    private void EnemyIdle()
    {
        //perform idle animation
        //shoot at player
    }
        
    float nextZapTime;

    /// <summary>
    /// Zaps in a random direction.
    /// </summary>
    private void EnemyZap()
    {
        Vector2 randomDirection = new Vector2(Random.Range(0,1),Random.Range(0,1)).normalized;
        transform.Translate(randomDirection * zapSpeed);
    }

    */

    Rigidbody2D rb;
    //The point to move to
    [SerializeField]
    private Transform[] targetPoint;
    private Seeker seeker;
    //The calculated path
    public Path path;
    //The AI's speed per second
    public float speed = 100;
    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;
    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    public float pathgenerationRate = 5f;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        // controller = GetComponent<CharacterController>();
        //Start a new path to the targetPosition, return the result to the OnPathComplete function


        InvokeRepeating("GenerateNewPath", 0f, pathgenerationRate);
    }
    int i = 0;
    private void GenerateNewPath()
    {
        Debug.Log(i);
        if(i < targetPoint.Length-1)
        {   
            seeker.StartPath(transform.position, targetPoint[i].localPosition, OnPathComplete);
            i++;
        } else{
            i = 0;
            seeker.StartPath(transform.position, targetPoint[i].localPosition, OnPathComplete);
        }
    }
    public void OnPathComplete(Path p)
    {
       // Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
        if (!p.error)
        {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
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
       //     Debug.Log("End Of Path Reached");
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