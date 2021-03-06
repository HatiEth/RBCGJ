using UnityEngine;
using System.Collections;

public class SadDaySlowdown : MonoBehaviour {

	public float m_fSlowdown = 0.1f;
	private UnityStandardAssets.ImageEffects.Grayscale grayscale;

	// Use this for initialization
	void Start()
	{
		grayscale = GetComponent<UnityStandardAssets.ImageEffects.Grayscale>();
		SadDayEvent.OnSadDay += StartSlowdown;

	}

	void StartSlowdown(bool isSadDay)
	{
		StartCoroutine(Slowdown(isSadDay));
	}

	// Update is called once per frame
	void OnDestroy()
	{
		SadDayEvent.OnSadDay -= StartSlowdown;
	}

	IEnumerator Slowdown(bool isSadDay)
	{
		if (isSadDay)
		{
			while (Time.timeScale > 0f)
			{
				Time.timeScale = Mathf.Clamp(Time.timeScale - m_fSlowdown * Time.fixedDeltaTime, 0f, 1f);
				grayscale.scale = 1f - Time.timeScale;
				yield return null;
			}
		}


		float Alpha = 0f;
		while (Alpha < 1f)
		{
			Alpha += Time.fixedDeltaTime;
			if(isSadDay)
				grayscale.rampOffset = -Alpha;
			else
				grayscale.rampOffset = Alpha;
			yield return null;
		}
		grayscale.rampOffset = isSadDay ? -1f : 0f;

		GameOverEvent.Send(!isSadDay);
		grayscale.rampOffset = 0f;
		grayscale.scale = 0f;
	}
}
