using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class RegalfachConfig : ScriptableObject {
	public Sprite RandomSprite()
	{
		return (m_Sprites[Random.Range(0, m_Sprites.Length)]);
	}
	public Ingredient[] PossibleIngredients { get { return m_Ingredients; } }

	[SerializeField]
	private Sprite[] m_Sprites;
	[SerializeField]
	private Ingredient[] m_Ingredients;

}
