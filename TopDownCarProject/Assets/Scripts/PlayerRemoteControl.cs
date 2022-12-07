using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRemoteControl : MonoBehaviour
{
    BasicCarController basicCarController;
    public float forwards;
    public float turn;
    void Awake()
    {
        basicCarController = GetComponent<BasicCarController>();
    }
    void Update()
    {

        forwards = Input.GetAxis("Vertical");
      
        if (Input.GetAxis("Horizontal") != 0)
        {
            turn = Input.GetAxis("Horizontal");
        }

        basicCarController.ChangeSpeed(forwards);
        basicCarController.Turn(turn);
    }
}
