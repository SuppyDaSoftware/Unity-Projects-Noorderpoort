using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedoCount : MonoBehaviour
{
    public Rigidbody playerCar;
    public float maxSpeed;
    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;

    [Header("UO")] 
    public TextMeshProUGUI speedLable;
    public RectTransform needle;
    public float speed = 0.0f;
    // Update is called once per frame
    void Update()
    {
        speed = playerCar.velocity.magnitude * 0.5f;

        if (speedLable != null)
        {
            speedLable.text = ((int)speed + "KM/H");
        }

        if (needle != null)
        {
            needle.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
        }
    }
}
