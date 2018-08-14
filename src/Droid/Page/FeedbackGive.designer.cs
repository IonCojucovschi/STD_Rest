using System;
using Android.Views;
using Android.Widget;
using Core.ViewModels;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class FeedbackGive
    {
        [CrossView(nameof(FeedbackGiveViewModel.BackgroundContent))]
        [InjectView(Resource.Id.main_content_background)]
        public LinearLayout BackgroundView { get; set; }

        [CrossView(nameof(FeedbackGiveViewModel.TitleText))]
        [InjectView(Resource.Id.titele_text_content)]
        public TextView TitleText { get; set; }

        [CrossView(nameof(FeedbackGiveViewModel.HeaderBackroundRoundText))]
        [InjectView(Resource.Id.view_service_image)]
        public View HeaderBackroundRoundText { get; set; }

        [CrossView(nameof(FeedbackGiveViewModel.BackroundServiceImage))]
        [InjectView(Resource.Id.service_image_feedback)]
        public ImageView BackroundServiceImage { get; set; }

        [CrossView(nameof(FeedbackGiveViewModel.SericeText))]
        [InjectView(Resource.Id.service_feedback_text)]
        public TextView SericeText { get; set; }


        [CrossView(nameof(FeedbackGiveViewModel.ListView))]
        [InjectView(Resource.Id.emoji_list)]
        public BaseRecyclerView ListView { get; set; }

        [CrossView(nameof(FeedbackGiveViewModel.ConfirmButton))]
        [InjectView(Resource.Id.submit_fedback_text)]
        public TextView ConfirmButton { get; set; }

    }
}
