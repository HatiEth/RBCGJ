using UnityEngine;
using System.Collections;

public class SadDayEvent {
	public delegate void SadDayAction();
	public static event SadDayAction OnSadDay;

	public static void Send()
	{
		if (OnSadDay != null) OnSadDay();
	}
}
