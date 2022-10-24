using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNumber;
    [SerializeField]
    Material activeMat;
    [SerializeField]
    Material inactiveMat;
    bool isPlayerTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().material = inactiveMat;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space) && isPlayerTurn == true)
        {
            Invoke("SwapTurn", 0.1f);
        }
    } 
    void SwapTurn()
    {
        GameObject.Find("GameManager").GetComponent<TurnManager>().SwapTurn();
    }
    public void SetActive(bool b)
    {
        if (b == true)
        {
            isPlayerTurn = true;
            GetComponent<SpriteRenderer>().material = activeMat;
        }
        else
        {
            isPlayerTurn = false;
            GetComponent<SpriteRenderer>().material = inactiveMat;
        }
    }

}
