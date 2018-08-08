using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lerpKit;

public class Intro : MonoBehaviour {

    public float timeBeforeHurry; //in minutes
    public AudioSource hurryUp;

    //need to be assigned in inspector
    public AudioSource intro;
    public AudioSource spaceForLamp;
    public AudioSource wasdToMove;
    public AudioSource playerReaction;
    public float panTime;

    //camera follow script
    public GameObject lightManager;
	public GameObject directFollowPoint;
	public GameObject GOAL;
    public GameObject PLAYER;
    public GameObject enemyManager;
	
    PlayerMovement _playerMovement;
	hangingLight _playerLight;
    health _playerHealth;
    Heartbeat _playerHeart;

    public GameObject tutMonster;
    public GameObject tutLight;

    void Start () {
        _playerMovement = PLAYER.GetComponent<PlayerMovement>();
		_playerLight = PLAYER.GetComponentInChildren<hangingLight>();
        _playerHealth = PLAYER.GetComponentInChildren<health>();
        _playerHeart = PLAYER.GetComponent<Heartbeat>();

        //make the game spooker after a while
        timeBeforeHurry = 3.5f;
        StartCoroutine(hurry());

        //the tutorial
        tutMonster.transform.position = new Vector3(81, 0, 73);
        tutMonster.SetActive(false);
        tutLight.GetComponentInChildren<Light>().intensity = 27.5f; //lightManager.GetComponent<lightManager>().light2MaxIntensity[tutLight.GetComponentInChildren<Light>()];

        StartCoroutine(goalTut());
        //_playerHeart.notInTutorial = true;
    }

    IEnumerator hurry()
    {
        yield return new WaitForSeconds(60 * timeBeforeHurry);
        hurryUp.Play();
    }

