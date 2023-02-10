using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_debut
{
    class Program
    {
        static void Main(string[] args)
        {
            Model methodesBDD = new Model();
            string demande;
            string refaire = "";
            do
            {
                do
                {
                    Console.WriteLine("Tapez un nom d'entreprise pour y retrouver tous ses clients (Exemple : France restauration   Blondel père et fils   Around the Horn   Ana Trujillo Emparedados y helados");
                    demande = Console.ReadLine();
                } while (demande == "");

                Console.WriteLine(methodesBDD.ChercherClientSociete(demande));

                Console.WriteLine("Recommencer? Espace si oui");
                refaire = Console.ReadLine();
                
                Console.Clear();
            } while (refaire == " ");

            Console.ReadLine();
        }
    }
}
