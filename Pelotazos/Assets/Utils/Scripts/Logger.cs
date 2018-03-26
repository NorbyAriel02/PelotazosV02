using System.IO;
using System;
using UnityEngine;
public abstract class LogBase
{
    public abstract void Log(string message, string filePath);
}
public class Logger : LogBase  {
    public override void Log(string message, string filePath)
    {
        using (StreamWriter streamWriter = new StreamWriter(filePath, true))
        {            
            streamWriter.WriteLine(DateTime.Now.ToLongDateString());
            streamWriter.WriteLine(message);
            streamWriter.WriteLine("------------------------------------------");
            streamWriter.Close();
        }
    }
}
