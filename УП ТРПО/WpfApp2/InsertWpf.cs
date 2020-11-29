using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class InsertWpf
    {
        public int[,] insert(string str, int num1, int num2)
        {
            int[] forresult = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(k => int.Parse(k.Trim())).ToArray();
            int[,] a = new int[num2, num1];
            int s=0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i,j] = forresult[s];
                    s++;
                }
            }
            return a;
        }
        public int[] insertlow(string str)
        {
            int[] result = str.Split(new[] { ' ', '}', '{' }, StringSplitOptions.RemoveEmptyEntries).Select(k => int.Parse(k.Trim())).ToArray();
            return result;
        }
    }
}
