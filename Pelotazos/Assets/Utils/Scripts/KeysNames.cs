using System;
using System.Collections;
using System.Collections.Generic;

public class KeysNames
{
    #region PlayerPref
    public static string CurrentLevel { get { return "CURRENTLEVEL"; } }
    public static string ScoreLevel { get { return "ScoreLevel|"; } }
    public static string MaxLevelUnlocked { get { return "MAXLEVELUNLOCKED"; } }
    #endregion

    #region SCENES
    /*Desarrollo*/
    public static string Stage { get { return "Level"; } }
    public static string LevelSelector { get { return "LevelsSelector"; } }
    /*produccion*/
    //public static string Stage { get { return "Stage"; } }
    public static string Menu { get { return "Menu"; } }
    #endregion

}
