using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //Bullet Time to live
   public float bulletTtl = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletTtl -= Time.deltaTime;
        if (bulletTtl <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Add score to collision
        if (collision.gameObject.CompareTag("Player"))
        {
   
            GameObject.Find("Canvas").GetComponent<ScoreScript>().AddP2Score();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            GameObject.Find("Canvas").GetComponent<ScoreScript>().AddP1Score();
        }

        //Swap player turn
        GameObject.Find("GameManager").GetComponent<TurnManager>().SwapTurn();

        //Delete bullet
        Destroy (gameObject);
    }
}
