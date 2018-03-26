using System;
using System.Collections;
using System.Collections.Generic;

[Serializable()]
public class Level
{

    private ListOfLevelObject objectList;

    internal int numberLevel;

    internal int numberOfObject;

    internal Double apples;

    public Level()
    {
        ObjectList = new ListOfLevelObject();
    }
     
    internal int NumberLevel
    {
        get
        {
            return numberLevel;
        }

        set
        {
            numberLevel = value;
        }
    }

    internal double Apples
    {
        get
        {
            return apples;
        }

        set
        {
            apples = value;
        }
    }

    internal ListOfLevelObject ObjectList
    {
        get
        {
            return objectList;
        }

        set
        {
            objectList = value;
        }
    }
}

[Serializable()]
internal class ListOfLevelObject
{
    ArrayList objectList = new ArrayList();

    Dictionary<string, int> positionInTheList = new System.Collections.Generic.Dictionary<string, int>();

    public void Add(Object obj, string sKey)
    {
        positionInTheList.Add(sKey, objectList.Count);
        objectList.Add(obj);
    }

    public Object Get(string sKey)
    {
        return objectList[positionInTheList[sKey]];
    }
}

[Serializable()]
public static class TypeObjectLevel
{
    public static string Enemies { get { return "ENEMIES"; } }


    public static string Blocks { get { return "BLOCKS"; } }

}