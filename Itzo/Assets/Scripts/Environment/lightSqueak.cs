using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSqueak : MonoBehaviour {

    public GameObject lightClick;
    public GameObject ourLight;

    public float soundRange;

    public AudioSource _1;
    public AudioSource _2;
    public AudioSource _3;
    public AudioSource _4;
    public AudioSource _5;

    [Range(0,1)]
    public float maxSqueakVolume;

    public float swinging0;
    public float following0;

    //calculate it for different setting so that you can change volume given velocity
    public bool calcMaxVel;
    public float maxVel; //for setting as of 4/17/19 (maxVel = .86)

    void Awake()
    {
        calcMaxVel = false;
        maxVel = 0;

        swinging0 = .1f;
        following0 = .05f;
        startSqueak();

        maxSqueakVolume = .15f;

        soundRange = 45;

        updateSoundRange();
    }

    void updateSoundRange()
    {
        _1.maxDistance = soundRange;
        _2.maxDistance = soundRange;
        _3.maxDistance = soundRange;
        _4.maxDistance = soundRange;
        _5.maxDistance = soundRange;
    }

    void Update()
    {
        updateSoundRange();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if(calcMaxVel)
            if (GetComponent<Rigidbody>().velocity.magnitude > maxVel)
                maxVel = GetComponent<Rigidbody>().velocity.magnitude;
    }

    void startSqueak()
    {
        StartCoroutine(squeakCoR());
    }

    IEnumerator squeakCoR()
    {
        Vector3 lastVelocity = Vector3.zero;
        AudioSource trackWeArePlaying = _1;

        //Infinite Loop
        while (1 == 1)
        {
            //If we are within the lights radius no noises are played
            if(lightClick.GetComponent<hangingLight>().lightsWeAreIn.Contains(ourLight.GetComponent<Light>()))
            {
                Vector3 currRot = lightClick.GetComponent<hangingLight>().lightToCurrRot[ourLight.GetComponent<Light>()].eulerAngles;
                Vector3 endRot = lightClick.GetComponent<hangingLight>().lightToEndRot[ourLight.GetComponent<Light>()].eulerAngles;
                Vector3 difRot = endRot - currRot;

                if (aprox0(difRot,following0))
                {
                    if (trackWeArePlaying.isPlaying)
                    {
                        trackWeArePlaying.Stop();

                        //randomly select one of the 5 squeaks
                        switch ((int)Mathf.Ceil(Random.Range(0, 5)))
                        {
                            case 1: trackWeArePlaying = _1; break;
                            case 2: trackWeArePlaying = _2; break;
                            case 3: trackWeArePlaying = _3; break;
                            case 4: trackWeArePlaying = _4; break;
                            case 5: trackWeArePlaying = _5; break;
                            default: break;
                        }
                    }
                    //Else... we have already selected a new track for the next time around
                }
                else
                {
                    if (trackWeArePlaying.isPlaying == false) //begin playing the track
                        trackWeArePlaying.Play();
                    else //change the volume of our track depending on our speed
                    {
                        //our Velocity Magnitude (0 -> .85)
                        //our Volume Magnitude (0 -> maxSqueakVolume)

                        float percentOfTravel = (GetComponent<Rigidbody>().velocity.magnitude - 0) / (.85f - 0);
                        trackWeArePlaying.volume = Mathf.Lerp(0, maxSqueakVolume, percentOfTravel);
                    }
                }
            }
            else //We Play Swining Noises Until We Come To A Stop
            {
                //We Stopped Moving... Grab A New Squeak To Run Next Time
                if (aprox0(gameObject.GetComponent<Rigidbody>().velocity,swinging0))
                {
                    if (trackWeArePlaying.isPlaying)
                    {
                        trackWeArePlaying.Stop();

                        //randomly select one of the 5 squeaks
                        switch ((int)Mathf.Ceil(Random.Range(0, 5)))
                        {
                            case 1: trackWeArePlaying = _1; break;
                            case 2: trackWeArePlaying = _2; break;
                            case 3: trackWeArePlaying = _3; break;
                            case 4: trackWeArePlaying = _4; break;
                            case 5: trackWeArePlaying = _5; break;
                            default: break;
                        }
                    } 
                    //Else... we have already selected a new track for the next time around
                }
                else //We Are Moving
                {
                    if (trackWeArePlaying.isPlaying == false) //begin playing the track
                        trackWeArePlaying.Play();
                    else //change the volume of our track depending on our speed
                    {
                        //our Velocity Magnitude (0 -> .85)
                        //our Volume Magnitude (0 -> maxSqueakVolume)

                        float percentOfTravel = (GetComponent<Rigidbody>().velocity.magnitude - 0) / (.85f - 0);
                        trackWeArePlaying.volume = Mathf.Lerp(0, maxSqueakVolume, percentOfTravel);
                    }
                }
            }

            lastVelocity = GetComponent<Rigidbody>().velocity;
            yield return new WaitForFixedUpdate();
        }
    }

    bool aprox0(Vector3 vect, float our0)
    {
        if (Mathf.Abs(vect.x) > our0)
            return false;
        if (Mathf.Abs(vect.y) > our0)
            return false;
        if (Mathf.Abs(vect.z) > our0)
            return false;
        return true;
    }
}
