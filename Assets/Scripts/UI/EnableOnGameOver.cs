using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnableOnGameOver : MonoBehaviour {

	private Text m_Text;
	public Image m_Image;
	public Image GameOverImage;
	private bool GameOvered = false;
	[SerializeField]
	private float FadeIn = 1f;

	// Use this for initialization
	void Start () {
		m_Text = GetComponent<Text>();
		m_Text.enabled = false;
		m_Image.enabled = false;
		GameOverImage.enabled = false;

		GameOverEvent.On += Enable;	
	}

	void OnDestroy()
	{
		GameOverEvent.On -= Enable;
	}

	void Enable(bool won)
	{
		m_Text.enabled = true;

		m_Image.enabled = true;
		m_Image.color = won ? Color.white : Color.black;

		if (!won)
			GameOverImage.enabled = true;

		StartCoroutine(Fade());
	}
	
	IEnumerator Fade()
	{
		Color c = m_Text.color;
		c.a = 0f;
		m_Text.color = c;
		yield return null;

		while(c.a < 1f)
		{
			c.a += Time.fixedDeltaTime * FadeIn;
			GameOverImage.color = c;
			m_Text.color = c;
			yield return null;
		}
		c.a = 1f;
		m_Text.color = c;
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
