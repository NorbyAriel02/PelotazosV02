using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    
    void Start () {
		
	}
	
	void Update () {
		
	}

    public void LoadLevel()
    {
        SceneManager.LoadScene(KeyNames.Stage);
    }

    public void LoadNextLevel()
    {        
        int nlvl = PlayerPrefs.GetInt(KeyNames.CurrentLevel);
        nlvl = nlvl + 1;
        PlayerPrefs.SetInt(KeyNames.CurrentLevel, nlvl);

        if (PlayerPrefs.GetInt(KeyNames.MaxLevelUnlocked) < nlvl)
            PlayerPrefs.SetInt(KeyNames.MaxLevelUnlocked, nlvl);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(KeyNames.Menu);
    }

    public void GoControllers()
    {
        SceneManager.LoadScene(KeyNames.Controllers);
    }

    public void GoLevelSelector()
    {
        SceneManager.LoadScene(KeyNames.LevelSelector);
    }
}
