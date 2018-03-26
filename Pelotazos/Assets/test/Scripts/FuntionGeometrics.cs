using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace consola_pruebas
{
    /*Esta debe recibir el numero de nivel 
     * y devolver un valor numerio que se 
     * asignara a una de las propiedades del nivel*/
    class FuntionGeometrics
    {
        public Double[] values = { 1, 1, 1, 1, 1 };
        public void setValuesFuntion(string sValues)
        {
            int index = 0;
            foreach (string val in sValues.Split(','))
            {
                values[index] = Convert.ToDouble(val);
                index++;
            }
        }

        public void setD(double val)
        {
            values[3] = val;
        }

        public void setA(double val)
        {
            values[0] = val;
        }

        public void setB(double val)
        {
            values[1] = val;
        }

        public void setC(double val)
        {
            values[2] = val;
        }

        public void setX(double val)
        {
            values[4] = val;
        }

        public string GetValues()
        {
            string result = "";
            foreach (double val in values)
            {
                result += "  " + val.ToString();
            }
            return result;
        }

        private double GetPointLevel(int level)
        {
            //ax3+bx2+cx+d a = b = c = d = 1            
            double a = values[0];
            double b = values[1];
            double c = values[2];
            double d = values[3];
            Double x = values[3] + level;
            x = a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * Math.Pow(x, 1) + d;

            return x;
        }


    }
}
