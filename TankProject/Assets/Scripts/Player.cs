using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNumber;
    bool isPlayerTurn = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerTurn == true)
        {
            Invoke("SwapTurn", 0.1f);
        }
    }

    public void SwapTurn()
    {
        GameObject.Find("GameManager").GetComponent<TurnManager>().SwapTurn();
    }
    public void SetActive(bool b)
    {
        if (b == true)
        {
            isPlayerTurn = true;
            
        }
        else
        {
            isPlayerTurn = false;
         
        }
    }
}