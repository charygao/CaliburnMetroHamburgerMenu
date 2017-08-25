namespace CaliburnMetroHamburgerMenu
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    using Caliburn.Micro;

    using CaliburnMetroHamburgerMenu.ViewModels;

    using MahApps.Metro.IconPacks;

    public class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper()
            : base(true)
        {
            this.Initialize();

            this.Container.Singleton<IWindowManager, MetroWindowManager>();

            this.Container.Instance<IPane>(new PaneViewModel("Acorn", PackIconModernKind.Acorn));
            this.Container.Instance<IPane>(new PaneViewModel("Page", PackIconModernKind.Page));
            this.Container.Instance<IPane>(new PaneViewModel("Baby", PackIconModernKind.Baby));

            this.Container.Singleton<ShellViewModel>();
        }

        public SimpleContainer Container { get; } = new SimpleContainer();


        protected override object GetInstance(Type serviceType, string key)
        {
            return this.Container.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return this.Container.GetAllInstances(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            this.Container.BuildUp(instance);
        }

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            this.DisplayRootViewFor<ShellViewModel>();
        }
    }
}
