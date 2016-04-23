using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Vector3 Freedoms = Vector3.one;
	public Transform Followee;

	void LateUpdate () {
		transform.position = transform.position + Vector3.Scale(Followee.position - transform.position, Freedoms);
	}
}
