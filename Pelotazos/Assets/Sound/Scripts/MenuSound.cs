using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class MenuSound : MonoBehaviour {
    public AudioClip clip;
    private AudioSource asMenu;	
	void Start () {
        asMenu = GetComponent<AudioSource>();
        asMenu.volume = PlayerPrefs.GetFloat(KeyNames.AudioMusictVolume);
        asMenu.clip = clip;
	}
		
	void Update () {
		
	}
}
