using Prism.Mvvm;
using Prism.Navigation;
using SharedTransitionPrimSample.Models;

namespace SharedTransitionPrimSample.ViewModels
{
    public class DetailPageViewModel : BindableBase, IInitialize
    {
        private Place _placeSelected;

        public Place PlaceSelected
        {
            get => _placeSelected;
            set => SetProperty(ref _placeSelected, value); 
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue("PLACE", out Place place))
            {
                PlaceSelected = place;
            }
        }
    }
}
