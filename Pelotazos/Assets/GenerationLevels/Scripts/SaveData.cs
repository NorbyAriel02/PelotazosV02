using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveData {
    private List<string> PathsList = new List<string>();
    private string sFile01 = @"test03.dat";        
    private Logger logger = new Logger();

    public SaveData()
    {
        try
        {
            Configuration();   
        }
        catch(Exception e)
        {
            logger.Log(e.Message+" "+e.StackTrace, PathHelper.Log);
        }
    }

    private void Configuration()
    {
        List<string> FilesListTemp = new List<string>();
        //Aca agrego uno a uno los nuevos archivos de datos tras las actualizaciones
        FilesListTemp.Add(sFile01);
        if (Application.platform == RuntimePlatform.Android)
        {   
            foreach (string file in FilesListTemp)
            {
                string PathOnAndroid = Path.Combine(Application.persistentDataPath, file);
                InitialUploadOfDataFiles(file, PathOnAndroid);
                PathsList.Add(PathOnAndroid);
            }
        }
        else
        {   
            foreach (string path in FilesListTemp)
            {
                string filePath = Path.Combine(Application.streamingAssetsPath, path);
                PathsList.Add(filePath);
            }
        }
    }

    private void InitialUploadOfDataFiles(string path, string PathOnAndroid)
    {
        if (File.Exists(PathOnAndroid))
            return;

        string fileDataPath = Path.Combine(Application.streamingAssetsPath, path);
        WWW www = new WWW(fileDataPath);

        while (www.isDone == false)
        {

        }
        
        File.WriteAllBytes(PathOnAndroid, www.bytes);
    }

    public void Save<T>(object obj, string path)
    {
        T _obj = (T)obj;
        FileStream fs = new FileStream(path, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            formatter.Serialize(fs, _obj);
        }
        catch (SerializationException e)
        {
            logger.Log(e.Message + " " + e.StackTrace, PathHelper.Log);
            throw;
        }
        finally
        {
            fs.Close();
        }
    }

    public T ReadToObject<T>(string path) where T : class, new()
    {
        T deserializedObject = null;
        FileStream fs = new FileStream(path, FileMode.Open);              
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();            
            deserializedObject = (T)formatter.Deserialize(fs);
        }
        catch (SerializationException e)
        {
            logger.Log(e.Message + " " + e.StackTrace, PathHelper.Log);
            throw;
        }
        finally
        {
            fs.Close();
        }
        return deserializedObject;
    }

    public void CreateFileDataLevels(List<Level> levels, string path)
    {
        Save<List<Level>>(levels, path);
    }

    public Level GetDataLevel(int numberLevel)
    {
        if (numberLevel <= 0)
            return null;

        List<Level> listLVL;
        foreach (string path in PathsList)
        {
            listLVL = ReadToObject<List<Level>>(path);
            int maxlevel = listLVL[listLVL.Count - 1].numberLevel;
            if (maxlevel < numberLevel)
                continue;

            numberLevel = numberLevel - 1;
            return listLVL[numberLevel];
        }

        return null;
    }

    public int GetScore(int level)
    {
        int index = (level - 1);
        List<Score> listScore = null;
        if (File.Exists(PathHelper.Score))
            listScore = ReadToObject<List<Score>>(PathHelper.Score);

        if (listScore == null)
            return 0;

        if (index > (listScore.Count - 1))
            return 0;
        
        return listScore[index].Value;
    }

    public void SaveScore(Score score)
    {
        try
        {
            List<Score> listScore = new List<Score>();
            if (!File.Exists(PathHelper.Score) && score.Level == 1)
            {
                listScore.Add(score);            
            }
            else
            {            
                listScore = ReadToObject<List<Score>>(PathHelper.Score);
                if (listScore == null)
                    return;

                int index = score.Level - 1;
                if (index > (listScore.Count - 1))
                    listScore.Add(score);
                else
                    listScore[index] = score;

            }
            Save<List<Score>>(listScore, PathHelper.Score);
        }
        catch(Exception e)
        {
            logger.Log(e.Message + " " + e.StackTrace, PathHelper.Log);
        }
    }

    public void UpdateDataLevel(Level lvl)
    {
        int numberLevel = lvl.numberLevel;
        List<Level> listLVL;
        foreach (string path in PathsList)
        {
            listLVL = ReadToObject<List<Level>>(path);            
            int maxlevel = listLVL[listLVL.Count - 1].numberLevel;
            if (maxlevel < numberLevel)
                continue;

            numberLevel = numberLevel - 1;
            listLVL[numberLevel] = lvl;
            CreateFileDataLevels(listLVL, path);
        }
    }

}
