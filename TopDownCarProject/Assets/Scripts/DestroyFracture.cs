using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFracture : MonoBehaviour
{
    public GameObject fracture;
    GameObject fractureContainer;

    public bool TimerOn = false;
    public float timerLeft;

    private void Awake()
    {
        TimerOn= true;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (timerLeft > 0)
            {
                timerLeft -= Time.deltaTime;
                updateTimer(timerLeft);
            }
            else
            {
                //Debug.Log("Destroying Objects");
                timerLeft = 0;
                TimerOn = false;
                Destroy(gameObject);
            }
        }

    }
    public void updateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);

        Debug.Log("Amount of seconds left " + seconds);
    }
}
