using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_debut_2
{
    class Program
    {
        static void Main(string[] args)
        {
            BDD fonctionsBDD = new BDD();

            Console.WriteLine("Ajouteur une ligne dans une table :");
            Console.WriteLine("Par exemple ajouter une catégories dans la table des catégories : \n--------------------------------------------------------------");
            Console.WriteLine("\n");
            
            Console.WriteLine("Nom de catégorie à ajouter ?");
            string categorie = Console.ReadLine();

            Console.WriteLine("Description de catégorie à ajouter ?");
            string descrip = Console.ReadLine();

            Console.WriteLine(fonctionsBDD.AjouterUneLigne(categorie, descrip));
            Console.ReadLine();
        }
    }
}
