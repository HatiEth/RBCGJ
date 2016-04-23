using UnityEngine;
using System.Collections;
using System;

public class LinkshaenderRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LinkshaenderStore.OnChange += RotateBasedOnMode;
		//RotateBasedOnMode();
	}

	void OnDestroy()
	{
		LinkshaenderStore.OnChange -= RotateBasedOnMode;
	}

	private void RotateBasedOnMode()
	{
		if (LinkshaenderStore.Enabled)
		{
			var rot = transform.rotation;
			rot = Quaternion.Euler(0f, -180f, 0f) * rot;
			transform.rotation = rot;
		}
		else
		{
			var rot = transform.rotation;
			rot = Quaternion.Euler(0f, -180f, 0f) * rot;
			transform.rotation = rot;
		}

	}
}
