using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Workbook.BLL.init;

namespace Workbook.Prism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            InitBLL.InitMapper();

            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}
