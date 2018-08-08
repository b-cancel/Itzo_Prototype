using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//NOTE: script created for a better Win Transition

public class winTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "LightClick")
        {
            //((other.gameObject.transform.parent).transform.parent).gameObject.GetComponent<PlayerMovement>().movementLocked = true;
            //TODO... CoRoutine to Flicker the world iso light to on
            //perhaps an animation of releif....
            //perhaps an animation of switch being pulled...
            //perhaps an animation of the player falling asleep
            //after everything fades to black again...
            //noises because inaudible (like player acheiving peice temporarily)
            SceneManager.LoadScene("Win", LoadSceneMode.Single);
        }
    }
}
