using UnityEngine;
using System.Collections;

public static class LinkshaenderStore {
	public delegate void ChangedLinkshaender();
	public static event ChangedLinkshaender OnChange;

	public static void Toggle() { Enabled = !Enabled; if (OnChange != null) OnChange(); }

	public static bool Enabled = false;
}


public class Linkshaender : MonoBehaviour {

	public bool FreedomX = true;
	public bool FreedomY = false;
	// Use this for initialization
	void Start()
	{
		LinkshaenderStore.OnChange += ScaleBasedOnMode;
		ScaleBasedOnMode();
	}

	public void OnDestroy()
	{
		LinkshaenderStore.OnChange -= ScaleBasedOnMode;
	}

	public void ToggleLefthandMode()
	{
		LinkshaenderStore.Toggle();
	}


	void ScaleBasedOnMode()
	{
		if (LinkshaenderStore.Enabled)
		{
			var scale = transform.localScale;
			if (FreedomX)
				scale.x = -Mathf.Abs(scale.x);
			if (FreedomY)
				scale.y = -Mathf.Abs(scale.y);
			transform.localScale = scale;
		}
		else
		{
			var scale = transform.localScale;
			if (FreedomX)
				scale.x = +Mathf.Abs(scale.x);
			if (FreedomY)
				scale.y = +Mathf.Abs(scale.y);
			transform.localScale = scale;
		}
	}
}
