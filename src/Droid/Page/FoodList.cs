using System;
using Android.App;
using Android.Content.PM;
using Core.ViewModels;
using Droid.Page.Base;

namespace Droid.Page
{
    [Activity(Label = "FoodList", Theme = "@style/AppTheme",
             LaunchMode = LaunchMode.SingleTop,
             ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
             ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class FoodList : NavigationBasePage<FoodViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.beer_list;
    }
}
