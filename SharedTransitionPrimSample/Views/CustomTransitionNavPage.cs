using System.Drawing;
using Plugin.SharedTransitions;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SharedTransitionPrimSample.Views
{
    public class CustomTransitionNavPage : SharedTransitionNavigationPage
    {
        public CustomTransitionNavPage()
        {
            //Code to make the NavigationPage translucent, if you don't want that you can remove it
            On<iOS>().SetIsNavigationBarTranslucent(true);
            BarBackgroundColor = Color.Transparent;
            BarTextColor = Color.Black;
            On<iOS>().SetHideNavigationBarSeparator(true);
        }

        public bool IgnoreLayoutChange { get; set; } = false;

        protected override void OnSizeAllocated(double width, double height)
        {
            if (!IgnoreLayoutChange)
                base.OnSizeAllocated(width, height);
        }
    }
}