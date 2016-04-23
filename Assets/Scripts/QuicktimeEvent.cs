using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuicktimeEvent : MonoBehaviour {

    private Slider slider;

    public bool running;
    private IItem foughtItem;

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

    public void startEvent(float startingValue, IItem item)
    {
        running = true;
        slider.enabled = true;
        foughtItem = item;
        currentValue = startingValue;
    }

    public IItem finishEvent()
    {
        running = false;
        slider.enabled = false;
        IItem tmp = foughtItem;
        foughtItem = null;
        return tmp;
    }

    private IItem throwCheck()
    {
        if(currentValue <= .05f)
        {
            return finishEvent();
        }

        return null;

    }

    public IItem influenceEvent(float value)
    {
        currentValue = Mathf.Clamp01(currentValue + value);
        return throwCheck();
    }

    public IItem tryToInspect()
    {
        //Befindet es sich in der entsprechenden Zone?
        if (Mathf.Abs(currentValue - targetSpot_value) <= targetSpot_tolerance)
        {
            return finishEvent();
        }

        return null;
    }
}
