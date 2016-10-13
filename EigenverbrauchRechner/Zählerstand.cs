using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EigenverbrauchRechner
{
    [DataContract]
    class Zählerstand
    {

        private int id;
        private int produziert;
        private int eingespeist;
        private int zugekauft;

        private int gesamtProduziert;
        private int gesamtEingespeist;
        private int gesamtZugekauft;

        public Zählerstand(int Id, int Produziert, int Eingespeist, int Zugekauft)
        {
            id = Id;
            gesamtProduziert = Produziert;
            gesamtEingespeist = Eingespeist;
            gesamtZugekauft = Zugekauft;
        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public int GesamtProduziert
        {
            get { return gesamtProduziert; }
            set { gesamtProduziert = value; }
        }

        [DataMember]
        public int GesamtEingespeist
        {
            get { return gesamtEingespeist; }
            set { gesamtEingespeist = value; }
        }

        [DataMember]
        public int GesamtZugekauft
        {
            get { return gesamtZugekauft; }
            set { gesamtZugekauft = value; }
        }

        public int Produziert
        {
            get { return produziert; }
            set { produziert = value; }
        }

        public int Eingespeist
        {
            get { return eingespeist; }
            set { eingespeist = value; }
        }

        public int Zugekauft
        {
            get { return zugekauft; }
            set { zugekauft = value; }
        }

        public void calc(Zählerstand letzteDaten)
        {
            gesamtProduziert = produziert - letzteDaten.Produziert;
            gesamtEingespeist = eingespeist - letzteDaten.Eingespeist;
            GesamtZugekauft = -zugekauft - letzteDaten.Zugekauft;
        }

    }
}
