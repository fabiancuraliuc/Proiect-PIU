namespace LibrariiModele
{
    public class Tranzactie
    {
        public TipTranzactie Tip { get; set; }
        public string Descriere { get; set; } = "";
        public double Suma { get; set; }

        public override string ToString()
        {
            return $"{Tip} - {Descriere} - {Suma} lei";
        }
    }
}