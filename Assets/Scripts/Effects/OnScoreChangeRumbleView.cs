using UnityEngine;
using System.Collections;

public class OnScoreChangeRumbleView : MonoBehaviour {

	[SerializeField]
	private float RumbleFalloff = 0.05f;
	[SerializeField]
	private float RumbleRadius = 0f;
	[SerializeField]
	private float ScoreEffector = 1.05f;

	// Use this for initialization
	void Start () {
		ScoreSystem.OnScoreChange += (oldScore, newScore) =>
		{
			RumbleRadius += Mathf.Abs(newScore - oldScore) * ScoreEffector;
		};
	}
	
	void LateUpdate () {
		if(RumbleRadius >= 0f)
		{
			RumbleRadius -= RumbleFalloff;
			transform.localPosition = Random.insideUnitCircle * Mathf.Max(0, RumbleRadius);
		}
	}
}
