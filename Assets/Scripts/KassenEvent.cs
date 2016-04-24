using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KassenEvent : MonoBehaviour {

    [SerializeField]
    static private float[] timePerItem = { 0.0f, 1.0f };

    static private bool m_running;

    [SerializeField]
    static List<IItem> items;
    static int currentIndex;

    static private MotherBehaviour mom;
    static private QuicktimeEvent qt;
	// Use this for initialization
	void Start () {
        mom = FindObjectOfType<MotherBehaviour>();
        qt = FindObjectOfType<QuicktimeEvent>();
        m_running = false;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Endzone"), LayerMask.NameToLayer("Wagen"));
	}
	
	// Update is called once per frame
	void Update () {
        if(m_running)
        {
            if (timePerItem[0] <= 0.0f)
                grabNextItem();

            if (timePerItem[0] > 0.0f)
                timePerItem[0] -= Time.deltaTime;
        }
    }

    private void beginEvent()
    {
        currentIndex = 0;
        m_running = true;
        qt.finishEvent();
        items = FindObjectOfType<ScoreSystem>().getList();
        mom.putIntoCart();
    }

    static private void finishEvent()
    {
        items = null;
        mom.handsFree();
    }

    static public void grabNextItem()
    {
        timePerItem[0] = timePerItem[1];
        IItem current = items[currentIndex++];
        Debug.Log(current);
        if (!mom.handsFree())
            mom.approveKasse();
        mom.holdItem = current;
        mom.inspect();

        if (currentIndex >= items.Count)
            finishEvent();
    }

    static public bool isRunning()
    {
        return m_running;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == mom.gameObject)
            beginEvent();
    }
}
