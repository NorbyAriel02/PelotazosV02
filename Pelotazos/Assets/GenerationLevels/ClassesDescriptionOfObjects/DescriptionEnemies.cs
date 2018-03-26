using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using UnityEngine;

[Serializable()]
public class DescriptionEnemies 
{
    private TypeEnemy type;
    
    private float[] scale = new float[3];
    private float[] position = new float[3];

    public float[] Scale
    {
        get  { return scale; }
        set { scale = value; }
    }

    public float[] Position
    {
        get { return position; }
        set { position = value;}
    }

    private int magnitudVelocity;
    
    public TypeEnemy Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }
    
    internal int MagnitudVelocity
    {
        get
        {
            return magnitudVelocity;
        }

        set
        {
            magnitudVelocity = value;
        }
    }
}

[Serializable()]
public enum TypeEnemy
{
    Basic,
    Fire,
    Ice
}