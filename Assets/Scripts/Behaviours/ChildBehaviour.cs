using UnityEngine;
using System.Collections;

public class ChildBehaviour : MonoBehaviour {

    private float eatingProgress;
    [SerializeField]
    private float eatingRate;
    [SerializeField]
    private float quickTimeRate;

	public IItem holdingItem { get; protected set; }

    TakeControl takeControl;
    private float[] DoSomethingCooldown = { 1.5f, 1.5f };

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
	}

	// Update is called once per frame
	void Update()
	{
        if(quicktimeEvent.running)
        {
            if(eatingProgress == 1.0f)
            {
                quicktimeEvent.finishEvent();
                finishedEating();
            }
            else
            { 
                quicktimeEvent.influenceEvent(quickTimeRate * Time.deltaTime);
                eatingProgress = Mathf.Clamp01(eatingProgress + eatingRate * Time.deltaTime);
            }
            
        }

		//Abklingzeit und es darf nichts halten
		if (DoSomethingCooldown[0] <= 0.0f && holdingItem == null)
		{
			makeDecision();
		}

        if(DoSomethingCooldown[0] > 0)
		DoSomethingCooldown[0] -= Time.deltaTime;
	}

	private void makeDecision()
	{
		Enums.TakeType takeDecision = (Enums.TakeType)Random.Range(1, (int)Enums.TakeType.COUNT);
		holdingItem = takeControl.take(takeDecision);

		if (holdingItem != null)
        {
            //1/3 Chance zu essen,  2/3 in den Wagen zu legen
            if (Random.Range(0,3) == 2)
                eat(holdingItem);
            else
                finishedPuttingIntoCart();
        }
    }

	public void eat(IItem itemToEat)
	{
        //Lets go animator
        quicktimeEvent.startEvent(1.0f, holdingItem);

	}

	//Called by Keyframe
	public void finishedEating()
	{
		if (holdingItem.HasNut)
		{
			Health = Health - 1;
			if (OnHealthChanged != null) { OnHealthChanged(Health); }
		}

        eatingProgress = 0.0f;
        DoSomethingCooldown[0] = DoSomethingCooldown[1];
        holdingItem = null;
	}


	//Called by Keyframe
	public void finishedPuttingIntoCart()
	{
		StoreItemEvent.Send(holdingItem);
		holdingItem = null;
    }

    public IItem motherTakesItem()
    {
        IItem tmp = holdingItem;
        holdingItem = null;
        return tmp;
	}

	public IItem TakeItem()
	{
		var item = holdingItem;
		holdingItem = null;
		return (item);
	}
}
