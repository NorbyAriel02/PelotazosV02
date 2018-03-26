using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SceneController))]
public class UIStageController : MonoBehaviour {
    public GameObject objGameController;    
    public GameObject panelFloat;
    public Text textPanel;
    public Button btnReset;
    public Button btnNext;
    public Button btnBack;
	public Button btnPause;
    public Text textLevel;
    public Text textApple;
    public Text textPoints;
    public Text textHealth;
    public Slider SliderAppleNumberDropping;
    public Slider SliderTimeBetweenApples;
    private LoadObject lObjGame;
    private GameObject objPlayer;
    private PlayerPoints playerPoints;
    private PlayerHealth playerHealth;
    private Level lvl;
    private GameCondition gCondition;
    private SceneController sceneController;
    private Image imagePanel;
    private SaveData savedata;
    void Start () {        
        AssignVarPanel();
        AssignVariables();
        UIStartConfig();
    }

    private void AssignVariables()
    {
        savedata = new SaveData();
        sceneController = GetComponent<SceneController>();
        lObjGame = objGameController.GetComponent<LoadObject>();
        gCondition = objGameController.GetComponent<GameCondition>();
        lvl = lObjGame.GetLevel;
        objPlayer = lObjGame.GetPlayer;
        playerPoints = objPlayer.GetComponent<PlayerPoints>();
        playerHealth = objPlayer.GetComponent<PlayerHealth>();

    }

    private void UIStartConfig()
    {
        textLevel.text += lvl.NumberLevel.ToString();
        btnReset.onClick.AddListener(Reset);
        btnNext.onClick.AddListener(NextLevel);
        btnBack.onClick.AddListener(Back);
		btnPause.onClick.AddListener (BtnPause);
    }

    private void Back()
    {
        if(gCondition.Won())
        {
            int nlvl = PlayerPrefs.GetInt(KeyNames.CurrentLevel);
            nlvl = nlvl + 1;

            if (PlayerPrefs.GetInt(KeyNames.MaxLevelUnlocked) < nlvl)
                PlayerPrefs.SetInt(KeyNames.MaxLevelUnlocked, nlvl);
        }
        sceneController.GoMenu();
    }

    private void AssignVarPanel()
    {
        imagePanel = panelFloat.GetComponent<Image>();
    }

	
	void Update () {
        UpdateDataUI();

        if (gCondition.GameOver())
            SetPanelToGameOver();

        if (gCondition.Won())
        {
            UpdateScore();
            SetPanelToWin();
        }
            

        if (Input.GetKeyDown(KeyCode.Escape))
            SetPanelToMenuFloat();
    }

	private void BtnPause()
	{
		SetPanelToMenuFloat();
	}

    void UpdateDataUI()
    {
        textPoints.text = "Score: " + playerPoints.Score.ToString();
        SliderAppleNumberDropping.value = gCondition.GetAppleNumberDropping;
        textHealth.text = "Health: " + playerHealth.GetHealt;
        textApple.text = "Apple: " + (playerPoints.apples).ToString()+"/"+(lvl.Apples).ToString();
        SliderTimeBetweenApples.value = (2 - playerPoints.GetTimeBetweenApple);
    }

    private void SetPanelToWin()
    {        
        textPanel.text = "Level complete";
        imagePanel.color = Color.green;
        btnBack.enabled = true;
        btnNext.enabled = true;
        btnNext.gameObject.SetActive(true);
        btnReset.enabled = true;
        panelFloat.SetActive(true);
    }

    private void SetPanelToGameOver()
    {
        textPanel.text = "You failed";
        imagePanel.color = Color.red;
        btnBack.enabled = true;
        btnNext.enabled = false;
        btnNext.gameObject.SetActive(false);
        btnReset.enabled = true;
        panelFloat.SetActive(true);
    }
    
    private void SetPanelToMenuFloat()
    {
        Time.timeScale = (Time.timeScale > 0) ? 0 : 1;
        textPanel.text = "Menu";
        imagePanel.color = Color.gray;
        btnBack.enabled = true;
        btnNext.enabled = false;
        btnNext.gameObject.SetActive(false);
        btnReset.enabled = true;
        panelFloat.SetActive(panelFloat.activeSelf ? false:true);
    }

    private void UpdateScore()
    {
        if (playerPoints.Score > savedata.GetScore(lvl.numberLevel))
        {
            Score score = new Score();
            score.Value = (int)playerPoints.Score;
            score.Level = lvl.numberLevel;

            savedata.SaveScore(score);
        }
    }

    private void NextLevel()
    {    
        sceneController.LoadNextLevel();
    }

    public void Reset()
    {
        sceneController.ReloadScene();
    }

    public void GoMenu()
    {
        sceneController.GoMenu();
    }
}
