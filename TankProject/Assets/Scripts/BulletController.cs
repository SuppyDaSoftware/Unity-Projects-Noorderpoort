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
        GameObject.Find("GameManager").GetComponent<TurnManager>().SwapTurn();
        Destroy (gameObject);
    }
}
