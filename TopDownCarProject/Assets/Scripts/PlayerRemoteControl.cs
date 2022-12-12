using UnityEngine;

public class PlayerRemoteControl : MonoBehaviour
{
    VroomVroomController basicCarController;
    public float forwards;
    public float turn;

    public Rigidbody rb;
    //[Header("Checkpoint Checker")]
    //public GameObject[] checkPoints;
    //public GameObject currentCheckPoint;
    //public int checkPointCounter = 0;
    void Awake()
    {
        basicCarController = GetComponent<VroomVroomController>();
        // NextCheckPoint();
    }
    void Update()
    {

        forwards = Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") != 0)
        {
            turn = Input.GetAxis("Horizontal");
        }

        basicCarController.verticalInput = forwards;
        basicCarController.horizontalInput = turn;
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
