using UnityEngine;
using System.Collections;

public class ChildBehaviour : MonoBehaviour {

	bool eating;
	float angryness;
    IItem holdingItem;

	ScoreSystem score;
	TakeControl takeControl;

	float[] DoSomethingCooldown = { 1.5f, 1.5f };

	[SerializeField]
	private int Health = 3;

	public delegate void ChangeHealth(int newHealth);
	public static event ChangeHealth OnHealthChanged;

	// Use this for initialization
	void Start()
	{
		score = (ScoreSystem)FindObjectOfType<ScoreSystem>();
		takeControl = GetComponent<TakeControl>();
	}

	// Update is called once per frame
	void Update()
	{
        //Abklingzeit und es darf nichts halten
		if (DoSomethingCooldown[0] > 0.0f && holdingItem == null)
		{
			makeDecision();
		}

        DoSomethingCooldown[0] -= Time.deltaTime;
    }

	private void makeDecision()
	{
		Enums.TakeType takeDecision = (Enums.TakeType)Random.Range(1, 5);
		holdingItem = takeControl.take(takeDecision);

		if (holdingItem != null)
			DoSomethingCooldown[0] = DoSomethingCooldown[1];
        else
            return;

        //1/3 Chance zu essen,  2/3 in den Wagen zu legen
        if(Random.Range(0,3) == 2)
            eat(holdingItem);
        else
            finishedPuttingIntoCart();
    }

	public void eat(IItem itemToEat)
	{
		//Lets go animator

	}

    //Called by Keyframe
    public void finishedEating()
    {
        if (holdingItem.HasNut)
        {
            Health = Health - 1;
            if (OnHealthChanged != null) { OnHealthChanged(Health); }
        }
    }


    //Called by Keyframe
    public void finishedPuttingIntoCart()
    {
        StoreItemEvent.Send(holdingItem);
        holdingItem = null;
    }
}
