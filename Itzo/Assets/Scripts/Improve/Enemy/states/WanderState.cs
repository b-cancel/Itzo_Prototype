using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class WanderState : MonoBehaviour {
    NavMeshAgent _controller;
    Vector2 randomNums;
    Vector3 target;
    Vector3 direction;
    public float wanderTime;
    public float wanderRadius;
//    NavMeshPath path;
    public bool prevDest;
    // Use this for initialization
    void Start() {
        // path = new NavMeshPath();
        _controller = GetComponent<NavMeshAgent>();
        InvokeRepeating("setWanderDestination", 1.0f, wanderTime);
    }

    void Update() {

        if (_controller.remainingDistance < 3) {//if enemy reaches the destination before the wanderTime is up, start a new destination
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, 9);
            _controller.SetDestination(newPos);
        }
        direction = _controller.destination - transform.position;
       // Debug.DrawRay(transform.position, direction, Color.red);
    }

    void setWanderDestination()
    {
       // Debug.Log("setting wander dest");
        if (prevDest == true)
        {//meaning it already has a previous destination from the chase state 
            if (transform.position.x == _controller.destination.x && transform.position.z == _controller.destination.z)
            {//if we have reached the destination then we can set a new destination
                prevDest = false;//will only be set to true from the Finite State Manager
            }
        }
        else
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, 9);
            _controller.SetDestination(newPos);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
