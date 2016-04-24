using UnityEngine;
using System.Collections;

public class ChangeAudioClipOnSadDay : MonoBehaviour {


	[SerializeField]
	private AudioClip m_NewClip;
	private new AudioSource audio;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();

		SadDayEvent.OnSadDay += Change;
	}
	
	// Update is called once per frame
	void OnDestroy () {
		SadDayEvent.OnSadDay -= Change;
	
	}

	void Change()
	{
		audio.clip = m_NewClip;
		audio.Play();
	}
}
