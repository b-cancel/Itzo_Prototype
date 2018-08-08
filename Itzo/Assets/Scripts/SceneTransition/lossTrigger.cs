using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//NOTE: script create for more complex transition for death

public class lossTrigger : MonoBehaviour {

    public GameObject player;
    Animator playerAnimation;
    health _health;

	// Use this for initialization
	void Awake () {
        _health = GetComponent<health>();
        playerAnimation = GameObject.FindGameObjectWithTag("playeranimator").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_health.currHealth <= 0)
        {
            player.GetComponent<PlayerMovement>().Dead = true;
            player.GetComponent<PlayerMovement>().movementLocked = true;
            player.GetComponent<PlayerMovement>().currSpeedLevel = 4;
           // playerAnimation.SetInteger("animationstate", 4);

            //TODO... CoRoutine to Fade To Black (after stoping all possible flicker)... 
            //perhaps some camera animations and then death screen... 
            //after everything fades to black.... 
            //and perhaps some sound playing a bit after the game fades to black
            Invoke("lossScreen", 4f);
        }
    }
    void lossScreen()
    {
        SceneManager.LoadScene("Loss", LoadSceneMode.Single);

    }
}
