using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckpointManager : MonoBehaviour
{
    public UnityEvent CheckpointReached;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "CarBody")
        {
            CheckpointReached.Invoke();
        }
    }
}
