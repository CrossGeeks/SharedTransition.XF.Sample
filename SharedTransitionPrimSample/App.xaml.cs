using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using SharedTransitionPrimSample.ViewModels;
using SharedTransitionPrimSample.Views;

namespace SharedTransitionPrimSample
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initialzer = null) : base(initialzer) { }
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("CustomTransitionNavPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CustomTransitionNavPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<DetailPage, DetailPageViewModel>();
        }
    }
}

