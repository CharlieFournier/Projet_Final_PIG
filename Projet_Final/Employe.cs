using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{
    internal class Employe : INotifyPropertyChanged
    {

        string matriculeEmploye;
        string nomEmploye;
        string prenomEmploye;
        string dateNaissance;
        string emailEmploye;
        string adresseEmploye;
        string dateEmbauche;
        double tauxHoraire;
        string urlPhoto;
        string statutEmploye;
        double nbrHeure;

        public event PropertyChangedEventHandler PropertyChanged;

        public Employe(string enomEmploye, string eprenomEmploye, string edateNaissance, string eemailEmploye, string eadresseEmploye, string edateEmbauche, double etauxHoraire, string eurlPhoto, string estatutEmploye, double enbrHeure)
        {
            nomEmploye = enomEmploye;
            prenomEmploye = eprenomEmploye;
            dateNaissance = edateNaissance;
            emailEmploye = eemailEmploye;
            adresseEmploye = eadresseEmploye;
            dateEmbauche = edateEmbauche;
            tauxHoraire = etauxHoraire;
            urlPhoto = eurlPhoto;
            statutEmploye = estatutEmploye;
            nbrHeure = enbrHeure;
        }

        public Employe()
        {

        }

        public override string ToString()
        {
            return $"{matriculeEmploye} \n {prenomEmploye} \n {nomEmploye}";
        }

        public string StringCSV()
        {
            return $"{matriculeEmploye} ; {prenomEmploye}  ;  {nomEmploye}";
        }

        public string MatriculeEmploye
        {
            get { return matriculeEmploye; }
            set
            {
                matriculeEmploye = value;
                this.OnPropertyChanged();
            }
        }
        public string NomEmploye
        {
            get { return nomEmploye; }
            set
            {
                nomEmploye = value;
                this.OnPropertyChanged();
            }
        }
        public string PrenomEmploye
        {
            get { return prenomEmploye; }
            set
            {
                prenomEmploye = value;
                this.OnPropertyChanged();
            }
        }

        public string DateNaissance
        {
            get { return dateNaissance; }
            set
            {
                dateNaissance = value;
                this.OnPropertyChanged();
            }
        }
        public string EmailEmploye
        {
            get { return emailEmploye; }
            set
            {
                emailEmploye = value;
                this.OnPropertyChanged();
            }
        }
        public string AdresseEmploye
        {
            get { return adresseEmploye; }
            set
            {
                adresseEmploye = value;
                this.OnPropertyChanged();
            }
        }

        public string DateEmbauche
        {
            get { return dateEmbauche; }
            set
            {
                dateEmbauche = value;
                this.OnPropertyChanged();
            }
        }

        public double TauxHoraire
        {
            get { return tauxHoraire; }
            set
            {
                tauxHoraire = value;
                this.OnPropertyChanged();
            }
        }

        public string UrlPhoto
        {
            get { return urlPhoto; }
            set
            {
                urlPhoto = value;
                this.OnPropertyChanged();
            }
        }

        public string StatutEmploye
        {
            get { return statutEmploye; }
            set
            {
                statutEmploye = value;
                this.OnPropertyChanged();
            }
        }

        public double NbrHeure
        {
            get { return nbrHeure; }
            set
            {
                nbrHeure = value;
                this.OnPropertyChanged();
            }
        }


        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
