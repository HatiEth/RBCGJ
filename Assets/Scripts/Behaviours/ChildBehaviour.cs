using UnityEngine;
using System.Collections;

public class ChildBehaviour : MonoBehaviour {

	private float eatingProgress;
	[SerializeField]
	private float eatingRate;
	[SerializeField]
	private float quickTimeRate;

	public IItem holdItem { get; protected set; }

	TakeControl takeControl;

	[SerializeField]
	private float[] DoSomethingCooldown = { 3.0f, 3.0f };

	[SerializeField]
	//1. Wert = akutelle Dauer/Z�hler   2. Wert = Max Wert  3. Wert = Effekt der mit Zeit multipliziert wird
	private float[] enrageEffect = { 10.0f, 10.0f, 1.2f };

	[SerializeField]
	//1. Wert = akutelle Dauer/Z�hler   2. Wert = Max Wert  3. Wert = Effekt der mit Zeit multipliziert wird
	private float[] soothedEffect = { 10.0f, 10.0f, 0.8f };


	[SerializeField]
	private int Health = 3;


	private QuicktimeEvent quicktimeEvent;

	public delegate void ChangeHealth(int newHealth);
	public static event ChangeHealth OnHealthChanged;

	// Use this for initialization
	void Start()
	{
		takeControl = GetComponent<TakeControl>();
		quicktimeEvent = FindObjectOfType<QuicktimeEvent>();
		quicktimeEvent.gameObject.SetActive(false);

		if(OnHealthChanged != null)
		{
			OnHealthChanged(Health);
		}

	}

	// Update is called once per frame
	void Update()
	{
		if (KassenEvent.isRunning())
			return;


		//M�gliche aktive Effekte berechnen: verschnellert oder verlangsamt Simulation
		float deltaTime = calculateEffectValue(Time.deltaTime);


		if (quicktimeEvent.running)
		{
			if (eatingProgress == 1.0f)
			{
				quicktimeEvent.finishEvent();
				finishedEating();
			}
			else
			{
				quicktimeEvent.influenceEvent(quickTimeRate * deltaTime);
				eatingProgress = Mathf.Clamp01(eatingProgress + eatingRate * Time.deltaTime);
			}
		}

		//Abklingzeit und es darf nichts halten
		if (DoSomethingCooldown[0] <= 0.0f && holdItem == null)
		{
			makeDecision();
		}

		if (DoSomethingCooldown[0] > 0)
			DoSomethingCooldown[0] -= deltaTime;
	}

	private void makeDecision()
	{
		Enums.TakeType takeDecision = (Enums.TakeType)Random.Range(1, (int)Enums.TakeType.COUNT);
		holdItem = takeControl.take(takeDecision);
		if (holdItem != null)
		{
			//1/3 Chance zu essen,  2/3 in den Wagen zu legen
			if (Random.Range(0, 6) == 0)
				eat(holdItem);
			else
				finishedPuttingIntoCart();
		}
	}

	public void eat(IItem itemToEat)
	{
		//Lets go animator
		quicktimeEvent.startEvent(1.0f);
	}

	//Called by Keyframe
	public void finishedEating()
	{
		if (holdItem.HasNut)
		{
			Health = Health - 1;
			if (OnHealthChanged != null) { OnHealthChanged(Health); }
		}
		finishAction();

		if (!holdItem.HasNut)
			soothed();
		holdItem = null;
	}


	//Called by Keyframe
	public void finishedPuttingIntoCart()
	{
		StoreItemEvent.Send(holdItem);
		finishAction();
		holdItem = null;
	}

	public IItem TakeItem(bool forcefully)
	{
		IItem item = holdItem;
		if (forcefully)
		{
			enrage();
			holdItem = null;
		}
		finishAction();
		return item;
	}

	public void enrage()
	{ enrageEffect[0] = enrageEffect[1]; }

	public void soothed()
	{ soothedEffect[0] = soothedEffect[1]; }


	private void finishAction()
	{
		eatingProgress = 0.0f;
		DoSomethingCooldown[0] = DoSomethingCooldown[1];
	}

	private float calculateEffectValue(float input)
	{
		//Falls beide aktiv, heben sie sich auf.
		if (soothedEffect[0] > 0.0f && enrageEffect[0] > 0.0f)
			return input;
		else if (soothedEffect[0] > 0.0f)
			return (input * soothedEffect[2]);
		else if (enrageEffect[0] > 0.0f)
			return (input * enrageEffect[2]);

		return input;

	}

}
