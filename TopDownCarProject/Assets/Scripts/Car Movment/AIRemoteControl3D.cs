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
    }


    void FixedUpdate()
    {
        Vector3 targetPosition = targetPositionTransform.position;
        float forwards = 0;
        float turn = 0;

        Vector3 directionToTarget = (targetPosition - transform.position);
        float dot = Vector3.Dot(transform.forward, directionToTarget);

        float distance = Vector3.Distance(transform.position, targetPosition);
        float minDistance = 2;

        if (distance > minDistance)
        {

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
        } else {
            targetPositionTransform = basicCarController.NextCheckPoint().transform;
        }
        basicCarController.ChangeSpeed(forwards);
        basicCarController.Turn(turn);
    }
}
