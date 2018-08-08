using UnityEngine;
using System.Collections;
//found from answers.unity user 0potable
public class SimpleCameraFollow : MonoBehaviour
{
    //extern linkages
    public GameObject Point;
    public GameObject Camera;
    public GameObject Target;

    public bool pointRotateWithTarget;
    public Vector3 pointRotation;

    public Vector3 cameraOffSet;
    public float cameraRotationX;

    void Awake()
    {
        pointRotateWithTarget = false;
        pointRotation = Vector3.zero;

        cameraOffSet = new Vector3(0, 15f, -15f);
        cameraRotationX = 45f;
    }

    private void Update()
    {
        //compute POINT transform
        Point.transform.position = Target.transform.position;
        if (pointRotateWithTarget)
        {
            Quaternion newRot = Target.transform.rotation;
            newRot = Quaternion.Euler(0, newRot.eulerAngles.y, newRot.eulerAngles.z);
            Point.transform.rotation = newRot;
        }
        else
            Point.transform.rotation = Quaternion.Euler(pointRotation.x, pointRotation.y, pointRotation.z);

        // computer CAMERA transform
        Camera.transform.localPosition = cameraOffSet;
        Camera.transform.localRotation = Quaternion.Euler(cameraRotationX, 0, 0);
    }
}
