using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometricalFuntion {

    Polynomial pol = new Polynomial();
    /// <summary>
    /// [a*level**2 + b*level + c] Con el numero de nivel y un conjunto de constantes, calcula la funcion polinomica y devuelve el valor de F(level)
    /// </summary>    
    /// <returns>Double</returns>
    public double Polynomial(int level, double[] constants)
    {
        foreach (double value in constants)
        {
            pol.constants.Add(value);
        }
        return pol.Function(level); ;
    }

    Logarithmic log = new Logarithmic();
    /// <summary>
    /// Con el numero de nivel y un conjunto de constantes, calcula la funcion Logaritmica y devuelve el valor de Log(level) Clampeado entre los valores de las constantes
    /// </summary>    
    /// <returns>Double</returns>
    public double Logarithmic(int level, int clapMin, int clapMax, float smooth)
    {
        return log.FunctionABS(level, clapMin, clapMax, smooth);
    }
}

public class Logarithmic
{
    public double FunctionABS(int level, int clapMin, int clapMax, float smooth)
    {        
        return Math.Abs(Mathf.Clamp(level, clapMin, clapMax) * smooth * Math.Log(level)); 
    }

    public double Function(int level, int clapMin, int clapMax, float smooth)
    {
        return (Mathf.Clamp(level, clapMin, clapMax) * smooth * Math.Log(level));
    }
}

public class Polynomial
{    
    public List<double> constants = new List<double>();
      
    public double Function(int level)
    {
        double x = 0;
        int pow = 0;
        foreach (double value in constants)
        {
            x += value * Math.Pow(level, pow++);
        }
        return x;
    }
}
