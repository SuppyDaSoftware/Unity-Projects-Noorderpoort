using UnityEngine;

public class PlayerRemoteControl : MonoBehaviour
{
    BasicCarController playerInput;
    public float forwards;
    public float turn;

    public Rigidbody rb;
    void Awake()
    {
        playerInput = GetComponent<BasicCarController>(); 
    }
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            forwards = Input.GetAxisRaw("Vertical");
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            turn = Input.GetAxisRaw("Horizontal");
        }

        playerInput.ChangeSpeed(forwards);
        playerInput.Turn(turn);
    }

}
