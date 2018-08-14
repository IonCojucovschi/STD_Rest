//
//  ProjectNavigationBaseViewModel.cs
//
//  Author:
//       Songurov <songurov@gmail.com>
//
//  Copyright (c) 2018 Songurov
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
using System.Collections.Generic;
using Core.Extensions;
using Core.Helpers;
using Core.Helpers.Manager.Home;
using Core.Models.DAL.Home;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Int.Core.Application.Menu.Contract;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Core.Helpers.Manager;

namespace Core.ViewModels.Base
{
    public abstract class ProjectNavigationBaseViewModel : ProjectBaseViewModel
    {
        [Flags]
        public enum HeaderAreaActionType
        {
            Nothing,
            Back,
            Shop,
            Menu
        }

        public string CurrentPageName { get; set; }

        public Action MenuOpen { get; set; }

        [CrossView]
        public IView RootViewSide { get; protected set; }

        [CrossView]
        public IView SideContainer { get; protected set; }

        [CrossView]
        public IImage SideImage { get; protected set; }

        public override void UpdateData()
        {
            base.UpdateData();


            MenuCell = new SideMenuCell(this);

            SideMenuListView?.UpdateDataSource(MenuManager.Instance.GetMenuItem());

            if (RootViewSide != null)
            {
                RootViewSide.Click -= MenuAction;
                RootViewSide.Click += MenuAction;
            }

            if (SideImage != null)
            {
                SideImage?.SetImageFromResource(DrawableConstants.MenuOpenIcon);
                SideImage?.SetSelected(ColorConstants.BlackColor);

                SideImage.Click -= MenuAction;
                SideImage.Click += MenuAction;
            }

            if (!SideContainer.IsNull())
            {
                SideContainer.SetBackgroundColor(ColorConstants.SelectorHome);

                SideContainer.Click += SideContainer_click;
                SideContainer.Click += SideContainer_click;
            }

            SideMenuListView?.UpdateDataSource(MenuManager.Instance.GetMenuItem());
            SetupHeaderView();
        }

        private void SideContainer_click(object sender, EventArgs eventArgs)
        {
            RootViewSide.Click -= MenuAction;
            RootViewSide.Click += MenuAction;
        }

        [CrossView]
        public IView HeaderRootView { get; protected set; }

        [CrossView]
        public IView ContentView { get; protected set; }

        [CrossView]
        public IText HeaderTextView { get; protected set; }

        [CrossView]
        public IText CounterTextView { get; protected set; }

        [CrossView]
        public IView HeaderLine { get; protected set; }

        [CrossView]
        public IView BottomHeaderLine { get; protected set; }
        //Left
        [CrossView]
        public IView HeaderLeftTouchArea { get; protected set; }
        [CrossView]
        public IImage HeaderLeftImageView { get; protected set; }


        //Right
        [CrossView]
        public IView HeaderRightTouchArea { get; protected set; }
        [CrossView]
        public IImage HeaderRightImageView { get; protected set; }


        //Menu List
        [CrossView]
        public IListView SideMenuListView { get; protected set; }


        [CrossView]
        public IView MenuLine { get; protected set; }

        ///menu Cell
        public ICrossCellViewHolder<IItemMenu> MenuCell;


        protected abstract string HeaderText { get; }

        protected abstract HeaderAreaActionType HeaderAreaAction { get; }

        public HeaderAreaActionType TypeMenu => HeaderAreaAction;

        protected virtual void SetupHeaderView()
        {
            MenuLine?.SetBackgroundColor(ColorConstants.BackgroundGray);
            BottomHeaderLine?.SetBackgroundColor(ColorConstants.BlackColor);
            HeaderRootView?.SetBackgroundColor(ColorConstants.BlackColor);
            ContentView?.SetBackgroundColor(ColorConstants.BackroundContent);
            HeaderLeftImageView?.SetSelected(ColorConstants.BlackColor);
            HeaderRightImageView?.SetSelected(ColorConstants.BlackColor);

            HeaderLine?.SetBackgroundColor(ColorConstants.BlackColor);

            if (CounterTextView != null)
                CounterTextView.Visibility = ViewState.Invisible;

            switch (HeaderAreaAction)
            {
                case HeaderAreaActionType.Nothing:

                    HeaderLeftImageView?.SetImageFromResource(null);
                    HeaderRightImageView?.SetImageFromResource(null);
                    if (!HeaderLeftTouchArea.IsNull())
                    {
                        HeaderLeftTouchArea.Click -= BackAction;
                        HeaderRightTouchArea.Click -= Shop;
                    }

                    break;
                case HeaderAreaActionType.Back:

                    HeaderLeftImageView?.SetImageFromResource(DrawableConstants.BackIcon);
                    HeaderLeftImageView?.SetSelected(ColorConstants.SelectorHome);

                    if (HeaderLeftImageView != null)
                    {
                        HeaderLeftImageView.Click -= BackAction;
                        HeaderLeftImageView.Click += BackAction;
                    }

                    HeaderRightImageView?.SetImageFromResource(null);

                    if (!HeaderTextView.IsNull())
                    {
                        HeaderTextView.Text = HeaderText;
                        HeaderTextView.SetTextColor(ColorConstants.WhiteColor);
                        HeaderTextView.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size18);
                    }
                    if (!HeaderLeftTouchArea.IsNull() && !HeaderRightTouchArea.IsNull())
                    {
                        HeaderLeftTouchArea.Click -= BackAction;
                        HeaderLeftTouchArea.Click += BackAction;
                        HeaderRightTouchArea.Click -= Shop;
                    }
                    break;

                case HeaderAreaActionType.Menu:

                    if (!HeaderLeftImageView.IsNull())
                    {
                        HeaderLeftImageView?.SetImageFromResource(DrawableConstants.MenuIcon);
                        HeaderLeftImageView?.SetSelected(ColorConstants.SelectorHome);
                        if (HeaderLeftImageView != null)
                        {
                            HeaderLeftImageView.Click -= MenuAction;
                            HeaderLeftImageView.Click += MenuAction;
                        }
                    }

                    HeaderRightImageView?.SetImageFromResource(null);

                    if (!HeaderTextView.IsNull())
                    {
                        HeaderTextView.Text = HeaderText;
                        HeaderTextView.SetTextColor(ColorConstants.WhiteColor);
                        HeaderTextView.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size18);
                    }

