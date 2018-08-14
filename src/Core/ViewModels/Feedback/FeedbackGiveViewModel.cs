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
using Core.Helpers;
using Core.Helpers.Manager.Feedback;
using Core.Models.Contract;
using Core.Resources.Colors;
using Core.Resources.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Data.MVVM.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;

#if __IOS__
#else
using Droid.Views.Feedback;
#endif

namespace Core.ViewModels
{
    public class FeedbackGiveViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => RFeedback.FeedbackText;

        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.Back;

        public virtual ICrossCellViewHolder<IFeedback> CellModel1 { get; protected set; }

        [CrossView]
        public IView BackgroundContent { get; set; }

        [CrossView]
        public IListView ListView { get; set; }

        [CrossView]
        public IView HeaderBackroundRoundText { get; set; }

        [CrossView]
        public IImage BackroundServiceImage { get; set; }

        [CrossView]
        public IText SericeText { get; set; }

        [CrossView]
        public IText TitleText { get; set; }

        [CrossView]
        public IText ConfirmButton { get; set; }

        public override void UpdateData()
        {
            base.UpdateData();

            InitViews();

            CellModel1 = new StatusFeedbackListCell(this);

            ListView?.UpdateDataSource(FeedbackManager.Instance.GetItem());
            ListView?.Orientation(OrientationListView.Horizontal);
        }
        private void InitViews()
        {
            BackgroundContent?.SetBackgroundColor(ColorConstants.BackroundContent);

            if (TitleText != null)
            {
                TitleText.Text = RFeedback.GiveUsFedbackText;
                TitleText.SetTextColor(ColorConstants.WhiteColor);
                TitleText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size24);
            }

            if (ConfirmButton != null)
            {
                ConfirmButton.SetTextColor(ColorConstants.WhiteColor);
                ConfirmButton.Text = RFeedback.SubmitFeedbackText.ToUpperInvariant();
                ConfirmButton.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
                ConfirmButton.SetBackgroundColor(ColorConstants.SelectorHome);
                ConfirmButton.Click -= Confirm_Click;
                ConfirmButton.Click += Confirm_Click;
                ConfirmButton.SetSelectedColor(ColorConstants.WhiteColor);

                ConfirmButton.Visibility = FeedbackManager.Instance.LastService ? ViewState.Visible : ViewState.Invisible;
            }

            HeaderBackroundRoundText?.SetBackgroundColor(ColorConstants.BackroundCell, type: RadiusType.Aspect);
            BackroundServiceImage?.SetImageFromResource(FeedbackManager.Instance.GetCurrentItem()?.ImagePathCategory);

            if (SericeText == null) return;
            SericeText.Text = FeedbackManager.Instance.GetCurrentItem()?.NameCategory;
            SericeText.SetTextColor(ColorConstants.WhiteColor);
            SericeText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size18);
        }

        public override void OnPause()
        {
            base.OnPause();

            FeedbackManager.Instance.ResetSelected();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            FeedbackManager.Instance.PostFeedback(GoBack, (obj) =>
             {
                 ShowError(obj);
             });
        }

        public class StatusFeedbackListCell : ICrossCellViewHolder<IFeedback>
        {
            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IImage ServiceImage { get; set; }

            [CrossView]
            public IText ServiceText { get; set; }

            private readonly IBaseViewModel _baseViewModel;

            public StatusFeedbackListCell(IBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            public void Bind(IFeedback model)
            {
                if (CellContentRootView != null)
                {
                    CellContentRootView.Tag = new { Model = model, Text = ServiceText, Image = ServiceImage };
                    CellContentRootView.Click -= CellContentRootView_Click;
                    CellContentRootView.Click += CellContentRootView_Click;

                    CellContentRootView.SetBackgroundColor(ColorConstants.TransparentColor);
                }

                if (ServiceText != null)
                {
                    ServiceText.Text = model.Name.ToUpperInvariant();
                    ServiceText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size12);

                    if (!FeedbackManager.Instance.LastService)
                        ServiceText.SetTextColor(ColorConstants.BackgroundGray);
                    else if (!model.Selected)
                        ServiceText.SetTextColor(ColorConstants.BackgroundGray);
                    else
                        ServiceText.SetTextColor(ColorConstants.SelectorHome);
                }

                if (ServiceImage == null) return;
                ServiceImage.SetImageFromResource(model.ImagePath);

                if (!FeedbackManager.Instance.LastService)
                    ServiceImage.SetImageColorFilter(ColorConstants.BackgroundGray);
                else if (!model.Selected)
                    ServiceImage.SetImageColorFilter(ColorConstants.BackgroundGray);
                else
                    ServiceImage.SetImageColorFilter(ColorConstants.SelectorHome);
            }

            private void CellContentRootView_Click(object sender, EventArgs e)
            {
                dynamic @object = (sender as IView)?.Tag;

                if (@object?.Model is IFeedback model) FeedbackManager.Instance.UpdateFeedbackItem(model.Id);

                (_baseViewModel as FeedbackGiveViewModel)?.UpdateData();
            }

            public void OnCreate() { }
        }
    }
}
