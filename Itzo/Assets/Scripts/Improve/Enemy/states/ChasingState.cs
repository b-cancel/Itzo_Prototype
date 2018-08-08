using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ChasingState : MonoBehaviour {
  //  enum STATE(WANDER, CHASE, FLEE);
    NavMeshAgent _controller;
    Transform _target;
    //STATE _currentState;
	void Start ()
	{
        _controller = GetComponent<NavMeshAgent>();
        _target = GameObject.Find("Player").transform;

      //  _currentState = STATE.WANDER;
    }
	
	void Update()
	{
      //  Debug.DrawLine(transform.position, _target.position, Color.blue);
        //_controller.SetDestination(_target.position);
		
	}
}
