using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LapScript : MonoBehaviour
{
    public Text LapNumber;
    public int Lap = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddLap();
        }
    }
    private void AddLap()
    {
        Lap++;
        LapNumber.text = Lap.ToString();
        if(Lap > 3)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}