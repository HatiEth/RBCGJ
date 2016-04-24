using UnityEngine;
using System.Collections;

public class TriggerSadDayOnLose : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ChildBehaviour.OnHealthChanged += Trigger;
	}

	public void Trigger(int newHealth)
	{
		if(newHealth <= 0)
			SadDayEvent.Send();
	}

#if UNITY_EDITOR
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			SadDayEvent.Send();
		}
	}
#endif

	// Update is called once per frame
	void OnDestroy () {
		ChildBehaviour.OnHealthChanged -= Trigger;
	}
}
