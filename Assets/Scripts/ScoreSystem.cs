using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

    public Text geld;

    public Slider levelProgress;

    public Image hp1;
    public Image hp2;
    public Image hp3;


	private int Score = 0;
	private List<IItem> Items = new List<IItem>();

	public delegate void ScoreChange(int newScore);
	public static event ScoreChange OnScoreChange;

	// Use this for initialization
	void Start () {
		OnScoreChange += (newScore) =>
		{
			Score = newScore;
		};
		StoreItemEvent.OnStoreItem += (item) =>
		{
			//Score += item.Ingredients.Length;
			OnScoreChange(Score + item.Ingredients.Length);
			Items.Add(item);

			if(OnScoreChange != null)
			{
				OnScoreChange(Score);
			}
		};

		OnScoreChange(Score);
	}
}
