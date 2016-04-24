using UnityEngine;
using System.Collections;

public class GameOverEvent {
	public delegate void _Action(bool won);
	public static event _Action On;

	public static void Send(bool won)
	{
		if (On != null) On(won);
	}
}
