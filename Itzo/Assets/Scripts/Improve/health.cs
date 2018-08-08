using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {

    public GameObject player;
    public GameObject lightClick;

    bool deathOnTimer;

    //----------Communicate Status (health stays same, gaining health, losing health)

    status currStatus;
    status prevStatus;
    enum status {normal, safe, danger };
    public int maxHealth;
    public int currHealth; //read this one to determine actual health
    int prevHealth;

    public bool weAreSafe;
    public bool weAreInDanger;

    //----------Communicate Potential Health Hit

    public AudioSource lightGoodFlicker;
    public AudioSource lightBadFlicker; //danger get out fast
    public AudioSource lightChange; //too late danger has affected you

    public bool pointLightFlicker;
    public bool spotLightOnFlicker;
    public bool spotLightOffFlicker;

    public GameObject compassLight;
    public GameObject objectLight;
    public GameObject haloOfLight;
    public GameObject environmentLights;
    public bool compassFlicker;
    public float origCompassIntensity;
    public bool objectFlicker;
    public float origObjectIntensity;
    public bool haloFlicker;
    public float origHaloIntensity;
    public bool healthFlicker;
    //public float origHealthIntensity... COMPLEX TODO...

    //----------Communicate Health Hit

    //---using Sound
    public bool useBreathing;
    bool prevUseBreathing;
    public bool isMale; 
    bool prevIsMale;
    public GameObject breathing;

    //---using Visuals
    public float currLightIntensity;
    public GameObject healthLight;

    //----extra to communict health increas
    public bool specialLightsCanHeal;
    public bool unlimitedHealthGain;
    public float minLightItensityForEnviron; //if this is set at 0 then our lights flickering will go to 0 and whether or not we are safe will be constantly flickering

    Coroutine increasingHealth;
    Coroutine decreasingHealth;
    public bool decHealthImmediately;

    void Start()
    {
        //---status
        currStatus = status.normal;
        prevStatus = status.normal;
        maxHealth = 5;
        prevHealth = 6;
        currHealth = 5;

        weAreSafe = false;
        weAreInDanger = false;

        //---potential health hit
        pointLightFlicker = true;
        spotLightOnFlicker = true;
        spotLightOffFlicker = true;

        compassFlicker = true;
        origCompassIntensity = compassLight.GetComponent<Light>().intensity;
        objectFlicker = true;
        origObjectIntensity = objectLight.GetComponent<Light>().intensity;
        haloFlicker = true;
        origHaloIntensity = haloOfLight.GetComponent<Light>().intensity;
        healthFlicker = true;
        //origHealthIntensity... COMPLEX TODO...

        //---health hit

        //using sound
        useBreathing = true; //USE
        prevUseBreathing = true; //PREV
        isMale = true; //USE
        prevIsMale = true; //PREV

        //using visuals
        currLightIntensity = healthLight.GetComponent<Light>().intensity;

        //-----extras to communicate health increase

        //we can set whatever light we want to have color other than white (we must do so by hand)
        specialLightsCanHeal = true; //lights that are not WHITE
        unlimitedHealthGain = false; //the light only gives you health once
        minLightItensityForEnviron = .1f;

        increasingHealth = null;
        decreasingHealth = null;
        decHealthImmediately = false;

        deathOnTimer = false;
        if(deathOnTimer)
            startTimerDecHealth();
    }

    void Update ()
    {

        /*
        //NOTE: Our Female version are not refined and are therefore should not be used 
         
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha3))
            isMale = false;
        if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKey(KeyCode.Alpha9))
            isMale = true;
        */

        //-----TESTING CODE START

        //NOTE: we are in danger and decHealthImmediately are set from the heart beat script

        //print("we are safe " + weAreSafe);
        if (weAreInDanger ^ weAreSafe) //XOR (one or the other MUST be pressed)
        {
            //print("DANGER or SAFE");
            if (weAreInDanger)
                currStatus = status.danger;
            else
                currStatus = status.safe;
        }
        else //both or none are pressed
            currStatus = status.normal;

        //print("Curr status " + currStatus);

        //-----TESTING CODE END

        //-----Status Change Through Breathing

        if (useBreathing)
        {
            if (isMale != prevIsMale)
            {
                breathing.GetComponent<breathingManager>().stopAllBreathing();
                breathing.GetComponent<breathingManager>().startBreathing(isMale, currHealth);
            }

            prevIsMale = isMale;
        }

        if (useBreathing != prevUseBreathing)
        {
            breathing.GetComponent<breathingManager>().stopAllBreathing();
            if (useBreathing)
                breathing.GetComponent<breathingManager>().startBreathing(isMale, currHealth);

            prevUseBreathing = useBreathing;
        }

        if (prevHealth != currHealth)
        {
            if (useBreathing)
            {
                breathing.GetComponent<breathingManager>().stopAllBreathing();
                breathing.GetComponent<breathingManager>().startBreathing(isMale, currHealth);
            }
            prevHealth = currHealth;
        }

        //-----Status Potential To Change

        if(currStatus != status.normal)
        {
            if (currStatus == status.safe) //we can continue to gain health if in a light
            {
                if (increasingHealth == null)
                    increasingHealth = StartCoroutine(increaseHealth());
            }
            else //we can continue to lose health if surrounded by monsters
            {
                if (decreasingHealth == null)
                    decreasingHealth = StartCoroutine(decreaseHealth());
            }
        }

        if (currStatus != prevStatus) //we have a new status a MIGHT have to start a CoR
            prevStatus = currStatus;
    }

    //---------NOTE: you ARE NEVER safe and in danger so these should never overlap each other (Safe > Danger)
   
    void startTimerDecHealth()
    {
        StartCoroutine(timerDecHealth());
    }

    IEnumerator timerDecHealth()
    {
        while(1 == 1)
        {
            yield return new WaitForSeconds(30f);
            weAreInDanger = true;
            decreasingHealth = StartCoroutine(decreaseHealth());
            yield return new WaitForEndOfFrame();
            while (lightChange.isPlaying == false)
                yield return null;
            weAreInDanger = false;
        }
    }

    //---when you are in danger this coroutine runs for a while until you lose a health unit

    public IEnumerator decreaseHealth()
    {
        if(0 <= (currHealth - 1))
        {
            player.GetComponent<PlayerMovement>().playerBoost();

            if (useBreathing)
            {
                breathing.GetComponent<breathingManager>().stopAllBreathing();
                breathing.GetComponent<breathingManager>().gasp(isMale, currHealth);
            }

            //-----Flicker the light for a while
            if (environmentLights.GetComponent<lightFlickerCompass>().compassFlicker != null) //stop any compass flicker
                environmentLights.GetComponent<lightFlickerCompass>().stopCompassFlicker();
            lightBadFlicker.Play();
            while (lightBadFlicker.isPlaying && decHealthImmediately == false)
            {
                yield return new WaitForEndOfFrame();
                flickerLight(lightBadFlicker);
                if (currStatus != status.danger)
                    lightBadFlicker.Stop(); 
            }
            changeLightIntensities(1);

            //there are 2 reasons why it stopped flickering
            if (currStatus == status.danger)
            {
                lightChange.Play();
                while (lightChange.isPlaying)
                    yield return new WaitForEndOfFrame();
                breathing.GetComponent<breathingManager>().lostSanity.Play();
                yield return new WaitForSeconds(breathing.GetComponent<breathingManager>().lostSanity.clip.length);
                currHealth--;
            }
            else
            {
                breathing.GetComponent<breathingManager>().almostLostSanity.Play();
                yield return new WaitForSeconds(breathing.GetComponent<breathingManager>().almostLostSanity.clip.length);
                breathing.GetComponent<breathingManager>().startBreathing(isMale, currHealth);
            }

            changeLightIntensities(1);
        }
        else //there is nothing else to remove
            yield return new WaitForEndOfFrame();
        decreasingHealth = null;
    }

    //---when you are safe this coroutine runs for a while unitl you gain a health unit

    IEnumerator increaseHealth()
    {
        if ((currHealth + 1) <= maxHealth)
        {
            if (useBreathing)
            {
                breathing.GetComponent<breathingManager>().stopAllBreathing();
                breathing.GetComponent<breathingManager>().sigh(isMale, currHealth);
            }

            //-----Flicker the light for a while
            if (environmentLights.GetComponent<lightFlickerCompass>().compassFlicker != null) //stop any compass flicker
                environmentLights.GetComponent<lightFlickerCompass>().stopCompassFlicker();
            lightGoodFlicker.Play();
            while (lightGoodFlicker.isPlaying)
            {
                yield return new WaitForEndOfFrame();
                flickerLight(lightGoodFlicker);
                if (currStatus != status.safe)
                    lightGoodFlicker.Stop();
            }
            changeLightIntensities(1);

            //there are 2 reasons why it stopped flickering
            if (currStatus == status.safe)
            {
                if (unlimitedHealthGain == false)
                    (lightClick.GetComponent<hangingLight>().returnClosestLight(true)).color = Color.white;

                lightChange.Play();
                while (lightChange.isPlaying)
                    yield return new WaitForEndOfFrame();
                breathing.GetComponent<breathingManager>().gainSanity.Play();
                yield return new WaitForSeconds(breathing.GetComponent<breathingManager>().gainSanity.clip.length);
                currHealth++;
            }
            else
            {
                breathing.GetComponent<breathingManager>().almostGainedSanity.Play();
                yield return new WaitForSeconds(breathing.GetComponent<breathingManager>().almostGainedSanity.clip.length);
                breathing.GetComponent<breathingManager>().startBreathing(isMale, currHealth);
            } 

            changeLightIntensities(1);
        }
        else //there is nothing else to add
            yield return new WaitForEndOfFrame();
        increasingHealth = null;
    }

    //light flicker pattern to follow sound
    void flickerLight(AudioSource source)
    {
        GetComponent<OutputVolume>().audioSource = source;
        GetComponent<OutputVolume>().calcVolume();
        float vol = GetComponent<OutputVolume>().getVolRaw();

        //calc how dim our light(s) should be
        float percentOfTravel;
        if (source == lightBadFlicker) //light flicker [0,0.1539215] {0,0.124559}
        {
            //percentOfTravel = (vol - 0) / (0.1539215f - 0); //using max RAW
            percentOfTravel = (vol - 0) / (0.124559f - 0); //using max DAMP
        }
        else if (source == lightGoodFlicker)
        {
            //percentOfTravel = (vol - 0) / (0.1539215f - 0); //using max RAW
            percentOfTravel = (vol - 0) / (.25f - 0); //using max DAMP
        }
        else //light change [0,0.2440041] {0,0.2293126}
        {
            //percentOfTravel = (vol - 0) / (0.2440041f - 0); //using max RAW
            percentOfTravel = (vol - 0) / (0.2293126f - 0); //using max DAMP
        }

        changeLightIntensities(percentOfTravel);
    }

    void changeLightIntensities(float percentOfTravel)
    {
        Dictionary<Light, float> tempRefs = environmentLights.GetComponent<lightManager>().light2MaxIntensity;
        foreach (var light in tempRefs.Keys)
        {
            
            if(light.type == LightType.Point) //---handle point lights
            {
                if (pointLightFlicker)
                    light.intensity = Mathf.Lerp(minLightItensityForEnviron, tempRefs[light], percentOfTravel);
                else
                    light.intensity = tempRefs[light];
            }
            else if(light.type == LightType.Spot) //-----handle spot lights
            {
                bool offFlicker = (Mathf.Approximately(light.intensity, 0) == true) && (spotLightOffFlicker);
                bool onFlicker = (Mathf.Approximately(light.intensity, 0) == false) && (spotLightOnFlicker);

                if (offFlicker || onFlicker)
                {
                    if (Mathf.Approximately(percentOfTravel, 1))
                    {
                        int multip = (environmentLights.GetComponent<lightManager>().light2isOn[light]) ? 1 : 0;
                        light.intensity = (tempRefs[light] * multip);
                    }
                    else
                        light.intensity = Mathf.Lerp(minLightItensityForEnviron, tempRefs[light], percentOfTravel);
                }
                else
                {
                    int multip = (environmentLights.GetComponent<lightManager>().light2isOn[light]) ? 1 : 0;
                    light.intensity = (tempRefs[light] * multip);
                }
            }
            //ELSE... this particlar light shouldn't be flickering
        }

        if (compassFlicker)
            compassLight.GetComponent<Light>().intensity = Mathf.Lerp(0, origCompassIntensity, percentOfTravel);
        else
            compassLight.GetComponent<Light>().intensity = origCompassIntensity;

        if (objectFlicker)
            objectLight.GetComponent<Light>().intensity = Mathf.Lerp(0, origObjectIntensity, percentOfTravel);
        else
            objectLight.GetComponent<Light>().intensity = origObjectIntensity;

        if (healthFlicker)
            healthLight.GetComponent<Light>().intensity = Mathf.Lerp(0, currLightIntensity, percentOfTravel);
        else
            healthLight.GetComponent<Light>().intensity = currLightIntensity;

        if (haloFlicker)
            haloOfLight.GetComponent<Light>().intensity = Mathf.Lerp(0, origHaloIntensity, percentOfTravel);
        else
            haloOfLight.GetComponent<Light>().intensity = origHaloIntensity;
    }
}