using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawningOnScore : MonoBehaviour {

    private List<GameObject> itemsInCart = new List<GameObject>();
    [SerializeField]
    private int maxCount;

    [SerializeField]
    private GameObject prefab;

    private Transform m_spawnPoint;

    private int lastScoreAdded = 0;

	void Awake()
    {
        m_spawnPoint = GetComponent<Transform>();
        ScoreSystem.OnScoreChange += (oldScore , newScore) =>
        {
            //Item droppen
            if(newScore > oldScore && (newScore - lastScoreAdded >= 10))
            {
                if (itemsInCart.Count < maxCount)
                {
                    GameObject added = (GameObject)Instantiate(prefab, m_spawnPoint.transform.position, Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward));
                    itemsInCart.Add(added);
                    lastScoreAdded += 10;
                }
            }
            //Item rausnehmen
            else if(newScore < oldScore)
            {
                GameObject remove = itemsInCart[Random.Range(0, itemsInCart.Count)];
                itemsInCart.Remove(remove);
                Destroy(remove);
                lastScoreAdded -= 10;
            }

        };
    }
}
