using System;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(SceneController))]
public class UILevelSelector : MonoBehaviour{
    public int levelForPanel;
    public GameObject levelsPanel;
    public Button btnNext;
    public Button btnAfter;
    public Button btnMenu;
	public Vector2 InputDirection { set; get; }
	public AxisOption axis = AxisOption.OnlyHorizontal;
    private Text[] arrayTextLevel;    
    private Button[] arrayButton;
    private int countPanels;
    private int maxPanel;
    private float rest;
    private SceneController sceneController;
    private SaveData saveData;
	private RectTransform panelRectTranform;
	Vector2 touchOrigin = Vector2.zero;
	Vector2 touchEnd = Vector2.zero;
	public float hSliderValue = 0.0F;
	void OnGUI() {
		Debug.Log (hSliderValue);
		hSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 0.0F, 10.0F);
	}
    void Start () {        
        AssignVariables();
        SetCountPanel();
        ButtonGenerator();
    }
    private void AssignVariables()
    {        
        if (!PlayerPrefs.HasKey(KeyNames.CurrentLevel))
        {
            PlayerPrefs.SetInt(KeyNames.CurrentLevel, 1);
            PlayerPrefs.SetInt(KeyNames.MaxLevelUnlocked, 1);
        }
        btnNext.onClick.AddListener(NextPanel);
        btnAfter.onClick.AddListener(AfterPanel);
        btnMenu.onClick.AddListener(GoMenu);
        saveData = new SaveData();
        sceneController = GetComponent<SceneController>();
        arrayButton = GetComponentsInChildren<Button>();
        arrayTextLevel = GetComponentsInChildren<Text>();
		panelRectTranform = levelsPanel.GetComponent<RectTransform> ();
    }
       
    private void SetCountPanel()
    {
        /*
         * q=(int)(Dividendo/divisor);
         * r=Dividendo%divisor;
         */
        rest = 0;
        countPanels = (int)(PlayerPrefs.GetInt(KeyNames.MaxLevelUnlocked) / levelForPanel);
        rest = (PlayerPrefs.GetInt(KeyNames.MaxLevelUnlocked) % levelForPanel);        
        if (rest != 0)
            countPanels++;

        maxPanel = countPanels;
    }
  
    private void ButtonGenerator()
    {
        int level = (levelForPanel * countPanels) - (levelForPanel-1);

        level = (level == 0) ? 1 : level;
        for(int x = 0;  x < levelForPanel; x++)
        {            
            /*Se utiliza una variable temporal para pasar el valor del level*/
            int tempLvl = level;
            arrayButton[x].onClick.AddListener(delegate { GoLevel(tempLvl); });
            arrayTextLevel[x].text = level.ToString() + Environment.NewLine + saveData.GetScore(level);

            arrayButton[x].interactable = true;

            if (PlayerPrefs.GetInt(KeyNames.MaxLevelUnlocked) < level)
                arrayButton[x].interactable = false;                

            level++;
        }
    }

    private void GoMenu()
    {
        sceneController.GoMenu();
    }

    private void GoLevel(int level)
    {
        PlayerPrefs.SetInt(KeyNames.CurrentLevel, level);
        sceneController.LoadLevel();
    }
    
    private void NextPanel()
    {
        countPanels++;
        if (maxPanel < countPanels)
            countPanels = maxPanel;

        ButtonGenerator();
    }

    private void AfterPanel()
    {
        countPanels--;
        if (countPanels < 1)
            countPanels = 1;

        ButtonGenerator();
    }


}
