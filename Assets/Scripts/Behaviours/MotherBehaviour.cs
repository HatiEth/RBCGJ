using UnityEngine;
using System.Collections;


public class MotherBehaviour : MonoBehaviour {

	public IItem holdItem;


	[SerializeField]
	private ChildBehaviour child;

	public bool inspecting;

	public QuicktimeEvent quicktimeEvent;

	[SerializeField]
	private float quickTimeRate;

	Animator anim;

	private int animId_tThrowItem;
	private int animId_tGiveItem;
	private int animId_tTakeItemChild;
	private int animId_tGrabItem;
	private int animId_tFailTakeItemChild;
	private int animId_bIsHolding;


	// Use this for initialization
	void Start()
	{
		//GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
		if (quicktimeEvent == null)
			quicktimeEvent = FindObjectOfType<QuicktimeEvent>();

		anim = GetComponent<Animator>();
		animId_tThrowItem = Animator.StringToHash("tThrowItem");
		animId_tGiveItem = Animator.StringToHash("tGiveItem");
		animId_tTakeItemChild = Animator.StringToHash("tTakeItemChild");
		animId_tGrabItem = Animator.StringToHash("tGrabItem");
		animId_tFailTakeItemChild = Animator.StringToHash("tFailTakeItemChild");

		animId_bIsHolding = Animator.StringToHash("bIsHolding");
	}

	void LateUpdate()
	{
		anim.SetBool(animId_bIsHolding, holdItem != null);

	}

	public void takeFromShelf(IItem item)
	{
		holdItem = item;
		Debug.Log(item.ToString());
		//Aktiviere Buttons o.Ä.
	}

	public bool handsFree()
	{
		return (holdItem == null);
	}

	private void setHandsFree()
	{
		GrabItemEvent.Send(null);
		inspecting = false;
		holdItem = null;
	}

	public void throwAway()
	{
		//AnimationStuff();
		if (holdItem.Equals(child.holdItem) && !holdItem.HasNut)
			child.enrage();

		anim.SetTrigger(animId_tThrowItem);

		setHandsFree();
	}
	public void putIntoCart()
	{
		StoreItemEvent.Send(holdItem);
		setHandsFree();
		anim.SetTrigger(animId_tGrabItem);
	}

	public void giveToChild()
	{
		child.eat(holdItem);
		setHandsFree();
		anim.SetTrigger(animId_tGiveItem);
	}

	public void inspect()
	{
		inspecting = true;
		GrabItemEvent.Send(holdItem);
		anim.SetTrigger(animId_tTakeItemChild);
	}

	public void checkChildItem()
	{
		if (quicktimeEvent.tryToInspect())
		{
			if (child.holdItem != null)
			{
				holdItem = child.TakeItem(false);
				inspect();
			}
		}
		else
		{
			anim.SetTrigger(animId_tFailTakeItemChild);
		}
	}

	public void takeFromChild()
	{
		float value = Random.Range(0.0f, 3.0f) * quickTimeRate;
		if (quicktimeEvent.influenceEvent(-value) && child.holdItem != null)
		{
			holdItem = child.TakeItem(true);
			throwAway();
		}
	}



	public void approveKasse()
	{
		setHandsFree();
	}





}
