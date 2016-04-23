using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class MenuRiegelOnMove : MonoBehaviour, IMoveHandler {
	public void OnMove(AxisEventData eventData)
	{
		Debug.Log(this.gameObject);
	}
}
