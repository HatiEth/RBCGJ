using UnityEngine;
using System.Collections;

public class Regalfach : MonoBehaviour {



	[HideInInspector]
	public RegalfachConfig Config;

	private SpriteRenderer sprite;

	void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
	}

	public IItem GrabItem()
	{
		BasicItem item = new BasicItem(Config.RandomSprite());
		return (item);
	}
}
