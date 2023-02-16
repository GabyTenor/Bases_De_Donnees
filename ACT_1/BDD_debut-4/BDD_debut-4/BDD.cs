using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;

namespace BDD_debut_4
{
    public struct BDD
    {
        public string DefinirCheminBD()
        {
            string CheminBDRelatif = System.IO.Directory.GetCurrentDirectory() + "\\Comptoirs.accdb";

            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + CheminBDRelatif;
        }

        public string List()
        {
            string resultat = "";
            DataSet sortie = new DataSet();
            try
            {            
                string query = "Select NomdeCategorie FROM Catégories";

                OleDbConnection maBDD = new OleDbConnection(DefinirCheminBD());           
                OleDbDataAdapter messager = new OleDbDataAdapter(query, maBDD);
                maBDD.Open();
                messager.Fill(sortie);
                maBDD.Close();

                for (int i = 0; i < sortie.Tables[0].Rows.Count; i++)
                {
                    resultat += sortie.Tables[0].Rows[i]["NomdeCategorie"].ToString() + "\n";              
                }

            }
            catch (Exception ex)
            {
                resultat = ex.Message;
            }

            return resultat;
        }
    }
}
