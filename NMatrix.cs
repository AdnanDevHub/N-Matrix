using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class DimensionMismatchException : Exception { };
    public class OutofNMatrixException : Exception { };
    public class NegativeSizeException : Exception { };
    public class MatrixNotSetException : Exception { };

    public class NMatrix
    {
        private List<int> matrix;
        private int n;
        private bool isSetMatrix = false;

        public NMatrix() 
        {
            n = 4;
            int length = n*n;
            matrix = new List<int>(length);
            for (int i = 0; i < length; i++)
            {
                matrix.Add(0);
            }


        }
        public NMatrix(int size)
        { 
           
            isSetMatrix = true;
            this.n = size;
            int length = n * n;
            matrix = new List<int>(length);
            for(int i = 0; i < length; i++) 
            {
                matrix.Add(i+1);
            }
        }

        private bool isNMatrix(int i, int j)
        {
            return i == j || j == 0 || j == n - 1;
        }
        public int Get(int i, int j)
        {
            if (!isSetMatrix)
            {
                throw new MatrixNotSetException();
            }
            if (i < 0 || i >= n || j < 0 || j >= n)
            {
                throw new OutofNMatrixException();
            }
            if (isNMatrix(i, j))
            {
                return matrix[i * n + j];
            }
            
                return 0;
           
        }



        public void Set(int i, int j, int value)
        {
            if (i < 0 || i >= n || j < 0 || j >= n)
            {
                throw new OutofNMatrixException();
            }
            
            if (isNMatrix(i,j))
            {
                matrix[i * n + j] = value;
            }
            else if (value != 0)
            {
                throw new ArgumentException("Invalid position for nonzero value");
            }
        }

        public void AddValues()
        {
            isSetMatrix = true;
            Console.WriteLine("Enter values for the matrix:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (isNMatrix(i,j))
                    {
                        Console.Write($"Enter value for position [{i},{j}]: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        Set(i, j, value);
                    }
                }
            }
        }

        
        public static NMatrix Add(NMatrix m1, NMatrix m2)
        {
            if (m1.n != m2.n)
            {
                throw new DimensionMismatchException();
            }
            NMatrix sum = new NMatrix(m1.n);
            for (int i = 0; i < m1.n; i++)
            {
                for (int j = 0; j < m1.n; j++)
                {
                    sum.Set(i, j, m1.Get(i, j) + m2.Get(i, j));
                }
            }

            return sum;
           
            
        }

        public static NMatrix Multiply(NMatrix m1, NMatrix m2)
        {
            if (m1.n != m2.n)
            {
                throw new DimensionMismatchException();
            }
            NMatrix result = new NMatrix(m1.n);
      
            for (int i = 0; i < m1.n; i++)
            {
                for (int j = 0; j < m1.n; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < m1.n; k++)
                    {
                        sum += m1.Get(i, k) * m2.Get(k, j);
                    }
                    result.Set(i, j, sum);
                }
            }

            return result;
        

    }

        public override string ToString()
        {
            if (isSetMatrix == false)
            {
                throw new MatrixNotSetException();
            }
            string print = $"{n}x{n}\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    print += Get(i, j).ToString().PadLeft(4);
                }
                print += "\n";
            }
            return print;
        }
        public override bool Equals(object obj)
        {
            var item = obj as NMatrix;
            return item.n == n;
        }
    }
}
