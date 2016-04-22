using UnityEngine;
using System.Collections;

public class Regalfach : MonoBehaviour {
	[ReadOnly]
	public RegalfachConfig Config;

	private SpriteRenderer sprite;

	void Awake()
	{
		sprite = GetComponent<SpriteRenderer>();
	}

	void Start()
	{
		sprite.sprite = Config.RandomFachSprite();
	}

	public IItem GrabItem()
	{
		int ingrCount = Random.Range(Config.MinIngredientsPerItem, Config.MaxIngredientsPerItem);
		BasicItem item = new BasicItem(Config.RandomItem());
		// FIXME: Ben�tigt Abfrage was zugeordnet wurde
		for(int i=0;i<ingrCount;++i)
		{
			item.AddIngredient(Config.PossibleIngredients.RetrieveRandom());
		}
		return (item);
	}
}
