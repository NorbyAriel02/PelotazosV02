using UnityEngine.UI;
using UnityEngine;
[RequireComponent(typeof(SceneController))]
public class UIMenu : MonoBehaviour {
    public Button btnPlay;
    public Button btnOptions;
    public Button btnExit;
    private SceneController sceneController;
	void Start ()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt(KeysNames.MaxLevelUnlocked, 78);
        sceneController = GetComponent<SceneController>();
        btnExit.onClick.AddListener(Exit);
        btnPlay.onClick.AddListener(Play);
        btnOptions.onClick.AddListener(Controllers);
	}
	
	void Update ()
    {
    }

    private void Controllers()
    {
        sceneController.GoControllers();
    }

    private void Play()
    {
        sceneController.GoLevelSelector();
    }

    private void Exit()
    {
        Application.Quit();
    }
    
}
