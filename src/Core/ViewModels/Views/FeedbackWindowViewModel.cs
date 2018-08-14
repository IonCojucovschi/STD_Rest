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
using Core.Resources.Drawables;
using Core.Resources.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Data.MVVM.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels.Views
{
    public class FeedbackWindowViewModel : ProjectBaseViewModel
    {
        [CrossView]
        public IView BackgroundView { get; set; }

        [CrossView]
        public IView MainWindowView { get; set; }

        [CrossView]
        public IText SubmitText { get; set; }

        [CrossView]
        public IText TitleText { get; set; }

        [CrossView]
        public IImage CloseImage { get; set; }

        [CrossView]
        public IListView ListViewEmoji { get; set; }

        [CrossView]
        public IListView ListViewCategory { get; set; }

        public virtual ICrossCellViewHolder<IFeedback> CellModel1 { get; set; }

        public virtual ICrossCellViewHolder<ICategory> CellModel2 { get; set; }

        public override void UpdateData()
        {
            MainWindowView?.SetBackgroundColor(ColorConstants.WhiteColor, 8);

            CellModel2 = new FeedbackListCategoryCell(this);

            BackgroundView?.SetBackgroundColor(ColorConstants.TransparentColor);

            if (SubmitText != null)
            {
                SubmitText.SetTextColor(ColorConstants.WhiteColor);
                SubmitText.Text = "Submit Feedback".ToUpperInvariant();
                SubmitText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
                SubmitText.SetBackgroundColor(ColorConstants.SelectorHome);
                SubmitText.Click -= Submit_Click;
                SubmitText.Click += Submit_Click;
                SubmitText.SetSelectedColor(ColorConstants.WhiteColor);
            }

            if (TitleText != null)
            {
                TitleText.Text = RFeedback.GiveUsFedbackText;
                TitleText.SetTextColor(ColorConstants.FeedbackTitle);
                TitleText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size24);
            }

            if (CloseImage != null)
            {
                CloseImage?.SetImageFromResource(DrawableConstants.FeedbackCloseIcon);
                CloseImage.Click -= BackgroundView_Click;
                CloseImage.Click += BackgroundView_Click;
            }

            //ListViewCategory?.UpdateDataSource(FeedbackManager.Instance.GetCategoryItem());
            //ListViewCategory?.Orientation(OrientationListView.Horizontal);

            ListViewEmoji?.UpdateDataSource(FeedbackManager.Instance.GetItem());
            ListViewEmoji?.Orientation(OrientationListView.Horizontal);
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            CurrentPopupWindow?.Close();
        }

        private void BackgroundView_Click(object sender, EventArgs e)
        {
            CurrentPopupWindow?.Close();
        }


        #region CellBinding

        public class FeedbackListCategoryCell : ICrossCellViewHolder<ICategory>
        {
            [CrossView]
            public IView CellContentRootView { get; set; }


            [CrossView]
            public IImage CategoryImage { get; set; }

            [CrossView]
            public IText CategoryText { get; set; }

            private readonly IBaseViewModel _baseViewModel;

            public FeedbackListCategoryCell(IBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            public void Bind(ICategory model)
            {
                CellContentRootView?.SetBackgroundColor(ColorConstants.BackroundCell, 4);

                if (CellContentRootView != null)
                {
                    CellContentRootView.Tag = model;
                    CellContentRootView.Click -= CellContentRootView_Click;
                    CellContentRootView.Click += CellContentRootView_Click;
                }

                if (CategoryText != null)
                {
                    CategoryText.Text = model.Name.ToUpperInvariant();
                    CategoryText.SetTextColor(ColorConstants.WhiteColor);
                    CategoryText.SetBackgroundColor(ColorConstants.SelectorHome, 4);
                    CategoryText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size12);
                }

                if (CategoryImage != null)
                {
                    CategoryImage.SetImageFromResource(model.Image);
                    CategoryImage.SetBackgroundColor(ColorConstants.TransparentColor, 4);
                }
            }

            private void CellContentRootView_Click(object sender, EventArgs e)
            {
            }

            public void OnCreate() { }
        }



        #endregion
    }
}
