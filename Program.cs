using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lgra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задайте названия соревнующихся комнад через запятую");
            string[,] matrix = SetTeams(); //задаем таблицу команд
            string[,] tournament = CreateTournamentTable(matrix); //создаем турнирную таблицу
            ShowMatrix(tournament);
            Console.ReadLine();
        }

        static string[,] SetTeams()
        {
            string input = Console.ReadLine();//получаем данные из консоли
            string[] arrInput = input.Split(',');//разбиваем полученную строку на отдельные элементы
            string[,] matrix = new string[arrInput.GetLength(0) + 1, arrInput.GetLength(0) + 1];//создаем двумерный массив (матрицу)
            for (int i = 1; i <= arrInput.GetLength(0); i++)//цикл, забивающий матрицу
            {
                matrix[0, i] = arrInput[i - 1];//Забиваем первую строку матрицы, начиная со 2 элемента
                matrix[i, 0] = arrInput[i - 1];//Забиваем первую колонку матрицы, начиная со 2 эелмента
            }
            return matrix;//"возвращаем" матрицу
        }
        static string[,] CreateTournamentTable(string[,] matrix)
        {
            matrix[0, 0] = "-----";
            int matchCounter = 1;//создаем счетчик матчей
            for (int m = 2; m<= matrix.GetLength(0); m++)//перебор строк матрицы циклом
            {
                for (int n = 2; n <= matrix.GetLength(1); n++)//перебор колонок матрицы циклом
                {
                    if (matrix[m-1,0] == matrix[0, n-1])
                    {
                        matrix[m-1, n-1] = "-----";
                    }
                    else if (matrix[m-1,n-1] != "xxxxx")
                    {
                        matrix[m-1, n-1] = "Матч" + matchCounter;
                        matrix[n-1, m-1] = "xxxxx";
                        matchCounter++;//прибавляем 1 к счетчику матчей
                    }
                }
            }
            return matrix;//"возвращаем" матрицу
        }
        static private void ShowMatrix(string[,] matrix)//Алгоритм выведения матрицы на экран
        {  
            for (int m = 0; m <= matrix.GetLength(0) - 1; m++)//Перебор колонок матрицы
            {
                Console.WriteLine("");
                for (int n = 0; n <= matrix.GetLength(1) - 1; n++)//Перебор строк матрицы
                {
                    Console.Write(matrix[m, n] + " ");//Отправка в консоль элемента матрицы
                }
            }
        }
    }
}
