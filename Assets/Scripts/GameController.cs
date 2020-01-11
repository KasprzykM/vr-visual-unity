using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    int playerScore = 0;
    private const int INITIAL_CUBE_AMOUNT = 5;
    private const float MIN_RANDOM_POS = -10.0f;
    private const float MAX_RANDOM_POS =  10.0f;

    private const float MIN_RANDOM_TIME = 2.5f;
    private const float MAX_RANDOM_TIME = 5.0f;
    float targetTime = MAX_RANDOM_TIME;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< INITIAL_CUBE_AMOUNT; i++)
        {
            CreateCube();
        }
    }

    private void CreateCube()
    {
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCube.AddComponent<EventTrigger>();
        newCube.AddComponent<Disappear>();
        EventTrigger evtTrigger = newCube.GetComponent<EventTrigger>();

        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener(
            (data) => { newCube.GetComponent<Disappear>().HasEntered(); });

        EventTrigger.Entry pointerExit = new EventTrigger.Entry();
        pointerExit.eventID = EventTriggerType.PointerExit;
        pointerExit.callback.AddListener(
            (data) => { newCube.GetComponent<Disappear>().ResetCounter(); });

        evtTrigger.triggers.Add(pointerExit);
        evtTrigger.triggers.Add(pointerEnter);

        newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();

        newCube.transform.position = new Vector3(Random.Range(MIN_RANDOM_POS, MAX_RANDOM_POS), Random.Range(0, MAX_RANDOM_POS), Random.Range(MIN_RANDOM_POS, MAX_RANDOM_POS));
    }
    
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            CreateCube();
            targetTime = Random.Range(MIN_RANDOM_TIME, MAX_RANDOM_TIME);
        }
    }
    
}
