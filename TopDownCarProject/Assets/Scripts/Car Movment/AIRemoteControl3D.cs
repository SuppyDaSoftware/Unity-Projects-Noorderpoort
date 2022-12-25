using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRemoteControl3D : MonoBehaviour
{
    [SerializeField] private Transform targetPositionTransform;

    BasicCarController basicCarController;


    private void Awake()
    {
        basicCarController = GetComponent<BasicCarController>();
        targetPositionTransform = basicCarController.checkPoints[0].transform;
    }


    void FixedUpdate()
    {
        Vector3 targetPosition = targetPositionTransform.position;
        float forwards = 0;
        float turn = 0;

        Vector3 directionToTarget = (targetPosition - transform.position);
        float dot = Vector3.Dot(transform.forward, directionToTarget);

        if (dot > 0)
        {
            forwards = 1;
        }
        else if (dot < 0)
        {
            forwards = -1;
        }

        float angle = Vector3.SignedAngle(transform.forward, directionToTarget, Vector3.up);

        if (angle > 5)
        {
            turn = 1;
        }
        else if (angle < -5)
        {
            turn = -1;
        }
        


        basicCarController.ChangeSpeed(forwards);
        basicCarController.Turn(turn);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            targetPositionTransform = basicCarController.NextCheckpoint().transform;
        }
    }
}
