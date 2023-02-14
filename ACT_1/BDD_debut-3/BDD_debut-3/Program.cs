using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_debut_3
{
    class Program
    {
        static void Main(string[] args)
        {
            BDD maBDD = new BDD();

            Console.WriteLine("Nom du messager dont on veut modifier le numéro de téléphone (Speedy Express / United Package / Federal Shipping) ?");
            string messager = Console.ReadLine();

            Console.WriteLine("Nouveau numéro de téléphone ?");
            string changement = Console.ReadLine();

            Console.WriteLine(maBDD.ModifierDonnee(messager, changement));
            Console.ReadLine();
            
        }
    }
}
