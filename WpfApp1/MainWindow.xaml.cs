using LibrariiModele;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        List<Tranzactie> tranzactii = new List<Tranzactie>();

        const double SUMA_MIN = 1;
        const double SUMA_MAX = 100000;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdauga_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;
            txtEroare.Text = "";
            ResetCulori();

            if (cmbTip.SelectedItem == null)
            {
                lblTip.Foreground = Brushes.Red;
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDescriere.Text))
            {
                lblDescriere.Foreground = Brushes.Red;
                valid = false;
            }

            double suma;
            if (!double.TryParse(txtSuma.Text, out suma) || suma < SUMA_MIN || suma > SUMA_MAX)
            {
                lblSuma.Foreground = Brushes.Red;
                valid = false;
            }

            if (!valid)
            {
                txtEroare.Text = "Date invalide! Verifica campurile.";
                return;
            }

            TipTranzactie tip = cmbTip.SelectedIndex == 0
                ? TipTranzactie.Venit
                : TipTranzactie.Cheltuiala;

            Tranzactie t = new Tranzactie
            {
                Tip = tip,
                Descriere = txtDescriere.Text,
                Suma = suma
            };

            tranzactii.Add(t);

            txtAfisare.Text += $"Tranzactie inregistrata: {t.Tip} - {t.Descriere} - {t.Suma} lei\n";

           

            txtDescriere.Clear();
            txtSuma.Clear();
            cmbTip.SelectedIndex = -1;
        }

        void ResetCulori()
        {
            lblTip.Foreground = Brushes.White;
            lblDescriere.Foreground = Brushes.White;
            lblSuma.Foreground = Brushes.White;
        }
    }
}