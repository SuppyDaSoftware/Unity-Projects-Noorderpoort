using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Fracture : MonoBehaviour
{

    public GameObject fractured;
    GameObject fractureContainer;
    public float breakForce;

    public bool TimerOn = false;
    public float timerLeft;
    void Awake()
    {
        //BreakTheThing();
        //TimerOn = true;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    BreakTheThing();
        //}        
    }

    void BreakTheThing()
    {
        fractureContainer = Instantiate(fractured, transform.position, transform.rotation);
        foreach (Rigidbody rb in fractured.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
            rb.AddForce(force);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("AI"))
        {

            BreakTheThing();
        }
    }
}
