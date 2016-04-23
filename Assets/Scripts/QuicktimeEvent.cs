using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuicktimeEvent : MonoBehaviour {

    private Slider slider;

    public bool running;

    //Current Value between 0 and 1
    private float currentValue;

    [SerializeField]
    private float targetSpot_value;
    [SerializeField]
    private float targetSpot_tolerance;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        if(running)
            slider.normalizedValue = currentValue;
	}

    public void startEvent(float startingValue)
    {
        running = true;
        slider.enabled = true;
        currentValue = startingValue;
    }

    public bool finishEvent()
    {
        running = false;
        slider.enabled = false;
        return true;
    }

    private bool throwCheck()
    {
        if(currentValue <= .05f)
        {
            return finishEvent();
        }

        return false;

    }

    public bool influenceEvent(float value)
    {
        currentValue = Mathf.Clamp01(currentValue + value);
        return throwCheck();
    }

    public bool tryToInspect()
    {
        //Befindet es sich in der entsprechenden Zone?
        if (Mathf.Abs(currentValue - targetSpot_value) <= targetSpot_tolerance)
        {
            return finishEvent();
        }

        return false;
    }
}
