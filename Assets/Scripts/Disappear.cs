using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    private const float INITIAL_TIME = 2.0f;
    private float targetTime = INITIAL_TIME;
    private bool hasEntered = false;

    void Update()
    {
        if(hasEntered)
        {
            targetTime -= Time.deltaTime;
            if(targetTime <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }


    public void HasEntered()
    {
        hasEntered = true;
    }


    public void ResetCounter()
    {
        targetTime = INITIAL_TIME;
        hasEntered = false;
    }
}
