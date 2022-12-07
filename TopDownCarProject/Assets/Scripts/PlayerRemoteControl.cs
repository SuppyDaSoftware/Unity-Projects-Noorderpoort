using UnityEngine;

public class PlayerRemoteControl : MonoBehaviour
{
    BasicCarController basicCarController;
    public float forwards;
    public float turn;

    //[Header("Checkpoint Checker")]
    //public GameObject[] checkPoints;
    //public GameObject currentCheckPoint;
    //public int checkPointCounter = 0;
    void Awake()
    {
        basicCarController = GetComponent<BasicCarController>();
        // NextCheckPoint();
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
    //public GameObject NextCheckPoint()
    //{
    //    checkPointCounter++;
    //    if (checkPointCounter == checkPoints.Length)
    //    {
    //        checkPointCounter = 1;
    //    }
    //    currentCheckPoint = checkPoints[checkPointCounter];
    //    return currentCheckPoint;
    //}
}
