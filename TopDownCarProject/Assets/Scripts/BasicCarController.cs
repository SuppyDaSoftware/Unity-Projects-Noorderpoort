using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCarController : MonoBehaviour
{
    [Header("Basic Car Variables")]
    public float maxSpeed;
    public float turnSpeed;
    public float accel;
    public float speed;

    [Header("Level Variables")]
    //we maken een array; een lijst van gameobjects
    public GameObject[] checkPoints;
    public GameObject currentCheckPoint;
    public int checkPointCounter = 0;

    public void ChangeSpeed(float throttle)
    {
        if (throttle != 0)
        {
            speed = speed + accel * throttle * Time.deltaTime;
            speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
        }
        else
        {
            speed = Mathf.Lerp(speed, 0, Time.deltaTime);
        }

        Vector3 velocity = Vector3.forward * speed;
        transform.Translate(velocity * Time.deltaTime, Space.Self);
    }

    public void Turn(float direction)
    {
        //transform.Rotate(0, 0, direction * turnSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0,1,0) * direction * turnSpeed * Time.deltaTime, Space.Self);
    }
    public GameObject NextCheckPoint()
    {
        checkPointCounter++;
        if (checkPointCounter > checkPoints.Length - 1)
        { 
            checkPointCounter= 0;
        }
        currentCheckPoint= checkPoints[checkPointCounter];
        return currentCheckPoint;
    }
}
