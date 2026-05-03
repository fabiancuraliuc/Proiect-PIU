using LibrariiModele;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls; // Adăugat pentru a recunoaște ComboBoxItem

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        List<Tranzactie> tranzactii = new List<Tranzactie>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdauga_Click(object sender, RoutedEventArgs e)
        {
            txtEroare.Text = "";

            if (!double.TryParse(txtSuma.Text, out double suma) || suma <= 0)
            {
                txtEroare.Text = "Suma invalidă";
                return;
            }

            if (rbVenit.IsChecked == false && rbCheltuiala.IsChecked == false)
            {
                txtEroare.Text = "Selectează tipul";
                return;
            }

            TipTranzactie tip = rbVenit.IsChecked == true
                ? TipTranzactie.Venit
                : TipTranzactie.Cheltuiala;

            // Preluăm opțiunea selectată din noul ComboBox
            string categorie = "Nespecificat";
            if (cmbCategorie.SelectedItem is ComboBoxItem itemSelectat)
            {
                categorie = itemSelectat.Content.ToString();
            }

            // Salvăm în modelul tău (am folosit 'categorie' pe post de descriere)
            Tranzactie t = new Tranzactie
            {
                Tip = tip,
                Descriere = categorie,
                Suma = suma
            };

            tranzactii.Add(t);

            // Afișare concisă, fără detalii inutile
            string textAfisare = $"{tip}: {suma} lei ({categorie})";

            // Adăugăm direct în noul ListBox în loc de vechiul TextBlock
            lstIstoric.Items.Add(textAfisare);

            // Resetare formular
            txtSuma.Clear();
            rbVenit.IsChecked = false;
            rbCheltuiala.IsChecked = false;
            cmbCategorie.SelectedIndex = 0; // Revine la prima categorie
        }
    }
}