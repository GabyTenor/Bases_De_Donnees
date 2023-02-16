using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;

namespace BDD_debut_5
{
    public struct BDD
    {
        public string DefinirCheminBD()
        {
            string CheminBDRelatif = System.IO.Directory.GetCurrentDirectory() + "\\Comptoirs.accdb";

            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + CheminBDRelatif;
        }

        public string SupprimerUneLigne(string nomCategorie)
        {
            string resultat = "";

            try
            {
                string query = "DELETE FROM Catégories WHERE NomdeCategorie =\"" + nomCategorie + "\";";

                OleDbConnection maBDD = new OleDbConnection(DefinirCheminBD());
                maBDD.Open();
                OleDbCommand command = new OleDbCommand(query, maBDD);
                command.ExecuteNonQuery();
                maBDD.Close();

                resultat = "Suppression effectuée.";

            }
            catch (Exception ex)
            {
                resultat = ex.Message;
            }

            return resultat;
        }
    }
}
