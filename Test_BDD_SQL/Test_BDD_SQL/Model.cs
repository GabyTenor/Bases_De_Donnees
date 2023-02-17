using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Test_BDD_SQL
{
    public struct Model
    {
        public string Connexion()
        {
            return "Data Source=PCI42103\\SQLEXPRESS;Initial Catalog=bibliotheque_bb;Integrated Security=True";
        }

        public string ChercherLivre(string titre)
        {
            string resultat = "";
            DataSet sortie = new DataSet();
            string query = "SELECT * FROM listeLivre WHERE titre=\"" + titre + "\";";

            try
            {
                SqlConnection maBDD = new SqlConnection(Connexion());
                maBDD.Open();

                SqlDataAdapter traducteur = new SqlDataAdapter(query, maBDD);

                traducteur.Fill(sortie);
                maBDD.Close();

                for (int i = 0; i < sortie.Tables[0].Rows.Count; i++)
                {
                    resultat += sortie.Tables[0].Rows[i]["nom"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["prenom"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["titre"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["illustrateur"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["traducteur"].ToString() + " | " +
                                sortie.Tables[0].Rows[i]["annee_parution"].ToString() + " | " + "\n";
                }
                
            }
            catch (Exception ex)
            {
                resultat = ex.Message;
                throw;
            }

            return resultat;
        }

        public string AjouterLivre(string titre, string annee)
        {
            string resultat;

            try
            {
                string query = "INSERT INTO listeLivre (titre, annee_parution) VALUES (@TitreLivre, @AnneeParution);";
                SqlConnection maBDD = new SqlConnection(Connexion());

                maBDD.Open();

                SqlCommand ajouter = new SqlCommand(query, maBDD);
                ajouter.Parameters.AddWithValue("@TitreLivre", titre);
                ajouter.Parameters.AddWithValue("@AnneeParution", annee);
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

        public string ModifierDonnee(string titre, string annee)
        {
            string resultat;
            try
            {
                string query = "UPDATE listeLivre SET annee_parution = @AnneeParution WHERE NomDuMessager = \"" + titre + "\";";

                SqlConnection bdd = new SqlConnection(Connexion());
                bdd.Open();

                SqlCommand command = new SqlCommand(query, bdd);
                command.Parameters.AddWithValue("@AnneeParution", annee);
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

        /*public string List()
        {
            string resultat = "";
            DataSet sortie = new DataSet();
            try
            {
                string query = "Select NomdeCategorie FROM Catégories";

                SqlConnection maBDD = new SqlConnection(Connexion());
                SqlDataAdapter messager = new SqlDataAdapter(query, maBDD);
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
        
        public string SupprimerUneLigne(string nomCategorie)
        {
            string resultat = "";

            try
            {
                string query = "DELETE FROM Catégories WHERE NomdeCategorie =\"" + nomCategorie + "\";";

                SqlConnection maBDD = new SqlConnection(Connexion());
                maBDD.Open();
                SqlCommand command = new SqlCommand(query, maBDD);
                command.ExecuteNonQuery();
                maBDD.Close();

                resultat = "Suppression effectuée.";

            }
            catch (Exception ex)
            {
                resultat = ex.Message;
            }

            return resultat;
        }*/

    }
}
