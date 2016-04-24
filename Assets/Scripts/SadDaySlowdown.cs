using UnityEngine;
using System.Collections;

public class SadDaySlowdown : MonoBehaviour {

	public float m_fSlowdown = 0.1f;
	private UnityStandardAssets.ImageEffects.Grayscale grayscale;

	// Use this for initialization
	void Start () {
		grayscale = GetComponent<UnityStandardAssets.ImageEffects.Grayscale>();
		SadDayEvent.OnSadDay += StartSlowdown;

	}

	void StartSlowdown()
	{
		StartCoroutine(Slowdown());
	}
	
	// Update is called once per frame
	void OnDestroy () {
		SadDayEvent.OnSadDay -= StartSlowdown;
	}

	IEnumerator Slowdown()
	{
		while(Time.timeScale > 0f)
		{
			Time.timeScale = Mathf.Clamp(Time.timeScale - m_fSlowdown * Time.fixedDeltaTime, 0f , 1f);
			grayscale.scale = 1f - Time.timeScale;
			yield return null;
		}

		float Alpha = 0f;
		while (Alpha < 1f)
		{
			Alpha += Time.fixedDeltaTime;
			grayscale.rampOffset = -Alpha;
			yield return null;
		}
		grayscale.rampOffset = -1f;

		GameOverEvent.Send();
		grayscale.rampOffset = 0f;
	}
}
