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
    internal class SingletonEmploye
    {
        static SingletonEmploye instance = null;
        MySqlConnection con;
        ObservableCollection<Employe> listeEmploye;
        DataSet ds;

        public SingletonEmploye()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2023_420325ri_fabeq5;Uid=2052524;Pwd=2052524;");
            listeEmploye = new ObservableCollection<Employe>();
        }

        public static SingletonEmploye getInstance()
        {
            if (instance == null)
                instance = new SingletonEmploye();

            return instance;
        }

        public ObservableCollection<Employe> getEmploye()
        {

            listeEmploye.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("P_Select_Employe");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure; ;

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {

                    string matriculeEmploye = (string)r["matriculeEmploye"];
                    string nomEmploye = (string)r["nomEmploye"];
                    string prenomEmploye = (string)r["prenomEmploye"];
                    string dateNaissance = (string)r["dateNaissance"];
                    string emailEmploye = (string)r["emailEmploye"];
                    string adresseEmploye = (string)r["adresseEmploye"];
                    string dateEmbauche = (string)r["dateEmbauche"];
                    double tauxHoraire = (double)r["tauxHoraire"];
                    string urlPhoto = (string)r["photo"];
                    string statutEmploye = (string)r["statut"];
                    double nbrHeure = (double)r["nbrHeures"];

                    Employe employe = new Employe { MatriculeEmploye = matriculeEmploye, NomEmploye = nomEmploye, PrenomEmploye = prenomEmploye, DateNaissance = dateNaissance, EmailEmploye = emailEmploye, AdresseEmploye = adresseEmploye, DateEmbauche = dateEmbauche, TauxHoraire = tauxHoraire, UrlPhoto = urlPhoto, StatutEmploye = statutEmploye, NbrHeure = nbrHeure };
                    listeEmploye.Add(employe);
                }

                r.Close();
                con.Close();


            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open) { }
                con.Close();
            }

            return listeEmploye;


        }

        public ObservableCollection<Employe> getEmployeProjet(String numPro)
        {

            listeEmploye.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("P_Select_Employe_Projet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure; ;

                commande.Parameters.AddWithValue("in_numeroProjet", numPro);

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {

                    string matriculeEmploye = (string)r["matriculeEmploye"];
                    string nomEmploye = (string)r["nomEmploye"];
                    string prenomEmploye = (string)r["prenomEmploye"];
                    string dateNaissance = (string)r["dateNaissance"];
                    string emailEmploye = (string)r["emailEmploye"];
                    string adresseEmploye = (string)r["adresseEmploye"];
                    string dateEmbauche = (string)r["dateEmbauche"];
                    double tauxHoraire = (double)r["tauxHoraire"];
                    string urlPhoto = (string)r["photo"];
                    string statutEmploye = (string)r["statut"];
                    double nbrHeure = (double)r["nbrHeures"];

                    Employe employe = new Employe { MatriculeEmploye = matriculeEmploye, NomEmploye = nomEmploye, PrenomEmploye = prenomEmploye, DateNaissance = dateNaissance, EmailEmploye = emailEmploye, AdresseEmploye = adresseEmploye, DateEmbauche = dateEmbauche, TauxHoraire = tauxHoraire, UrlPhoto = urlPhoto, StatutEmploye = statutEmploye, NbrHeure = nbrHeure };
                    listeEmploye.Add(employe);
                }

                r.Close();
                con.Close();


            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open) { }
                con.Close();
            }

            return listeEmploye;


        }

        public void supprimer(int position)
        {
            Employe e = SingletonEmploye.getInstance().getListe()[position];
            string matriculeEmploye = e.MatriculeEmploye;

            try
            {
                MySqlCommand commande = new MySqlCommand("P_Delete_Employe");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("in_MatriculeEmploye", matriculeEmploye);
                con.Open();
                commande.ExecuteNonQuery();

                con.Close();
            }

            catch (MySqlException ex)
            {
                con.Close();
            }
        }

        public void update(Employe e, int position)
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


        public void Ajout(Employe e)
        {

            string nomEmploye = e.NomEmploye;
            string prenomEmploye = e.PrenomEmploye;
            string dateNaissance = e.DateNaissance;
            string emailEmploye = e.EmailEmploye;
            string adresseEmploye = e.AdresseEmploye;
            string dateEmbauche = e.DateEmbauche;
            double tauxHoraire = e.TauxHoraire;
            string urlPhoto = e.UrlPhoto;
            string statutEmploye = e.StatutEmploye;
            double nbrHeure = e.NbrHeure;

            try
            {
                MySqlCommand commande = new MySqlCommand("P_Ajout_Employe");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("in_nomEmploye", nomEmploye);
                commande.Parameters.AddWithValue("in_prenomEmploye", prenomEmploye);
                commande.Parameters.AddWithValue("in_dateNaissance", dateNaissance);
                commande.Parameters.AddWithValue("in_emailEmploye", emailEmploye);
                commande.Parameters.AddWithValue("in_adresseEmploye", adresseEmploye);
                commande.Parameters.AddWithValue("in_dateEmbauche", dateEmbauche);
                commande.Parameters.AddWithValue("in_tauxHoraire", tauxHoraire);
                commande.Parameters.AddWithValue("in_urlPhoto", urlPhoto);
                commande.Parameters.AddWithValue("in_statutEmploye", statutEmploye);
                commande.Parameters.AddWithValue("in_nbrHeures", nbrHeure);

                con.Open();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                con.Close();
            }
        }

        public ObservableCollection<Employe> getListe()
        {
            return listeEmploye;
        }


    }
}