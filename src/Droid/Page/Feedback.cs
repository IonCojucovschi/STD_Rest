//
// Splash.cs
//
// Author:
//       Songurov Fiodor <songurov@gmail.com>
//
// Copyright (c) 2017 Songurov Fiodor
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.


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
    [Activity(Label = "Feedback", Theme = "@style/AppTheme",
              LaunchMode = LaunchMode.SingleTop,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class Feedback : NavigationBasePage<FeedbackViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.feedback;
        protected override void InitViews()
        {
            base.InitViews();

            ListView?.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                              new FeedbackListCellViewHolder(inflater,
                                              parent,
                                              ModelView.CellModel1)));
        }
    }

    public class FeedbackListCellViewHolder : ComponentViewHolder<IFeedback>
    {
        public FeedbackListCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                          ICrossCellViewHolder<IFeedback> cellModel)
            : base(inflator.Inflate(Resource.Layout.feedback_item_cell, parent, false), cellModel) { }

        [CrossView(nameof(FeedbackViewModel.FeedbackListCell.ServiceText))]
        [InjectView(Resource.Id.feedback_label1)]
        public TextView ServiceText { get; set; }

        [CrossView(nameof(FeedbackViewModel.FeedbackListCell.ServiceImage))]
        [InjectView(Resource.Id.type_image_feedback)]
        public ImageView ImageService { get; set; }

        [CrossView(nameof(FeedbackViewModel.FeedbackListCell.Service2Text))]
        [InjectView(Resource.Id.feedback_label_bottom_type)]
        public TextView Service2Text { get; set; }

        [CrossView(nameof(FeedbackViewModel.FeedbackListCell.ProgressView))]
        [InjectView(Resource.Id.progress_view)]
        public View ProgressView { get; set; }

        [CrossView(nameof(FeedbackViewModel.FeedbackListCell.ProgressView20))]
        [InjectView(Resource.Id.progress_view_20)]
        public View ProgressView20 { get; set; }

        [CrossView(nameof(FeedbackViewModel.FeedbackListCell.ProgressView40))]
        [InjectView(Resource.Id.progress_view_40)]
        public View ProgressView40 { get; set; }

        [CrossView(nameof(FeedbackViewModel.FeedbackListCell.ProgressView60))]
        [InjectView(Resource.Id.progress_view_60)]
        public View ProgressView60 { get; set; }

        [CrossView(nameof(FeedbackViewModel.FeedbackListCell.ProgressView80))]
        [InjectView(Resource.Id.progress_view_80)]
        public View ProgressView80 { get; set; }

        [CrossView(nameof(FeedbackViewModel.FeedbackListCell.ImageStatus))]
        [InjectView(Resource.Id.emoji_feedback)]
        public ImageView EmojiImage { get; set; }


        [CrossView(nameof(FeedbackViewModel.FeedbackListCell.FeedbackStatus))]
        [InjectView(Resource.Id.feedback_status)]
        public TextView FeedbackStatus { get; set; }

        [CrossView(nameof(FeedbackViewModel.FeedbackListCell.FeedbackVotes))]
        [InjectView(Resource.Id.feedback_votes)]
        public TextView FeedbackVotes { get; set; }

        [CrossView(nameof(EventsViewModel.EventsListSubTagCell.CellContentRootView))]
        [InjectView(Resource.Id.fedback_cell_root_view)]
        public LinearLayout CellContentRootView { get; set; }
    }
}
