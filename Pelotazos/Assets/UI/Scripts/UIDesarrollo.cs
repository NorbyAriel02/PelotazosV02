using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIDesarrollo : MonoBehaviour {
    public InputField inputLvl;
    public InputField inputEnemies;
    public InputField inputScaleEnemies;
    public InputField inputBlocks;
    public InputField inputApples;
    
    public Button btnSave;
    
    void Start () {
        btnSave.onClick.AddListener(Save);
	}
	
	void Update () {
		
	}

    private void Save()
    {
        SaveData saveData = new SaveData();
        Level lvl = StartGeneratorLevel();
        saveData.UpdateDataLevel(lvl);
    }

    private Level StartGeneratorLevel()
    {
        return new Level
        {
            NumberLevel = Convert.ToInt16(inputLvl.text),
            Apples = Convert.ToDouble(inputApples.text),
            ObjectList = GetListObject(Convert.ToInt16(inputLvl.text))
        };
    }

    private ListOfLevelObject GetListObject(int level)
    {
        ListOfLevelObject listObj = new ListOfLevelObject();

        List<DescriptionEnemies> lstEnemies = GetListEnemies(level);
        List<DescriptionBlocks> listBlock = GetListBlock(level);

        listObj.Add(lstEnemies, TypeObjectLevel.Enemies);
        listObj.Add(listBlock, TypeObjectLevel.Blocks);

        return listObj;
    }

    private List<DescriptionBlocks> GetListBlock(int level)
    {
        List<DescriptionBlocks> listBlock = new List<DescriptionBlocks>();
        int numberBlock = Convert.ToInt16(inputBlocks.text);
        for (int x = 0; x < numberBlock; x++)
        {
            DescriptionBlocks descriptionBlock = new DescriptionBlocks(); ;
            descriptionBlock.SetType = BlockType.Solid;
            listBlock.Add(descriptionBlock);
        }
        return listBlock;
    }

    private List<DescriptionEnemies> GetListEnemies(int level)
    {
        List<DescriptionEnemies> lstEnemies = new List<DescriptionEnemies>();

        int numberEnemies = Convert.ToInt16(inputEnemies.text);

        float scaleValue = Convert.ToInt16(inputScaleEnemies.text);

        for (int x = 0; x <= numberEnemies; x++)
        {
            DescriptionEnemies enemy = new DescriptionEnemies();
            enemy.Type = TypeEnemy.Basic;
            enemy.Scale = new float[] { scaleValue, scaleValue, scaleValue };
            enemy.Position = new float[] { UnityEngine.Mathf.Clamp(x * 15, 1, 100), UnityEngine.Mathf.Clamp(x * 15, 1, 100), 0 };
            enemy.MagnitudVelocity = UnityEngine.Random.Range(-18, -28);
            lstEnemies.Add(enemy);
        }

        return lstEnemies;
    }
    
}
