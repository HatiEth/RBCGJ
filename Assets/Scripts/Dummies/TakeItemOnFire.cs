using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(Regalfach))]
public class TakeItemOnFire : MonoBehaviour {

	private Regalfach Fach;

	void Start()
	{
		Fach = GetComponent<Regalfach>();

	}

#if UNITY_EDITOR
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F))
		{
			IItem item = Fach.GrabItem();
			GrabItemEvent.Send(item);
		}
	}
#endif
}
