using System;
using System.Collections.Generic;

public class GeneratorLevel {
	public Double[] values = {1, 1, 1};
	public float coefficientOfVariationForBlocks = 0.05f;
	public float coefficientOfVariationForEnemies = 0.08f;
	public float coefficientOfVariationForApples = 0.07f;
	public float coefficientScaleEnemyB = 1.2785f;
	public float coefficientScaleEnemyM = -0.0928333f;
	private List<Level> listLVL = new List<Level> ();
	
	public List<Level> GetListLevel(int numbersOfLevels)
	{
		for (int x = 1; x <= numbersOfLevels; x++) {
			Level lvl = StartGeneratorLevel (x);
			listLVL.Add (lvl);
		}

		return listLVL;
	}

	public void SetValuesFuntion(string sValues)
	{
		int index = 0;
		foreach (string val in sValues.Split(','))
		{
			values[index] = Convert.ToDouble(val);
			index++;
		}
	}

	public void SetD(double val)
	{
		values[3] = val;
	}

	public void SetA(double val)
	{
		values[0] = val;
	}

	public void SetB(double val)
	{
		values[1] = val;
	}

	public void SetC(double val)
	{
		values[2] = val;
	}

	public void SetX(double val)
	{
		values[4] = val;
	}

	public double GetA()
	{
		return values[0];
	}

	public double GetB()
	{
		return values[1];
	}

	public double GetC()
	{
		return values[2];
	}

	public double GetD()
	{
		return values[3];
	}

	private Level StartGeneratorLevel(int numberLevel)
	{
		return new Level
		{
			NumberLevel = numberLevel,
			Apples = GetPointLevel(numberLevel),
			ObjectList = GetListObject(numberLevel)
		};
	}

	private ListOfLevelObject GetListObject(int level)
	{
		ListOfLevelObject listObj = new ListOfLevelObject();

		List<DescriptionEnemies> lstEnemies = GetListEnemies (level);
		List<DescriptionBlocks> listBlock = GetListBlock(level);
		
		listObj.Add (lstEnemies, TypeObjectLevel.Enemies);
		listObj.Add(listBlock, TypeObjectLevel.Blocks);

		return listObj;
	}

	private List<DescriptionBlocks> GetListBlock(int level)
	{
		List<DescriptionBlocks> listBlock = new List<DescriptionBlocks>();
		int numberBlock = UnityEngine.Mathf.RoundToInt(coefficientOfVariationForBlocks * level);
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
		List<DescriptionEnemies> lstEnemies = new List<DescriptionEnemies> ();

		int numberEnemies = 2 + UnityEngine.Mathf.RoundToInt(coefficientOfVariationForEnemies*level);

		float scaleValue = coefficientScaleEnemyM * numberEnemies + coefficientScaleEnemyB;

		for (int x = 0; x < numberEnemies; x++) {
			DescriptionEnemies enemy = new DescriptionEnemies();
			enemy.Type = TypeEnemy.Basic;
			enemy.Scale = new float[] { scaleValue, scaleValue, scaleValue };
			enemy.Position = new float[] { UnityEngine.Mathf.Clamp(x * 15, 1, 100), UnityEngine.Mathf.Clamp(x * 15, 1, 100), 0 };
			enemy.MagnitudVelocity = UnityEngine.Random.Range(-18, -28);
			lstEnemies.Add (enemy);
		}

		return lstEnemies;
	}


	private double GetPointLevel(int level)
	{
		return (5 + UnityEngine.Mathf.RoundToInt(coefficientOfVariationForApples*level));
	}
}
