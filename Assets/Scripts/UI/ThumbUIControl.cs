using UnityEngine;
using System.Collections;

public class ThumbUIControl : MonoBehaviour {

	public float UpRotationAngle = 0f;
	public float DownRotationAngle = 23f;

	public float PlaceDelayS = 0.5f;

	void Start()
	{
		StartCoroutine(ChangeThumb(UpRotationAngle, DownRotationAngle));
	}

	IEnumerator LiftThumb()
	{
		yield return StartCoroutine(ChangeThumb(DownRotationAngle, UpRotationAngle));
		yield return StartCoroutine(ChangeThumb(UpRotationAngle, DownRotationAngle));
	}

	IEnumerator ChangeThumb(float from, float to)
	{
		float Alpha = 0f;
		while(Alpha < 1f)
		{
			transform.localRotation = Quaternion.Slerp(Quaternion.Euler(from, 0f, 0f), Quaternion.Euler(to, 0f, 0f), Alpha);
			Alpha += Time.deltaTime / PlaceDelayS;
			yield return null;
		}
		transform.localRotation = Quaternion.Slerp(Quaternion.Euler(from, 0f, 0f), Quaternion.Euler(to, 0f, 0f), 1f);
	}

	public void Lift()
	{
		StartCoroutine(LiftThumb());
	}

}
