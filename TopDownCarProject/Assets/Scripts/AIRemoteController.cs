using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRemoteController : MonoBehaviour
{
    [Header("Input variables")]
    BasicCarController basicCarController;
    public float forwards = 1;
    public float turn = -1;

    [Header("Level variables")]
    private Transform targetPositionTransform;

    private void Awake()
    {
        basicCarController= GetComponent<BasicCarController>();
        targetPositionTransform = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void fixedUpdate()
    {
        basicCarController.ChangeSpeed(forwards);
        basicCarController.Turn(turn);
    }
}
