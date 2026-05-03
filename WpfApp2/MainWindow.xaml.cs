using System.Windows;

namespace WPFApp2
{
    public partial class LoginWindow : Window
    {
        public static string NumePersoana;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                MessageBox.Show("Introdu un nume!");
                return;
            }

            NumePersoana = txtNume.Text;

            LoginWindow main = new MainWindow();
            main.Show();

            this.Close();
        }
    }
}