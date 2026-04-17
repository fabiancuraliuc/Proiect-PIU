using LibrariiModele;
using StocareTranzactie;
using System.IO;
using System.Windows;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        object stocare;
        bool fisier = true;

        public MainWindow()
        {
            InitializeComponent();

            string configPath = "config.txt";

            if (!File.Exists(configPath))
                File.WriteAllText(configPath, "tip=fisier");

            string config = File.ReadAllText(configPath);

            if (config.Contains("memorie"))
            {
                stocare = new StocareMemorie();
                fisier = false;
            }
            else
            {
                stocare = new StocareFisier();
            }

            Persoana p = new Persoana
            {
                Nume = "Popescu",
                Prenume = "Ion",
                Varsta = 21
            };

            txtPersoana.Text = p.Info;

            AdaugaTest();
            Afiseaza();
        }

        void AdaugaTest()
        {
            var t = new Tranzactie
            {
                Tip = TipTranzactie.Venit,
                Descriere = "Salariu",
                Suma = 3000
            };

            if (fisier)
                ((StocareFisier)stocare).Adauga(t);
            else
                ((StocareMemorie)stocare).Adauga(t);
        }

        void Afiseaza()
        {
            if (fisier)
            {
                listaTranzactii.ItemsSource = ((StocareFisier)stocare).GetAll();
                txtTotal.Text = "Total: " + ((StocareFisier)stocare).TotalVenit();
            }
            else
            {
                listaTranzactii.ItemsSource = ((StocareMemorie)stocare).GetAll();
                txtTotal.Text = "Total: " + ((StocareMemorie)stocare).TotalVenit();
            }
        }
    }
}