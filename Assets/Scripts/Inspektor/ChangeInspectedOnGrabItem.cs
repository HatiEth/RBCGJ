using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class ChangeInspectedOnGrabItem : MonoBehaviour {

	private Image m_Image;
	private Text m_Text;

	// Use this for initialization
	void Start()
	{
		m_Image = GetComponent<Image>();
		m_Text = GetComponentInChildren<Text>();

		GrabItemEvent.OnGrabItem += Grabitem;
	}

	void OnDestroy()
	{
		GrabItemEvent.OnGrabItem -= Grabitem;
	}

	void Grabitem(IItem item)
	{
		// Destroy previous holding item
		UnityEngine.Assertions.Assert.IsTrue(transform.childCount <= 1);
		for (int cIt = 0; cIt < transform.childCount; ++cIt)
		{
			Destroy(transform.GetChild(cIt).gameObject);
		}
		if (item == null)
			return;

		var go = GameObject.Instantiate(item.ItemPrefab);
		Vector3 localpos = go.transform.localPosition;

		go.transform.SetParent(this.transform);
		go.transform.localPosition = localpos;
		go.transform.localScale = Vector3.one;

		go.GetComponent<IInspectorInitializer>().Initialize(item);
	}
}
