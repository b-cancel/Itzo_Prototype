using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hangingLightEnemy : MonoBehaviour {

    public GameObject lightManager;

    public List<Light> lightsWeAreIn;
    public Dictionary<Light, Quaternion> lightToEndRot;
    public Dictionary<Light, Quaternion> lightToCurrRot;

    [Range(0, 1)]
    public float followToAvoid;

    [Range(0, 1)]
    public float lerpValue;

    public Vector3 forwards;
    public Vector3 upwards;

    public bool firstLampOn;

    void Start()
    {
        lightsWeAreIn = new List<Light>();
        lightToCurrRot = new Dictionary<Light, Quaternion>();
        lightToEndRot = new Dictionary<Light, Quaternion>();

        followToAvoid = 0;

        lerpValue = .1f;

        firstLampOn = false;
    }

    void FixedUpdate()
    {
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
