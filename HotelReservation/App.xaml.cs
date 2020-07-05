using HotelReservation.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HotelReservation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnExit(ExitEventArgs e)
        {
            FileStorageService fileStorageService = new FileStorageService();
            fileStorageService.Save();
            base.OnExit(e);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            FileStorageService fileStorageService = new FileStorageService();
            fileStorageService.Open();
        }
    }
}
