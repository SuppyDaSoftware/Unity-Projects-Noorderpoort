using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField]
    Transform barrelRotator;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    GameObject bulletToFire;

    public float MoveSpeed;

    public int PlayerNumber;
    public int shootingForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerNumber == 1)
        {
            barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Vertical") * Time.deltaTime);
        }
        if (PlayerNumber == 2)
        {
            barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Vertical") * -Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Shoot bullet with added force
            GameObject b = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            if (PlayerNumber == 1)
            {
                b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.right * shootingForce, ForceMode2D.Impulse);
            }
            if (PlayerNumber == 2)
            {
                b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.right * -1 * shootingForce, ForceMode2D.Impulse);
            }
        }
        if (PlayerNumber == 1){ }

        if (Input.GetKeyDown(KeyCode.O))
        {
            IncreasePower();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            DecreasePower();
        }

        //Move tank left and right
        transform.Translate(Vector2.right * Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime);
    }
    public void IncreasePower()
    {
        shootingForce++;
    }

    public void DecreasePower()
    {
        shootingForce--;
    }
}