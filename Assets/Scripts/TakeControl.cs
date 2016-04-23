using UnityEngine;
using System.Collections;

public class TakeControl : MonoBehaviour {

	[SerializeField]
	private GameObject oben;

	[SerializeField]
	private GameObject mitte;

	[SerializeField]
	private GameObject unten;

	//[SerializeField]
	//private GameObject untenRechts;

	[SerializeField]
	private LayerMask mask;

	public IItem take(Enums.TakeType takeAction)
	{
		GameObject selectedZone = null;
		//Debug.Log("Take:" + takeAction);
		switch (takeAction)
		{
			case Enums.TakeType.Oben:
				selectedZone = oben;
				break;
			case Enums.TakeType.Mitte:
				selectedZone = mitte;
				break;
			case Enums.TakeType.Unten:
				selectedZone = unten;
				break;
		}
        RaycastHit2D hit = Physics2D.BoxCast(selectedZone.transform.position, new Vector2(0.9f, 1f/3f),0,Vector2.zero, 0f, mask);

		if (hit.collider != null)
		{
			IItem item = hit.collider.gameObject.GetComponent<Regalfach>().GrabItem();
			return item;
		}
		return null;
	}
}
