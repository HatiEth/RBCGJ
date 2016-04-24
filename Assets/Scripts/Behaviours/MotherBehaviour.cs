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

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
        if( quicktimeEvent == null)
            quicktimeEvent = FindObjectOfType<QuicktimeEvent>();
    }

    private void setHandsFree()
    {
        GrabItemEvent.Send(null);
        inspecting = false;
        holdItem = null;
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

    

    public void throwAway()
    {
        //AnimationStuff();
        if (holdItem.Equals(child.holdItem) && !holdItem.HasNut)
            child.enrage();


        setHandsFree();
    }
    public void putIntoCart()
    {
        StoreItemEvent.Send(holdItem);
        setHandsFree();
    }

    public void giveToChild()
    {
        child.eat(holdItem);
        setHandsFree();
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
            if(child.holdItem != null)
            {
                holdItem = child.TakeItem(false);
                inspect();
            }
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
