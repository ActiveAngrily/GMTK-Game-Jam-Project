
using UnityEngine;
using System.Collections;
using Pathfinding;
public class ChaserAI : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    //The point to move to
    public Transform targetPoint;
    private Seeker seeker;
    //The calculated path
    public Path path;
    //The AI's speed per second
    public float speed = 100;
    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;
    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    public float pathgenerationRate = 4f;
    public void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        // controller = GetComponent<CharacterController>();
        //Start a new path to the targetPosition, return the result to the OnPathComplete function


        InvokeRepeating("GenerateNewPath", 0f, pathgenerationRate);
    }
    private void GenerateNewPath()
    {
        seeker.StartPath(transform.position, targetPoint.position, OnPathComplete);
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
    public void FixedUpdate()
    {
        if (path == null)
        {
            //We have no path to move after yet
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            //Debug.Log("End Of Path Reached");
            return;
        }
        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        if (dir.x >= 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Buddy")
        {
            anim.SetBool("Attacking", true);
        }
        if (collision.tag == "Laser")
        {
            anim.SetTrigger("GetDamaged");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Buddy")
        {
            Debug.Log("check");
            anim.SetBool("Attacking", false);
        }
    }
}





















