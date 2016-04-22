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
			while(transform.childCount > 0)
			{
				Destroy(transform.GetChild(0).gameObject);
			}
			var go = GameObject.Instantiate(item.ItemPrefab);
			go.transform.parent = this.transform;
			go.GetComponent<IInspectorInitializer>().Initialize(item);
		};
	}
}
