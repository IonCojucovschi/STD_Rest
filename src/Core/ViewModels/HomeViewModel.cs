//
//  HomeViewModel.cs
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
using Core.Helpers.Manager;
using Core.Helpers.Manager.Home;
using Core.Models.DAL.Home;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.ViewModels.Base;
using Int.Core.Application.Menu.Contract;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels
{
    public class HomeViewModel : ProjectBaseViewModel
    {
        [CrossView]
        public IListView ListView { get; set; }

        public virtual ICrossCellViewHolder<IItemMenu> CellModel { get; protected set; }

        [CrossView]
        public IImage LogoImage { get; private set; }

        public override void UpdateData()
        {
            base.UpdateData();

            CellModel = new HomeListCell(this);
            LogoImage?.SetImageFromResource(DrawableConstants.LogoIcon);

            ListView?.UpdateDataSource(MenuManager.Instance.GetItem());
            ListView?.RowCountLimit(3);
        }

        public override void OnCreate()
        {
            base.OnCreate();

            Show();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                OrderManager.Instance.GetOrder((obj) =>
                {
                    Hide();
                }, err => ShowError(err));
            });
        }

        public class HomeListCell : ICrossCellViewHolder<IItemMenu>
        {
            [CrossView]
            public IImage NameImage { get; set; }

            [CrossView]
            public IText NameText { get; set; }

            [CrossView]
            public IView CellContentRootView { get; set; }

            private readonly ProjectBaseViewModel _baseViewModel;

            public HomeListCell(ProjectBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            public void Bind(IItemMenu model)
            {
                NameImage?.SetImageFromResource((model as IHome)?.ImageHome);

                if (!NameText.IsNull())
                {
                    NameText.Text = model.Name;

                    NameText?.SetTextColor(ColorConstants.WhiteColor);
                    NameText?.SetFont(FontsConstant.RobotoBold, FontsConstant.Size36);
                }

                if (CellContentRootView.IsNull()) return;
                CellContentRootView.Tag = model;
                CellContentRootView.Click -= CellContentRootView_Click;
                CellContentRootView.Click += CellContentRootView_Click;
            }

            public void OnCreate()
            {
            }

            private void CellContentRootView_Click(object sender, EventArgs e)
            {
                if (!((sender as IView)?.Tag is IHome data)) return;
                switch (data.Page)
                {
                    case Models.DAL.Home.TypePage.Beer:
                    case Models.DAL.Home.TypePage.Food:
                    case Models.DAL.Home.TypePage.Call:
                    case Models.DAL.Home.TypePage.Events:
                    case Models.DAL.Home.TypePage.Feedback:
                        GetPage(data);
                        break;
                    case Models.DAL.Home.TypePage.Orders:
                        if (OrderManager.Instance.OrderMenu)
                            GetPage(data);
                        break;
                }
            }

            private void GetPage(IHome data)
            {
                var page = MenuManager.Instance.GetItem()
                                      .OfType<IHome>()
                                      .FirstOrDefault(x => x.Page == data.Page && x.PageActive)
                                      ?.ClickArgument;

                _baseViewModel.GoPage(page);
            }
        }
    }
}
