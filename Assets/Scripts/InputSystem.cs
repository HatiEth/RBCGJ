using UnityEngine;
using System.Collections;

public class InputSystem : MonoBehaviour {
    //Flankenabfrage?
    bool rightPressed;
    bool upPressed;
    bool pressedDown;

    MotherBehaviour motherBehaviour;

    // Use this for initialization
    void Start () {
        motherBehaviour = (MotherBehaviour) FindObjectOfType(typeof(MotherBehaviour));
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
            motherBehaviour.inspect();
        }

        if (Input.GetButtonDown("takeObenLinks"))
        {
            motherBehaviour.take(Enums.TakeType.ObenLinks);
        }
        else if(Input.GetButtonDown("takeObenRechts"))
        {
            motherBehaviour.take(Enums.TakeType.ObenRechts);
        }
        else if (Input.GetButtonDown("takeUntenLinks"))
        {
            motherBehaviour.take(Enums.TakeType.UntenLinks);
        }
        else if(Input.GetButtonDown("takeUntenRechts"))
        {
            motherBehaviour.take(Enums.TakeType.UntenRechts);
        }

	}
}
