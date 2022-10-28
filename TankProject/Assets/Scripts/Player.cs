using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNumber;
    public int maxHealth = 100;
    public int currentHealth;

    bool isPlayerTurn = false;

    public Healthbar healthbar;

    void Start()
    {
       // currentHealth = maxHealth;
       // healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerTurn == true)
        {
            takeDamage(20);
            Invoke("SwapTurn", 0.1f);
        }
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;

        //healthbar.SetHealth(currentHealth);
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