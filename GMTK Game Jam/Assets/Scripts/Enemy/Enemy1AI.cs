using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    /*
     * Okay, so diving the development of this script into three phases, but first
     * What I want the enemy to do -
     *    Wait idle for 3 seconds
     *    Zap to another place(let's oscillate to 2 places)
     *    shoot while idle
     */
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
}
    