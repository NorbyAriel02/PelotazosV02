using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SceneController))]
public class Intro : MonoBehaviour {
	public GameObject userFeedback;
    public Button btnGoMenu;
	public string[] filesDelete;
	public bool restartPlayerpref;
	private SceneController scene;
	void Start () {
		if (restartPlayerpref)
			RestartPlayerPref ();
		
        Configuration();

        scene = GetComponent<SceneController>();
        btnGoMenu.onClick.AddListener(GoMenu);
		
		if (PlayerPrefs.GetInt(KeyNames.SendUserFeedback) > 0)
			Instantiate(userFeedback);
		else
			scene.GoMenu();
	}	
	
	void GoMenu () {
        scene.GoMenu();
	}

    private void FilesDelete()
    {
        if (Application.platform == RuntimePlatform.Android)
            foreach (string file in filesDelete)
            {
                string PathOnAndroid = Path.Combine(Application.persistentDataPath, file);
                if (File.Exists(PathOnAndroid))
                    File.Delete(PathOnAndroid);

            }
    }

    private void SetPlayerPref()
    {
        if (!PlayerPrefs.HasKey(KeyNames.MaxLevelUnlocked))
            PlayerPrefs.SetInt(KeyNames.MaxLevelUnlocked, 1);

        if (!PlayerPrefs.HasKey(KeyNames.JoystickMonoCommand))
            PlayerPrefs.SetInt(KeyNames.JoystickMonoCommand, 1);

        if (!PlayerPrefs.HasKey(KeyNames.CurrentLevel))
            PlayerPrefs.SetInt(KeyNames.CurrentLevel, 1);

        if (!PlayerPrefs.HasKey(KeyNames.AudioEffectVolume))
            PlayerPrefs.SetFloat(KeyNames.AudioEffectVolume, 1);

        if (!PlayerPrefs.HasKey(KeyNames.AudioMusictVolume))
            PlayerPrefs.SetFloat(KeyNames.AudioMusictVolume, 1);

    }

	void RestartPlayerPref()
	{
		PlayerPrefs.DeleteAll ();
	}

    private void Configuration()
	{
        FilesDelete();
        SetPlayerPref();        
    }
}
