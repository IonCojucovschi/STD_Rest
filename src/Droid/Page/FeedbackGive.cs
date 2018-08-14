using System;
using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Core.Models.Contract;
using Core.ViewModels;
using Droid.Page.Base;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    [Activity(Label = "Events", Theme = "@style/AppTheme",
             LaunchMode = LaunchMode.SingleTop,
             ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
             ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class FeedbackGive : NavigationBasePage<FeedbackGiveViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.give_feedback;

        protected override void InitViews()
        {
            base.InitViews();


            ListView?.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                                   new EmojiFeedbackListCellViewHolder(inflater,
                                              parent, ModelView.CellModel1)));
        }
    }


    public class EmojiFeedbackListCellViewHolder : ComponentViewHolder<IFeedback>
    {
        public EmojiFeedbackListCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                               ICrossCellViewHolder<IFeedback> cellModel)
            : base(inflator.Inflate(Resource.Layout.emoji_item_feedback, parent, false), cellModel) { }

        [CrossView(nameof(FeedbackGiveViewModel.StatusFeedbackListCell.CellContentRootView))]
        [InjectView(Resource.Id.cell_emoji_content_wrapper)]
        public LinearLayout CellContentRootView { get; set; }

        [CrossView(nameof(FeedbackGiveViewModel.StatusFeedbackListCell.ServiceImage))]
        [InjectView(Resource.Id.image_status_feedback)]
        public ImageView ServiceImage { get; set; }

        [CrossView(nameof(FeedbackGiveViewModel.StatusFeedbackListCell.ServiceText))]
        [InjectView(Resource.Id.status_text)]
        public TextView ServiceText { get; set; }

    }
}
