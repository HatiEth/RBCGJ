using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BasicItem : IItem {
	public bool HasNut
	{
		get
		{
			return (m_HasNut);
		}
	}

	public Ingredient[] Ingredients
	{
		get
		{
			return (m_arrIngredients.ToArray());
		}
	}

	public Sprite ItemSprite
	{
		get
		{
			return (m_ItemSprite);
		}
	}

	private List<Ingredient> m_arrIngredients;
	private bool m_HasNut = false;

	private Sprite m_ItemSprite;


	public BasicItem(Sprite itemSprite)
	{
		m_arrIngredients = new List<Ingredient>();
		m_ItemSprite = itemSprite;
	}

	public void AddIngredient(Ingredient ingr)
	{
		m_arrIngredients.Add(ingr);
		m_HasNut |= ingr.HasNut;

	}

	public bool ContainsIngredient(Ingredient ingr)
	{
		return (m_arrIngredients.Contains(ingr));
	}
}
