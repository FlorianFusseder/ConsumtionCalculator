using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EigenverbrauchRechner
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private ViewModel vm;

        protected override void OnStartup(StartupEventArgs e)
        {

            var win = new MainWindow
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Title = "Rechner"
            };

            vm = new ViewModel();
            var service = new PersistenzService<ObservableCollection<Zählerstand>>();
            if (File.Exists("data.xml"))
                vm.Jahre = service.Load();
            else
                vm.Jahre = new ObservableCollection<Zählerstand>();

            win.DataContext = vm;
            win.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {


            var service = new PersistenzService<ObservableCollection<Zählerstand>>();

            File.Delete(@"data.xml");

            while (File.Exists(@"data.xml")) ;

            service.Save(vm.Jahre);

            base.OnExit(e);
        }
    }
}
