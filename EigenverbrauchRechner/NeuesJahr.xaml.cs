using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EigenverbrauchRechner
{
    /// <summary>
    /// Interaktionslogik für NeuesJahr.xaml
    /// </summary>
    public partial class NeuesJahr : Window
    {

        private Zählerstand zählerStand;

        internal Zählerstand ZählerStand
        {
            get { return zählerStand; }
            set { zählerStand = value; }
        }

        public NeuesJahr()
        {
            InitializeComponent();

            for (int i = 2010; i < 2100; i++)
            {
                cb.Items.Add(i.ToString());
            }
            cb.SelectedIndex = 0;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (tb1.Text != string.Empty && tb2.Text != string.Empty && tb3.Text != string.Empty)
            {
                zählerStand = new Zählerstand(Convert.ToInt32(cb.Text), Convert.ToInt32(tb1.Text), Convert.ToInt32(tb2.Text), Convert.ToInt32(tb3.Text));
                DialogResult = true;
                Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Papa, alles ausfüllen...");
                DialogResult = false;
                Close();
            }
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
