using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class BasicCarController : MonoBehaviour
{

    [FormerlySerializedAs("KMH")] [Header("Basic Car Variables")]
    public float maxSpeed = 100;
    public float turnSpeed = 25;
    public float accel = 2.5f;
    public float speed = 0;
    [SerializeField]    
    Rigidbody rb;
    bool isGrounded;

    [Header("Level Variables")]
    public GameObject[] checkPoints;
    public GameObject currentCheckPoint;
    public int checkPointCounter = 0;
    public LayerMask GroundLayer;
    float GroundedDistance = 1;
    RaycastHit hit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private bool HandleIsGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, GroundedDistance, GroundLayer);
        return isGrounded;
    }
    public void FixedUpdate()
    {
        if (!HandleIsGrounded())
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 1.0f * Time.deltaTime);
        }
    }

    public void ChangeSpeed(float throttle)
    {
        float forwardSpeed = Vector3.Dot(transform.forward, rb.velocity);

        if (forwardSpeed < maxSpeed && forwardSpeed > -maxSpeed && isGrounded)
        {

            if (throttle != 0)
            {
                speed = speed + accel * throttle * Time.deltaTime;
                speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
                rb.drag = Mathf.Lerp(rb.drag, 0, Time.deltaTime);
            }
            else
            {
                speed = Mathf.Lerp(speed, 0, Time.deltaTime);
                rb.drag = Mathf.Lerp(rb.drag, 10, Time.deltaTime);
            }

            Vector3 velocity = Vector3.forward * speed;
            rb.AddRelativeForce(velocity, ForceMode.Acceleration);
        }
    }
    public void Turn(float direction)
    {
        transform.Rotate(0, direction * turnSpeed * Time.deltaTime, 0);
    }
    public GameObject NextCheckpoint()
    {
        checkPointCounter++;
        print(checkPointCounter);
        if (checkPointCounter > checkPoints.Length - 1)
        {
            checkPointCounter = 0;
        }
        currentCheckPoint = checkPoints[checkPointCounter];
        return currentCheckPoint;

    }
}
