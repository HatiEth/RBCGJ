using UnityEngine;
using System.Collections;

public class InputSystem : MonoBehaviour {
    //Flankenabfrage?
    bool rightPressed;
    bool upPressed;
    bool pressedDown;

    MotherBehaviour motherBehaviour;
    TakeControl takeControl;

    // Use this for initialization
    void Start () {
        motherBehaviour = GetComponent<MotherBehaviour>();
        takeControl = GetComponent<TakeControl>();
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown("ActionRight"))
        {
            motherBehaviour.throwAway();
        }
        else if(Input.GetButtonDown("ActionUp"))
        {
            motherBehaviour.giveToChild();
        }
        else if (Input.GetButtonDown("ActionDown"))
        {
            if(motherBehaviour.holdingItem == null)
                motherBehaviour.inspect();
            //else Leg innen Wagen, wenn man sich schon etwas anschaut
        }
        IItem item = null;
        if (Input.GetButtonDown("takeObenLinks"))
        {
            item = takeControl.take(Enums.TakeType.ObenLinks);
        }
        else if(Input.GetButtonDown("takeObenRechts"))
        {
            item = takeControl.take(Enums.TakeType.ObenRechts);
        }
        else if (Input.GetButtonDown("takeUntenLinks"))
        {
            item = takeControl.take(Enums.TakeType.UntenLinks);
        }
        else if(Input.GetButtonDown("takeUntenRechts"))
        {
            item = takeControl.take(Enums.TakeType.UntenRechts);
        }

        if (item != null)
            motherBehaviour.holdingItem = item;
	}
}
