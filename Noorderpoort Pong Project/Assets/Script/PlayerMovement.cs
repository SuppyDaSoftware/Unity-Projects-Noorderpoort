using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public int playerNumber = 1;
    public int playerSpeed = 7;

    // Update is called once per frame
    void Update()
    {
        //Player collision movement to stop when it hits the border
        

        //Player 1 movement
        if (playerNumber == 1)
        {
            transform.Translate(new Vector3(0, Input.GetAxis("Player1") * Time.deltaTime * playerSpeed));
        }
        //Player 2 movement
        if (playerNumber == 2)
        {
            transform.Translate(new Vector3(0, Input.GetAxis("Player2") * Time.deltaTime * playerSpeed));
        }
        
    }
}
