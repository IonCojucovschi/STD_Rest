//
// BasePage.cs
//
// Author:
//       Songurov Fiodor <songurov@gmail.com>
//
// Copyright (c) 2016 Songurov Fiodor
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

using System;
using System.Collections.Generic;
using Core.ViewModels.Base;
using Int.Core.Application.Menu.Contract;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.iOS.Extensions;
using Int.iOS.Factories.Adapter;
using iOS.Storyboard;
using iOS.Views.Window.Menu.Cell;
using iOS.Views.Window.Menu.UI;
using UIKit;
using static Core.ViewModels.Base.ProjectNavigationBaseViewModel;

namespace iOS.Page.BasePage
{
    public abstract class BasePageNavigation<TViewModel> : BaseView<TViewModel> where TViewModel : ProjectNavigationBaseViewModel
    {
        protected HeaderView Header => GetContainerView<HeaderView>();

        private bool _openMenu;

        private MenuView MenuView { get; set; } = new MenuView();

        protected UITableView TableViewMenu { get; set; }

        protected BasePageNavigation(IntPtr intP) : base(intP) { }

        protected override void BindViews()
        {
            base.BindViews();

            TableViewMenu = MenuView.TableView;

            ModelView.CurrentPageName = GetType().Name;

            if (!TableViewMenu.IsNull())
                TableViewMenu.Source = ComponentViewSourceFactory.CreateForTable(nameof(MenuViewCell),
                                                                                 new List<IItemMenu>(),
                                                                                 TableViewMenu,
                                                                                 crossCellModel: new SideMenuCell(ModelView), register: true);

            if (ModelView.TypeMenu != HeaderAreaActionType.Back)
            {
                View.OnSwipe((obj) =>
                {
                    switch (obj.Direction)
                    {
                        case UISwipeGestureRecognizerDirection.Left:
                            SwipeLeftToRight();
                            break;
                        case UISwipeGestureRecognizerDirection.Right:
                            SwipeRightToLeft();
                            break;
                    }
                });
            }
            ModelView.MenuOpen = PerformTableTransition;
        }

        private void SwipeLeftToRight()
        {
            if (_openMenu)
                PerformTableTransition();
        }

        private void SwipeRightToLeft()
        {
            if (!_openMenu)
                PerformTableTransition();
        }


        private void PerformTableTransition()
        {
            if (_openMenu)
            {
                MenuView.AnimationFade(AnimationType.Out);
                _openMenu = false;
            }
            else
            {
                MenuView.Frame = View.Frame;
                View.AddSubview(MenuView);
                MenuView.AnimationFade(AnimationType.In);
                _openMenu = true;
            }
        }
        //Menu
        [CrossView(nameof(ProjectNavigationBaseViewModel.RootViewSide))]
        UIView view1 => MenuView?.RootView;

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideContainer))]
        UIView view2 => MenuView?.Container;

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideImage))]
        UIImageView view3 => MenuView?.ImageMenu;


        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuListView))]
        UITableView view4 => MenuView?.TableView;


        //Header
        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderTextView))]
        UILabel textTitle => Header?.TextHeader;

        [CrossView(nameof(ProjectNavigationBaseViewModel.CounterTextView))]
        UILabel textTitle1 => Header?.TextHeaderCounter;

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderLeftTouchArea))]
        UIView viewLeft => Header?.ViewAreLeft;

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderRightTouchArea))]
        UIView viewRight => Header?.ViewAreRight;

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderLeftImageView))]
        UIImageView imageLeft => Header?.ImageLeft;

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderRightImageView))]
        UIImageView imageRight => Header?.ImageRight;

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderLine))]
        UIView viewLine => Header?.ViewLine;
    }
}
