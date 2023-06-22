using CRUDORM_GeorgiMitev_Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDORM_GeorgiMitev_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 for Form Application or 2 for Console Application.");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else if (choice == 2)
            {
                Display display = new Display();
            }
            
        }
    }
}
