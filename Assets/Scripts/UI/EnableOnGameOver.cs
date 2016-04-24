using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnableOnGameOver : MonoBehaviour {

	private Text m_Text;
	private bool GameOvered = false;
	[SerializeField]
	private float FadeIn = 1f;

	// Use this for initialization
	void Start () {
		m_Text = GetComponent<Text>();
		m_Text.enabled = false;

		GameOverEvent.On += Enable;	
	}

	void OnDestroy()
	{
		GameOverEvent.On -= Enable;
	}

	void Enable()
	{
		m_Text.enabled = true;
		m_Text.CrossFadeAlpha(1f, FadeIn, true);
		StartCoroutine(Fade());
	}
	
	IEnumerator Fade()
	{
		yield return new WaitForSeconds(FadeIn);
		GameOvered = true;
	}

	// Update is called once per frame
	void Update () {
		if(GameOvered && Input.anyKeyDown)
		{
			SceneManager.LoadScene(0);
		}
	}
}
