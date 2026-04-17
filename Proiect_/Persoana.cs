namespace LibrariiModele
{
    public class Persoana
    {
        public string Nume { get; set; } = "";
        public string Prenume { get; set; } = "";
        public int Varsta { get; set; }

        public string Info => $"{Nume} {Prenume}, {Varsta} ani";
    }
}