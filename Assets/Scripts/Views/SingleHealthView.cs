using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SingleHealthView : MonoBehaviour {

	private Image m_Image;

	[SerializeField]
	private Sprite[] Sprites;

	void Awake () {
		m_Image = GetComponent<Image>();
		ChildBehaviour.OnHealthChanged += UpdateHealth;
	}

	void UpdateHealth(int newHealth)
	{
		m_Image.sprite = Sprites[Mathf.Clamp(newHealth, 0, Sprites.Length - 1)];
	}

	void OnDestroy()
	{
		ChildBehaviour.OnHealthChanged -= UpdateHealth;
	}
}
