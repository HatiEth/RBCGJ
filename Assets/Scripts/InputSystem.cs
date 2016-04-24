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
		if (KassenEvent.isRunning())
		{
			KassenInput();
			return;
		}

		if (Input.GetButtonDown("ActionLeft"))
		{
			if (motherBehaviour.handsFree() && motherBehaviour.quicktimeEvent.running)
			{
				motherBehaviour.takeFromChild();
			}
			else if (!motherBehaviour.handsFree())
			{
				motherBehaviour.throwAway();
			}
		}
		else if (Input.GetButtonDown("ActionUp") && !motherBehaviour.handsFree())
		{
			motherBehaviour.giveToChild();
		}
		else if (Input.GetButtonDown("ActionDown"))
		{
			if (motherBehaviour.handsFree())
			{
				motherBehaviour.checkChildItem();
			}
			else if (motherBehaviour.inspecting)
			{
				motherBehaviour.putIntoCart();
			}
			else
			{
				motherBehaviour.inspect();
			}
		}

		IItem item = null;

		if (motherBehaviour.handsFree())
		{
			if (Input.GetButtonDown("takeOben"))
			{
				item = takeControl.take(Enums.TakeType.Oben);
			}
			else if (Input.GetButtonDown("takeMitte"))
			{
				item = takeControl.take(Enums.TakeType.Mitte);
			}
			else if (Input.GetButtonDown("takeUnten"))
			{
				item = takeControl.take(Enums.TakeType.Unten);
			}
		}
		if (item != null)
			motherBehaviour.takeFromShelf(item);
	}

	private void KassenInput()
	{
		if (Input.GetButtonDown("ActionLeft"))
		{
			motherBehaviour.throwAway();
			KassenEvent.grabNextItem();
		}
		else if (Input.GetButtonDown("ActionDown"))
		{
			motherBehaviour.approveKasse();
			KassenEvent.grabNextItem();
		}
	}
}
