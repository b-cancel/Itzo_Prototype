using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watch : MonoBehaviour {

    public GameObject player;
    public GameObject watchLight;
    public GameObject playerWrist;

    public Vector3 offSet;

    void Awake()
    {
        offSet = new Vector3(0, 0, 0);
    }
	
	void FixedUpdate ()
    {
        gameObject.transform.position = (playerWrist.transform.position + offSet);
        watchLight.GetComponent<Light>().color = player.GetComponent<Heartbeat>().bpmZone;
	}
}
