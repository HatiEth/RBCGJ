using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChildHealthView : MonoBehaviour {

	private Image m_Image;

	[SerializeField]
	private int RequiredHealth = 0;

	void Start()
	{
		m_Image = GetComponent<Image>();
		ChildBehaviour.OnHealthChanged += (newHealth) =>
		{
			m_Image.enabled = newHealth >= RequiredHealth;
		};
	}
}
