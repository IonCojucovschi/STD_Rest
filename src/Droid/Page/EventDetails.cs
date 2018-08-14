using System;
using Android.App;
using Android.Content.PM;
using Core.ViewModels;
using Droid.Page.Base;

namespace Droid.Page
{
    [Activity(Label = "EventsDetail", Theme = "@style/AppTheme",
              LaunchMode = LaunchMode.SingleTop,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class EventDetails : NavigationBasePage<EventDetailsViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.event_detail;
    }
}
