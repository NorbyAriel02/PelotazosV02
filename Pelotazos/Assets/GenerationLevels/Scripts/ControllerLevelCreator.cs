using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControllerLevelCreator : MonoBehaviour {
	public Button btnSet;
	public Button btnView;
	public Button btnCreate;
	public Button btnModif;
	public InputField inputSetA;
	public InputField inputSetB;
	public InputField inputSetC;
	public InputField inputSetD;
	public InputField inputSearchLevel;    
	public Text txtViewLevel;
	private GeneratorLevel generatorLVL;
	private SaveData saveData;
	public Double[] values = { 1, 1, 1, 1, 1 };
	public int[] percentageX = { 5, 95, 50 };
	public int[] percentageY = { 55, 55, 75 };

	void Start () {
		btnCreate.onClick.AddListener(CreateLevels);
		btnSet.onClick.AddListener(SetValues);
		btnView.onClick.AddListener(SearchLevel);
		saveData = new SaveData();
		btnModif.onClick.AddListener(UpdateLevel);
		generatorLVL = new GeneratorLevel ();
	}

	void UpdateLevel()
	{
	/*
	string path = Path.Combine(Application.streamingAssetsPath, "test03.dat");
	List<Level> levels = saveData.ReadToObject<List<Level>>(path);
	int y = 0;
	foreach (Level lvl in levels)
	{
		if (lvl.NumberLevel == 4)
			y = 2;
		else if (lvl.NumberLevel == 7)
			y = 3;
		else if (lvl.NumberLevel == 10)
			y = 8;

		List<DescriptionBlocks> blocks = (List<DescriptionBlocks>)lvl.ObjectList.Get(TypeObjectLevel.Blocks);
		//blocks.Clear(); 
		for(int x= 0; x < y; x++)
		{
			DescriptionBlocks block = new DescriptionBlocks();
			block.SetType = BlockType.HidingPlace;

			block.Position = x;

			blocks.Add(block);
		}
		Debug.Log("fin");
	}
	saveData.Save<List<Level>>(levels, path);*/
}

	void SetValues()
	{        
		string a = inputSetA.text != "" ? inputSetA.text : generatorLVL.GetA().ToString();
		string b = inputSetB.text != "" ? inputSetB.text : generatorLVL.GetB().ToString();
		string c = inputSetC.text != "" ? inputSetC.text : generatorLVL.GetC().ToString();
		string d = inputSetD.text != "" ? inputSetD.text : generatorLVL.GetD().ToString();
		string values = a + "," + b + "," + c + "," + d+",1";
		generatorLVL.SetValuesFuntion(values);
	}

	void SearchLevel()
	{
		Level lvl = saveData.GetDataLevel(Convert.ToInt32(inputSearchLevel.text));

		if (lvl == null)
			return;

		List<DescriptionEnemies> le = (List<DescriptionEnemies>)lvl.ObjectList.Get (TypeObjectLevel.Enemies);
		Debug.Log(le[0].Type);
		txtViewLevel.text = " lvl " + lvl.NumberLevel.ToString () + " points " + lvl.Apples.ToString ();
	}

	void CreateLevels()
	{		
		Debug.Log ("Start Proccess");
		saveData.CreateFileDataLevels (generatorLVL.GetListLevel (100), Path.Combine(Application.streamingAssetsPath, "test03.dat"));
		Debug.Log ("End Proccess");
	}
	
	void Update () {
		
	}
}
