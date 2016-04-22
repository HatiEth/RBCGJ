using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class BasicItemInspect : MonoBehaviour, IInspectorInitializer {
	public void Initialize(IItem item)
	{
		GetComponentInChildren<UnityEngine.UI.Text>().text = string.Join(", ", item.Ingredients.Select(ingr => ingr.Name).ToArray());
	}
}
