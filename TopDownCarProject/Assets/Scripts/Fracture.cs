using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fracture : MonoBehaviour
{

    public GameObject fractured;
    public float breakForce;

    public void Awake()
    {
        //BreakTheThing();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            BreakTheThing();
        }
    }
    public void BreakTheThing()
    {
        Instantiate(fractured, transform.position, transform.rotation);
        foreach (Rigidbody rb in fractured.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
            rb.AddForce(force);
        }
        Destroy(gameObject);
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "testFracture")
        {
            BreakTheThing();
        }
    }
}
