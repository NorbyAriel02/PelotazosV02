using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SceneController))]
public class UIController : MonoBehaviour {
	public Toggle CheckMonoCommand;
    public Slider sliderMusic;
    public Slider sliderEffect;
    public Button btnMenu;
	public Button btnSendMail;
	public GameObject userFeedBack;
    private SceneController sceneController;
    void Start () {
        sceneController = GetComponent<SceneController>();
        CheckMonoCommand.onValueChanged.AddListener((value) => { SetValuemonoCommand(value); });
        sliderEffect.onValueChanged.AddListener((value) => { SetAudioEffect(value); });
        sliderMusic.onValueChanged.AddListener((value) => { SetAudioMusic(value); });
        btnMenu.onClick.AddListener(GoMenu);
		btnSendMail.onClick.AddListener (SendMail);
        SetStartConfig();
    }

	private void SendMail()
	{
		Instantiate (userFeedBack);
	}

    private void GoMenu()
    {
        sceneController.GoMenu();
    }
    
    private void SetStartConfig()
    {
        if (PlayerPrefs.HasKey(KeyNames.AudioEffectVolume))
            sliderEffect.value = PlayerPrefs.GetFloat(KeyNames.AudioEffectVolume);
        else
            sliderEffect.value = 1;

        if (PlayerPrefs.HasKey(KeyNames.AudioMusictVolume))
            sliderMusic.value = PlayerPrefs.GetFloat(KeyNames.AudioMusictVolume);
        else
            sliderMusic.value = 1;

        if (PlayerPrefs.HasKey(KeyNames.JoystickMonoCommand))
            CheckMonoCommand.isOn = PlayerPrefs.GetInt(KeyNames.JoystickMonoCommand) > 0 ? true : false;
        else
            CheckMonoCommand.isOn = false;
    }
	
    private void SetAudioEffect(float value)
    {
        PlayerPrefs.SetFloat(KeyNames.AudioEffectVolume, value);        
    }

    private void SetAudioMusic(float value)
    {
        PlayerPrefs.SetFloat(KeyNames.AudioMusictVolume, value);
    }

    private void SetValuemonoCommand(bool value)
	{
        PlayerPrefs.SetInt(KeyNames.JoystickMonoCommand, value ? 1:0);        
    }
}
