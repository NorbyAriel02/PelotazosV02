using System;

[Serializable()]
public class Score  {
    public int Level { get; set; }
    public int Value { get; set; }

    public Score()
    {
        Level = 0;
        Value = 0;
    }
}
