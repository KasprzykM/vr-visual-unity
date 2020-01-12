using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    private const float INITIAL_TIME = 1.5f;
    private float targetTime = INITIAL_TIME;
    private bool hasEntered = false;
    private float thrust = 1.0f;

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

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = RandomVector(0f, 2f);
    }

    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
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
