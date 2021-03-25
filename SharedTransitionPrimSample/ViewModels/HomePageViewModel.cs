using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SharedTransitionPrimSample.Models;

namespace SharedTransitionPrimSample.ViewModels
{
    public class HomePageViewModel : BindableBase
    {
        INavigationService _navigationService;

        public List<Place> Places { get; private set; }

        public DelegateCommand<Place> NavigateToDetailCommand { get; }

        private string _selectedPlaceId;
        public string SelectedPlaceId
        {
            get => _selectedPlaceId;
            set => SetProperty(ref _selectedPlaceId, value);
        }

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateToDetailCommand = new DelegateCommand<Place>(async(param) => await ExecuteNavigateToDetail(param));

            Places = new List<Place> {
                {new Place("Resorts", "https://www.planetware.com/wpimages/2020/12/dominican-republic-best-all-inclusive-resorts-hyatt-ziva-cap-cana.jpg", "The huge Hyatt complex is in the upscale Cap Cana region of Punta Cana, sitting on Playa Juanillo (Juanillo Beach). This five-start luxury resort offers just about everything one could ask for in an all-inclusive vacation, starting with a stretch of private beach on the Dominican Republic's most exclusive shoreline.") },
                {new Place("Jarabacoa", "https://www.planetware.com/photos-large/DOM/dominican-republic-el-limon-waterfall.jpg", "While many Dominican vacationers consider Jarabacoa a summer retreat destination, foreign travelers tend to see it as an outdoor adventure playground in the mountains of the Dominican Republic's interior. In the vicinity are opportunities for rafting, hiking, biking, and other types of exploration.") },
                {new Place("Zone Colonial", "https://www.planetware.com/photos-large/DOM/dominican-republic-santo-domingo-church-on-calle-el-conde.jpg", "In this city, where Christopher Columbus first landed in the America's, you'll find the hustle and bustle of modern day life being played out against the backdrop of centuries-old buildings. The colonial architecture, much of which today houses museums, restaurants, shops, and quaint hotels, lines the streets and squares, and takes you back to another era in mind-blowing fashion. Much of the activity focuses around Calle El Conde, the main thoroughfare and a popular street for shopping or dining el fresco. ") },
                {new Place("Bahia de Las Aguilas", "https://www.planetware.com/wpimages/2018/08/dominican-republic-attractions-places-to-visit-bahia-de-las-aguilas.jpg", "Well off the major tourist route, the remote Bahia de Las Aguillas in Jaragua National Park is a glorious eight-kilometer stretch of beach, which you may have all to yourself on any given day. The shallow, clear, calm water and white-sand bottom, combined with a distinct lack of tourism and development, make this one of the most pristine beaches in the Dominican Republic.") }
              };
        }

        async Task ExecuteNavigateToDetail(Place place)
        {
            SelectedPlaceId = place.Id;
            await _navigationService.NavigateAsync("DetailPage", (("PLACE", place)));
        }
    }
}
