using Android;
using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Core.ViewModels.Beer;
using Droid.Page.Base;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    [Activity(LaunchMode = LaunchMode.SingleTop,
              Theme = "@style/AppTheme",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class Code : NavigationBasePage<CodeViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.qr_code_layout;
    }


}

