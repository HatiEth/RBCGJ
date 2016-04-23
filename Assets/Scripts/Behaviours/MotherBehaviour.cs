using UnityEngine;
using System.Collections;
using System;

public class MotherBehaviour : MonoBehaviour {

    public IItem holdingItem;
    

    [SerializeField]
    private ChildBehaviour child;

    public bool inspecting;
    
    public QuicktimeEvent quicktimeEvent;
    [SerializeField]
    private float quickTimeRate;

    // Use this for initialization
    void Start () {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
        quicktimeEvent = FindObjectOfType<QuicktimeEvent>();
    }

    public void setItem(IItem item)
    {
        holdingItem = item;
        //Aktiviere Buttons o.Ä.
    }

    public bool handsFree()
    {
        return (holdingItem == null);
    }

    void setHandsFree()
    {
        GrabItemEvent.Send(null);
        inspecting = false;
        holdingItem = null;
    }

   

    public void giveToChild()
    {
        child.eat(holdingItem);
        setHandsFree();
    }

    public void inspect()
    {
		inspecting = true;
		GrabItemEvent.Send(holdingItem);
    }

    public void checkChildItem()
    {
        holdingItem = quicktimeEvent.tryToInspect();
        if(holdingItem != null)
            inspect();
    }

    public void throwAway()
    {
        //AnimationStuff();
        setHandsFree();
    }

    public void takeFromChild()
    {
        holdingItem = quicktimeEvent.influenceEvent(-quickTimeRate);
        if (holdingItem != null)
            throwAway();
    }

    public void putIntoCart()
    {
        StoreItemEvent.Send(holdingItem);
        setHandsFree();
    }
}
