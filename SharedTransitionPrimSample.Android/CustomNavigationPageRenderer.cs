using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AView = Android.Views.View;
using Android.Content;
using SharedTransitionPrimSample.Views;
using SharedTransitionPrimSample.Droid;
using Plugin.SharedTransitions.Platforms.Android;

[assembly: ExportRenderer(typeof(CustomTransitionNavPage), typeof(CustomNavigationPageRenderer))]
namespace SharedTransitionPrimSample.Droid
{
    public class CustomNavigationPageRenderer : SharedTransitionNavigationPageRenderer
    {
        public CustomNavigationPageRenderer(Context context) : base(context)
        {

        }

        IPageController PageController => Element as IPageController;
        CustomTransitionNavPage CustomNavigationPage => Element as CustomTransitionNavPage;

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            CustomNavigationPage.IgnoreLayoutChange = true;
            base.OnLayout(changed, l, t, r, b);
            CustomNavigationPage.IgnoreLayoutChange = false;

            int containerHeight = b - t;

            PageController.ContainerArea = new Rectangle(0, 0, Context.FromPixels(r - l), Context.FromPixels(containerHeight));

            for (var i = 0; i < ChildCount; i++)
            {
                AView child = GetChildAt(i);

                if (child is Android.Support.V7.Widget.Toolbar)
                {
                    continue;
                }

                child.Layout(0, 0, r, b);
            }
        }
    }
}
