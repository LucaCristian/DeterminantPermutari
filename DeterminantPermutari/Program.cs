using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeterminantPermutari
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduceti ordinul matricei: ");
            int n = int.Parse(Console.ReadLine());
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = rnd.Next(10);

            afisare(a);
            Console.WriteLine($"Determinanul matricei este {calculDeterminant(a)}.");

            Console.ReadKey();
        }
        public static Random rnd = new Random();
        public static int[,] matrice(int[,] old, int linie, int coloana)
        {
            int n = old.GetLength(0);
            int[,] aux = new int[n - 1, n - 1];

            for (int i = 0; i < linie; i++)
            {
                for (int j = 0; j < coloana; j++)
                {
                    aux[i, j] = old[i, j];
                }
            }

            for (int i = linie + 1; i < n; i++)
            {
                for (int j = 0; j < coloana; j++)
                {
                    aux[i - 1, j] = old[i, j];
                }
            }

            for (int i = 0; i < linie; i++)
            {
                for (int j = coloana + 1; j < n; j++)
                {
                    aux[i, j - 1] = old[i, j];
                }
            }

            for (int i = linie + 1; i < n; i++)
            {
                for (int j = coloana + 1; j < n; j++)
                {
                    aux[i - 1, j - 1] = old[i, j];
                }
            }
            return aux;
        }

        public static int calculDeterminant(int[,] a)
        {
            int n = a.GetLength(0);
            if (n == 1)
                return a[0, 0];
            else
            {
                int s = 0;
                for (int i = 0; i < n; i++)
                    s += (int)Math.Pow(-1, i) * a[0, i] * calculDeterminant(matrice(a, 0, i));
                return s;
            }
        }

        public static void afisare(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
