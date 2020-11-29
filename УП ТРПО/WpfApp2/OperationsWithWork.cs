using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class OperationsWithWork
    {
        public int[,] VectorTranspos(int[,] matrix, int[] matr )
        {
            int[,] matix = matrix;
            for (int i = matr.Length - 1, b = 0; b < matrix.GetLength(0); i--, b++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matix[b, j] = matrix[matr[i] - 1, j];
                }
            }
            return matix;
        }
        public int[,] MatrixUmScalar(int[,] matix)
        {
            int[,] matrix = matix;
            int[,] scalarmatrix = new int[matix.GetLength(1), matix.GetLength(0)];
            for (int i = 0; i < matix.GetLength(0); i++)
            {
                for (int j = 0; j < matix.GetLength(1); j++)
                {
                    scalarmatrix[j, i] = matrix[i, j];
                }
            }
            int[,] resultmatrix = new int[matrix.GetLength(0), scalarmatrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < scalarmatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < scalarmatrix.GetLength(0); k++)
                    {
                        resultmatrix[i, j] += matrix[i, k] * scalarmatrix[k, j];
                    }
                }
            }
            return resultmatrix;
        }
        public int[,] matrixxscalar(int[,] matix, int scalar)
        {
            int[,] matrix = matix;
            for (int i = 0; i < matix.GetLength(0); i++)
            {
                for (int j = 0; j < matix.GetLength(1); j++)
                {
                    matrix[i, j] *= scalar;
                }
            }
            return matrix;
        }
        public int[,] movestroks(int[,] matrix, int num1, int num2)
        {
            int[,] array = matrix;
            int[,] resultArray = new int[6, 5];
            int k = num1 -1;
            int kaka = num2 -1;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    resultArray[i, j] = array[i, j];
                }
            }
            for (int i = 0; i < array.GetLength(1); i++)
            {
                array[k, i] = resultArray[kaka, i];
                array[kaka, i] = resultArray[k, i];
            }
            return array;
        }
        public int[,] ArrayTrans(int[,] matrix)
        {
            int[,] arrayy = matrix;
            int[,] tranmatr = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    tranmatr[j, i] = arrayy[i, j];
                }
            }
            return tranmatr;
        }
        public int[,] MatOp(int[,] matrix, int[,] matrix2, int cases)
        {
            int[,] array1 = matrix;
            int[,] array2 = matrix2;
            int[,] resultarray = new int[matrix.GetLength(0), matrix2.GetLength(1)]; 
            switch (cases)
            {
                case 1:
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            resultarray[i, j] = array1[i, j] + array2[i, j];
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {

                            resultarray[i, j] = array1[i, j] - array2[i, j];
                        }
                    }
                    break;
            }
            return resultarray;
        }
    }
}
