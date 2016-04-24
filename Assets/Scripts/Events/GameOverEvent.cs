using UnityEngine;
using System.Collections;

public class GameOverEvent {
	public delegate void _Action();
	public static event _Action On;

	public static void Send()
	{
		if (On != null) On();
	}
}
