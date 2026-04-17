using LibrariiModele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StocareTranzactie
{
    public class StocareFisier
    {
        private string cale = "date.txt";
        private List<Tranzactie> tranzactii = new List<Tranzactie>();

        public StocareFisier()
        {
            Citeste();
        }

        public void Adauga(Tranzactie t)
        {
            tranzactii.Add(t);
            Salveaza();
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

        private void Salveaza()
        {
            File.WriteAllLines(cale,
                tranzactii.Select(t => $"{t.Tip}|{t.Descriere}|{t.Suma}"));
        }

        private void Citeste()
        {
            if (!File.Exists(cale)) return;

            tranzactii = File.ReadAllLines(cale)
                .Select(l =>
                {
                    var p = l.Split('|');
                    return new Tranzactie
                    {
                        Tip = Enum.Parse<TipTranzactie>(p[0]),
                        Descriere = p[1],
                        Suma = double.Parse(p[2])
                    };
                }).ToList();
        }
    }
}