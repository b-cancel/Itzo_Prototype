using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource _movementSound;

    Animator _animator;
    Heartbeat _heartbeat;
    Rigidbody _rigidbody;
    
    public bool movementLocked;
	public bool autoMove;
    public bool Dead;
	
    public float currSpeed;
    public int currSpeedLevel;
    public float currSoundDistance;
    public bool sprinting;

    Coroutine boostCoR;
    public float boostTime;

    //all these values are in meters per seconds (meters is unitys standard measurement system)
    float walkSpeed;
    float runSpeed;
    float sprintSpeed; //for when we implement speed

    float turnSmoothing;

    public Vector3 movementVector;

    private void Awake()
    {
        Dead = false;
        _animator = GetComponentInChildren<Animator>();
        _animator.SetInteger("animationstate", 0);
        _heartbeat = GetComponent<Heartbeat>();
        _rigidbody = GetComponent<Rigidbody>();

        movementLocked = false;
        currSpeed = 0;
        currSoundDistance = 0;
        sprinting = false;

        boostTime = 15f;//seconds

        walkSpeed = 5;//3f;
        runSpeed = 10;//6f;
        sprintSpeed = 15;//9f;

        turnSmoothing = 5f;
    }

    void Update()
    {
        movementVector = Vector3.zero;

        if (movementLocked == false)
        {
            //n e s w
            if (Input.GetKey(KeyCode.W))
                movementVector += new Vector3(0, 0, 1);
            if (Input.GetKey(KeyCode.D))
                movementVector += new Vector3(1, 0, 0);
            if (Input.GetKey(KeyCode.S))
                movementVector += new Vector3(0, 0, -1);
            if (Input.GetKey(KeyCode.A))
                movementVector += new Vector3(-1, 0, 0);
            movementVector.Normalize();
        }
		else if( movementLocked == true && autoMove == true) //move forward during movement tutorial
			movementVector += new Vector3(0,0,1);

        //Things that depend on Speed
        if (movementVector == Vector3.zero)
        {
            //sound management
            if(_movementSound.isPlaying == true)
                _movementSound.Stop();

            //NOTE: rotation stays as it was when you are moving

            currSpeed = 0;
        }
        else
        {
            //sound management
            if (_movementSound.isPlaying == false)
                _movementSound.Play();

            //rotation management
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_rigidbody.velocity.normalized), Time.fixedDeltaTime * 10f);

            if (Input.GetKey(KeyCode.LeftShift) == false)
                currSpeed = walkSpeed;
            else
            {
                if (sprinting == false)
                    currSpeed = runSpeed;
                else
                    currSpeed = sprintSpeed;
            }
        }
        if (!Dead)
        {
            currSpeedLevel = (int)((currSpeed / 5f));
        }
        //speed to moving sound pitch (0 -> 0, 3 -> 1, 6 -> 2, 9 -> 3)
        _movementSound.pitch = currSpeedLevel;

        //speed to movement animation
        if(_animator.GetInteger("animationstate") != 4)
            _animator.SetInteger("animationstate", (int)currSpeedLevel);

        //speed to Bpm
        _heartbeat.speedLevelToBpm((int)currSpeedLevel);

        //speed to velocity
        _rigidbody.velocity = movementVector * currSpeed;

        //speed to soundDistane
        currSoundDistance = currSpeed;
    }

    public void playerBoost()
    {
        if(boostCoR != null)
            StopCoroutine(boostCoR);
        //ELSE... we are not running boost

        boostCoR = StartCoroutine(boost());
    }

    IEnumerator boost()
    {
        sprinting = true;
        yield return new WaitForSeconds(boostTime);
        sprinting = false;
        boostCoR = null;
    }
}