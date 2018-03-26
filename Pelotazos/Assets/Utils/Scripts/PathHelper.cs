using System.IO;
using UnityEngine;

public class PathHelper {

    public static string Score
    {
        get
        {
            string FilePath = "";

            if (Application.platform == RuntimePlatform.Android)
            {
                FilePath = Path.Combine(Application.persistentDataPath, KeyNames.FileScore);
            }
            else
            {
                FilePath = Path.Combine(Application.streamingAssetsPath, KeyNames.FileScore);
            }

            return FilePath;
        }
    }

    public static string Log
    {
        get
        {
            string FilePath = "";

            if (Application.platform == RuntimePlatform.Android)
            {
                FilePath = Path.Combine(Application.persistentDataPath, KeyNames.FileErrorLog);
            }
            else
            {
                FilePath = Path.Combine(Application.streamingAssetsPath, KeyNames.FileErrorLog);
            }

            return FilePath;
        }
    }

    public static string ScremShot
    {
        get
        {
            string FilePath = "";

            if (Application.platform == RuntimePlatform.Android)
            {
                FilePath = Path.Combine(Application.persistentDataPath, "pelotazos.png");
            }
            else
            {
                FilePath = Path.Combine(Application.streamingAssetsPath, "pelotazos.png");
            }

            return FilePath;
        }
    }

    public static string Mail
    {
        get
        {
            string FilePath = "";

            if (Application.platform == RuntimePlatform.Android)
            {
                FilePath = Path.Combine(Application.persistentDataPath, KeyNames.FileDataMail);
            }
            else
            {
                FilePath = Path.Combine(Application.streamingAssetsPath, KeyNames.FileDataMail);
            }

            return FilePath;
        }
    }
}
