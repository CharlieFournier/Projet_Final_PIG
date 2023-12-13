using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{
    internal class SingletonProjet
    {
        static SingletonProjet instance = null;
        MySqlConnection con;
        ObservableCollection<Projet> listeProjet;
        DataSet ds;

        public SingletonProjet()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2023_420325ri_fabeq5;Uid=2052524;Pwd=2052524;");
            listeProjet = new ObservableCollection<Projet>();
        } 

        public static SingletonProjet getInstance()
        {
            if (instance == null)
                instance = new SingletonProjet();

            return instance;
        }

        public ObservableCollection<Projet> getMateriel()
        {

            listeProjet.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("P_Select_Projet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure; ;

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {

                    string numeroProjet = (string)r["numeroProjet"];
                    string titre = (string)r["titre"];
                    string dateDebut = (string)r["dateDebut"];
                    string description  = (string)r["Description"];
                    double budget = (double)r["budget"];
                    int nbEmploye = (int)r["nbEmploye"];
                    double totalSalaire = (double)r["totalSalaire"];
                    int idClient = (int)r["idClient"];
                    string statutProjet = (string)r["statutProjet"];

                    Projet projet = new Projet { NumeroProjet = numeroProjet, Titre = titre, DateDebut = dateDebut, Description = description, Budget = budget, NbEmploye = nbEmploye, TotalSalaire = totalSalaire, IdClient = idClient, StatutProjet = statutProjet};
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
            Projet p = SingletonProjet.getInstance().getListe()[position];
            string numeroProjet = p.NumeroProjet;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"DELETE FROM produits WHERE numeroProjet = @numeroProjet;";

                commande.Parameters.AddWithValue("@numeroProjet", numeroProjet);
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
            Projet pro = SingletonProjet.getInstance().getListe()[position];
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
            string statutProjet = p.StatutProjet;

                try
                {
                    MySqlCommand commande = new MySqlCommand();
                    commande.Connection = con;
                    commande.CommandText = $"insert into projet values(null, @titre, @dateDebut, @description, @budget, @nbEmploye, @totalSalaire, @idClient, @statutProjet)";

                    commande.Parameters.AddWithValue("@titre", titre);
                    commande.Parameters.AddWithValue("@dateDebut", dateDebut);
                    commande.Parameters.AddWithValue("@description", description);
                    commande.Parameters.AddWithValue("@budget", budget);
                    commande.Parameters.AddWithValue("@nbEmploye", nbEmploye);
                    commande.Parameters.AddWithValue("@totalSalaire", totalSalaire);
                    commande.Parameters.AddWithValue("@idClient", idClient);
                    commande.Parameters.AddWithValue("@statutProjet", statutProjet);

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