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
	void Start()
	{
		motherBehaviour = GetComponent<MotherBehaviour>();
		takeControl = GetComponent<TakeControl>();
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetButtonDown("ActionRight"))
		{
			motherBehaviour.throwAway();
		}
		else if (Input.GetButtonDown("ActionUp"))
		{
			motherBehaviour.giveToChild();
		}
		else if (Input.GetButtonDown("ActionDown"))
		{
			if (motherBehaviour.holdingItem == null)
			{
				motherBehaviour.inspect();
			}
			else
			{
				StoreItemEvent.Send(motherBehaviour.holdingItem);
				motherBehaviour.holdingItem = null;
			}
		}
		IItem item = null;
		if (Input.GetButtonDown("takeObenLinks"))
		{
            item = takeControl.take(Enums.TakeType.Oben);
		}
		else if (Input.GetButtonDown("takeObenRechts"))
		{
            item = takeControl.take(Enums.TakeType.Mitte);
		}
		else if (Input.GetButtonDown("takeUntenLinks"))
		{
            item = takeControl.take(Enums.TakeType.Unten);
		}

		/*
		if (item != null)
			motherBehaviour.holdingItem = item;
		*/
	}
}
