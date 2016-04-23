using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KassenEvent : MonoBehaviour {

    [SerializeField]
    static private float[] timePerItem = { 0.0f, 1.0f };

    static private bool m_running;

    static List<IItem> items;
    static int currentIndex;

    static private MotherBehaviour mom;
    static private QuicktimeEvent qt;
	// Use this for initialization
	void Start () {
        mom = FindObjectOfType<MotherBehaviour>();
        qt = FindObjectOfType<QuicktimeEvent>();
        m_running = false;
        currentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (timePerItem[0] <= 0.0f)
            grabNextItem();

        if (timePerItem[0] > timePerItem[1])
            timePerItem[0] -= Time.deltaTime;
	}

    private void beginEvent()
    {
        m_running = true;
        qt.finishEvent();
        items = FindObjectOfType<ScoreSystem>().getList();
        mom.putIntoCart();
    }
    static public void grabNextItem()
    {
        timePerItem[0] = timePerItem[1];
        IItem current = items[currentIndex++];
        mom.holdItem = current;
        mom.inspect();
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
