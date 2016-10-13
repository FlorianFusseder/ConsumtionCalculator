using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EigenverbrauchRechner
{
    partial class ViewModel
    {
        private ICommand addCommand;
        private ICommand delCommand;


        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand(obj => addJahre());

                return addCommand;
            }
        }

        public ICommand DelCommand
        {
            get
            {
                if (delCommand == null)
                    delCommand = new RelayCommand(obj => Jahre.Remove(ausgewählt), obj => ausgewählt != null);

                return delCommand;
            }
        }

        private void addJahre()
        {
            NeuesJahr neuJahr = new NeuesJahr();

            if (neuJahr.ShowDialog().Value)
                Jahre.Add(neuJahr.ZählerStand);
        }

    }
}
