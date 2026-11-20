using System;
using System.Collections.Generic;
using System.Text;

namespace Konyvek
{
    public class Konyvek
    {
        public string cim { get; set; }
        public string szerzo { get; set; }
        public int oldalszam { get; set; }
        public string mufaj { get; set; }
        public bool elerheto { get; set; }
        public Konyvek(string cim,string szerzo,int oldalszam,string mufaj,bool elerheto)
        {
            this.cim = cim;
            this.szerzo = szerzo;
            this.oldalszam = oldalszam;
            this.mufaj = mufaj;
            this.elerheto = elerheto;
        }
    }
}