    //pan our camera from our goal to our player (in the meantime explain the rules of the game)
    //Also Zoom and Rotate our Camera into our player (so we can see the fact that the map is a brain at the start)
    IEnumerator goalTut()
    {
        //-------------------------VAR SETTING AND SAVING-------------------------

        //---set vars to determine length of LERPS
        float delay1 = 1;
        float delay2 = 0;
        float totalTime = delay1 + intro.clip.length + delay2;

        //---set our desired camera values
        Vector3 currPosition = GOAL.transform.position;
        Vector3 currCameraOffSet = new Vector3(0f, 250f, 0f);
        float currCameraRotationX = 90f;

        //---save the values our simple camera follow is using
        Vector3 goalPosition = PLAYER.transform.position;
        Vector3 goalCameraOffset = directFollowPoint.GetComponent<SimpleCameraFollow>().cameraOffSet;
        float goalCameraXRotation = directFollowPoint.GetComponent<SimpleCameraFollow>().cameraRotationX;

        //-------------------------IMMEDIATE CHANGES TO OUR CAMERA AND CONTROLS-------------------------

        directFollowPoint.transform.position = currPosition;
        directFollowPoint.GetComponent<SimpleCameraFollow>().cameraOffSet = currCameraOffSet;
        directFollowPoint.GetComponent<SimpleCameraFollow>().cameraRotationX = currCameraRotationX;

        //-------------------------DISTRACT OUR CAMERA AND LOCK CONTROLS-------------------------

        directFollowPoint.GetComponent<SimpleCameraFollow>().Target = directFollowPoint;

        _playerMovement.movementLocked = true;
        _playerLight.lightLocked = true;

        //-------------------------LINEAR INTERPOLATION VELOCITY CALCULATION-------------------------

        //calc lerp vel of pos
        float diffInPos = Vector3.Distance(currPosition, goalPosition);
        float posLerpVel = lerpKit.lerpHelper.calcLerpVelocity(diffInPos, totalTime, unitOfTime.seconds, updateLocation.Update);

        //calc lerp vel of offset
        float diffInOffset = Vector3.Distance(currCameraOffSet, goalCameraOffset);
        float offSetLerpVel = lerpKit.lerpHelper.calcLerpVelocity(diffInOffset, totalTime, unitOfTime.seconds, updateLocation.Update);

        //calc lerp vel of rotation
        float diffInRotation = Mathf.Abs(currCameraRotationX - goalCameraXRotation);
        float rotationLerpVel = lerpKit.lerpHelper.calcLerpVelocity(diffInRotation, totalTime, unitOfTime.seconds, updateLocation.Update);

        //-------------------------LINEAR INTERPOLATION-------------------------

        //NOTE: we must yield return new waitUntilNextFrame (or update loop) for things to work properly given that that is how we calculated out lerpVelocity

        //wait till our first delay is complete
        while (delay1 > 0)
        {
            yield return new WaitForEndOfFrame();

            //lerp camPos
            float posLerpValue = lerpKit.lerpHelper.calcLerpValue(currPosition, goalPosition, posLerpVel);
            currPosition = Vector3.Lerp(currPosition, goalPosition, posLerpValue);
            directFollowPoint.transform.position = currPosition;
            //lerp camOffset
            float offsetLerpValue = lerpKit.lerpHelper.calcLerpValue(currCameraOffSet, goalCameraOffset, offSetLerpVel);
            currCameraOffSet = Vector3.Lerp(currCameraOffSet, goalCameraOffset, offsetLerpValue);
            directFollowPoint.GetComponent<SimpleCameraFollow>().cameraOffSet = currCameraOffSet;
            //lerp camRotation
            float rotationLerpValue = lerpKit.lerpHelper.calcLerpValue(currCameraRotationX, goalCameraXRotation, rotationLerpVel);
            currCameraRotationX = Mathf.Lerp(currCameraRotationX, goalCameraXRotation, rotationLerpValue);
            directFollowPoint.GetComponent<SimpleCameraFollow>().cameraRotationX = currCameraRotationX;

            delay1 -= Time.deltaTime;
        }
        //begin playing our introduction
        intro.Play();
        //wait till our intro sound finishes playing
        while (intro.isPlaying)
        {
            yield return new WaitForEndOfFrame();

            //lerp camPos
            float posLerpValue = lerpKit.lerpHelper.calcLerpValue(currPosition, goalPosition, posLerpVel);
            currPosition = Vector3.Lerp(currPosition, goalPosition, posLerpValue);
            directFollowPoint.transform.position = currPosition;
            //lerp camOffset
            float offsetLerpValue = lerpKit.lerpHelper.calcLerpValue(currCameraOffSet, goalCameraOffset, offSetLerpVel);
            currCameraOffSet = Vector3.Lerp(currCameraOffSet, goalCameraOffset, offsetLerpValue);
            directFollowPoint.GetComponent<SimpleCameraFollow>().cameraOffSet = currCameraOffSet;
            //lerp camRotation
            float rotationLerpValue = lerpKit.lerpHelper.calcLerpValue(currCameraRotationX, goalCameraXRotation, rotationLerpVel);
            currCameraRotationX = Mathf.Lerp(currCameraRotationX, goalCameraXRotation, rotationLerpValue);
            directFollowPoint.GetComponent<SimpleCameraFollow>().cameraRotationX = currCameraRotationX;
        }
        //wait till our second delay is complete
        while (delay2 > 0)
        {
            yield return new WaitForEndOfFrame();

            //lerp camPos
            float posLerpValue = lerpKit.lerpHelper.calcLerpValue(currPosition, goalPosition, posLerpVel);
            currPosition = Vector3.Lerp(currPosition, goalPosition, posLerpValue);
            directFollowPoint.transform.position = currPosition;
            //lerp camOffset
            float offsetLerpValue = lerpKit.lerpHelper.calcLerpValue(currCameraOffSet, goalCameraOffset, offSetLerpVel);
            currCameraOffSet = Vector3.Lerp(currCameraOffSet, goalCameraOffset, offsetLerpValue);
            directFollowPoint.GetComponent<SimpleCameraFollow>().cameraOffSet = currCameraOffSet;
            //lerp camRotation
            float rotationLerpValue = lerpKit.lerpHelper.calcLerpValue(currCameraRotationX, goalCameraXRotation, rotationLerpVel);
            currCameraRotationX = Mathf.Lerp(currCameraRotationX, goalCameraXRotation, rotationLerpValue);
            directFollowPoint.GetComponent<SimpleCameraFollow>().cameraRotationX = currCameraRotationX;

            delay2 -= Time.deltaTime;
        }

        //-------------------------REFOCUS OUR CAMERA AND UNLOCK CONTROLS-------------------------

        directFollowPoint.GetComponent<SimpleCameraFollow>().Target = PLAYER;
        directFollowPoint.GetComponent<SimpleCameraFollow>().cameraOffSet = goalCameraOffset;
        directFollowPoint.GetComponent<SimpleCameraFollow>().cameraRotationX = goalCameraXRotation;

        //-------------------------TURN HEART ON-------------------------

        _playerHeart.notInTutorial = true;

        StartCoroutine(proximityTut());
    }

