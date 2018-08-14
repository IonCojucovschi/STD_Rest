// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using Core.Models.Contract;
using Core.ViewModels;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.iOS.Factories.Adapter;
using iOS.Page.BasePage;
using UIKit;

namespace iOS.Storyboard
{
    public partial class Feedback : BasePageNavigation<FeedbackViewModel>
    {
        public Feedback(IntPtr handle) : base(handle) { }

        protected override void BindViews()
        {
            base.BindViews();

            TableView.Source = ComponentViewSourceFactory.CreateForTable(nameof(FeedbackCell),
                            new List<IFeedback>(),
                            TableView,
                            crossCellModel: new FeedbackViewModel.FeedbackListCell(ModelView));
        }
    }

    partial class Feedback
    {
        [CrossView(nameof(FeedbackViewModel.ListView))]
        UITableView view1 => TableView;


        [CrossView(nameof(FeedbackViewModel.LeaveFedbackButton))]
        UILabel view2 => lblGiveUs;

        [CrossView(nameof(FeedbackViewModel.BackgroundContent))]
        UIView view3 => mainView;

        [CrossView(nameof(FeedbackViewModel.LeaveFedbackText))]
        UILabel view4 => lblTitle;
    }
}
