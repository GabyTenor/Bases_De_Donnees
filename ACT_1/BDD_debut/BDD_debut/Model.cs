using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;


namespace BDD_debut
{
    public struct Model
    {
        public string DefinirCheminBD()
        {
            string CheminBDRelatif = System.IO.Directory.GetCurrentDirectory() + "\\Comptoirs.accdb";

            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + CheminBDRelatif;
        }
        public string ChercherClientSociete(string societe)
        {
            string resultat = "";
            DataSet sortie = new DataSet();
            string query = "SELECT * FROM Clients WHERE Société=\"" + societe + "\";";

            try
            {
                OleDbConnection maBDD = new OleDbConnection(DefinirCheminBD());
                maBDD.Open();

                OleDbDataAdapter traducteur = new OleDbDataAdapter(query, maBDD);

                traducteur.Fill(sortie);

                for (int i = 0; i < sortie.Tables[0].Rows.Count; i++)
                {
                    resultat += sortie.Tables[0].Rows[i]["Code Client"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["Société"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["Contact"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["Fonction"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["Adresse"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["Ville"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["Région"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["Pays"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["Téléphone"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["Fax"].ToString() + " | " + "\n";
                }


                maBDD.Close();
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