using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
 *Messy im not sure it needs to be, but wanted to emphasis 2d array table
 */
namespace Lab8
{
    class Program
    {
        static void available(bool[,] checker)
        {
            string s = "";
            bool and = false;
            for (int i = 0; i < checker.GetLength(0); i++)
                if (checker[i, 0] == false)
                {
                    s += "Category 1 is still available";
                    and = true;
                    break;
                }
            for (int i = 0; i < checker.GetLength(0); i++)
                if (checker[i, 1] == false && and == true)
                {
                    s += ", and category 2 is still available";
                    break;
                }
                else if (checker[i,1] == false)
                {
                    s = "Category 2 is still available";
                    break;
                }
            Console.WriteLine(s);
        }

        static void Main(string[] args)
        {
            string[,] students = new string[2, 2] { {"Warren","Burger" },{"Gana","Egg" } };
            bool[,] checker = new bool[2, 2];
            string[] name = new string[2] { "Jordan", "Nana" };
            string temp = "";
            int studentNumber, category;


            while (true)
            {
                try
                {
                    Console.Write("\nChoose a student (theres 2): ");
                    studentNumber = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Enter 1 for town, 2 for food: ");
                    category = int.Parse(Console.ReadLine()) - 1;
                    checker[studentNumber, category] = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
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
                available(checker);
                ask2:
                Console.Write("Again(y/n): ");
                temp = Console.ReadLine().ToLower();
                if (temp == "y")
                    continue;
                else if (temp == "n")
                    break;
                else
                    goto ask2;
            }
        }
    }
}