    IEnumerator proximityTut()
    {
        tutMonster.SetActive(true);
        playerReaction.Play();
        //wait until the monster kills a bit of your health to allow the player to move
        while (_playerHealth.breathing.GetComponent<breathingManager>().lostSanity.isPlaying == false)
            yield return null;

        tutMonster.SetActive(false);
        tutMonster.transform.position = new Vector3(1000, 1000, 1000);

        StartCoroutine(lampFollowTut());
    }

    //You auto walk across the lamp in front of your and see that it follows you
    //You walk to the edge of another lamp and are asked to turn it on
    //You see the lamp is blue and begin to be healed by it
    IEnumerator lampFollowTut()
    {
        //walk towards the light
        _playerMovement.autoMove = true;
        yield return new WaitForSeconds(3.5f); //TODO... set this value
        _playerMovement.autoMove = false;

        StartCoroutine(lampInteractTut());
    }

    
    IEnumerator lampInteractTut()
    {
        _playerLight.lightLocked = false;

        bool lightOn = false;

        while(lightOn == false)
        {
            spaceForLamp.Play();
            yield return new WaitForEndOfFrame();
            while (spaceForLamp.isPlaying)
            {
                yield return new WaitForEndOfFrame();
                if (Mathf.Approximately(PLAYER.GetComponentInChildren<hangingLight>().returnClosestLight(false).intensity, 0) == false)
                    lightOn = true;
            }

            float timeToWait = 5; //TODO... set this value
            while(timeToWait > 0)
            {
                yield return new WaitForEndOfFrame();
                timeToWait -= Time.deltaTime;
                if (Mathf.Approximately(PLAYER.GetComponentInChildren<hangingLight>().returnClosestLight(false).intensity, 0) == false)
                    lightOn = true;
            }
        }

        StartCoroutine(walkTut());
    }

    
    //after you are healed the game prompts you to begin moving and the game has begun
    IEnumerator walkTut()
    {
        _playerMovement.movementLocked = false;

        bool haveMoved = false;

        while (haveMoved == false)
        {
            wasdToMove.Play();
            yield return new WaitForEndOfFrame();
            while (wasdToMove.isPlaying)
            {
                yield return new WaitForEndOfFrame();
                if (PLAYER.GetComponentInChildren<PlayerMovement>().movementVector != Vector3.zero)
                    haveMoved = true;
            }

            float timeToWait = 5; //TODO... set this value
            while (timeToWait > 0)
            {
                yield return new WaitForEndOfFrame();
                timeToWait -= Time.deltaTime;
                if (PLAYER.GetComponentInChildren<PlayerMovement>().movementVector != Vector3.zero)
                    haveMoved = true;
            }
        }
    }
}
