using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundColliderScript : MonoBehaviour
{
    public GameObject playerHeardText;
    public GameObject Enemy;
    EnemyMovement thisEnemy;
    // Use this for initialization
    void Start()
    {
        //getting the EnemyMovement script variables of the enemy that parents this soundDetector
        thisEnemy = Enemy.GetComponent<EnemyMovement>();
        //        Debug.Log("The name of the enemy: "+ gameObject.transform.parent.gameObject.name);
    }

    private IEnumerator waitToErase()
    {
        yield return new WaitForSeconds(2);
        playerHeardText.GetComponent<Text>().enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {//will reach here when the sphere representing the player collides with the sphere collider respresenting the 
        //sound collider for the player
        if (other.gameObject.name == "SoundTriggerGameObject")
        {
            //   Debug.Log("I Hear You!");
            //thisEnemy.playerHeard = true;
            playerHeardText.GetComponent<Text>().enabled = true;
            StartCoroutine(waitToErase());

        }
    }

    void OnTriggerExit(Collider other)
    {//will reach here only if the player gets out of hearing range of the enemy
        if (other.gameObject.name == "SoundTriggerGameObject")
        {
            //Debug.Log("I can't hear You");
            //thisEnemy.playerHeard = false;
        }
    }


}
