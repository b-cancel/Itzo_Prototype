using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine;

public class Enemy2FiniteStateManager : MonoBehaviour
{
    NavMeshAgent _controller;
    public int maxDistance;
    GameObject player;
    PlayerMovement movementScript;
    //hiding closetScript;
    bool chaseState;
    bool wanderState;
    Text playerHeardNotification;
    public bool poweredUP;

    bool closetScriptResult;

    // Use this for initialization
    void Start()
    {
        playerHeardNotification = GameObject.Find("SoundNotification").GetComponent<Text>();
        _controller = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        movementScript = player.GetComponent<PlayerMovement>();
        //closetScript = player.GetComponent<hiding>();
        closetScriptResult = false;
        chaseState = false;
        wanderState = true;
  
        poweredUP = false;

        gameObject.GetComponent<WanderState>().enabled = wanderState;
    }

    /*
    void changeState()
    {
        gameObject.GetComponent<WanderState>().enabled = wanderState;
        gameObject.GetComponent<ChasingState>().enabled = chaseState;
  
    }

    // Update is called once per frame
    void Update()
    {
       if (wanderState)
        {
            if (!closetScriptResult)
            {
                if (InSight())
                {
                    wanderState = false;
                    chaseState = true;
                    changeState();
                    _controller.speed = 20;
                    //gameObject.GetComponent<AudioSource>().volume = 1;
                    //   Debug.Log("SWITCH TO: chaseState");
                }
            
                else if (false)//if the player is sprinting 
                {//generate a random number to determine if the player is detected by enemy
                    //if detected, switch to chaseState
                    int randNum1 = Random.Range(0, 200);
                    int randNum2 = Random.Range(0, 200);
                    if (randNum1 == randNum2)
                    {//switching to the chaseState if the two random numbers equal 10, essetially acts as a probability generator,
                     //as long as the player is running and within range of the enemy there is a possibility they will be heard and be chased.  
                        wanderState = false;
                        chaseState = true;
                        Debug.Log("They hear you...");
                        playerHeardNotification.enabled = true;
                        changeState();
                        Invoke("disableText", 2);
                        _controller.speed = 20;
                    }
                }
            }
        }
        else if (chaseState)
        {
            if (closetScriptResult)
            {
                wanderState = true;
                chaseState = false;
   
                changeState();
                _controller.speed = 15;
                gameObject.GetComponent<WanderState>().prevDest = true;
            }

            else if (!InSight())
            {
                wanderState = true;
                chaseState = false;
   
                changeState();
                _controller.speed = 15;
                gameObject.GetComponent<WanderState>().prevDest = true;
                //Debug.Log("SWITCH TO: wanderState");
            }
        }    
    }
    void disableText() {
        playerHeardNotification.enabled = false;
    }
    bool InSight()
    {
        RaycastHit hit;
        Vector3 direction = player.transform.position - gameObject.transform.position;
        //Debug.DrawRay(transform.position, direction, Color.red);
        if (Physics.Raycast(gameObject.transform.position, direction, out hit, maxDistance)) {
            
            if (hit.transform.CompareTag("Player"))
            {
               //   Debug.Log("HIT THIS: "+hit.transform.name);
                return true;
            }
        }
        //Debug.Log("Lost line of sight");
        return false;
    } 
    */
}