using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovrCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public enum MoveType
    {
        WAY_POINT,
        LOOK_AT,
        GEAR_VR
    }
    public MoveType moveType = MoveType.WAY_POINT;
    public float speed = 1.0f;
    public float damping = 3.0f;

    public Transform[] points;
    private Transform tr;
    private CharacterController cc;
    private Transform camTr;
    private int nextIdx = 1;


    public Transform[] points;
    void Start()
    {
        tr = GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
        camTr = Camera.main.GetComponent<Transform>();
        GameObject wayPointGroup = GameObject.Find("WayPointGroup");
        if(wayPointGroup != null)
        {
            points = wayPointGroup.GetComponentsInChildren<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (moveType)
        {
            case MoveType.WAY_POINT;
                MoveWaypoint();
                break;
            case MoveType.LOOK_AT;
                MoveLookAt(1);
                break;
            case MoveType.GEAR_VR;
                break;
        }
    }
    void MoveWayPoint()
    {
        Vector3 direction = points[nextIdx].position - tr.position;
        Quaternion rot = Quaternion.LookRotation(direction);
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
        tr.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    void MoveLookAt(int facing)
    {

    }
}
