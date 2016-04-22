using UnityEngine;
using System.Collections;

public interface ICanHazNut {
	bool HasNut { get; }
}

public interface IItem : ICanHazNut {
	GameObject ItemPrefab { get; }
	Ingredient[] Ingredients { get; }
}
