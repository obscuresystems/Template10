﻿using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace Template10.Samples.BusyIndicatorControlSample
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    sealed partial class App : Template10.Common.BootStrapper
    {
        public App()
        {
            InitializeComponent();
        }

        public override Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            NavigationService.Navigate(typeof(Views.MainPage));

			return Task.CompletedTask;
        }
    }
}

