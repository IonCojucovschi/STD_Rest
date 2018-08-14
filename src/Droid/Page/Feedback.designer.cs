using System;
using Android.Widget;
using Core.ViewModels;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class Feedback
    {

        [CrossView(nameof(FeedbackViewModel.BackgroundContent))]
        [InjectView(Resource.Id.feedback_background)]
        public LinearLayout BackGroundContent { get; set; }


        [CrossView(nameof(FeedbackViewModel.ListView))]
        [InjectView(Resource.Id.fedback_list)]
        public BaseRecyclerView ListView { get; set; }

        [CrossView(nameof(FeedbackViewModel.LeaveFedbackButton))]
        [InjectView(Resource.Id.give_feeedback_button)]
        public TextView LeaveFedback { get; set; }

        [CrossView(nameof(FeedbackViewModel.LeaveFedbackText))]
        [InjectView(Resource.Id.beedback_text_top)]
        public TextView LeaveFedbackText { get; set; }

    
    }
}
