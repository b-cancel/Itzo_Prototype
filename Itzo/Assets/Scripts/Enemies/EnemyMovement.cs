using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //to easily jump to the locations where the monster gets "destroyed" use ctrl+F and search "BYEBYE Monster"
    public bool SoundOnly; // will chase the player based on the sound they are making
    public bool SightOnly; //will chase the player when they are in sight
    public bool SightAndSound; // will use sight and sound to locate the player
    public float enemySpeed; //how fast the enemy moves
    public bool playerHeard; //a bool that is made true when the monster is close enough to hear the enemy
    public bool waitUntilInSight; //monster will not move (no patroling) until the player is seen
    public bool searchSlowly; //a bool that changes the monster's speed, makes it slower when patroling
    public bool searchFrantically; //a bool that changes the monster's speed, makes it faster when patroling
    public int respawnRadius; //how far away from the player the monster should respawn.
    public bool wanderFlag; //used so it only plays wander sound once per wander state transition 
    public bool chaseSightFlag;
    public bool chaseSoundFlag;
    public bool chaseSightState;
    public bool chaseSoundState;
    bool destPatrol;
    bool destOrigin;
    float searchSpeed;
    NavMeshAgent _controller;
    Transform playerLocation;
    public int playerDetectionDistance;
    public GameObject playerSeenText;
    public GameObject player;
    public GameObject patrolpoint;
    public GameObject secondPatrolpointObject;
    public GameObject secondSpawnpointObject;
    public GameObject playerHeardText;
    EnemySounds enemySounds;
    bool toggle;
    bool inSight;
    Vector3 originPoint;
    Vector3 firstSpawnPoint;
    Vector3 secondSpawnPoint;
    Vector3 patrolPointPosition;
    Vector3 firstPatrolPoint;
    Vector3 secondPatrolPoint;

    // Use this for initialization
    void Start()
    {
        chaseSightState = false;
        chaseSoundState = false;
        toggle = true;
        originPoint = gameObject.transform.position;
        firstSpawnPoint = originPoint;
        secondSpawnPoint = secondSpawnpointObject.transform.position;
        destOrigin = false;//setting these two bools so the enmey moves towards his patrol point 
        destPatrol = true;//unpon initialization
       
        patrolPointPosition = patrolpoint.transform.position;
        firstPatrolPoint = patrolPointPosition;
        secondPatrolPoint = secondPatrolpointObject.transform.position;

        enemySounds = gameObject.transform.GetComponentInChildren<EnemySounds>();
        playerLocation = player.transform;
        _controller = GetComponent<NavMeshAgent>();
        _controller.speed = enemySpeed;
        if (searchSlowly)
        {
            searchSpeed = 2.5f;
        }
        else if (searchFrantically) { searchSpeed = 8.5f; }
        else { searchSpeed = 5.5f; }
        _controller.SetDestination(patrolPointPosition);

    }

    private IEnumerator EraseHeardText()
    {
        yield return new WaitForSeconds(2);
        playerHeardText.GetComponent<Text>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        playerHeard = listenForPlayer();
        inSight = lineOfSight();
        if (SightAndSound && (inSight || playerHeard))
        {//checking if either of the methods of detection is working
            ChasePlayer();
            if (playerHeard)
            {
                playerHeardText.GetComponent<Text>().enabled = true;
                StartCoroutine(EraseHeardText());
            }
            if (Vector3.Distance(player.transform.position, transform.position) <=2 )
            {//reach here if the enemy is too close to the player, has reached the player
                EnemyDie();
            }
        }
        else if (SoundOnly && playerHeard)
        {
            playerHeardText.GetComponent<Text>().enabled = true;
            StartCoroutine(EraseHeardText());
            if (!chaseSoundFlag)
            {
                chaseSoundState = true;
                wanderFlag = false;
                chaseSightFlag = false;
                chaseSoundFlag = true;
                Debug.Log("Sound Only");
                enemySounds.toSoundChase();
                _controller.speed = enemySpeed;
            }
            //            Debug.Log("Detecting by Sound");
            _controller.SetDestination(playerLocation.position);
            if (Vector3.Distance(player.transform.position, transform.position) <= 2 && inSight)
            {//reach here if the enemy is too close to the player, has reached the player
                EnemyDie();
            }
        }
        else if (SightOnly && inSight)
        {//can see the player without obstruction, assumming the player does not have a large collider attached to it.
         //Debug.Log("Detecting by sight");
         //      Vector3 direction = playerLocation.position - transform.position;    
            ChasePlayer();
            if (Vector3.Distance(player.transform.position, transform.position) <= 2 && lineOfSight())
            {//reach here if the enemy is too close to the player, has reached the player
                EnemyDie();
            }
        }
        else
        {//reach here if the player is not in sight or is not heard entering chase state
         //  Debug.Log(_controller.remainingDistance); //will show the remaining distance till the enemy reaches its destination
            if (!wanderFlag)
            {
                chaseSightState = false;
                chaseSoundState = false;
                wanderFlag = true;
                chaseSightFlag = false;
                chaseSoundFlag = false;
                enemySounds.toWander();
                _controller.speed = searchSpeed;
                StartCoroutine(waitAWhile());
            }
            if (!(waitUntilInSight))
            {
                if (destPatrol)
                {//reach here to move towards the 
                  //  _controller.SetDestination(patrolPointPosition);
                    if (_controller.remainingDistance <= 2)
                    {
                        _controller.SetDestination(originPoint);
                        destPatrol = false;
                        destOrigin = true;
                    }
                }
                else if (destOrigin)
                {//should reach here after reaching the patrol point so it can head back to where it came.
                   // _controller.SetDestination(originPoint);
                    if (_controller.remainingDistance <= 2)
                    {
                        _controller.SetDestination(patrolPointPosition);
                        destPatrol = true;
                        destOrigin = false;
                    }
                }
            }
        }
    }

    bool lineOfSight()
    {
        RaycastHit hit;
        Vector3 direction = playerLocation.position - gameObject.transform.position;
        Vector3 playerRelative = transform.InverseTransformPoint(playerLocation.position);
        if (playerRelative.z > 0)
        {//checking if they are in visual pie
         //  Debug.Log("In MY SIGHTS");
            if (Physics.Raycast(gameObject.transform.position, direction, out hit, playerDetectionDistance))
            {//checking if there are no obstacles in the way 
             //  Debug.DrawRay(gameObject.transform.position, direction, Color.green, 2.0f);
                if (hit.transform.gameObject.name == "Player")
                {//checking if the object hit is the player
                 //    Debug.DrawRay(gameObject.transform.position, direction, Color.red, 4.0f);
                 //Debug.Log("I See You");
                    return true;
                }
            }
        }
        return false;
    }

    bool listenForPlayer()
    {
        float speed = player.GetComponent<PlayerMovement>().currSpeed;
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (speed == 11 && distance <= 30) { return true;  }
        else if (speed == 8 && distance <= 20) { return true; }
        else if (speed == 5 && distance <= 10) { return true; } 
        return false;
    }

 /* had been setting up a random respawn but decided to actively move them to a predetermined location. 
    Vector3 RandomNavSphere(Vector3 origin, float dist)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection = new Vector3(origin.x + randDirection.x, 0, origin.z + randDirection.z);


        NavMeshHit navHit;

        // Debug.Log(randDirection);
        // Debug.DrawLine(gameObject.transform.position, randDirection, Color.cyan, 10);

        NavMesh.SamplePosition(randDirection, out navHit, dist, 1);

        return navHit.position;
    }
    */
    private IEnumerator waitAWhile()
    {
        yield return new WaitForSeconds(2);//enemies keep heading towards player for two seconds after the player stops making noise
        _controller.SetDestination(patrolPointPosition);
    }


    void ChasePlayer()
    {
        if (!chaseSightFlag)
        {
            chaseSightState = true;
            enemySounds.toSightChase();
            _controller.speed = enemySpeed;
            wanderFlag = false;
            chaseSightFlag = true;
            chaseSoundFlag = false;
        }
        _controller.SetDestination(playerLocation.position);
    }

    void EnemyDie()
    {
        if (gameObject.name.CompareTo("SEnemy(1)") == 0) { gameObject.transform.position = originPoint; }
        else
        {
            if (toggle)
            {
                _controller.Warp(secondSpawnPoint);
                originPoint = secondSpawnPoint;
                patrolPointPosition = secondPatrolPoint;
            }
            else
            {
                _controller.Warp(firstSpawnPoint);
                originPoint = firstSpawnPoint;
                patrolPointPosition = firstPatrolPoint;
            }
            toggle = !toggle;
        }
        wanderFlag = false;
        chaseSightFlag = false;
        chaseSoundFlag = false;
        _controller.SetDestination(patrolPointPosition);
        destPatrol = true;
        destOrigin = false;
        enemySounds.toDeath();
    }

}
