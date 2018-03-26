using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour {
    public AudioClip clip;
    public bool upgradeVol;
    private AudioSource asMenu;

    void Start()
    {
        asMenu = GetComponent<AudioSource>();
        asMenu.volume = PlayerPrefs.GetFloat(KeyNames.AudioMusictVolume);
        asMenu.clip = clip;
        asMenu.Play();
    }

    void Update()
    {
        if(upgradeVol)
            asMenu.volume = PlayerPrefs.GetFloat(KeyNames.AudioMusictVolume);
    }
}
