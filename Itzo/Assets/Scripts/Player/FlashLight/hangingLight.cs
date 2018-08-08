using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lerpKit;

public class hangingLight : MonoBehaviour {

    public GameObject health;

    public GameObject lightManager;
    public AudioSource lightClick;

    public List<Light> lightsWeAreIn;
    public Dictionary<Light, Quaternion> lightToEndRot;
    public Dictionary<Light, Quaternion> lightToCurrRot;

    public bool lightLocked;

    [Range(0,1)]
    public float followToAvoid;

    [Range(0,1)]
    public float lerpValue;

    public Vector3 forwards;
    public Vector3 upwards;
	
	public bool firstLampOn;

    void Start()
    {
        lightsWeAreIn = new List<Light>();
        lightToCurrRot = new Dictionary<Light, Quaternion>();
        lightToEndRot = new Dictionary<Light, Quaternion>();

        lightLocked = false;

        followToAvoid = 0;

        lerpValue = .1f;
		
		firstLampOn = false;
    }

    void Update()
    {
        //-----Let the Player Pull The Switch
        if (Input.GetKeyDown(KeyCode.Space) && lightLocked == false)
            if (lightsWeAreIn.Count != 0)
                StartCoroutine(pullClosestSwitch());
    }

    void FixedUpdate()
    {
        //-----Let the Player Know If They Are Safe
        if (health.GetComponent<health>().specialLightsCanHeal)
        {
            if (lightsWeAreIn.Count != 0)
            {
                //---check if a light is NOT WHITE -and- ON 
                bool weAreSafe = false;
                foreach(var light in lightsWeAreIn)
                {
                    if (light.color != Color.white && Mathf.Approximately(light.intensity, 0) == false)
                    {
                        weAreSafe = true;
                        break; //we only need one of our lights to be special
                    }
                }
                health.GetComponent<health>().weAreSafe = weAreSafe;
            }
            else //we are not under a light
                health.GetComponent<health>().weAreSafe = false;
        }
        else //special lights can heal to dont look for em
            health.GetComponent<health>().weAreSafe = false;

        //-----Make The Lamps Follow The Player
        foreach (var light in lightsWeAreIn)
        {
            GameObject lampModel = light.transform.parent.gameObject; //Lamp3D
            GameObject lampPivot = lampModel.transform.parent.gameObject; //Lamp
            lampModel.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Vector3 lampToPlayer = (gameObject.transform.position - lampPivot.transform.position).normalized;

            Quaternion curRotation = lampPivot.transform.rotation;

            Quaternion followRotation = Quaternion.LookRotation(lampToPlayer);
            Vector3 followRotationVector = (followRotation.eulerAngles * -1);
            Quaternion avoidRotation = Quaternion.Euler(followRotationVector.x, followRotationVector.y, followRotationVector.z);

            //NOTE: linear interpolation directly using (Quaternion.Angle, then Quaternion.Lerp) and indirectly using Vector3s was attempted but did not work   
            Quaternion endRotation = Quaternion.Lerp(followRotation, avoidRotation, followToAvoid);
            Quaternion nextRotation = Quaternion.Lerp(curRotation, endRotation, lerpValue);

            lightToCurrRot[light] = nextRotation;
            lightToEndRot[light] = endRotation;

            //THIS IS VERY IMPORTANT... AND MUST FUNCTION WITH A JOINT THAT IS "CONFIGURED IN WORLD SPACE"
            lampModel.transform.localRotation = Quaternion.identity;
            lampPivot.transform.rotation = nextRotation;
        }
    }

    //NOTE: because of how the code is setup... 
    //we KNOW for a FACT that this light will still exist and this function will NOT return NULL
    //we KNOW for a FACT that we will be able to return a light that IS SPECIAL (when needed)
    public Light returnClosestLight(bool onlySpecial)
    {
        Light closestLight = null;
        float smallestDistance = float.MaxValue;
        foreach (var light in lightsWeAreIn)
        {
            bool isSpecial = false;
            //if a light is NOT WHITE -and- ON 
            if (light.color != Color.white && Mathf.Approximately(light.intensity, 0) == false)
                isSpecial = true;

            if ((onlySpecial == false) || (onlySpecial && isSpecial))
            {
                float thisLight = Vector3.Distance(light.gameObject.transform.position, gameObject.transform.position);
                if (thisLight < smallestDistance)
                {
                    closestLight = light;
                    smallestDistance = thisLight;
                }
            }
        }
        return closestLight;
    }

    IEnumerator pullClosestSwitch()
    {
        Light thisLight = returnClosestLight(false);
        lightClick.Play();
        while (lightClick.isPlaying)
            yield return null;
		firstLampOn = true;
        bool isOn = lightManager.GetComponent<lightManager>().light2isOn[thisLight]; //how the light was before we pulled the string
        isOn = !isOn; //we pulled the string so now its the opposite of what it was
        lightManager.GetComponent<lightManager>().light2isOn[thisLight] = isOn; //save the state of the light
        thisLight.intensity = (isOn) ? lightManager.GetComponent<lightManager>().light2MaxIntensity[thisLight] : 0; //reflect the state of the light
    }

    //NOTE: this assumes that onTriggerEnter and onTriggerExit never fail (which they have before in previous projects)

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "switchLight")
            addLight(other.gameObject.GetComponentInChildren<Light>());
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "switchLight")
            removeLight(other.gameObject.GetComponentInChildren<Light>());
    }

    void addLight(Light aLight)
    {
        lightsWeAreIn.Add(aLight);
        lightToCurrRot.Add(aLight, aLight.gameObject.transform.localRotation);
        lightToEndRot.Add(aLight, aLight.gameObject.transform.localRotation);
    }

    void removeLight(Light aLight)
    {
        lightsWeAreIn.Remove(aLight);
        lightToCurrRot.Remove(aLight);
        lightToEndRot.Remove(aLight);
    }
}
