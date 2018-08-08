using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLight : MonoBehaviour {

    public GameObject flashLightAttach;

    public GameObject compassGO;
    public GameObject healthGO;
    public GameObject objectGO;

    Light compassLight;
    Light healthLight;
    Light objectLight;

    [Range(0,150)]
    public float rangeSlider; //connects the ranges off all the lights in the Flash Light Together

    float compassToHealth;
    float compassToObject;

    void Awake ()
    {
        compassLight = compassGO.GetComponent<Light>();
        healthLight = healthGO.GetComponent<Light>();
        objectLight = objectGO.GetComponent<Light>();

        rangeSlider = compassLight.range;

        compassToHealth = 1; //one to one ratio
        compassToObject = (7 / 10f);
    }
	
	void Update ()
    {
        //we copy the position of an object so this is we dont have trouble locating this
        gameObject.transform.position = flashLightAttach.transform.position;

        compassLight.range = rangeSlider;
        healthLight.range = rangeSlider * compassToHealth;
        objectLight.range = rangeSlider * compassToObject;
    }
}
