using LibrariiModele;
using System.Collections.Generic;
using System.Linq;

namespace StocareTranzactie
{
    public class StocareMemorie
    {
        private List<Tranzactie> tranzactii = new List<Tranzactie>();

        public void Adauga(Tranzactie t)
        {
            tranzactii.Add(t);
        }

        public List<Tranzactie> GetAll()
        {
            return tranzactii;
        }

        public double TotalVenit()
        {
            return tranzactii
                .Where(t => t.Tip == TipTranzactie.Venit)
                .Sum(t => t.Suma);
        }
    }
}