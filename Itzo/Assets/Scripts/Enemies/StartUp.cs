using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour {
    public GameObject[] enemies;//this is the array that will hold all the enemies
    ///////////////////////////////////
    public bool SoundOnly;
    public bool SightOnly;//these bools specify how we want the enemy to search for 
    public bool SightAndSound;//the player. Only set one of these to true.
    //////////////////////////////////

    public int EnemySpeed;// enemy speed when chasing

    /////////////////////////////////////////
    //these bools specify enemy behavior
    public bool WaitUntilInSight;//will be set to true for stationary enemies
    public bool SearchSlowly; //enable this to the enemies move slowly when searching
    public bool SearchFrantically; //enable this to make enemies move quickly when searching
    /////////////////////////////////////////

    public int DetectionDist;//sets how far away enemies can locate player when using sight.
    public int RespawnRadius;//currently not working, there is a problem with navmesh sample position function returning infinity
    
    void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().SoundOnly = SoundOnly;
            enemy.GetComponent<EnemyMovement>().SightOnly = SightOnly;
            enemy.GetComponent<EnemyMovement>().SightAndSound = SightAndSound;
            enemy.GetComponent<EnemyMovement>().enemySpeed = EnemySpeed;
            enemy.GetComponent<EnemyMovement>().searchSlowly = SearchSlowly;
            enemy.GetComponent<EnemyMovement>().searchFrantically = SearchFrantically;
            enemy.GetComponent<EnemyMovement>().respawnRadius = RespawnRadius;
            enemy.GetComponent<EnemyMovement>().playerDetectionDistance = DetectionDist;

            if (enemy.name[0].CompareTo('S') == 0)
            {
                enemy.GetComponent<EnemyMovement>().waitUntilInSight = WaitUntilInSight;
            }
            else { enemy.GetComponent<EnemyMovement>().waitUntilInSight = false; }
            if (enemy.name.CompareTo("SEnemy(1)") == 0) { enemy.transform.position = new Vector3(82, 0, 54); }
        }
    } 	
}
