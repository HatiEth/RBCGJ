using UnityEngine;
using System.Collections;

public class MotherBehaviour : MonoBehaviour {

    public GameObject obenLinks;
    public GameObject obenRechts;
    public GameObject untenLinks;
    public GameObject untenRechts;

    public LayerMask mask;
	// Use this for initialization
	void Start () {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void take(Enums.TakeType takeAction)
    {
        GameObject selectedZone = null;
        //Debug.Log("Take:" + takeAction);
        switch(takeAction)
        {
            case Enums.TakeType.ObenLinks:
                selectedZone = obenLinks;
                break;
            case Enums.TakeType.ObenRechts:
                selectedZone = obenRechts;
                break;
            case Enums.TakeType.UntenLinks:
                selectedZone = untenLinks;
                break;
            case Enums.TakeType.UntenRechts:
                selectedZone = untenRechts;
                break;
        }
        RaycastHit2D hit =  Physics2D.CircleCast(selectedZone.transform.position, 0.25f, new Vector2(0,0), 0, mask);

        if(hit.collider != null)
        {
            //Debug.Log(hit.collider.name);
            //Do Stuff
        }
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
