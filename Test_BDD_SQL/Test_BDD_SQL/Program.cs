using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BDD_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Model bdd = new Model();
            string choix;

            string titre;
            string annee;

            do
            {
                Console.WriteLine("Que souhaitez-vous faire? (a = afficher, + = ajouter, m = modifier)");
                choix = Console.ReadLine();
            } while (choix == "");

            switch (choix)
            {
                case "a":
                    Console.WriteLine("Nom du livre?");
                    titre = Console.ReadLine();

                    Console.WriteLine(bdd.ChercherLivre(titre));
                    break;

                case "+":
                    Console.WriteLine("Titre du livre?");
                    titre = Console.ReadLine();

                    Console.WriteLine("Annee de parition?");
                    annee = Console.ReadLine();

                    Console.WriteLine(bdd.AjouterLivre(titre, annee));
                    break;

                case "m":
                    Console.WriteLine("Titre du livre?");
                    titre = Console.ReadLine();

                    Console.WriteLine("Annee de parition à modifier?");
                    annee = Console.ReadLine();
                    break;
                
                default:
                    Console.WriteLine("Mauvais choix!");
                    break;
            }

            Console.ReadLine();
        }
    }
}
