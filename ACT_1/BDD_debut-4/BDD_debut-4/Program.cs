using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_debut_4
{
    class Program
    {
        static void Main(string[] args)
        {
            BDD pont = new BDD();

            Console.WriteLine("Liste des catégories disponibles : ");
            Console.WriteLine(pont.List());
            Console.ReadLine();
        }
    }
}
