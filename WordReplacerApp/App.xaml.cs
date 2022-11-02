using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WordReplacerApp.ViewModels;

namespace WordReplacerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            SetupDependencyInjection();
        }

        private void SetupDependencyInjection()
        {
            Ioc.Default.ConfigureServices(
            new ServiceCollection()
                    .AddSingleton<IDialogService, DialogService>()
                    .AddSingleton<MainViewModel>()
                    .BuildServiceProvider());

        }
    }
}
