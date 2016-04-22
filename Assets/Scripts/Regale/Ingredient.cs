using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Ingredient : ICanHazNut {
	public bool HasNut { get { return m_HasNut; } }
	public string Name { get { return (m_Name); } }

	[SerializeField]
	private string m_Name = "";
	[SerializeField]
	private bool m_HasNut = false;
}