                    break;

                case HeaderAreaActionType.Shop:

                    HeaderLeftImageView?.SetImageFromResource(DrawableConstants.MenuIcon);
                    HeaderLeftImageView?.SetSelected(ColorConstants.SelectorHome);
                    if (HeaderLeftImageView != null)
                    {
                        HeaderLeftImageView.Click -= MenuAction;
                        HeaderLeftImageView.Click += MenuAction;
                    }


                    HeaderRightImageView?.SetImageFromResource(DrawableConstants.ShopIcon);
                    HeaderRightImageView?.SetSelected(ColorConstants.SelectorHome);

                    HeaderRightImageView.Click -= Shop;
                    HeaderRightImageView.Click += Shop;

                    if (!CounterTextView.IsNull())
                    {
                        CounterTextView.Visibility = ViewState.Visible;
                        CounterTextView.Text = OrderManager.Instance.CurrentOrderCount.ToString();

                        OrderManager.Instance.ChangeOrder -= Instance_ChangeOrder;
                        OrderManager.Instance.ChangeOrder += Instance_ChangeOrder;
                        CounterTextView.SetTextColor(ColorConstants.WhiteColor);

                        CounterTextView.SetBackgroundColor(ColorConstants.SelectorHome, 8);
                    }

                    if (!HeaderTextView.IsNull())
                    {
                        HeaderTextView.Text = HeaderText;
                        HeaderTextView.SetTextColor(ColorConstants.WhiteColor);
                        HeaderTextView.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size18);
                    }

                    if (!HeaderLeftTouchArea.IsNull() && !HeaderRightTouchArea.IsNull())
                    {
                        HeaderLeftTouchArea.Click -= MenuAction;
                        HeaderLeftTouchArea.Click += MenuAction;

                        HeaderRightTouchArea.Click -= Shop;
                        HeaderRightTouchArea.Click += Shop;
                    }

                    break;
            }
        }

        public override void OnPause()
        {

        }

        private void Instance_ChangeOrder(string counter)
        {
            if (!CounterTextView.IsNull())
                CounterTextView.Text = OrderManager.Instance.CurrentOrderCount.ToString();
        }

        protected virtual void MenuAction(object sender, EventArgs e)
        {
            MenuOpen?.Invoke();
        }

        protected virtual void BackAction(object sender, EventArgs e) => GoBack();

        protected virtual void Shop(object sender, EventArgs e)
        {

            if (OrderManager.Instance.CurrentOrderCount > 0)
                this.GoPage(PageConstants.PageNameOrder);
        }


        #region ListMenuItems 

        public class SideMenuCell : ICrossCellViewHolder<IItemMenu>
        {
            private readonly ProjectNavigationBaseViewModel _baseViewModel;

            public SideMenuCell(ProjectNavigationBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            [CrossView]
            public IImage ImageItemMenu { get; protected set; }

            [CrossView]
            public IView Line { get; protected set; }

            [CrossView]
            public IView RootView { get; protected set; }


            public void Bind(IItemMenu model)
            {
                var concretModel = model as IHome;

                Line?.SetBackgroundColor(ColorConstants.BackgroundGray);

                if (ImageItemMenu.IsNull()) return;

                ImageItemMenu?.SetImageFromResource(concretModel?.ImageMenu);

                if (concretModel != null && !concretModel.PageActive)
                {
                    ImageItemMenu?.SetImageColorFilter(ColorConstants.WhiteColor.SelectorTransparence(ColorConstants.Procent50));
                    return;
                }

                ImageItemMenu?.SetImageColorFilter(ColorConstants.WhiteColor);

                if (RootView != null)
                {
                    RootView.Tag = model;
                    RootView.Click -= ClickHandler;
                    RootView.Click += ClickHandler;
                }

                ImageItemMenu?.SetSelectedColor(ColorConstants.BlackColor);
            }

            public void OnCreate() { }

            private void ClickHandler(object sender, EventArgs e)
            {
                if (!(sender is IView iView)) return;
                if (!(iView.Tag is IItemMenu menuItem)) return;

                if (menuItem.ClickArgument == _baseViewModel?.CurrentPageName)
                    return;

                _baseViewModel?.GoPage(menuItem.ClickArgument);
            }
        }
        #endregion
    }
}
