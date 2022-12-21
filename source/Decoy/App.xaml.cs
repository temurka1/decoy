namespace Decoy
{
    using System;
    using System.Windows;

    using Prism.Ioc;
    using Prism.Mvvm;
    using Prism.DryIoc;

    using ViewModels;
    using Infrastructure;
    using Domain.Services;

    /// <summary>1
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        #region Methods

        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var type = typeof(MainViewModel);

                var viewModelTypeName = viewType.Name.Replace("View", "ViewModel");
                var viewModelTypeFullName = $"{type.Namespace}.{viewModelTypeName},{type.Assembly.FullName}";

                var vmType = Type.GetType(viewModelTypeFullName);
                return vmType;
            });
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<DecoyDbContext>();
            containerRegistry.RegisterSingleton<IQuoteGenerator, QuoteGenerator>();
        }

        #endregion
    }
}
