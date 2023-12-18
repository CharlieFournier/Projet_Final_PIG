using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{
    internal class SingletonProjet2
    {
        static SingletonProjet2 instance = null;
        MySqlConnection con;
        ObservableCollection<Projet> listeProjet;
        DataSet ds;
        public SingletonProjet2()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2023_420325ri_fabeq5;Uid=2052524;Pwd=2052524;");
            listeProjet = new ObservableCollection<Projet>();
        }

        public static SingletonProjet2 getInstance()
        {
            if (instance == null)
                instance = new SingletonProjet2();

            return instance;
        }

        public ObservableCollection<Projet> getProjet()
        {

            listeProjet.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("P_Select_Projet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {


                    string numeroProjet = (string)r["numeroProjet"];
                    string titre = (string)r["titre"];
                    string dateDebut = (string)r["dateDebut"];
                    string description = (string)r["Description"];
                    double budget = (double)r["budget"];
                    int nbEmploye = (int)r["nbEmploye"];
                    double totalSalaire = (double)r["totalSalaire"];
                    int idClient = (int)r["idClient"];
                    string statutProjet = (string)r["statutProjet"];

                    Projet projet = new Projet { NumeroProjet = numeroProjet, Titre = titre, DateDebut = dateDebut, Description = description, Budget = budget, NbEmploye = nbEmploye, TotalSalaire = totalSalaire, IdClient = idClient, StatutProjet = statutProjet };
                    listeProjet.Add(projet);
                }

                r.Close();
                con.Close();

            }

            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open) { }
                con.Close();
            }

            return listeProjet;


        }

        public ObservableCollection<Projet> getProjetEnCours()
        {

            listeProjet.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("P_Select_Projet_EnCours");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {


                    string numeroProjet = (string)r["numeroProjet"];
                    string titre = (string)r["titre"];
                    string dateDebut = (string)r["dateDebut"];
                    string description = (string)r["Description"];
                    double budget = (double)r["budget"];
                    int nbEmploye = (int)r["nbEmploye"];
                    double totalSalaire = (double)r["totalSalaire"];
                    int idClient = (int)r["idClient"];
                    string statutProjet = (string)r["statutProjet"];

                    Projet projet = new Projet { NumeroProjet = numeroProjet, Titre = titre, DateDebut = dateDebut, Description = description, Budget = budget, NbEmploye = nbEmploye, TotalSalaire = totalSalaire, IdClient = idClient, StatutProjet = statutProjet };
                    listeProjet.Add(projet);
                }

                r.Close();
                con.Close();

            }



            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open) { }
                con.Close();
            }

            return listeProjet;

        }

        public ObservableCollection<Projet> getProjetClient(Client c)
        {
            int idCli = c.IdClient;

            listeProjet.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("P_Select_Projet_Client");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("in_idClient", idCli);

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {


                    string numeroProjet = (string)r["numeroProjet"];
                    string titre = (string)r["titre"];
                    string dateDebut = (string)r["dateDebut"];
                    string description = (string)r["Description"];
                    double budget = (double)r["budget"];
                    int nbEmploye = (int)r["nbEmploye"];
                    double totalSalaire = (double)r["totalSalaire"];
                    int idClient = (int)r["idClient"];
                    string statutProjet = (string)r["statutProjet"];

                    Projet projet = new Projet { NumeroProjet = numeroProjet, Titre = titre, DateDebut = dateDebut, Description = description, Budget = budget, NbEmploye = nbEmploye, TotalSalaire = totalSalaire, IdClient = idClient, StatutProjet = statutProjet };
                    listeProjet.Add(projet);
                }

                r.Close();
                con.Close();

            }



            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open) { }
                con.Close();
            }

            return listeProjet;

        }


        public ObservableCollection<Projet> getProjet_EmployeActif(Employe e)
        {
            string matriculeEmp = e.MatriculeEmploye;

            listeProjet.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("P_Select_Projet_Actif_Employe");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("in_matriculeEmploye", matriculeEmp);

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {


                    string numeroProjet = (string)r["numeroProjet"];
                    string titre = (string)r["titre"];
                    string dateDebut = (string)r["dateDebut"];
                    string description = (string)r["Description"];
                    double budget = (double)r["budget"];
                    int nbEmploye = (int)r["nbEmploye"];
                    double totalSalaire = (double)r["totalSalaire"];
                    int idClient = (int)r["idClient"];
                    string statutProjet = (string)r["statutProjet"];

                    Projet projet = new Projet { NumeroProjet = numeroProjet, Titre = titre, DateDebut = dateDebut, Description = description, Budget = budget, NbEmploye = nbEmploye, TotalSalaire = totalSalaire, IdClient = idClient, StatutProjet = statutProjet };
                    listeProjet.Add(projet);
                }

                r.Close();
                con.Close();

            }



            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open) { }
                con.Close();
            }

            return listeProjet;

        }

        public ObservableCollection<Projet> getProjet_EmployeInactif(Employe e)
        {
            string matriculeEmp = e.MatriculeEmploye;

            listeProjet.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("P_Select_Projet_Inactif_Employe");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("in_matriculeEmploye", matriculeEmp);

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {


                    string numeroProjet = (string)r["numeroProjet"];
                    string titre = (string)r["titre"];
                    string dateDebut = (string)r["dateDebut"];
                    string description = (string)r["Description"];
                    double budget = (double)r["budget"];
                    int nbEmploye = (int)r["nbEmploye"];
                    double totalSalaire = (double)r["totalSalaire"];
                    int idClient = (int)r["idClient"];
                    string statutProjet = (string)r["statutProjet"];

                    Projet projet = new Projet { NumeroProjet = numeroProjet, Titre = titre, DateDebut = dateDebut, Description = description, Budget = budget, NbEmploye = nbEmploye, TotalSalaire = totalSalaire, IdClient = idClient, StatutProjet = statutProjet };
                    listeProjet.Add(projet);
                }

                r.Close();
                con.Close();

            }



            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open) { }
                con.Close();
            }

            return listeProjet;

        }


        public void supprimer(int position)
        {
            Projet p = SingletonProjet2.getInstance().getListe()[position];
            string numeroProjet = p.NumeroProjet;

            try
            {
                MySqlCommand commande = new MySqlCommand("P_Delete_Projet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("in_NumeroProjet", numeroProjet);
                con.Open();
                commande.ExecuteNonQuery();

                con.Close();
            }

            catch (MySqlException ex)
            {
                con.Close();
            }
        }

        public void update(Projet p, int position)
        {
            /*
                Projet pro = SingletonProjet2.getInstance().getListe()[position];
                int numeroProjet = pro.NumeroProjet;

                string modele = m.Modele;
                string meuble = m.Meuble;
                string categorie = m.Categorie;
                string couleur = m.Couleur;
                double prix = m.Prix;



                try
                {
                    MySqlCommand commande = new MySqlCommand();
                    commande.Connection = con;
                    commande.CommandText = $"update produits set modele= @modele, meuble= @meuble, categorie= @categorie, couleur= @couleur, prix= @prix WHERE code = @code;";

                    commande.Parameters.AddWithValue("@code", code);

                    commande.Parameters.AddWithValue("@modele", modele);
                    commande.Parameters.AddWithValue("@meuble", meuble);
                    commande.Parameters.AddWithValue("@categorie", categorie);
                    commande.Parameters.AddWithValue("@couleur", couleur);
                    commande.Parameters.AddWithValue("@prix", prix);
                    con.Open();
                    commande.ExecuteNonQuery();

                    con.Close();
                }

                catch (MySqlException ex)
                {
                    con.Close();
                } */
        }


        public void Ajout(Projet p)
        {

            string titre = p.Titre;
            string dateDebut = p.DateDebut;
            string description = p.Description;
            double budget = p.Budget;
            int nbEmploye = p.NbEmploye;
            double totalSalaire = p.TotalSalaire;
            int idClient = p.IdClient;

            try
            {
                MySqlCommand commande = new MySqlCommand("P_Ajout_Projet");

                if (p.PrenomEmploye != "")
                {
                    commande = new MySqlCommand("P_Ajout_Projet_Employe");
                }

                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("in_titre", titre);
                commande.Parameters.AddWithValue("in_dateDebut", dateDebut);
                commande.Parameters.AddWithValue("in_description", description);
                commande.Parameters.AddWithValue("in_budget", budget);
                commande.Parameters.AddWithValue("in_nbEmploye", nbEmploye);
                commande.Parameters.AddWithValue("in_totalSalaire", totalSalaire);
                commande.Parameters.AddWithValue("in_IdClient", idClient);
                commande.Parameters.AddWithValue("in_statutProjet", "En cours");
                if (p.PrenomEmploye != "")
                {
                    string prenomEmploye = p.PrenomEmploye;
                    commande.Parameters.AddWithValue("in_prenomEmploye", prenomEmploye);
                }
                con.Open();
                commande.ExecuteNonQuery();

                con.Close();
            }

            catch (MySqlException ex)
            {
                con.Close();
            }
        }



        public ObservableCollection<Projet> getListe()
        {
            return listeProjet;
        }
    }
}