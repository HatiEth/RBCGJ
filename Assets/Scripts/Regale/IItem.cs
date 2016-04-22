using UnityEngine;
using System.Collections;

public interface ICanHazNut {
	bool HasNut { get; }
}

public interface IItem : ICanHazNut {
	Sprite ItemSprite { get; }
	Ingredient[] Ingredients { get; }
}
