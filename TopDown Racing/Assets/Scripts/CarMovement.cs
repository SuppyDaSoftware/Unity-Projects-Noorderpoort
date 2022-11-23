using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [Header("Basic car movement")]
    [SerializeField]
    public float driftForce;
    [SerializeField]
    public float speedForce;
    [SerializeField]
    public float turningForce;
    [SerializeField]
    public float maxSpeed;

    float accelerationForce = 0;
    float steeringForce = 0;
    float rotationAngle = 0;

    [Header("Speed in velocity")]
    public float velocityVsUp = 0;

    Rigidbody2D carRB;

    //Get the script to auto apply Rigidbody to Car
    void Awake()
    {
        carRB = GetComponent<Rigidbody2D>();
    }

    //Apply the force of physics without framerate limit
    private void FixedUpdate()
    {
        ApplyEngineForce();

        KillOrthagonalVelocity();

        ApplySteering();
    }

    void ApplyEngineForce()
    {
        //Calculate how fast as frick we go boi
        velocityVsUp = Vector2.Dot(transform.up, carRB.velocity);

        //Limit the speed the Car can go
        if (velocityVsUp > maxSpeed && accelerationForce > 0)
        {
            return;
        }

        //Limit the speed by 50% as its in reverse
        if (velocityVsUp < -maxSpeed * 0.5f && accelerationForce < 0)
        {
            return;
        }
        //Limit the speed while in any direction
        if (carRB.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationForce > 0)
        {
            return;
        }
        //Apply a drag that will slow down Car
        if (accelerationForce == 0)
        {
            carRB.drag = Mathf.Lerp(carRB.drag, 2.0f, Time.fixedDeltaTime * 2);
        }
        else
        {
            carRB.drag = 0;
        }

        //Create force for the engine
        Vector2 engineForceVector = transform.up * accelerationForce * speedForce;

        //Apply force to push the car forward
        carRB.AddForce(engineForceVector, ForceMode2D.Force);
    }
 
    void ApplySteering()
    {
        float minSpeedBeforeAllowedTurning = (carRB.velocity.magnitude / 8);
        minSpeedBeforeAllowedTurning = Mathf.Clamp01(minSpeedBeforeAllowedTurning);

        //Adjust angle by rotation from input
        rotationAngle -= steeringForce * turningForce * minSpeedBeforeAllowedTurning;

        //Apply steering by rotating the Car
        carRB.MoveRotation(rotationAngle);
    }
    //Kill off some force when turning
    void KillOrthagonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRB.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRB.velocity, transform.right);

        carRB.velocity = forwardVelocity + rightVelocity * driftForce;
    }
    public void SetInput(Vector2 inputVector)
    {
        steeringForce = inputVector.x;
        accelerationForce = inputVector.y;
    }
}
