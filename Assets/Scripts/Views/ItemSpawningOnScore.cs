using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawningOnScore : MonoBehaviour {

    private List<GameObject> itemsInCart = new List<GameObject>();
    [SerializeField]
    private int maxCount;

    [SerializeField]
    private GameObject [] prefabs;

    private Transform m_spawnPoint;

    private int lastScoreAdded = 0;

	void Awake()
    {
        m_spawnPoint = GetComponent<Transform>();
        ScoreSystem.OnScoreChange += ScoreChange;
    }

    void OnDestroy()
    {
        ScoreSystem.OnScoreChange -= ScoreChange;
    }

    void ScoreChange (int oldScore, int newScore)
    {
        //Item droppen
        if (newScore > oldScore && (newScore - lastScoreAdded >= 10))
        {
            if (itemsInCart.Count < maxCount)
            {
                GameObject added = (GameObject)Instantiate(ArrayRandomExtension.RetrieveRandom<GameObject>(prefabs), m_spawnPoint.transform.position, Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward));
                itemsInCart.Add(added);
                lastScoreAdded += 10;
            }
        }
        //Item rausnehmen
        else if (newScore < oldScore)
        {
            GameObject remove = ListRandomExtension.RetrieveRandom<GameObject>(itemsInCart);
            itemsInCart.Remove(remove);
            Destroy(remove);
            lastScoreAdded -= 10;
        }
    }
}
