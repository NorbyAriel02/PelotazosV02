using System;
using System.Collections;
using System.Collections.Generic;
[Serializable()]
public class DescriptionEdge  {
    private EdgeType type = EdgeType.Normal;
    public EdgeType Type { get { return type; } }
    public EdgeType SetType { set { type = value; } }
}
[Serializable()]
public enum EdgeType
{
    Normal,
    Fire,
    Thorny
}