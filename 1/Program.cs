//Microsoft Visual Studio Professional 2013
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------Чтение матрицы из файла----------
            var line = File.ReadAllLines("input.txt", Encoding.Default);
            var n = line.Length;
            var matrix = new int[n][];
            var sumDiagonals = new int[2*n - 1];
            for (var i = 0; i < n; i++)
            {
                line[i] = Regex.Replace(line[i], @"[^0-9 \-]", String.Empty);
                var item = line[i].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
                var m = item.Length;
                if (m != n)
                {
                    File.WriteAllText("output.txt","Проверьте входные данные");
                    Environment.Exit(0);
                }
                matrix[i] = new int[m];
                for (var j = 0; j < m; j++)
                    matrix[i][j] = Convert.ToInt32(item[j]);
            }
            //-------------------------------------------

            //----------Суммирование диагоналей----------
            for (var i = 0; i < 2*n - 1; i++)
                sumDiagonals[i] = 0;
            for (var i = 0; i < n; i++)
            {
                sumDiagonals[0] += matrix[i][i];
                for (var j = 1; j + i < n; j++)
                {
                    sumDiagonals[j] += matrix[i][i + j];
                    sumDiagonals[n + j - 1] += matrix[i + j][i];
                }
            }
            //-------------------------------------------

            //----------Поиск максимальной суммы диагонали исключая главную диагональ----------
            var maxSumDiagonals = sumDiagonals[1];
            for (var i = 2; i < 2*n - 1; i++)
            {
                if (sumDiagonals[i] > maxSumDiagonals)
                {
                    maxSumDiagonals = sumDiagonals[i];
                }
            }
            //---------------------------------------------------------------------------------

            //----------Вывод максимальной суммы диагонали----------
            File.WriteAllText("output.txt", maxSumDiagonals.ToString());
            //------------------------------------------------------
        }
    }
}
