using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownObject : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 3f;

    public void Start()
    {
        currentTime = startingTime;
    }


    public void Countdown()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    public void Update()
    {
        Countdown();
    }
}
