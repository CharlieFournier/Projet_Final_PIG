using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{
    internal class Client : INotifyPropertyChanged
    {

        int idClient;
        string nomClient;
        string adresseClient;
        string numeroTel;
        string emailClient;


        public event PropertyChangedEventHandler PropertyChanged;

        public Client(int cidClient, string cnomClient, string cadresseClient, string cnumeroTel, string cemailClient)
        {
            idClient = cidClient;
            nomClient = cnomClient;
            adresseClient = cadresseClient;
            numeroTel = cnumeroTel;
            emailClient = cemailClient;
        }

        public Client(string cnomClient, string cadresseClient, string cnumeroTel, string cemailClient)
        {
            nomClient = cnomClient;
            adresseClient = cadresseClient;
            numeroTel = cnumeroTel;
            emailClient = cemailClient;
        }

        public Client()
        {

        }

        public override string ToString()
        {
            return $"{idClient} \n {nomClient}";
        }

        public string StringCSV()
        {
            return $"{idClient} ; {nomClient}";
        }

        public int IdClient
        {
            get { return idClient; }
            set
            {
                idClient = value;
                this.OnPropertyChanged();
            }
        }
        public string NomClient
        {
            get { return nomClient; }
            set
            {
                nomClient = value;
                this.OnPropertyChanged();
            }
        }
        public string AdresseClient
        {
            get { return adresseClient; }
            set
            {
                adresseClient = value;
                this.OnPropertyChanged();
            }
        }

        public string NumeroTel
        {
            get { return numeroTel; }
            set
            {
                numeroTel = value;
                this.OnPropertyChanged();
            }
        }

        public string EmailClient
        {
            get { return emailClient; }
            set
            {
                emailClient = value;
                this.OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
