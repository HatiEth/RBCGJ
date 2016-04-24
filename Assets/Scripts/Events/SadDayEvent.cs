using UnityEngine;
using System.Collections;

public class SadDayEvent {
	public delegate void SadDayAction(bool isSadDay);
	public static event SadDayAction OnSadDay;

	public static void Send(bool isSadDay)
	{
		if (OnSadDay != null) OnSadDay(isSadDay);
	}
}
