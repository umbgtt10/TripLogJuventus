namespace TripLog.Views
{
    using System;

    using Xamarin.Forms;

    using TripLog.ViewModels;

    public class ViewFactory
    {
        private readonly ViewModelFactory _viewModelFactory;

        public ViewFactory(ViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public ContentPage Build(ViewType modelType, BaseViewModel viewModel)
        {
            switch(modelType)
            {
                case ViewType.Main:
                    var mainPage = new MainPage(viewModel);
                    return mainPage;
                case ViewType.New:
                    var newEntryPage = new NewEntryPage(viewModel);
                    return newEntryPage;
                case ViewType.Detail:
                    var detailPage = new DetailPage(viewModel);
                    return detailPage;
                    default:
                    throw new Exception($"Unknown {modelType}");
            }
        }
    }
}
