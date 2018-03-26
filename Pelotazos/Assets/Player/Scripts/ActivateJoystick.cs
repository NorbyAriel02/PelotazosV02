using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateJoystick : MonoBehaviour {
    public GameObject joystickHor;
    public GameObject joystickVer;
    public GameObject joystickMonoCommand;
	void Start () {
		if(PlayerPrefs.GetInt(KeyNames.JoystickMonoCommand) > 0)
        {
            joystickHor.SetActive(false);
            joystickVer.SetActive(false);
            joystickMonoCommand.SetActive(true);
        }
        else
        {
            joystickHor.SetActive(true);
            joystickVer.SetActive(true);
            joystickMonoCommand.SetActive(false);
        }
	}
	
	
	void Update () {
		
	}
}
