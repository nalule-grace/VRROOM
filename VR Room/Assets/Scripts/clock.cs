using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject hourHand;
    public GameObject minuteHand;
    public GameObject secondHand;
    private int previousSecond;

    void Start()
    {
        // Initialize the last second with the current system second
        previousSecond = DateTime.Now.Second;
    }

    void Update()
    {
        // Continuously update the clock hands
        SyncClockHands();
    }

    // Method to update the positions of the clock hands
    private void SyncClockHands()
    {
        int currentSecond = DateTime.Now.Second;

        if (currentSecond != previousSecond)
        {
            // Update the second hand rotation
            float secondRotation = (currentSecond / 60f) * 360f;
            secondHand.transform.rotation = Quaternion.Euler(secondRotation, 0, 0);

            // Update the minute hand rotation
            int currentMinute = DateTime.Now.Minute;
            float minuteRotation = (currentMinute / 60f) * 360f;
            minuteHand.transform.rotation = Quaternion.Euler(minuteRotation, 0, 0);

            // Update the hour hand rotation
            int currentHour = DateTime.Now.Hour % 12;
            float hourRotation = (currentHour + (currentMinute / 60f)) * 30f;
            hourHand.transform.rotation = Quaternion.Euler(hourRotation, 0, 0);

            // Store the current second to detect changes in the next frame
            previousSecond = currentSecond;
        }
    }
}
