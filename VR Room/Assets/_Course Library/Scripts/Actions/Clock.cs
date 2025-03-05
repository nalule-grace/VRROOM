using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;


    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now; // Get real-world time

        float hourAngle = (currentTime.Hour % 12) * 30f + (currentTime.Minute * 0.5f); // 360° / 12 hours
        float minuteAngle = currentTime.Minute * 6f; // 360° / 60 minutes
        float secondAngle = currentTime.Second * 6f; // 360° / 60 seconds

        hourHand.localRotation = Quaternion.Euler(0, 0, -hourAngle);
        minuteHand.localRotation = Quaternion.Euler(0, 0, -minuteAngle);

        if (secondHand != null)
            secondHand.localRotation = Quaternion.Euler(0, 0, -secondAngle);
    }
}
