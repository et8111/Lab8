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
        static void print(string[,] students, bool[,] checker,string temp)
        {
            Console.WriteLine("Name:".PadRight(17) + "Town:".PadRight(17) + "Food:".PadRight(17));
            Console.WriteLine("===================================================");
            for (int i = 0; i < students.GetLength(0); i++)
            {
                Console.Write(students[i, 0].PadRight(16) + "|");
                for (int j = 1; j < students.GetLength(1); j++)
                {
                    temp = (checker[i, j] == true) ? students[i, j] : " ";
                    Console.Write(temp.PadRight(16) + "|");
                }
                Console.WriteLine();
            }
            available(checker);
        }

        static int FINDER(string[,] students)
        {
            int num = 0;
            string word = Console.ReadLine();
            if (int.TryParse(word,out num))
            {
                return num-1;
            }

            for(int i = 0; i < students.GetLength(0); i++)
            {
                if (students[i, 0] == word)
                    return i;
            }
            Console.WriteLine("Invalid Input.");
            return FINDER(students);
        }
        static void available(bool[,] checker)
        {
            string s = "";
            bool and = false;
            for (int i = 0; i < checker.GetLength(0); i++)
                if (checker[i, 1] == false)
                {
                    s += "Category 1 is still available";
                    and = true;
                    break;
                }
            for (int i = 0; i < checker.GetLength(0); i++)
                if (checker[i, 2] == false && and == true)
                {
                    s += ", and category 2 is still available";
                    break;
                }
                else if (checker[i, 1] == false)
                {
                    s = "Category 2 is still available";
                    break;
                }
            Console.WriteLine("\n"+s);
        }

        static void Main(string[] args)
        {
            string[,] students = new string[15, 3] {
            {"Michael", "Canton", "Chicken Wings" },
            { "Taylor", "Caro", "Cordon Bleu" },
 { "Joshua", "Taylor", "Turkey" },
 { "Lin-Z", "Toledo", "Ice Cream" },
 { "Madelyn", "Oxford", "Croissent" },
 { "Nana", "Guana", "Empanadas"},
 { "Rochelle", "Mars", "Space Cheese"},
 { "Shah", "Newark", "Chicken Wings"},
  { "Tim", "Detroit", "Chicken Parm"},
   { "Abby", "Traverse City", "Soup"},
   { "Blake", "Los Angeles", "Cannolis"},
   { "Bob", "St. Clair Shores", "Pizza"},
   { "Jordan", "Warren", "Burgers"},
   { "Jay", "Macomb", "Pickles"},
   { "Jon", "Huntington Woods", "Ribs"},};
            bool[,] checker = new bool[students.GetLength(0), students.GetLength(1)];
            string temp = "";
            int studentNumber, category = 0;


            while (true)
            {
                try
                {
                    print(students, checker, temp);
                    Console.Write("Enter student name OR 1-15: ");
                    studentNumber = FINDER(students);
                    Console.Write("Town or 1 | Food or 2: ");
                    temp = Console.ReadLine();
                    if (temp == "Town" || temp == "1")
                        category = 1;
                    else if (temp == "Food" || temp == "2")
                        category = 2;
                    checker[studentNumber, category] = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                print(students, checker, temp);
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
