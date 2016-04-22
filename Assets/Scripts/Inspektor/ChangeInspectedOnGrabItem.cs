using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class ChangeInspectedOnGrabItem : MonoBehaviour {

	private Image m_Image;
	private Text m_Text;

	// Use this for initialization
	void Start () {
		m_Image = GetComponent<Image>();
		m_Text = GetComponentInChildren<Text>();

		GrabItemEvent.OnGrabItem += (item) =>
		{
			m_Image.sprite = item.ItemSprite;
			m_Text.text = string.Join(", ", item.Ingredients.Select(ingr => ingr.Name).ToArray());
		};
	}
}
