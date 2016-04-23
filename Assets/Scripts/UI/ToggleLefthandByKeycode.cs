using UnityEngine;
using System.Collections;

public class ToggleLefthandByKeycode : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.L))
		{
			LinkshaenderStore.Toggle();
		}
	}
}
