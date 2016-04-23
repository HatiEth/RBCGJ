using UnityEngine;
using System.Collections;

public class TakeControl : MonoBehaviour {
    public GameObject obenLinks;
    public GameObject obenRechts;
    public GameObject untenLinks;
    public GameObject untenRechts;


    public LayerMask mask;

    public IItem take(Enums.TakeType takeAction)
    {
        GameObject selectedZone = null;
        //Debug.Log("Take:" + takeAction);
        switch (takeAction)
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
        RaycastHit2D hit = Physics2D.CircleCast(selectedZone.transform.position, 0.25f, new Vector2(0, 0), 0, mask);

        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.name);
            IItem item = hit.collider.gameObject.GetComponent<Regalfach>().GrabItem();
            //GrabItemEvent.Send(item);
            return item;

        }
        return null;
    }
}
