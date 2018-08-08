using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compassLight : MonoBehaviour {

    public GameObject player;
    public GameObject inFrontOfPlayer;
    public GameObject health;
    public GameObject goal;

    public AudioSource buzzing;
    [Range(0,1)]
    public float minVolume;
    [Range(0, 1)]
    public float maxVolume;

	void Start () {
        minVolume = 0f;
        maxVolume = .05f;
	}
	
	void Update ()
    {
        //if our compass DOES NOT flicker then go for it always... otherwise only when 
        bool compassActive = (health.GetComponent<health>().compassFlicker) ? false : true;
        if (compassActive == false)
        {
            bool badFlicker = (health.GetComponent<health>().lightBadFlicker.isPlaying) ? true : false;
            bool goodFlicker = (health.GetComponent<health>().lightGoodFlicker.isPlaying) ? true : false;
            compassActive = ((goodFlicker || badFlicker) == false);
        }

        if (compassActive)
        {
            Vector3 directionOfGoal = (goal.transform.position - player.transform.position).normalized;
            Vector3 directionOfPlayer = (inFrontOfPlayer.transform.position - player.transform.position).normalized;
            directionOfGoal.y = 0;
            directionOfPlayer.y = 0;

            float angle = Vector3.Angle(directionOfGoal, directionOfPlayer);

            //the range should be between 0 and 180
            float percentOfTravel = (angle - 0) / (180 - 0); //using max DAMP

            //set compass light intensity
            GetComponent<Light>().intensity = Mathf.Lerp(health.GetComponent<health>().origCompassIntensity, 0, percentOfTravel);
            //set compass light sound intensity
            buzzing.volume = Mathf.Lerp(maxVolume, minVolume, percentOfTravel);
        }
        else
            buzzing.volume = 0;
	}
}
