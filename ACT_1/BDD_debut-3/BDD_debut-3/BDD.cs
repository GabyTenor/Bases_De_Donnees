using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;


namespace BDD_debut_3
{
    public struct BDD
    {
        public string DefinirCheminBD()
        {
            string CheminBDRelatif = System.IO.Directory.GetCurrentDirectory() + "\\Comptoirs.accdb";

            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + CheminBDRelatif;
        }

        public string ModifierDonnee(string messager, string changement)
        {
            string resultat;
            try
            {
                string query = "UPDATE Messagers SET Telephone = @Telephone WHERE NomDuMessager = \"" + messager + "\";";
                
                OleDbConnection bdd = new OleDbConnection(DefinirCheminBD());
                bdd.Open();

                OleDbCommand command = new OleDbCommand(query, bdd);
                command.Parameters.AddWithValue("@Telephone", changement);
                command.ExecuteNonQuery();

                bdd.Close();

                resultat = "Mise à jour effectuée";

            }
            catch (Exception ex)
            {
                resultat = ex.Message;
                throw;
            }

            return resultat;
        }
    }
}
