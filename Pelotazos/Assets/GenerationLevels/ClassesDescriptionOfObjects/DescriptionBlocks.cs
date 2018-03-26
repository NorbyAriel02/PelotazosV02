using System;
using System.Collections;
using System.Collections.Generic;

[Serializable()]
public class DescriptionBlocks  {
    private BlockType type = BlockType.Solid;
    public BlockType Type { get { return type; } }
    public BlockType SetType { set {  type = value; } }
    public int Position { get; set; }//por ahora del 0 al 8
}
[Serializable()]
public enum BlockType
{
    Solid,
    HidingPlace,
    Thorny
}
