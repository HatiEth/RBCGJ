using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GrabItemEvent {
	public delegate void GrabItemAction(IItem item);
	public static event GrabItemAction OnGrabItem;

	public static void Send(IItem item)
	{
		if (OnGrabItem != null) OnGrabItem(item);
	}
}
