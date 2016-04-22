using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class RegalfachConfig : ScriptableObject {
	public GameObject RandomItem()
	{
		return (m_ItemPrefabs.RetrieveRandom());
	}
	public Sprite RandomFachSprite()
	{
		return (m_FachSprites.RetrieveRandom());
	}

	public int MinIngredientsPerItem = 1;
	public int MaxIngredientsPerItem = 1;
	public Ingredient[] PossibleIngredients { get { return m_Ingredients; } }

	[SerializeField]
	private GameObject[] m_ItemPrefabs;
	[SerializeField]
	private Sprite[] m_FachSprites;
	[SerializeField]
	private Ingredient[] m_Ingredients;

}
