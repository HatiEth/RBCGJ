using UnityEngine;
using System.Collections;

public class FakeTiles : MonoBehaviour {

	public GameObject Tile;
	public Rect Tilemap;
	public float TileDimensionX = 16f;
	public float TileDimensionY = 16f;

	// Use this for initialization
	void Start()
	{

		for (float x = Tilemap.xMin; x < Tilemap.xMax; x += TileDimensionX)
		{
			for (float y = Tilemap.yMin; y < Tilemap.yMax; y += TileDimensionY)
			{
				GameObject go = GameObject.Instantiate(Tile, new Vector3(x, y, this.transform.position.z), Quaternion.identity) as GameObject;
				go.transform.SetParent(this.transform, false);
			}
		}
	}

	public void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;


		Gizmos.DrawWireCube(new Vector3(Tilemap.center.x, Tilemap.center.y, 0f), Tilemap.size);
	}
}
