using System;
using System.Collections;
using System.Collections.Generic;

public class KeyNames
{
    #region PlayerPref
    public static string CurrentLevel { get { return "CURRENTLEVEL"; } }
    public static string MaxLevelUnlocked { get { return "MAXLEVELUNLOCKED"; } }
    public static string JoystickMonoCommand { get { return "JoystickMonoCommand"; } }
    public static string AudioEffectVolume { get { return "EffectVolume"; } }
    public static string AudioMusictVolume { get { return "MusicVolume"; } }
    public static string SendUserFeedback { get { return "SendUserFeedback"; } }
    #endregion

    #region SCENES
    /*Desarrollo*/
    public static string Stage { get { return "Level"; } }
    public static string LevelSelector { get { return "LevelsSelector"; } }
    public static string Controllers { get { return "Controller"; } }
    /*produccion*/
    //public static string Stage { get { return "Stage"; } }
    public static string Menu { get { return "Menu"; } }
    #endregion

    #region Files
    public static string FileScore { get { return "Score.dat"; } }
    public static string FileDataLevel { get { return "test03.dat"; } }
    public static string FileErrorLog { get { return "error.log"; } }
    public static string FileDataMail { get { return "mail.log"; } }
    #endregion

}
