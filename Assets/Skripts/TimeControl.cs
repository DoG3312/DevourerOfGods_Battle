using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public bool isFrizingTime = false;

    public void TimeFrizing()
    {
        if (isFrizingTime)
        {
            Time.timeScale = 1.0f;
            isFrizingTime = false;
        }
        else
        {
            Time.timeScale = 0.25f;
            isFrizingTime = true;
        }
    }
}
