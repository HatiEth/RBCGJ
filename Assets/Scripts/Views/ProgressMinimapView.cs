using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressMinimapView : MonoBehaviour {

	[SerializeField]
	private Transform Start;
	[SerializeField]
	private Transform End;
	[SerializeField]
	private Transform Player;

	private Slider m_Slider;

	void Awake()
	{
		m_Slider = GetComponent<Slider>();
	}

	void Update()
	{
		float dEndStart = End.position.x - Start.position.x;
		float dPlayerStart = Player.position.x - Start.position.x;

		m_Slider.normalizedValue = Mathf.Clamp01(dPlayerStart / dEndStart);
	}
}
