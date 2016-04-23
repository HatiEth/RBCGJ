using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTextView : MonoBehaviour {

	private Text m_Text;

	// Use this for initialization
	void Awake () {
		m_Text = GetComponent<Text>();
		ScoreSystem.OnScoreChange += (newScore) =>
		{
			m_Text.text = "" + newScore;
		};
	}
}
