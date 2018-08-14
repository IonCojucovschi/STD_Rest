//
//  FeedbackViewModel.cs
//
//  Author:
//       Songurov <songurov@gmail.com>
//
//  Copyright (c) 2018 Songurov Fiodor
//
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
//
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using System.Linq;
using System.Threading;
using Core.Extensions;
using Core.Helpers;
using Core.Helpers.Manager.Feedback;
using Core.Models.Contract;
using Core.Resources.Colors;
using Core.Resources.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;

#if __IOS__
#else
using Droid.Views.Feedback;
#endif

namespace Core.ViewModels
{
    public class FeedbackViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => RFeedback.FeedbackText;

        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.Menu;


        public virtual ICrossCellViewHolder<IFeedback> CellModel1 { get; protected set; }

        [CrossView]
        public IView BackgroundContent { get; set; }

        [CrossView]
        public IListView ListView { get; set; }

        [CrossView]
        public IText LeaveFedbackText { get; set; }

        [CrossView]
        public IText LeaveFedbackButton { get; set; }

        public override void UpdateData()
        {
            base.UpdateData();

            InitViews();

            CellModel1 = new FeedbackListCell(this);

            LoadListItems();
        }

        private void LoadListItems()
        {
            Show();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                FeedbackManager.Instance.GetCategoryItem(data =>
                {
                    Hide();

                    ListView?.UpdateDataSource(data);
                    ListView?.RowCountLimit(4);

                }, err => ShowError(err));
            });
        }


        private void InitViews()
        {
            BackgroundContent?.SetBackgroundColor(ColorConstants.BackroundContent);

            if (LeaveFedbackText != null)
            {
                LeaveFedbackText.Text = RFeedback.ClientsFeedBakText;
                LeaveFedbackText.SetTextColor(ColorConstants.WhiteColor);
                LeaveFedbackText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size24);
            }

            if (LeaveFedbackButton == null) return;
            LeaveFedbackButton.SetTextColor(ColorConstants.WhiteColor);
            LeaveFedbackButton.Text = RFeedback.GiveUsFedbackText.ToUpperInvariant();
            LeaveFedbackButton.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
            LeaveFedbackButton.SetBackgroundColor(ColorConstants.SelectorHome);
            LeaveFedbackButton.Click -= LeaveFedbakButtonIsClicked;
            LeaveFedbackButton.Click += LeaveFedbakButtonIsClicked;
            LeaveFedbackButton.SetSelectedColor(ColorConstants.WhiteColor);
        }
        private void LeaveFedbakButtonIsClicked(object sender, EventArgs e)
        {
            this.GoPage(PageConstants.PageNameFeedbackGive);
        }

        public class FeedbackListCell : ICrossCellViewHolder<IFeedback>
        {
            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IText ServiceText { get; set; }

            [CrossView]
            public IText Service2Text { get; set; }

            [CrossView]
            public IText FeedbackVotes { get; set; }

            [CrossView]
            public IText FeedbackStatus { get; set; }

            [CrossView]
            public IImage ServiceImage { get; set; }

            [CrossView]
            public IImage ImageStatus { get; set; }

            [CrossView]
            public IView ProgressView { get; set; }

            [CrossView]
            public IView ProgressView20 { get; set; }

            [CrossView]
            public IView ProgressView40 { get; set; }

            [CrossView]
            public IView ProgressView60 { get; set; }

            [CrossView]
            public IView ProgressView80 { get; set; }

            private readonly ProjectBaseViewModel _baseViewModel;

            public FeedbackListCell(ProjectBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            public void Bind(IFeedback model)
            {
                CellContentRootView?.SetBackgroundColor(ColorConstants.TransparentColor, 4);

                if (ServiceText != null)
                {
                    ServiceText.Text = "";
                    ServiceText.SetTextColor(ColorConstants.WhiteColor);
                    ServiceText.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size12);
                }

                if (Service2Text != null)
                {
                    Service2Text.Text = model.NameCategory;
                    Service2Text.SetTextColor(ColorConstants.WhiteColor);
                    Service2Text.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size12);
                }

                if (FeedbackStatus != null)
                {
                    FeedbackStatus.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size18);
                    FeedbackStatus.SetTextColor(ColorConstants.WhiteColor);
                }

                if (FeedbackVotes != null)
                {
                    FeedbackVotes.Text = "";
                    FeedbackVotes.SetTextColor(ColorConstants.BackgroundGray);
                    FeedbackVotes.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size12);
                }

                ServiceImage?.SetImageFromResource(model.ImagePathCategory);
                ProgressView?.SetBackgroundColor(ColorConstants.WhiteColor.SelectorTransparence(ColorConstants.Procent20), 5);

                if (model.Rating == 0)
                {
                    ResetView();

                    FeedbackStatus.Text = RFeedback.TerribleText.ToUpperInvariant();
                    ImageStatus?.SetImageFromResource(FeedbackManager.Instance.GetItem().ElementAtOrDefault(0).ImagePath);
                }
                else if (model.Rating <= 20)
                {
                    FeedbackStatus.Text = RFeedback.TerribleText.ToUpperInvariant();
                    ImageStatus?.SetImageFromResource(FeedbackManager.Instance.GetItem().ElementAtOrDefault(0).ImagePath);
                    ProgressView20?.SetBackgroundColor(ColorConstants.SelectorHome, 5);

                    ProgressView20.Visibility = ViewState.Visible;
                    ProgressView40.Visibility = ViewState.Invisible;
                    ProgressView60.Visibility = ViewState.Invisible;
                    ProgressView80.Visibility = ViewState.Invisible;
                }
                else if (model.Rating <= 40)
                {
                    FeedbackStatus.Text = RFeedback.BadText.ToUpperInvariant();
                    ImageStatus?.SetImageFromResource(FeedbackManager.Instance.GetItem().ElementAtOrDefault(1).ImagePath);
                    ProgressView40?.SetBackgroundColor(ColorConstants.SelectorHome, 5);

                    ProgressView40.Visibility = ViewState.Visible;
                    ProgressView20.Visibility = ViewState.Invisible;
                    ProgressView60.Visibility = ViewState.Invisible;
                    ProgressView80.Visibility = ViewState.Invisible;
                }
                else if (model.Rating <= 60)
                {
                    FeedbackStatus.Text = RFeedback.OkayText.ToUpperInvariant();
                    ImageStatus?.SetImageFromResource(FeedbackManager.Instance.GetItem().ElementAtOrDefault(2).ImagePath);
                    ProgressView60?.SetBackgroundColor(ColorConstants.SelectorHome, 5);

                    ProgressView60.Visibility = ViewState.Visible;
                    ProgressView40.Visibility = ViewState.Invisible;
                    ProgressView20.Visibility = ViewState.Invisible;
                    ProgressView80.Visibility = ViewState.Invisible;
                }
                else if (model.Rating <= 80)
                {
                    FeedbackStatus.Text = RFeedback.GoodText.ToUpperInvariant();
                    ImageStatus?.SetImageFromResource(FeedbackManager.Instance.GetItem().ElementAtOrDefault(3).ImagePath);
                    ProgressView80?.SetBackgroundColor(ColorConstants.SelectorHome, 5);

                    ProgressView80.Visibility = ViewState.Visible;
                    ProgressView60.Visibility = ViewState.Invisible;
                    ProgressView40.Visibility = ViewState.Invisible;
                    ProgressView20.Visibility = ViewState.Invisible;
                }
                else if (model.Rating == 100)
                {
                    FeedbackStatus.Text = RFeedback.GreatText.ToUpperInvariant();
                    ImageStatus?.SetImageFromResource(FeedbackManager.Instance.GetItem().ElementAtOrDefault(4).ImagePath);
                    ProgressView?.SetBackgroundColor(ColorConstants.SelectorHome, 5);

                    ResetView();
                }

                ImageStatus?.SetImageColorFilter(ColorConstants.WhiteColor.SelectorTransparence(ColorConstants.Procent84));
            }

            private void ResetView()
            {
                ProgressView80.Visibility = ViewState.Invisible;
                ProgressView60.Visibility = ViewState.Invisible;
                ProgressView40.Visibility = ViewState.Invisible;
                ProgressView20.Visibility = ViewState.Invisible;
            }

            public void OnCreate() { }
        }
    }
}
