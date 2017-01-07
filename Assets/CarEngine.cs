using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour {

    public Transform path;

    public float maxSteerAngle = 45;

    public WheelCollider wheelFL;
    public WheelCollider wheelFR;

    private List<Transform> nodes;

    private int activeNode = 0;

    float startDistance = 0;

    

    // Use this for initialization
    void Start () {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        foreach (Transform t in pathTransforms)
        {
            if (t != path.transform)
            {
                nodes.Add(t);
            }
        }
        startDistance = Vector3.Distance(nodes[activeNode].position, transform.position);
        drive(20);
    }

    void drive(float torque)
    {

        wheelFL.motorTorque = torque;
        wheelFR.motorTorque = torque;

        
    }
    

    // Update is called once per frame
    void Update () {
        if(Vector3.Distance(nodes[activeNode].position, transform.position) < 1+5* UnityEngine.Random.Range(0,1))
        {
            activeNode = (activeNode + 1) % nodes.Count;
            startDistance = Vector3.Distance(nodes[activeNode].position, transform.position);
        }
        ApplySteer();
	}

    
    private void ApplySteer()
    {
        Vector3 rv3a = getRelativeVectorOfNode(activeNode);
        //Vector3 rv3b = getRelativeVectorOfNode((activeNode+1)%nodes.Count);

        float newSteerA = (rv3a.x / rv3a.magnitude) * maxSteerAngle;
        //float newSteerB = (rv3b.x / rv3b.magnitude) * maxSteerAngle;


        //float distanceA = Vector3.Distance(nodes[activeNode].transform.position, transform.position);
        //float distanceB = Vector3.Distance(nodes[(activeNode + 1) % nodes.Count].transform.position, transform.position);

        //float distanceSum = distanceA + distanceB;

        float newSteer = newSteerA;

        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;

        Vector3 node1 = nodes[activeNode].transform.position;
        //Vector3 node2 = nodes[(activeNode + 1) % nodes.Count].transform.position;

        //Vector3 fromTo = node2 - node1;

        float currentDistance = Vector3.Distance(transform.position, node1);

        //float angle = Vector3.Angle(node2, fromTo);

        //maxSteerAngle = 0 torque   +5
        //0             = 15 torque  +5

        float newTorque = ((currentDistance/startDistance))*100 + 5 + 10* UnityEngine.Random.Range(0,1);

        print(currentDistance);

        drive(newTorque);
    }


    private Vector3 getRelativeVectorOfNode(int i)
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[i].position);


        relativeVector = relativeVector / relativeVector.magnitude;

        return relativeVector;
    }
}
