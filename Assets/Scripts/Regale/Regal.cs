using UnityEngine;


public class Regal : MonoBehaviour {


	[SerializeField]
	private Regalfach[] Regalfach;
	public RegalfachConfig[] PossibleConfigs;

	void Awake()
	{
		foreach(var fach in Regalfach)
		{
			fach.Config = PossibleConfigs[Random.Range(0, PossibleConfigs.Length)];
		}
	}
}
