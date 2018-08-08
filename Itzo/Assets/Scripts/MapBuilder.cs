using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour {

    public bool awake;

    public GameObject wallFolder;
    public GameObject wallPrefab;

    public bool lockToIntX;
    public bool lockToIntZ;

    public float yValue;
    public float wallHeight;

    Vector3 potentialPoint1;
    Vector3 potentialPoint2;

    Vector3 savedPanStart;

    int scale; //NOTE: MUST be POSITIVE INTEGER

    void Awake()
    {
        lockToIntX = true;
        lockToIntZ = true;

        yValue = 0f;
        wallHeight = .75f;

        StartCoroutine(waitForGenWall());

        scale = 5;

        awake = true;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0)
        {
            //zoom in or out
            if (scroll > 0)
                Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - 1, 1, float.MaxValue);
            else if (scroll < 0)
                Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + 1, 1, float.MaxValue);
        }
        else
        {
            //panning
            if (Input.GetKeyDown(KeyCode.Mouse1))
                savedPanStart = getWorldPoint(false, false);
            else if (Input.GetKeyUp(KeyCode.Mouse1))
                savedPanStart = Vector3.zero;

            if (Input.GetKey(KeyCode.Mouse1))
            {
                //shift the camera so that the position of the mouse is on the starting point
                Vector3 dif = savedPanStart - getWorldPoint(false, false);
                Camera.main.gameObject.transform.position = Camera.main.gameObject.transform.position + dif;
            }
        }
    }

    
    //this loop infinitely
    IEnumerator waitForGenWall()
    {
        while (1 == 1)
        {
            //-----grab point 1

            while (1 == 1)
            {
                potentialPoint1 = getWorldPoint(lockToIntX, lockToIntZ);
                potentialPoint2 = potentialPoint1;
                yield return new WaitForEndOfFrame();
                if (Input.GetKey(KeyCode.Mouse0) == true)
                    break;
            }

            //-----instantiate wall

            GameObject newWall = Instantiate(wallPrefab, wallFolder.transform);

            //-----grab point 2

            while (1 == 1)
            {
                potentialPoint2 = getWorldPoint(lockToIntX, lockToIntZ);

                //-----update wall position, scale, and rotation
                newWall.transform.position = Vector3.Lerp(potentialPoint1, potentialPoint2, .5f); //set position
                newWall.transform.localScale = new Vector3(Vector3.Distance(potentialPoint1, potentialPoint2) + 1, wallHeight, 1); //set scale
                Vector3 vect = (potentialPoint1.z < potentialPoint2.z) ? (potentialPoint1 - potentialPoint2) : (potentialPoint2 - potentialPoint1);
                float angle = Vector3.Angle(new Vector3(1, 0, 0), vect) + 180;
                newWall.transform.rotation = Quaternion.Euler(0, angle, 0);

                yield return new WaitForEndOfFrame();
                if (Input.GetKey(KeyCode.Mouse0) == false)
                    break;
            }
        }
    }
    
    Vector3 getWorldPoint(bool lockX, bool lockZ)
    {
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosWorld.y = yValue;
        if (lockX)
            mousePosWorld.x = returnLockedValueToScale(mousePosWorld.x);
        if (lockZ)
            mousePosWorld.z = returnLockedValueToScale(mousePosWorld.z);
        return mousePosWorld;
    }

    int returnLockedValueToScale(float valFloat)
    {
        if (scale == 0)
            return Mathf.RoundToInt(valFloat);
        else
        {
            int valInt = Mathf.RoundToInt(valFloat);
            if (valInt % scale != 0)
            {
                int left = (int)(valFloat / scale) * scale;
                int right = left + scale;

                if (Mathf.Abs(valFloat - left) < Mathf.Abs(valFloat - right))
                    return left;
                else
                    return right;
            }
            else
                return valInt;
        }

    }

    void OnDrawGizmos()
    {
        if (awake)
        {
            float distProc = Vector3.Distance(potentialPoint2, potentialPoint1) / scale;
            Vector3 pointProc = potentialPoint2 / scale;
            print(pointProc + " |  " + distProc);

            Gizmos.color = Color.red;

            //draw a sphere on your mouse (given a rounded x and z and a manually set y)
            Gizmos.DrawSphere(potentialPoint1, 1);

            //draw a sphere on your 1st potential point once its set (once the 2nd is set and the 2 points save the 1st point follows the mouse)
            Gizmos.DrawSphere(potentialPoint2, 1);

            //draw the line between them
            Gizmos.DrawLine(potentialPoint1, potentialPoint2);

            Gizmos.color = Color.blue;
            for (int x = ((int)potentialPoint2.x - scale - 1); x <= ((int)potentialPoint2.x + scale + 1); x++)
            {
                for (int z = ((int)potentialPoint2.z - scale - 1); z <= ((int)potentialPoint2.z + scale + 1); z++)
                {
                    if (x % scale == 0 && z % scale == 0)
                    {
                        Gizmos.color = Color.blue;
                        Gizmos.DrawWireCube(new Vector3(x, potentialPoint2.y, z), new Vector3(scale, scale, scale));
                        Gizmos.color = Color.red;
                        Gizmos.DrawWireSphere(new Vector3(x, potentialPoint2.y, z), scale / 2f);
                        Gizmos.DrawSphere(new Vector3(x, potentialPoint2.y, z), .5f);
                    }
                    else
                    {
                        //Gizmos.color = Color.blue;
                        //Gizmos.DrawWireSphere(new Vector3(x, potentialPoint2.y, z), .25f);
                    }
                }

            }
        }   
    }
}