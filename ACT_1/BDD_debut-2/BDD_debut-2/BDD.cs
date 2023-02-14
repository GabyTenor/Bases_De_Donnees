using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;


namespace BDD_debut_2
{
    public struct BDD
    {
        public string DefinirCheminBD()
        {
            string CheminBDRelatif = System.IO.Directory.GetCurrentDirectory() + "\\Comptoirs.accdb";

            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + CheminBDRelatif;
        }

        public string AjouterUneLigne(string categorie, string descrip)
        {
            string resultat;

            try
            {
                string query = "INSERT INTO Catégories (NomdeCategorie, Description) VALUES (@NomdeCategorie, @Description);";
                OleDbConnection maBDD = new OleDbConnection(DefinirCheminBD());
               
                maBDD.Open();
                
                OleDbCommand ajouter = new OleDbCommand(query, maBDD);
                ajouter.Parameters.AddWithValue("@NomdeCategorie", categorie);
                ajouter.Parameters.AddWithValue("@Description", descrip);
                ajouter.ExecuteNonQuery();
               
                maBDD.Close();
                
                resultat = "Ajout effectué";
                
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