using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lerpKit;

//TODO... modify this so it takes .1 seconds to lerp the distance of 1 unity unit (3 meters)

public class ComplexCameraFollow : MonoBehaviour {

    public GameObject pointFollowsPlayer;
    public GameObject cameraPointFollow;
    public GameObject cameraPointAngle;
    public GameObject camera;
    public GameObject player;

    public bool followRot;

    //Natural Order is Scale, Rotation, Translation
    public float minSpeed;
    public float maxSpeed;
    public float speed;

    //set in preferences
    [Range(0,1)]
    public float timeFor90DegRot;
    [Range(0, 1)]
    public float timeFor1TileTravel;

    public bool speedSetsCameraAngle;

    //camera point settings
    public float minDistFromPlayer;
    public float maxDistFromPlayer;
    public float distanceFromPlayer;

    public float minPovAngle;
    public float maxPovAngle;
    public float povAngle;

    public bool speedSetsDistAhead;

    //other camera point settings
    public float minDistAheadPlayer;
    public float maxDistAheadPlayer;
    public float distAheadPlayer;

    //calculated on runtime
    float lerpRotVelocity;
    float lerpPosVelocity;

    void Awake()
    {
        followRot = true;

        minSpeed = 22.5f;
        maxSpeed = 90;
        speed = Mathf.Clamp(90, minSpeed, maxSpeed);

        timeFor90DegRot = .25f; //in seconds
        timeFor1TileTravel = .1f; //in seconds

        speedSetsCameraAngle = true;

        minDistFromPlayer = -1;
        maxDistFromPlayer = 50;
        distanceFromPlayer = Mathf.Clamp(50, minDistFromPlayer, maxDistFromPlayer);

        minPovAngle = 22.5f;
        maxPovAngle = 90;
        povAngle = Mathf.Clamp(45, minPovAngle, maxPovAngle);

        speedSetsDistAhead = true;
        minDistAheadPlayer = 0;
        maxDistAheadPlayer = 22.5f;
        distAheadPlayer = Mathf.Clamp(0, minDistAheadPlayer, maxDistAheadPlayer);
    }

    //for the sake of testing (linearly interpolate between these values)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            speed += 22.5f;
        if (Input.GetKeyDown(KeyCode.K))
            speed -= 22.5f;
    }

    void FixedUpdate()
    {
        //-----follow point

        //follow player position
        lerpPosVelocity = lerpHelper.calcLerpVelocity(1, timeFor1TileTravel, unitOfTime.seconds, updateLocation.fixedUpdate);
        smoothFollowPosition();

        //follow player rotation
        if (followRot)
        {
            lerpRotVelocity = lerpHelper.calcLerpVelocity(90, timeFor90DegRot, unitOfTime.seconds, updateLocation.fixedUpdate); //TODO... this should need to be adjusted after variable is established
            smoothFollowRotation();
        }

        //-----CONDITIONAL

        speed = Mathf.Clamp(speed, minSpeed, maxSpeed); //ensrue range before continuing
        float percentOfTravel = (speed - minSpeed) / (maxSpeed - minSpeed);

        if (speedSetsCameraAngle) //overwrite the values being set in the inspector
        {
            //both angle and distance must linearly interpolate between their limits just like speed

            //calculated by looking at speed (Value between 0 and 1)
            povAngle = Mathf.Lerp(maxPovAngle, minPovAngle, percentOfTravel);
            distanceFromPlayer = Mathf.Lerp(minDistFromPlayer, maxDistFromPlayer, percentOfTravel);
        }

        if (speedSetsDistAhead)
        {
            //NOTE: a direct mapping doesnt produce the disired results
            //distAheadPlayer = Mathf.Lerp(minDistAheadPlayer, maxDistAheadPlayer, percentOfTravel);

            //22, 45, 67, 90
            int aproxSpeed = (int)speed;
            switch (aproxSpeed)
            {
                case 90: distAheadPlayer = maxDistAheadPlayer; break; //first person view
                case 67: distAheadPlayer = 12.5f; break; //third person view V1
                case 45: distAheadPlayer = 10f; break; //third person view V2
                case 22: distAheadPlayer = minDistAheadPlayer; break;
                default: distAheadPlayer = minDistAheadPlayer; break; //top down view
            }
        }

        //-----dist ahead player

        distAheadPlayer = Mathf.Clamp(distAheadPlayer, minDistAheadPlayer, maxDistAheadPlayer);
        cameraPointFollow.transform.localPosition = new Vector3(0, distAheadPlayer, 0);

        //-----angle point

        //set pov Angle
        povAngle = Mathf.Clamp(povAngle, minPovAngle, maxPovAngle); //ensure range before continuing
        cameraPointAngle.transform.localRotation = Quaternion.Euler((povAngle * -1), 0, 0);

        //-----distance point

        //set cam distance from player
        distanceFromPlayer = Mathf.Clamp(distanceFromPlayer, minDistFromPlayer, maxDistFromPlayer); //ensur ein range before continuing
        Vector3 newPos = Vector3.zero;
        newPos.z = (distanceFromPlayer * -1);
        camera.transform.localPosition = newPos;
    }

    //-------------------------follow point

    void smoothFollowPosition()
    {
        //extra code so that linear interpolation take X ammount of time for every tile of travel
        float lerpValue = lerpHelper.calcLerpValue((Vector2)pointFollowsPlayer.transform.position, (Vector2)player.transform.position, lerpPosVelocity);

        //lerp z value
        Vector2 zValue = Vector2.Lerp((Vector2)pointFollowsPlayer.transform.position, (Vector2)player.transform.position, lerpValue);

        //apply position
        Vector3 newPos = zValue;
        //newPos.z = cameraPoint.transform.position.z; //retain our cameras z position
        newPos.z = player.transform.position.z; //immediately follow our players z position
        pointFollowsPlayer.transform.position = newPos;
    }

    void smoothFollowRotation()
    {
        Vector3 playerRot = (player.transform.rotation).eulerAngles;
        Vector3 camRot = (pointFollowsPlayer.transform.rotation).eulerAngles;  

        if (Mathf.Approximately(camRot.z, playerRot.z) == false)
        {
            //---cover edge cases
            float difference = Mathf.Abs(playerRot.z - camRot.z);
            if(difference > 180)
            {
                if (playerRot.z < camRot.z)
                    playerRot.z += 360;
                else
                    camRot.z += 360;
            }

            //extra code so that linear interpolation take X ammount of time for every 90 degrees
            float lerpValue = lerpHelper.calcLerpValue(camRot.z, playerRot.z, lerpRotVelocity);

            //lerp z value
            float zValue = Mathf.Lerp(camRot.z, playerRot.z, lerpValue);

            //apply rotation
            pointFollowsPlayer.transform.rotation = Quaternion.Euler(playerRot.x, playerRot.y, zValue);
        }
    }
}