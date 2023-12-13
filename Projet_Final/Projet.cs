using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{
    internal class Projet : INotifyPropertyChanged
    {

            string numeroProjet;
            string titre;
            string dateDebut;
            string description;
            double budget;
            int nbEmploye;
            double totalSalaire;
            int idClient;
            string statutProjet;    

            public event PropertyChangedEventHandler PropertyChanged;

            public Projet( string ptitre, string pdateDebut, string pdescription, double pbudget, int pnbEmploye, double ptotalSalaire, int pidClient, string pstatutProjet)
            {
                titre = ptitre;
                dateDebut = pdateDebut;
                description = pdescription;
                budget = pbudget;
                nbEmploye = pnbEmploye;
                totalSalaire = ptotalSalaire;
                idClient = pidClient;
                statutProjet = pstatutProjet;
            }

            public Projet()
            {

            }

            public override string ToString()
            {
                return $"{numeroProjet} \n {titre} \n {idClient}";
            }

            public string StringCSV()
            {
                return $"{numeroProjet} ; {titre}  ;  {idClient}";
            }

            public string NumeroProjet
            {
                get { return numeroProjet; }
                set
                {
                    numeroProjet = value;
                    this.OnPropertyChanged();
                }
            }
        public string Titre
            {
                get { return titre; }
                set
                {
                titre = value;
                    this.OnPropertyChanged();
                }
            }
            public string DateDebut
        {
                get { return dateDebut; }
                set
                {
                dateDebut = value;
                    this.OnPropertyChanged();
                }
            }

            public string Description
            {
                get { return description; }
                set
                {
                description = value;
                    this.OnPropertyChanged();
                }
            }
            public double Budget
        {
                get { return budget; }
                set
                {
                budget = value;
                    this.OnPropertyChanged();
                }
            }
            public int NbEmploye
            {
                get { return nbEmploye; }
                set
                {
                nbEmploye = value;
                    this.OnPropertyChanged();
                }
            }

            public double TotalSalaire
        {
                get { return totalSalaire; }
                set
                {
                totalSalaire = value;
                    this.OnPropertyChanged();
                }
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

            public string StatutProjet
        {
                get { return statutProjet; }
                set
                {
                statutProjet = value;
                    this.OnPropertyChanged();
                }
            }


        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
