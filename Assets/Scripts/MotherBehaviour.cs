using UnityEngine;
using System.Collections;

public class MotherBehaviour : MonoBehaviour {

    public IItem holdingItem;
  
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
	}

   

    public void giveToChild()
    {
        
    }

    public void inspect()
    {
        
    }

    public void throwAway()
    {
        
    }
}
