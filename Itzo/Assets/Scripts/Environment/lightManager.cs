using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightManager : MonoBehaviour {

    //Light Types (spot, directional, point, area [only baked])
    //NOTE: we can also create NAME -or- TAG -or- LAYER -or- LIGHT TYPE filters

    public Dictionary<Light, float> light2MaxIntensity;
    public Dictionary<Light, bool> light2isOn;

	// Use this for initialization
	void Awake ()
    {
        light2MaxIntensity = new Dictionary<Light, float>();
        light2isOn = new Dictionary<Light, bool>();
        Light[] allLights = GetComponentsInChildren<Light>();

        foreach(var light in allLights)
        {
            if(light.gameObject.name != "Map Light")
            {
                //NOTE: this assumes every lights intensity before you start the game is that particular lights max intensity
                light2MaxIntensity.Add(light, light.intensity);

                if (light.type == LightType.Spot)
                {
                    light.intensity = 0; //assume all spot lights start of OFF
                    light2isOn.Add(light, false);
                }
            }
        }
    }
}