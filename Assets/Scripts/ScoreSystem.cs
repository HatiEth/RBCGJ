using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {
    private int Score = 0;

    [SerializeField]
	private List<IItem> Items = new List<IItem>();

	public delegate void ScoreChange(int oldScore, int newScore);
	public static event ScoreChange OnScoreChange;
	// Use this for initialization
	void Start () {
		OnScoreChange += (_, newScore) =>
		{
			Score = newScore;
		};
		StoreItemEvent.OnStoreItem += (item) =>
		{
			Items.Add(item);

			if(OnScoreChange != null)
			{
				OnScoreChange(Score, Score + CalculateScore(item));
			}
		};

		OnScoreChange(Score, Score);
	}

    public static void SendScoreChange(int oldScore, int newScore)
    {
        OnScoreChange(oldScore, newScore);
    }

    public List<IItem> getList()
    {
        return Items;
    }

    public int getScore()
    {
        return Score;
    }

    public static int CalculateScore(IItem item)
    {
        return item.Ingredients.Length;
    }

}
