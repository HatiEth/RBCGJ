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

	private ScoreSystem score;
	Animator anim;

	private int animId_tThrowItem;
	private int animId_tGiveItem;
	private int animId_tTakeItemChild;
	private int animId_tGrabItem;
	private int animId_tFailTakeItemChild;
	private int animId_bIsHolding;

	private new AudioSource audio;
	public AudioClip m_AudioTakeFromChild;
	public AudioClip m_AudioGiveChild;

	// Use this for initialization
	void Start()
	{
		audio = GetComponent<AudioSource>();
		score = FindObjectOfType<ScoreSystem>();
		GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
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
		anim.SetTrigger(animId_tGrabItem);
		inspect();
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
		child.eat(holdItem, true);
		setHandsFree();
		anim.SetTrigger(animId_tGiveItem);
		audio.PlayOneShot(m_AudioGiveChild);
	}

	public void inspect()
	{
		inspecting = true;
		GrabItemEvent.Send(holdItem);
	}

	public void checkChildItem()
	{
		if (quicktimeEvent.tryToInspect())
		{
			if (child.holdItem != null)
			{
				holdItem = child.TakeItem(false);
				audio.PlayOneShot(m_AudioTakeFromChild);
				anim.SetTrigger(animId_tTakeItemChild);
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
			audio.PlayOneShot(m_AudioTakeFromChild);
			throwAway();
		}
	}



	public void approveKasse()
	{
        if(holdItem.HasNut)
        {
            child.applyDamage();
        }
		setHandsFree();
	}

    public void denyKasse()
    {
        int oldScore = score.getScore();
        int itemScore = ScoreSystem.CalculateScore(holdItem);
        ScoreSystem.SendScoreChange(oldScore, oldScore - itemScore);
        
        setHandsFree();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "End")
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
