using System;
using System.IO;
using System.Text;
using UnityEngine;
using System.Collections.Generic;
class xxxx
{
	const string NameFileDataLevel = "NameFileDataLevel";
    const string ExtensionFileData = ".json";
	public Double[] values = {1,1,1,1,1};
	public xxxx()
	{
	}

	public void StartDataLevel()
	{
		string json = SerializationLevelsToJON();
		WriteFile(json, NameFileDataLevel);
	}

	private void WriteFile(string value, string nameFile)
	{
		nameFile += ".json";
		string pathFolder = Path.Combine(Application.dataPath, "Datos");
		if (!Directory.Exists(pathFolder))
		{
			Directory.CreateDirectory(pathFolder);
		}
		string fullPath = Path.Combine(pathFolder, nameFile);

		File.WriteAllText(fullPath, value);
	}

	private string ReadFile(string nameFile)
	{
		string result = "El archivo no Existe";
		nameFile += ".json";
		string pathFolder = Path.Combine(Application.dataPath, "Datos");
		string fullPath = Path.Combine(pathFolder, nameFile);
		if (File.Exists(fullPath))
		{
			result = File.ReadAllText(fullPath);
		}
		return result;
	}

	public Level GetDataLevel(int numberLevel)
	{            
		string json = ReadFile(NameFileDataLevel);
		List<Level> levels = DeserializedJSONToLeves(json);
		foreach (Level level in levels)
		{
			if (level.NumberLevel == numberLevel)
				return level;
		}            
		return null;
	}

	public static List<Level> DeserializedJSONToLeves(string json)
	{
		List<Level> deserializedLevel = new List<Level>();
		MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

		System.Runtime.Serialization.DataContractSerializer ser = new System.Runtime.Serialization.DataContractSerializer(deserializedLevel.GetType());
		deserializedLevel = ser.ReadObject(ms) as List<Level>;
		ms.Close();
		return deserializedLevel;
	}

	public void setValuesFuntion(string sValues)
	{
		int index = 0;
		foreach (string val in sValues.Split(','))
		{
			values[index] = Convert.ToDouble(val);
			index++;
		}
	}

	public void setD(double val)
	{
		values[3] = val;
	}

	public void setA(double val)
	{
		values[0] = val;
	}

	public void setB(double val)
	{
		values[1] = val;
	}

	public void setC(double val)
	{
		values[2] = val;
	}

	public void setX(double val)
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

    private string SerializationLevelsToJON()
	{
		List<Level> levels = new List<Level>();
		for (int index = 0; index <= 100; index++)
		{
			Level level = new Level();
			level = GeneratorLevel(index);
			levels.Add(level);
		}          

		MemoryStream ms = new MemoryStream();

		System.Runtime.Serialization.DataContractSerializer ser = new System.Runtime.Serialization.DataContractSerializer(typeof(List<Level>));
		ser.WriteObject(ms, levels);
		byte[] json = ms.ToArray();
		ms.Close();
		return Encoding.UTF8.GetString(json, 0, json.Length);
	}

	private Level GeneratorLevel(int numberLevel)
	{
        return new Level
        {
            NumberLevel = numberLevel,
           // VictoryCondition = VictoryCondition.point,            
           // PointsToWin = GetPointLevel(numberLevel),
           // NumberOfEnemies = 2
        };
    }

	private double GetPointLevel(int level)
	{
		//ax3+bx2+cx+d a = b = c = d = 1            
		double a = values[0];
		double b = values[1];
		double c = values[2];
		double d = values[3];
		Double x = values[3] + level;
		x = a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * Math.Pow(x, 1) + d;

		return x;
	}

	public string GetValues()
	{
		string result= "";
		foreach(double val in values)
		{
			result += "  " + val.ToString();
		}
		return result;
	}

	public static string WriteFromObject()
	{
		Level level = new Level();

		MemoryStream ms = new MemoryStream();

		System.Runtime.Serialization.DataContractSerializer ser = new System.Runtime.Serialization.DataContractSerializer(typeof(Level));
		ser.WriteObject(ms, level);
		byte[] json = ms.ToArray();
		ms.Close();
		return Encoding.UTF8.GetString(json, 0, json.Length);
	}

	public static Level ReadToObject(string json)
	{
		Level deserializedLevel = new Level();
		MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
		System.Runtime.Serialization.DataContractSerializer ser = new System.Runtime.Serialization.DataContractSerializer(deserializedLevel.GetType());
		deserializedLevel = ser.ReadObject(ms) as Level;
		ms.Close();
		return deserializedLevel;
	}
}

enum VictoryCondition
{
    byTime,
    point,
    forKillingEnemies
}

enum Prefabs
{
    Enemies = 0,
    Apples,
    Ammor
}