using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EigenverbrauchRechner
{

    partial class ViewModel : BaseViewModel
    {
        private ObservableCollection<Zählerstand> jahre;
        private Zählerstand ausgewählt;
        private Zählerstand second;

        public string GesamtProduziert
        {
            get
            {
                return (ausgewählt == null) ? string.Empty : ausgewählt.GesamtProduziert.ToString();
            }
        }

        public string GesamtEingespeist
        {
            get
            {
                return (ausgewählt == null) ? string.Empty : ausgewählt.GesamtEingespeist.ToString();
            }
        }

        public string GesamtEingekauft
        {
            get
            {
                return (ausgewählt == null) ? string.Empty : ausgewählt.GesamtZugekauft.ToString();
            }
        }

        public string JahresProdukt
        {
            get
            {
                return (ausgewählt == null) ? string.Empty : (ausgewählt.GesamtProduziert - second.GesamtProduziert).ToString();
            }
        }

        public string JahresEinspeisung
        {
            get
            {
                return (ausgewählt == null) ? string.Empty : (ausgewählt.GesamtEingespeist - second.GesamtEingespeist).ToString();
            }
        }

        public string Eigenverbrauch
        {
            get
            {
                return (ausgewählt == null) ? string.Empty : (Convert.ToInt32(JahresProdukt) - Convert.ToInt32(JahresEinspeisung)).ToString();
            }
        }

        public string JahresEinkauf
        {
            get
            {
                return (ausgewählt == null) ? string.Empty : (ausgewählt.GesamtZugekauft - second.GesamtZugekauft).ToString();
            }
        }

        public string JahresVerbrauch
        {
            get
            {
                return (ausgewählt == null) ? string.Empty : (Convert.ToInt32(Eigenverbrauch) + Convert.ToInt32(JahresEinkauf)).ToString();
            }
        }

        public string EigenverbrauchProzent
        {
            get
            {
                if(ausgewählt == null)
                    return string.Empty;
                else
                {
                    decimal teiler = Convert.ToDecimal(JahresVerbrauch) / 100;
                    decimal eigen = Convert.ToDecimal(Eigenverbrauch) / teiler;
                    
                    return Math.Round(eigen, 2).ToString() + "%\t" + Eigenverbrauch;
                }
            }
        }

        public string KaufenProzent
        {
            get
            {
                if (ausgewählt == null)
                    return string.Empty;
                else
                {
                    decimal teiler = Convert.ToDecimal(JahresVerbrauch) / 100;
                    decimal kaufen = Convert.ToDecimal(JahresEinkauf) / teiler;
                    return Math.Round(kaufen, 2).ToString() + "%\t" + JahresEinkauf;
                }
            }
        }

        public Zählerstand Ausgewählt
        {
            get { return ausgewählt; }
            set
            {
                ausgewählt = value;
                if (jahre.IndexOf(value) > 0)
                {
                    second = jahre[jahre.IndexOf(value) - 1];
                }
                else
                {
                    second = new Zählerstand(0, 0, 0, 0);
                }

                OnPropertyChanged("Ausgewählt");
                OnPropertyChanged("GesamtProduziert");
                OnPropertyChanged("GesamtEingespeist");
                OnPropertyChanged("GesamtEingekauft");
                OnPropertyChanged("JahresProdukt");
                OnPropertyChanged("JahresEinspeisung");
                OnPropertyChanged("Eigenverbrauch");
                OnPropertyChanged("JahresEinkauf");
                OnPropertyChanged("JahresVerbrauch");
                OnPropertyChanged("EigenverbrauchProzent");
                OnPropertyChanged("KaufenProzent");
            }
        }

        public ObservableCollection<Zählerstand> Jahre
        {
            get { return jahre; }
            set
            {
                jahre = value;
            }
        }

        public ViewModel()
        {
        }
    }
}
