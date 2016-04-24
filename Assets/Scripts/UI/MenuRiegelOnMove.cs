using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class MenuRiegelOnMove : MonoBehaviour, IMoveHandler {
	[SerializeField]
	ThumbUIControl Thumb;

	[SerializeField]
	MenuRiegelOnMove Other;

	protected bool m_IsMoving;
	public bool SetSelected = false;

	void Start()
	{
		Time.timeScale = 1f;
		if(SetSelected)
		{
			EventSystem.current.SetSelectedGameObject(this.gameObject);
		}
	}

	public void OnMove(AxisEventData eventData)
	{
		if (eventData.used) return;
		eventData.Use();

		if (m_IsMoving || Other.m_IsMoving)
		{
			EventSystem.current.SetSelectedGameObject(this.gameObject);
			return;
		}

		m_IsMoving = true; Other.m_IsMoving = true;
		Debug.Log("Event onMove");

		Thumb.Lift();
		Vector3 spawn = Other.transform.position;
		Other.initMoveTo(transform.position);
		StartCoroutine(Dropout(spawn));
	}

	IEnumerator Dropout(Vector3 spawnPoint)
	{
		float Alpha = 0f;
		var target = transform.position + Vector3.down * 1000f;
		while (Alpha < 1f)
		{
			transform.position = Vector3.Lerp(transform.position, target, Alpha);
			Alpha += Time.deltaTime / Thumb.PlaceDelayS;
			yield return null;
		}

		transform.position = spawnPoint;
		yield return new WaitForSeconds(0.2f);
		m_IsMoving = false;
	}

	public void initMoveTo(Vector3 position)
	{
		StartCoroutine(MoveTo(position));
	}

	IEnumerator MoveTo(Vector3 position)
	{
		float Alpha = 0f;
		while (Alpha < 1f)
		{
			transform.position = Vector3.Lerp(transform.position, position, Alpha);
			Alpha += Time.deltaTime / Thumb.PlaceDelayS;
			yield return null;
		}

		transform.position = Vector3.Lerp(transform.position, position, 1f);
		yield return new WaitForSeconds(0.2f);
		m_IsMoving = false;
	}
}
