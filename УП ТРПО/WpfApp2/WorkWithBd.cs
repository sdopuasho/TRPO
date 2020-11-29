using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class WorkWithBd
    {
        GanEntities con = new GanEntities();
        string result;
        public string convert(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1) - 1)
                    {
                        result += matrix[i, j].ToString() + "} {";
                    }
                    else
                    {
                        result += matrix[i, j].ToString();
                    }
                }
            }
            return result;

        }
        public void addmatrixbd(int[,] matrix)
        {
            string str = convert(matrix);
            Matrix MIB = new Matrix()
            {
                Matrix1 = str,
                i = matrix.GetLength(0),
                j = matrix.GetLength(1)
            };
            con.Matrix.Add(MIB);
            con.SaveChanges();
        }
        public int CheckFromBd(int[,] matrix)
        {
            string a = convert(matrix);
            int i2 = matrix.GetLength(0), j2 = matrix.GetLength(1);
            return con.Matrix.Where(w => w.Matrix1 ==a && w.i == i2 && w.j == j2).Select(s => s.id).FirstOrDefault();
        }
    }
}
