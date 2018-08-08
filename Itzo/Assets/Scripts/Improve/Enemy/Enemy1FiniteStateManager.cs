using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy1FiniteStateManager : MonoBehaviour
{
    NavMeshAgent _controller;
    public int maxDistance;
    GameObject player;
    //hiding closetScript;
    bool chaseState;
    bool wanderState;
    bool fleeState;
    public bool poweredUP;

    bool playerHidden;

    // Use this for initialization
    void Start()
    {
        _controller = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        //closetScript = player.GetComponent<hiding>();
        playerHidden = false; //not yet discussed or tested (can add later on)
        chaseState = false;
        wanderState = false;
        poweredUP = false;

        gameObject.GetComponent<WanderState>().enabled = wanderState;
    }

    void changeState()
    {
        gameObject.GetComponent<WanderState>().enabled = wanderState;
        gameObject.GetComponent<ChasingState>().enabled = chaseState;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (InSight() && !playerHidden)
        {//was stationary or wandering and can now see the player, will begin to chase
            wanderState = false;
            chaseState = true;
            changeState();
            _controller.speed = 20;
            gameObject.GetComponent<AudioSource>().volume = 1;
            //Debug.Log("SWITCH TO: chaseState");
        }
        else if (chaseState)
        {
            if (playerHidden)
            {//only go to wander state if enemy loses player in a closet, this is so the enemies don't get stuck outside the
                //closet waiting to get the player
                wanderState = true;
                chaseState = false;            
                changeState();
                _controller.speed = 15;
                //gameObject.GetComponent<WanderState>().prevDest = true;
            }

            else if (!InSight())
            {//if chasing and lose sight go back to being stationary
                chaseState = false;
                changeState();
                _controller.speed = 0; //stay where you are.
            }
        }    
        
    }

    bool InSight()
    {
        RaycastHit hit;
        Vector3 direction = player.transform.position - gameObject.transform.position;
        if (Physics.Raycast(gameObject.transform.position, direction, out hit, maxDistance))
            if (hit.transform.gameObject.name == "Player")
                return true;

        return false;
    }
}
