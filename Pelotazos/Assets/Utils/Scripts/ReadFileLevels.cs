using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadFileLevels : MonoBehaviour {
	public GameObject mail;
    public bool modBlock;
    public bool modEnemies;
    public Button BtnGetLevel;
    public Button BtnUpdate;
    public InputField inputNumberLevel;
	public InputField inputApples;
	public InputField inputEnemies;
    public InputField inputEnemiesVelocity;
    public InputField inputBlocksHiding;
    public InputField inputBlocksSolid;
    public InputField inputPositionBlocksHiding;
    public InputField inputPositionBlocksSolid;
    private SaveData loadLevel;
	private Level lvl;

	void Start () {
		loadLevel = new SaveData ();
		BtnGetLevel.onClick.AddListener (GetLevel);
        BtnUpdate.onClick.AddListener(UpdateFile);
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
            UpdateFile();

        if (Input.GetKeyDown(KeyCode.G))
            GetLevel();

        if (Input.GetKeyDown(KeyCode.B))
            modBlock = true;

        if (Input.GetKeyDown(KeyCode.E))
            modEnemies = true;

    }

	private void GetLevel()
	{
		int level = Convert.ToInt16 (inputNumberLevel.text);
		lvl = loadLevel.GetDataLevel (level);
		inputApples.text = lvl.Apples.ToString();

		List<DescriptionBlocks> lstBlocks = (List<DescriptionBlocks>)lvl.ObjectList.Get (TypeObjectLevel.Blocks);
		int numBlockshiding = 0;
        int numBlockSolid = 0;
        inputPositionBlocksHiding.text = "";
        inputPositionBlocksSolid.text = "";

        foreach (DescriptionBlocks b in lstBlocks) {
            if (b.Type.Equals(BlockType.HidingPlace))
            {
                numBlockshiding++;
                inputPositionBlocksHiding.text += b.Position.ToString() + "-";
            }
            else if (b.Type.Equals(BlockType.Solid))
            {
                numBlockSolid++;
                inputPositionBlocksSolid.text += b.Position.ToString() + "-";
            }				
		}

		List<DescriptionEnemies> lstEnemies = (List<DescriptionEnemies>)lvl.ObjectList.Get (TypeObjectLevel.Enemies);
        if(modEnemies)
            foreach (DescriptionEnemies e in lstEnemies)
            {
                Debug.Log(e.Position[0]+" "+ e.Position[1] + " " + e.MagnitudVelocity);
            }
		inputEnemies.text = lstEnemies.Count.ToString();
        inputEnemiesVelocity.text = Mathf.Abs(lstEnemies[0].MagnitudVelocity).ToString();
        inputBlocksHiding.text = numBlockshiding.ToString ();
        inputBlocksSolid.text = numBlockSolid.ToString();
	}

	private void UpdateFile()
	{     
		Instantiate (mail);
		/*
        Level nLvl = new Level ();
        ListOfLevelObject listObj = new ListOfLevelObject();

        if (inputNumberLevel.text != "")
            nLvl.NumberLevel = Convert.ToInt16(inputNumberLevel.text);
        else
            return;

        if (PlayerPrefs.GetInt(KeyNames.MaxLevelUnlocked) < Convert.ToInt16(inputNumberLevel.text))
            PlayerPrefs.SetInt(KeyNames.MaxLevelUnlocked, Convert.ToInt16(inputNumberLevel.text));

        if (inputApples.text != "")
            nLvl.Apples = Convert.ToInt32(inputApples.text);
        
        List<DescriptionBlocks> lstBlocks = (List<DescriptionBlocks>)lvl.ObjectList.Get(TypeObjectLevel.Blocks);
        if(modBlock)
        {
            modBlock = false;
            lstBlocks.Clear();
            lstBlocks = GetListBlocks();
        }
                        
        List<DescriptionEnemies> lstEnemies = (List<DescriptionEnemies>)lvl.ObjectList.Get(TypeObjectLevel.Enemies);
        if(modEnemies)
        {
            modEnemies = false;
            lstEnemies.Clear();
            lstEnemies = GetListEnemies(Convert.ToInt16(inputEnemies.text)); ;            
        }

        listObj.Add(lstEnemies, TypeObjectLevel.Enemies);
        listObj.Add(lstBlocks, TypeObjectLevel.Blocks);

        nLvl.ObjectList = listObj;

        loadLevel.UpdateDataLevel(nLvl);*/
    }

    private List<DescriptionBlocks> GetListBlocks()
    {
        List<DescriptionBlocks> lstBlocks = new List<DescriptionBlocks>();
        string[] posHiding = inputPositionBlocksHiding.text.Split('-');
        string[] posSolid = inputPositionBlocksSolid.text.Split('-');
        foreach (string pos in posHiding)
        {
            DescriptionBlocks block = new DescriptionBlocks();
            if (pos == "")
                break;
            
            block.SetType = BlockType.HidingPlace;
            block.Position = Convert.ToInt32(pos);
            lstBlocks.Add(block);
        }

        foreach (string pos in posSolid)
        {
            DescriptionBlocks block = new DescriptionBlocks();
            if (pos == "")
                break;
         
            block.SetType = BlockType.Solid;
            block.Position = Convert.ToInt32(pos);
            lstBlocks.Add(block);
        }

        return lstBlocks;
    }

    private List<DescriptionEnemies> GetListEnemies(int numberEnemies)
    {
        List<DescriptionEnemies> lstEnemies = new List<DescriptionEnemies>();
        
        float scaleValue = -0.0928333f * numberEnemies + 1.2785f;

        for (int x = 0; x < numberEnemies; x++)
        {
            DescriptionEnemies enemy = new DescriptionEnemies();
            enemy.Type = TypeEnemy.Basic;
            enemy.Scale = new float[] { scaleValue, scaleValue, scaleValue };

            if (UnityEngine.Random.value > 0.4f)
                enemy.Position = new float[] { UnityEngine.Mathf.Clamp(x * 15, 1, 40), UnityEngine.Mathf.Clamp(x * 15, 1, 40), 0 };
            else
                enemy.Position = new float[] { UnityEngine.Mathf.Clamp(x * 15, 60, 100), UnityEngine.Mathf.Clamp(x * 15, 60, 100), 0 };

            enemy.MagnitudVelocity = -Convert.ToInt16(inputEnemiesVelocity.text);
            lstEnemies.Add(enemy);
        }

        return lstEnemies;
    }
}
