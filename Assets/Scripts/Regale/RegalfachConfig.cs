using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class RegalfachConfig : ScriptableObject {
	public Sprite RandomItemSprite()
	{
		return (m_ItemSprites.RetrieveRandom());
	}
	public Sprite RandomFachSprite()
	{
		return (m_FachSprites.RetrieveRandom());
	}

	public int MinIngredientsPerItem = 1;
	public int MaxIngredientsPerItem = 1;
	public Ingredient[] PossibleIngredients { get { return m_Ingredients; } }

	[SerializeField]
	private Sprite[] m_ItemSprites;
	[SerializeField]
	private Sprite[] m_FachSprites;
	[SerializeField]
	private Ingredient[] m_Ingredients;

}
