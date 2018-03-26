using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class FxController : MonoBehaviour {
    public AudioClip clip;
    private AudioSource asMenu;

    void Start()
    {
        asMenu = GetComponent<AudioSource>();
        asMenu.volume = PlayerPrefs.GetFloat(KeyNames.AudioEffectVolume);
        asMenu.clip = clip;        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(asMenu != null)
            asMenu.PlayOneShot(clip);
    }
}
