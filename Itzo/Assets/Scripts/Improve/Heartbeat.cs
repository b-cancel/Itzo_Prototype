using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heartbeat : MonoBehaviour {

    public GameObject healthGO;

    public GameObject enemyManager;

    public AudioSource _heartBeatSound;

    public bool notInTutorial;

    public float currBpm; //bpm with no smoothing
    public Color bpmZone;

    /*
     * ----------FUTURE PLANS
     * 
     * Colors Chosen Given Thoroughly Tested Garmin Watch Color Zones
     * 
     * FOR DETECTION PURPOSES (larger ranges to 1. faster speeds [for quick decisions] 2. slower speeds [for planned decisions])
     * [210 bpm difference in total]
     * 
     * ---MIN BPM-> 50
     * White (50 -> 100) [50] (stable @ 60)
     * Blue (100 -> 135) [35] (stable @ 110)
     * Green (135 -> 165) [30] (stable @ 145)
     * Orange (165 -> 200) [35] (stable @ 175)
     * Red (200 -> 250) [50] (doesnt stabalize)
     * ---MAX BPM -> 250
     * 
     * idle (4 detection zones) [stable @ white] [blue, green, orange, red]
     * walking (3 detection zones) [stable @ blue] [green, orange, red]
     * running (2 detection zones) [stable @ green] [orange, red]
     * sprinting (1 detection zone) [stable @ orange] [red]
     */

    float idleBpm;
    float runningBpm; 
    float walkingBpm;
    float sprintingBpm;

    float timeToChangeBPM; //time to smooth from resting->running and vice versa
    float speedOfChange; //gets rate of change of targetbpm

    public float smallestZoneRadius;
    public float zoneIncrement;

    public int closestZoneTheyAreIn;

    Coroutine hearBeatCoR;

    // Use this for initialization
    void Start () {
        currBpm = 50f;
        bpmZone = Color.white;


        idleBpm = 50f;
        walkingBpm = 100f;
        runningBpm = 135f;
        sprintingBpm = 165f;

        timeToChangeBPM = 5f;

        smallestZoneRadius = 5f;
        zoneIncrement = 10f;
        //max of 55

        closestZoneTheyAreIn = 6;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (notInTutorial)
        {
            int speedLevel = GetComponent<PlayerMovement>().currSpeedLevel;
            float shortestDist = getSmallestDistanceFromPlayer();
            closestZoneTheyAreIn = getClosestZoneTheyAreIn(shortestDist);

            currBpm = Mathf.Max(speedLevelToBpm(speedLevel), shortestDistToBpm(shortestDist));
        }
    }

    // Fixed Update is calledonce per fixed frame
    void FixedUpdate()
    {
        if (notInTutorial)
        {
            if (hearBeatCoR == null)
                hearBeatCoR = StartCoroutine(heartBeat());
        }
    }

    //-------------------------BPM Function Called

    IEnumerator heartBeat()
    {
        _heartBeatSound.Play();
        float startTime = Time.timeSinceLevelLoad;
        while ((Time.timeSinceLevelLoad - startTime) < (60f / currBpm))
            yield return new WaitForFixedUpdate();
        hearBeatCoR = null;
    }

    //-------------------------Other Functions

    public float speedLevelToBpm(int speed)
    {
        float potentialBpm;
        switch (speed)
        {
            case 3: potentialBpm = sprintingBpm; break; //SPRINT
            case 2: potentialBpm = runningBpm; break; //RUN
            case 1: potentialBpm = walkingBpm; break; //WALK
            default: potentialBpm = idleBpm; break; //IDLE
        }
        return potentialBpm;
    }

    public float getSmallestDistanceFromPlayer()
    {
        bool weAreInDanger = false;
        bool decHealthImmediately = false;

        float closestDistance = float.MaxValue;
        for (int i = 0; i < enemyManager.GetComponent<StartUp>().enemies.Length; i++)
        {
            Vector3 playerPos = gameObject.transform.position;
            playerPos.y = 0;
            Vector3 monsterPos = enemyManager.GetComponent<StartUp>().enemies[i].transform.position;
            monsterPos.y = 0;

            float thisDistance = Vector3.Distance(playerPos, monsterPos);

            //for our health we care for all the monster within an area... 
            int zoneThisMonsterIsIn = getClosestZoneTheyAreIn(thisDistance);
            if(zoneThisMonsterIsIn <= 2)
            {
                //then this monster might be causing progressive... OR immediate damage...
                if (enemyManager.GetComponent<StartUp>().enemies[i].GetComponent<EnemyMovement>().chaseSightFlag)
                {
                    weAreInDanger = true;
                    if (zoneThisMonsterIsIn == 1)
                        decHealthImmediately = true;
                }
            }

            //NOTE: for our heart beat we only care for our closest distance
            if (thisDistance < closestDistance)
                closestDistance = thisDistance;
        }

        healthGO.GetComponent<health>().weAreInDanger = weAreInDanger;
        healthGO.GetComponent<health>().decHealthImmediately = decHealthImmediately;

        return closestDistance;
    }

    //-------------------------Zone Mappings-------------------------

    /*
    * ---MIN BPM-> 50
    * White (50)
    * Yellow (50 -> 100) [50] (stable @ 60)
    * Yellow (100 -> 135) [35] (stable @ 110)
    * Orange (135 -> 165) [30] (stable @ 145)
    * Redd (165 -> 200) [35] (stable @ 175)
    * Red (200 -> 250) [50] (doesnt stabalize)
    * ---MAX BPM -> 250
    */

    public void bpmToBpmZone()
    {
        if (currBpm > 165)
            bpmZone = Color.red;
        else if (currBpm > 135) //sprint
            bpmZone = new Color(255 / 255f, 100 / 255f, 45 / 255f);
        else if (currBpm > 100) //run
            bpmZone = Color.green;
        else if (currBpm > 50) //walk
            bpmZone = Color.blue;
        else //idle
            bpmZone = Color.white;
    }

    public float shortestDistToBpm(float smallestDist)
    {
        float potentialBpm;
        float beatDif;
        float distDif;
        switch (closestZoneTheyAreIn)
        {
            case 1: // SUPER CLOSE
                beatDif = 250 - 200;
                distDif = (smallestZoneRadius + (zoneIncrement * (0))) - 0;
                smallestDist -= 0;
                potentialBpm = Mathf.Lerp(250, 200, (smallestDist/distDif));
                break;
            case 2: // CLOSE
                beatDif = 200 - 165;
                distDif = (smallestZoneRadius + (zoneIncrement * (1))) - (smallestZoneRadius + (zoneIncrement * (0)));
                smallestDist -= (smallestZoneRadius + (zoneIncrement * (0)));
                potentialBpm = Mathf.Lerp(200, 165, (smallestDist / distDif));
                break;
            case 3: // MEDIUM
                beatDif = 165 - 135;
                distDif = (smallestZoneRadius + (zoneIncrement * (2))) - (smallestZoneRadius + (zoneIncrement * (1)));
                smallestDist -= (smallestZoneRadius + (zoneIncrement * (1)));
                potentialBpm = Mathf.Lerp(165, 135, (smallestDist / distDif));
                break;
            case 4: // FAR 
                beatDif = 135 - 100;
                distDif = (smallestZoneRadius + (zoneIncrement * (3))) - (smallestZoneRadius + (zoneIncrement * (2)));
                smallestDist -= (smallestZoneRadius + (zoneIncrement * (2)));
                potentialBpm = Mathf.Lerp(135, 100, (smallestDist / distDif));
                break;
            case 5: // SUPER FAR 
                beatDif = 100 - 50;
                distDif = (smallestZoneRadius + (zoneIncrement * (4))) - (smallestZoneRadius + (zoneIncrement * (3)));
                smallestDist -= (smallestZoneRadius + (zoneIncrement * (3)));
                potentialBpm = Mathf.Lerp(100, 50, (smallestDist / distDif));
                break;
            default:
                return 0; break;
        }
        return potentialBpm;
    }

    public int getClosestZoneTheyAreIn(float closestDistance)
    {
        closestZoneTheyAreIn = 6;
        for(int i = 1; i < closestZoneTheyAreIn; i++)
            if (closestDistance < (smallestZoneRadius + (zoneIncrement * (i-1)))) //1 through 5
                return i;
        return 6;
    }

    //-------------------------Debugging Function

    void OnDrawGizmos()
    {
        switch (closestZoneTheyAreIn)
        {
            case 1:
                Gizmos.color = Color.red; //5
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 0)); //15
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 1)); //25
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 2)); //35
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 3)); //45
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 4)); //55
                break;
            case 2:
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 0));
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 1));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 2));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 3));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 4));
                break;
            case 3:
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 0));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 1));
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 2));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 3));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 4));
                break;
            case 4:
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 0));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 1));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 2));
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 3));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 4));
                break;
            case 5:
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 0));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 1));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 2));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 3));
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 4));
                break;
            default:
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 0));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 1));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 2));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 3));
                Gizmos.DrawWireSphere(transform.position, smallestZoneRadius + (zoneIncrement * 4));
                break;
        }
    }
}
