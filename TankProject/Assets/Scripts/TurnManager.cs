using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private int playerTurn = 1;
    public GameObject player1;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in players)
        {
            if (g.GetComponent<Player>().playerNumber == 1)
            {
                player1 = g;
            }
        }

        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject g in enemy)
        {
            if (g.GetComponent<Player>().playerNumber == 2)
            {
                player2 = g;
            }
        }
        // make the player active on its turn.
        Invoke("Init", 0.1f);
    }
    void Init()
    {
        if (playerTurn == 1)
        {
            Debug.Log("player1active");
            //Make player 1 active
            player1.GetComponent<TankController>().enabled = true;
            player2.GetComponent<TankController>().enabled = false;
        }
        else if (playerTurn == 2)
        {
            Debug.Log("player2active");
            //Make player 2 active
            player1.GetComponent<TankController>().enabled = false;
            player2.GetComponent<TankController>().enabled = true;
        }
    }
    public void SwapTurn()
    {        
        if (playerTurn == 1)
        {
            Debug.Log("It is Player 2's turn");
            playerTurn = 2;
            player1.GetComponent<TankController>().enabled = false;
            player2.GetComponent<TankController>().enabled = true;
        }
        else if (playerTurn == 2)
        {
            Debug.Log("It is Player 1's turn");
            playerTurn = 1;
            player1.GetComponent<TankController>().enabled = true;
            player2.GetComponent<TankController>().enabled = false;
        }
    }
}