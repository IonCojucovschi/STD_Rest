using System;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;
using Core.ViewModels.Views;
using Android.Widget;
using Int.Droid.Factories.Adapter.RecyclerView;

namespace Droid.Views.Feedback
{
    public partial class FeedbackWindow
    {
        [CrossView(nameof(FeedbackWindowViewModel.BackgroundView))]
        [InjectView(Resource.Id.main_content_background)]
        public LinearLayout BackgroundView { get; set; }

        [CrossView(nameof(FeedbackWindowViewModel.MainWindowView))]
        [InjectView(Resource.Id.fedback_content_lists)]
        public LinearLayout MainWindowView { get; set; }

        [CrossView(nameof(FeedbackWindowViewModel.CloseImage))]
        [InjectView(Resource.Id.close_window_button)]
        public ImageView CloseImage { get; set; }

        [CrossView(nameof(FeedbackWindowViewModel.TitleText))]
        [InjectView(Resource.Id.titele_text_content)]
        public TextView TitleText { get; set; }

        [CrossView(nameof(FeedbackWindowViewModel.ListViewCategory))]
        [InjectView(Resource.Id.services_list)]
        public BaseRecyclerView ListViewCategory { get; set; }

        [CrossView(nameof(FeedbackWindowViewModel.ListViewEmoji))]
        [InjectView(Resource.Id.emoji_list)]
        public BaseRecyclerView ListViewEmoji { get; set; }

        [CrossView(nameof(FeedbackWindowViewModel.SubmitText))]
        [InjectView(Resource.Id.submit_fedback_text)]
        public TextView SubmitText { get; set; }

    }
}
