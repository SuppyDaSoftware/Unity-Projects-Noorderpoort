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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Rotate Barrel
        barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Vertical")* Time.deltaTime);

        //Fire Bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * 10, ForceMode2D.Impulse);
        }
    }
}