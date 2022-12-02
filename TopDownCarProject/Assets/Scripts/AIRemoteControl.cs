using UnityEngine;

public class AIRemoteControl : MonoBehaviour
{
    CarMovementController CarMovement;

    public enum AIMode {followPlayer, followWaypoints};
    public AIMode aiMode;

    Vector3 targetPos = Vector3.zero;
    Transform targetTransform = null;

    void Awake()
    {
        CarMovement = GetComponent<CarMovementController>();
    }

    void FixedUpdate()
    {
        Vector3 input = Vector3.zero;

        switch (aiMode)
        {
            case AIMode.followPlayer:
                FollowPlayer();
                break;
        }
        input.x = TurnToTarget();
        input.z = 1.0f;
        //Send Input to car movement
        CarMovement.SetInput(input);
    }
    void FollowPlayer()
    {
        if (targetTransform != null)
        {
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (targetTransform != null)
        {
            targetPos = targetTransform.position;
        }
    }
    float TurnToTarget()
    {
        Vector3 vectorToTarget = targetPos - transform.position;
        vectorToTarget.Normalize();

        //Calculate the distance
        float angleToTarget = Vector3.SignedAngle(transform.forward, vectorToTarget, new Vector3(0,0,1));
        angleToTarget *= -1;

        float steerAmount = angleToTarget / 45.0f;

        steerAmount = Mathf.Clamp(steerAmount, -1.0f, 1.0f);

        return steerAmount;
    }
}
