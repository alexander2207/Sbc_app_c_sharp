using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public class fotbalist
    {   
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Varsta { get; set; }
        public string Echipa { get; set; }
        public int Meciuri_jucate {get; set;}
        public int Goluri_marcate {get; set;}

        public fotbalist(string nume, string prenume, int age, string team, int games, int goals)
        {
            Nume = nume;
            Prenume = prenume;
            Varsta = age;
            Echipa = team;
            Meciuri_jucate = games;
            Goluri_marcate = goals;
        }
        public override string ToString()
        {
            return Nume;
            
        }
    }
}
