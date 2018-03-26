using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AppleFXController : MonoBehaviour {
    public AudioClip clip;
    
    private AudioSource asMenu;
    private bool play = false;
    private float timer;

    void Start()
    {
        asMenu = GetComponent<AudioSource>();
        asMenu.volume = PlayerPrefs.GetFloat(KeyNames.AudioEffectVolume);
        asMenu.clip = clip;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
            gameObject.SetActive(false);

        if (play)
        {
            asMenu.PlayOneShot(clip);
            play = false;
        }
            
    }
    public void Play()
    {
        play = true;
        timer = clip.length;
    } 
}
