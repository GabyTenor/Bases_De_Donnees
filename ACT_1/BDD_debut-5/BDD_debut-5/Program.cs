using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_debut_5
{
    class Program
    {
        static void Main(string[] args)
        {
            BDD pont = new BDD();

            Console.WriteLine("Supprimer une ligne dans la table des catégories\n");
            Console.WriteLine("Nom de catégorie à supprimer ?");
            string nomCategorie = Console.ReadLine();
            
            Console.WriteLine(pont.SupprimerUneLigne(nomCategorie));
            Console.ReadLine();
        }
    }
}
