using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {//I got a little fancy for no reason
            string[,] students = new string[2, 2] { {"Warren","Burger" },{"Gana","Egg" } };
            bool[,] checker = new bool[2, 2];
            string[] name = new string[2] { "Jordan", "Nana" };
            string temp = "";
            int studentNumber, category;


            while (true)
            {
                ask1:
                Console.Write("\nChoose a student (theres 2): ");
                studentNumber = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Enter 1 for town, 2 for food: ");
                category = int.Parse(Console.ReadLine()) - 1;
                if (studentNumber >= students.GetLength(0) || category >= students.GetLength(1))
                {
                    Console.WriteLine("One or more entries was too big...");
                    goto ask1;
                }
                checker[studentNumber, category] = true;
                Console.WriteLine("Name:".PadRight(10) + "Town:".PadRight(10) + "Food:".PadRight(10));
                Console.WriteLine("============================");
                for (int i = 0; i < students.GetLength(0); i++)
                {
                    Console.Write(name[i].PadRight(9) + "|");
                    for (int j = 0; j < students.GetLength(1); j++)
                    {
                        temp = (checker[i,j] == true) ? students[i, j] : " ";
                        Console.Write(temp.PadRight(9) + "|");
                    }
                    Console.WriteLine();
                }
                Console.Write("Again(y/n): ");
                if (Console.ReadLine().ToLower() == "y")
                    continue;
                else
                    break;
            }
        }
    }
}
