using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Menu
    {
        
        private NMatrix matrix = new NMatrix();

        public void Run()
        {
            int num;
            do
            {
                num = GetMenuChoice();
                switch (num)
                {
                    case 1:
                        CreateMatrix();

                        break;
                    case 2:
                        GetElement();
                        break;
                    case 3:
                        AddMatrix();
                        break;
                    case 4:
                        MultiplyMatrix();
                        break;
                    case 5:
                        PrintMatrix();
                        break;

                    default:
                        Console.WriteLine("Have a nice Day :-)");
                        break;
                }

            } while (num != 0);

        }




        private void DisplayMenu()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create Matrix");
            Console.WriteLine("2. Get Element");
            Console.WriteLine("3. Add Matrix");
            Console.WriteLine("4. Multiply Matrix");
            Console.WriteLine("5. Print Matrix");

            Console.WriteLine("*********************************");

        }
        private int GetMenuChoice()
        {
            int choice;
            do
            {
                DisplayMenu();
                Console.WriteLine("Enter your choice");
                try
                {
                    choice = int.Parse(Console.ReadLine()!);
                }
                catch (System.FormatException)
                {
                    choice = -1;
                }
            } while (choice < 0 || choice > 5);
            return choice;
        }
        private void CreateMatrix()
        {
            try
            {
                Console.WriteLine("Enter size of matrix");
                int size = int.Parse(Console.ReadLine()!);
                matrix = new NMatrix(size);
                matrix.AddValues();
                Console.WriteLine("Matrix created successfully!");
                Console.WriteLine($"{matrix.ToString()}");
            }
            catch (NegativeSizeException)
            {
                Console.WriteLine("Size must be greater than 0");
            }


        }
        private void GetElement()
        {

            try
            {
                Console.Write("Enter the index i j :: ");
                string[] input = (Console.ReadLine()!).Split(" ");
                int i = int.Parse(input[0]);
                int j = int.Parse(input[1]);
                int element = matrix.Get(i, j);
                Console.WriteLine($"Element at index {i} {j} is: {element}");
            }
            catch (OutofNMatrixException)
            {
                Console.WriteLine("Exception caught: Index outside of matrix");
            }
            catch (MatrixNotSetException)
            {
                Console.WriteLine("Exception caught: Set matrix first");
            }
        }
        private void AddMatrix()
        {
            try
            {
                Console.WriteLine("Enter size for matrix 1");
                int size1 = int.Parse(Console.ReadLine()!);
                NMatrix matrix1 = new NMatrix(size1);
                matrix1.AddValues();
                Console.WriteLine("Matrix created successfully!");
                Console.WriteLine("Enter size for matrix 2");
                int size2 = int.Parse(Console.ReadLine()!);
                NMatrix matrix2 = new NMatrix(size2);
                matrix2.AddValues();
                Console.WriteLine("Matrix created successfully!");

                NMatrix result = NMatrix.Add(matrix1, matrix2);
                Console.WriteLine("Added successfully!");
                Console.WriteLine($"{result.ToString()}\n\n");
            }
            catch (NegativeSizeException)
            {
                Console.WriteLine("Size must be greater than 0");
            }
            catch (DimensionMismatchException)
            {
                Console.WriteLine("Exception caught: invalid sum");
            }

        }
        private void MultiplyMatrix()
        {
            Console.WriteLine("Enter size for matrix 1");
            int size1 = int.Parse(Console.ReadLine()!);
            NMatrix matrix1 = new NMatrix(size1);
            matrix1.AddValues();
            Console.WriteLine($"{matrix1.ToString() }");
            Console.WriteLine("Matrix created successfully!");
            Console.WriteLine("Enter size for matrix 2");
            int size2 = int.Parse(Console.ReadLine()!);
            NMatrix matrix2 = new NMatrix(size2);
            matrix2.AddValues();
            Console.WriteLine($"{matrix2.ToString()}");
            Console.WriteLine("Matrix created successfully!");

            try
            {
                NMatrix result = NMatrix.Multiply(matrix1, matrix2);
                Console.WriteLine("Multiplied successfully!");
                Console.WriteLine($"{result.ToString()}");
            }
            catch (DimensionMismatchException)
            {
                Console.WriteLine("Exception caught: invalid multiplication");
            }
        }
        private void PrintMatrix()
        {
            try
            {
                Console.WriteLine($"{matrix.ToString()}\n\n");

            }
            catch (MatrixNotSetException)
            {
                Console.WriteLine("Exception caught: Set Matrix first");
            }
        }
    }
   
}
