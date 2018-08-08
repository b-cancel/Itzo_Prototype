using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlickerCompass : MonoBehaviour {
    
    //NOTE: this scripts importance is secondary and can be overidden by health flickering

    //this variable limits how far lights can be from the goal rotation
    //if they are further than this they would simply mislead the player
    public float maxAngleDifference;

    public bool usePointLights;
    public bool useSpotLightsOn;
    public bool useSpotLightsOff;

    public GameObject goal;
    public GameObject player;
    public GameObject health;

    public AudioSource lightFlickerSound;

    public Coroutine compassFlicker;

	void Start () {
        maxAngleDifference = 45; //45 is the literal max... and gives you a minimum 4 directions

        //NOTE: changes of these variables hapen AFTER the selected compass light stops flickering
        usePointLights = true;
        useSpotLightsOn = true;
        useSpotLightsOff = true;

        startCoR();
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
            indicateDirection();
	}

    IEnumerator hintCoR()
    {
        float waitTime = Random.Range(15,30);
        yield return new WaitForSeconds(waitTime);
        indicateDirection();
        startCoR();
    }

    void startCoR()
    {
        StartCoroutine(hintCoR());
    }

    public void indicateDirection()
    {
        if (health.GetComponent<health>().lightBadFlicker.isPlaying == false || health.GetComponent<health>().lightGoodFlicker.isPlaying == false)
        {
            Vector3 adjustedGoal = goal.transform.position;
            adjustedGoal.y = 0;
            Vector3 adjustedPlayer = player.transform.position;
            adjustedPlayer.y = 0;
            Vector3 directionOfGoal = (adjustedGoal - adjustedPlayer).normalized;

            float smallestAngle = float.MaxValue;
            Light compassLight = null;

            Dictionary<Light, float> tempRefs = GetComponent<lightManager>().light2MaxIntensity;
            foreach (var light in tempRefs.Keys)
            {
                if (withinCamera(light.transform.position))
                {
                    //-----Determine If we should use said light

                    bool usableLight = false;
                    //---handle using point lights
                    if (light.type == LightType.Point && usePointLights)
                        usableLight = true;
                    //---handle using spot lights
                    if (light.type == LightType.Spot)
                    {
                        if (Mathf.Approximately(light.intensity, 0) == false && useSpotLightsOn)
                            usableLight = true;
                        else if (Mathf.Approximately(light.intensity, 0) && useSpotLightsOff)
                            usableLight = true;
                    }

                    //-----Use the light

                    if (usableLight)
                    {
                        Vector3 adjustedLight = light.gameObject.transform.position;
                        adjustedLight.y = 0;
                        Vector3 directionOfLight = (adjustedLight - adjustedPlayer).normalized;
                        float thisAngle = Vector3.Angle(directionOfGoal, directionOfLight);
                        if (thisAngle < smallestAngle)
                        {
                            smallestAngle = thisAngle;
                            compassLight = light;
                        }
                        //ELSE... we already have a better light selected
                    }
                    //ELSE... this light should be used for the compass given our boolean variables
                }
                //ELSE... this light isnt within view so it would not be beneficial to select it
            }

            if (compassLight != null)
            {
                if (smallestAngle < maxAngleDifference)
                    compassFlicker = StartCoroutine(startCompassFlicker(compassLight));
                //ELSE... we have no compassLight an appropiate ANGLE distance from our goal (a non misleading distance)
            }
            //ELSE... we have no compassLight in our view
        }
        //ELSE... light are currently flickering and they take precedence over us
    }

    bool withinCamera(Vector3 position)
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(position);
        return (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1);
    }

    public void stopCompassFlicker()
    {
        StopCoroutine(compassFlicker);
        lightFlickerSound.Stop();
        compassFlicker = null;
    }

    //NOTE: this really should never have to interupt itself

    //light flicker pattern to follow sound
    IEnumerator startCompassFlicker(Light lightToFlicker)
    {
        float origIntensity = GetComponent<lightManager>().light2MaxIntensity[lightToFlicker];

        lightFlickerSound.Play();
        while (lightFlickerSound.isPlaying)
        {
            yield return new WaitForEndOfFrame();

            GetComponent<OutputVolume>().audioSource = lightFlickerSound;
            GetComponent<OutputVolume>().calcVolume();
            float vol = GetComponent<OutputVolume>().getVolRaw();

            //calc how dim our light(s) should be
            float percentOfTravel;
            //NOTE: values taken from 
            //percentOfTravel = (vol - 0) / (0 - 0); //using max RAW
            percentOfTravel = (vol - 0) / (0.2166753f - 0); //using max DAMP

            lightToFlicker.intensity = Mathf.Lerp(0, origIntensity, percentOfTravel);
        }
        if (lightToFlicker.type == LightType.Spot)
        {
            int multip = (GetComponent<lightManager>().light2isOn[lightToFlicker]) ? 1 : 0;
            lightToFlicker.intensity = (origIntensity * multip);
        }
        else
            lightToFlicker.intensity = origIntensity;
        compassFlicker = null;
    }
}