using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimationController : MonoBehaviour {
    Animator _animator;
    EnemyMovement _enemyMovement;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
        _enemyMovement = GetComponentInParent<EnemyMovement>();
        //need to rotate, something's off about the origin when imported
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);

    }

    // Update is called once per frame
    void Update () {
		if(_enemyMovement.chaseSightState)
        {
            _animator.SetInteger("state", 2);
        }
        else if (_enemyMovement.chaseSoundState)
        {
            _animator.SetInteger("state", 1);
        }
        else
        {
            _animator.SetInteger("state", 0);
        }
    }
}
