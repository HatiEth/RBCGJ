using UnityEngine;
using System.Collections;

public class MotherBehaviour : MonoBehaviour {

    public IItem holdingItem;

    public ChildBehaviour child;
  
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
	}

    public void setItem(IItem item)
    {
        holdingItem = item;

        //Aktiviere Buttons o.Ä.
    }

    public bool handsFree()
    {
        return holdingItem == null;
    }

   

    public void giveToChild()
    {
        child.eat(holdingItem);
        holdingItem = null;
    }

    public void inspect()
    {
		holdingItem = child.TakeItem();
		GrabItemEvent.Send(holdingItem);
    }

    public void throwAway()
    {
        GrabItemEvent.Send(null);
        holdingItem = null;
    }

    public void putIntoCart()
    {
        StoreItemEvent.Send(holdingItem);
        holdingItem = null;
    }
}
