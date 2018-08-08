using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRadiusAdjuster : MonoBehaviour {

    // Use this for initialization
    GameObject player;//used to get the Player GameObject
    PlayerMovement pSpeed; //gets the speed variable from teh player Movement script on the player gameObject
    void Start () {
        player = GameObject.Find("Player");
        pSpeed = player.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
                gameObject.GetComponent<SphereCollider>().radius = 2 *pSpeed.currSoundDistance;

    }



}
