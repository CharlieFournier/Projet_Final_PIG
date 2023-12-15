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
    internal class SingletonClient
    {
        static SingletonClient instance = null;
        MySqlConnection con;
        ObservableCollection<Client> listeClient;
        DataSet ds;

        public SingletonClient()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2023_420325ri_fabeq5;Uid=2052524;Pwd=2052524;");
            listeClient = new ObservableCollection<Client>();
        }

        public static SingletonClient getInstance()
        {
            if (instance == null)
                instance = new SingletonClient();

            return instance;
        }

        public ObservableCollection<Client> getClient()
        {

            listeClient.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("P_Select_Client");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure; ;

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {

                    int idClient = (int)r["idClient"];
                    string nomClient = (string)r["nomClient"];
                    string adresseClient = (string)r["adresseClient"];
                    string numeroTel = (string)r["numeroTel"];
                    string emailClient = (string)r["emailClient"];


                    Client client = new Client { IdClient = idClient, NomClient = nomClient, AdresseClient = adresseClient, NumeroTel = numeroTel, EmailClient = emailClient};
                    listeClient.Add(client);
                }

                r.Close();
                con.Close();


            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open) { }
                con.Close();
            }

            return listeClient;


        }

        public void supprimer(int position)
        {
            Client c = SingletonClient.getInstance().getListe()[position];
            int idClient = c.IdClient;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"DELETE FROM client WHERE idClient = @idClient;";

                commande.Parameters.AddWithValue("@idClient", idClient);
                con.Open();
                commande.ExecuteNonQuery();

                con.Close();
            }

            catch (MySqlException ex)
            {
                con.Close();
            }
        }

        public void update(Client c, int position)
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


        public void Ajout(Client c)
        {

            string nomClient = c.NomClient;
            string adresseClient = c.AdresseClient;
            string numeroTel = c.NumeroTel;
            string emailClient = c.EmailClient;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"insert into client values(null, @nomClient, @adresseClient, @numeroTel, @emailClient)";

                commande.Parameters.AddWithValue("@nomClient", nomClient);
                commande.Parameters.AddWithValue("@adresseClient", adresseClient);
                commande.Parameters.AddWithValue("@numeroTel", numeroTel);
                commande.Parameters.AddWithValue("@emailClient", emailClient);

                con.Open();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                con.Close();
            }
        }

        public ObservableCollection<Client> getListe()
        {
            return listeClient;
        }


    }
}