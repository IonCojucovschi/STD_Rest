//
//  BeerListViewModel.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Core.Extensions;
using Core.Helpers;
using Core.Helpers.Manager;
using Core.Models.DAL;
using Core.Resources.Colors;
using Core.Resources.Page;
using Core.ViewModels.Base;
using Core.ViewModels.Beer.Order;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels.Beer
{
    public class BeerListViewModel : BaseOrderPaymentViewModel
    {
        protected override string HeaderText => RBeerList.BeerText;

        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.Shop;

        public new virtual ICrossCellViewHolder<List<IBeerContent>> CellModel { get; protected set; }

        [CrossView]
        public new IListView ListView { get; set; }

        private IList<List<IBeerContent>> Products { get; set; } = new List<List<IBeerContent>>();

        public override void OnConnectNetwork()
        {
            base.OnConnectNetwork();

            OnCreate();
        }

        public override void OnCreate()
        {
            base.OnCreate();

            Show();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                ProductManager.Instance.GetProduct(data =>
                {
                    Hide();

                    Products = data;

                    ListView?.UpdateDataSource(Products);
                    ListView?.RowCountLimit(3);
                    ListView?.UpdateDataSource(Products);

                }, err => ShowError(err));
            });
        }


        public override void UpdateData()
        {
            OrderManager.Instance.OrderType = OrderVisibility.Local;

            base.UpdateData();

            CellModel = new BeerListCell(this);

            OrderManager.Instance.ChangeOrder -= Instance_ChangeOrder;
            OrderManager.Instance.ChangeOrder += Instance_ChangeOrder;

            ListView?.RowCountLimit(3);
            ListView?.UpdateDataSource(Products);
        }

        private void Instance_ChangeOrder(string quantity)
        {
            base.UpdateData();

            if (quantity != "0") return;
            ListView?.RowCountLimit(3);
            ListView?.UpdateDataSource(Products);
        }

        #region CellBinding
        public class BeerListCell : ICrossCellViewHolder<List<IBeerContent>>
        {
            private readonly ProjectNavigationBaseViewModel _baseViewModel;

            public BeerListCell(ProjectNavigationBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            //Left
            [CrossView]
            public IView MainViewLeft { get; set; }

            [CrossView]
            public IView Beer1WrapperContent { get; set; }

            [CrossView]
            public IText Beer1Name { get; set; }

            [CrossView]
            public IText Beer1Volume { get; set; }

            [CrossView]
            public IText Beer1Price { get; set; }

            [CrossView]
            public IImage Beer1Image { get; set; }

            [CrossView]
            public IImage Beer1Image2 { get; set; }

            [CrossView]
            public IText Beer1Add { get; set; }


            //Item Add Product left
            [CrossView]
            public IText Beer1Plus { get; set; }

            [CrossView]
            public IText Beer1Counter { get; set; }

            [CrossView]
            public IText Beer1Minus { get; set; }

            [CrossView]
            public IView Beer1AddContent { get; set; }


            //Right
            [CrossView]
            public IView MainViewRight { get; set; }

            [CrossView]
            public IView Beer2WrapperContent { get; set; }

            [CrossView]
            public IText Beer2Name { get; set; }

            [CrossView]
            public IText Beer2Volume { get; set; }

            [CrossView]
            public IText Beer2Price { get; set; }

            [CrossView]
            public IImage Beer2Image2 { get; set; }

            [CrossView]
            public IImage Beer2Image { get; set; }

            [CrossView]
            public IText Beer2Add { get; set; }


            //Item Add Product Right
            [CrossView]
            public IText Beer2Plus { get; set; }

            [CrossView]
            public IText Beer2Counter { get; set; }

            [CrossView]
            public IText Beer2Minus { get; set; }

            [CrossView]
            public IView Beer2AddContent { get; set; }

            public void Bind(List<IBeerContent> model)
            {
                SetLeftCell(model.ElementAtOrDefault(0));
                SetRightCell(model.ElementAtOrDefault(1));
            }

            private void SetLeftCell(IBeerContent model)
            {
                if (model.IsNull())
                {
                    MainViewLeft.Visibility = ViewState.Invisible;
                    Beer1AddContent.Visibility = ViewState.Invisible;
                    Beer1Add.Visibility = ViewState.Visible;
                    return;
                }

                MainViewLeft.Visibility = ViewState.Visible;
                Beer1Image?.SetImageFromUrl(model.ImagePath);
                Beer1WrapperContent?.SetBackgroundColor(ColorConstants.BackroundCell, 5);

                UpdateView(model, Beer1AddContent, Beer1Add, Beer1Image, Beer1Image2);

                if (Beer1Name != null)
                {
                    Beer1Name.Text = model.NameBeer;
                    Beer1Name.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
                    Beer1Name.SetTextColor(ColorConstants.WhiteColor);
                }

                if (Beer1Volume != null)
                {
                    Beer1Volume.Text = model.Volume;
                    Beer1Volume.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size14);
                    Beer1Volume.SetTextColor(ColorConstants.BeerListCantity);
                }

                if (Beer1Price != null)
                {
                    Beer1Price.Text = model.Price + App.CurrencyEuro;
                    Beer1Price.SetFont(FontsConstant.OpenSansExtraBold);
                    Beer1Price.SetTextColor(ColorConstants.SelectorHome);
                }

                if (Beer1Add != null)
                {
                    Beer1Add.Text = "+";
                    Beer1Add.SetBackgroundColor(ColorConstants.BlackColor.SelectorTransparence(ColorConstants.Procent70), type: RadiusType.Aspect);
                    Beer1Add.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size36);

                    Beer1Add.SetTextColor(ColorConstants.WhiteColor);

                    Beer1Add.SetSelectedColor(ColorConstants.WhiteColor);
                    Beer1Add.SetSelectedTextColor(ColorConstants.BlackColor);

                    Beer1Add.Tag = new
                    {
                        Model = model,
                        View = Beer1AddContent,
                        Image1 = Beer1Image,
                        Image2 = Beer1Image2,
                        Counter = Beer1Counter
                    };

                    Beer1Add.Click -= BeerAdd_Click;
                    Beer1Add.Click += BeerAdd_Click;
                }

                //Left Add
                if (Beer1Counter != null)
                {
                    Beer1Counter.Text = OrderManager.Instance.GetQuantityProduct(model.Id).ToString();
                    Beer1Counter.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size20);
                    Beer1Counter.SetTextColor(ColorConstants.WhiteColor);
                }

                if (!Beer1Plus.IsNull())
                {
                    Beer1Plus.Text = "+";
                    Beer1Plus?.SetTextColor(ColorConstants.WhiteColor);
                    Beer1Plus?.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size20);
                    Beer1Plus?.SetBackgroundColor(ColorConstants.SelectorHome, type: RadiusType.Aspect);
                    Beer1Plus?.SetSelectedColor(ColorConstants.SelectorHome.SelectorTransparence(ColorConstants.Procent50));

                    Beer1Plus.Tag = new { Model = model, Counter = Beer1Counter };

                    Beer1Plus.Click -= PlusText_Click;
                    Beer1Plus.Click += PlusText_Click;
                }

                if (!Beer1Minus.IsNull())
                {
                    Beer1Minus.Text = "-";
                    Beer1Minus?.SetTextColor(ColorConstants.WhiteColor);
                    Beer1Minus?.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size20);
                    Beer1Minus?.SetBackgroundColor(ColorConstants.SelectorHome, type: RadiusType.Aspect);
                    Beer1Minus?.SetSelectedColor(ColorConstants.SelectorHome.SelectorTransparence(ColorConstants.Procent50));

                    Beer1Minus.Tag = new
                    {
                        Model = model,
                        View = Beer1Add,
                        Image1 = Beer1Image,
                        Image2 = Beer1Image2,
                        Counter = Beer1Counter
                    };

                    Beer1Minus.Click -= BeerMinus_Click;
                    Beer1Minus.Click += BeerMinus_Click;
                }
            }

            private void UpdateView(IBeerContent model, IView viewAddContent, IView addView, IView viewImage1, IImage image2)
            {
                if (!viewAddContent.IsNull() && OrderManager.Instance.GetQuantityProduct(model.Id) <= 0)
                {
                    viewAddContent.Visibility = ViewState.Invisible;
                    addView.Visibility = ViewState.Visible;

                    if (image2 != null)
                        image2.Visibility = ViewState.Invisible;

                    if (viewImage1 != null)
                        viewImage1.Visibility = ViewState.Visible;
                }
                else
                {
                    if (addView != null)
                    {
                        addView.Visibility = ViewState.Invisible;
                        viewAddContent.Visibility = ViewState.Visible;
                    }

                    if (viewImage1 != null)
                        viewImage1.Visibility = ViewState.Invisible;

                    if (image2 != null)
                    {
                        image2.Visibility = ViewState.Visible;
                        image2?.SetImageFromUrl(model.ImagePath);
                    }
                }
            }

            private void SetRightCell(IBeerContent model)
            {
                if (model.IsNull())
                {
                    MainViewRight.Visibility = ViewState.Invisible;
                    Beer2AddContent.Visibility = ViewState.Invisible;
                    Beer2Add.Visibility = ViewState.Visible;
                    return;
                }

                MainViewRight.Visibility = ViewState.Visible;
                Beer2Image?.SetImageFromUrl(model.ImagePath);
                Beer2WrapperContent?.SetBackgroundColor(ColorConstants.BackroundCell, 5);

                UpdateView(model, Beer2AddContent, Beer2Add, Beer2Image, Beer2Image2);

                if (Beer2Name != null)
                {
                    Beer2Name.Text = model.NameBeer;
                    Beer2Name.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
                    Beer2Name.SetTextColor(ColorConstants.WhiteColor);
                }

                if (Beer2Volume != null)
                {
                    Beer2Volume.Text = model.Volume;
                    Beer2Volume.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size14);
                    Beer2Volume.SetTextColor(ColorConstants.BeerListCantity);
                }

                if (Beer2Price != null)
                {
                    Beer2Price.Text = model.Price + App.CurrencyEuro;
                    Beer2Price.SetFont(FontsConstant.OpenSansExtraBold);
                    Beer2Price.SetTextColor(ColorConstants.SelectorHome);
                }

                if (Beer2Add != null)
                {
                    Beer2Add.Text = "+";
                    Beer2Add.SetBackgroundColor(ColorConstants.BlackColor.SelectorTransparence(ColorConstants.Procent70), type: RadiusType.Aspect);
                    Beer2Add.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size36);

                    Beer2Add.SetTextColor(ColorConstants.WhiteColor);

                    Beer2Add.SetSelectedColor(ColorConstants.WhiteColor);
                    Beer2Add.SetSelectedTextColor(ColorConstants.BlackColor);

                    Beer2Add.Tag = new
                    {
                        Model = model,
                        View = Beer2AddContent,
                        Image1 = Beer2Image,
                        Image2 = Beer2Image2,
                        Counter = Beer2Counter
                    };

                    Beer2Add.Click -= BeerAdd_Click;
                    Beer2Add.Click += BeerAdd_Click;
                }

                //Left Add
                if (Beer2Counter != null)
                {
                    Beer2Counter.Text = OrderManager.Instance.GetQuantityProduct(model.Id).ToString();
                    Beer2Counter.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size20);
                    Beer2Counter.SetTextColor(ColorConstants.WhiteColor);
                }

                if (!Beer2Plus.IsNull())
                {
                    Beer2Plus.Text = "+";
                    Beer2Plus?.SetTextColor(ColorConstants.WhiteColor);
                    Beer2Plus?.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size20);
                    Beer2Plus?.SetBackgroundColor(ColorConstants.SelectorHome, type: RadiusType.Aspect);
                    Beer2Plus?.SetSelectedColor(ColorConstants.SelectorHome.SelectorTransparence(ColorConstants.Procent50));

                    Beer2Plus.Tag = new { Model = model, Counter = Beer2Counter };

                    Beer2Plus.Click -= PlusText_Click;
                    Beer2Plus.Click += PlusText_Click;
                }

                if (!Beer2Minus.IsNull())
                {
                    Beer2Minus.Text = "-";
                    Beer2Minus?.SetTextColor(ColorConstants.WhiteColor);
                    Beer2Minus?.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size20);
                    Beer2Minus?.SetBackgroundColor(ColorConstants.SelectorHome, type: RadiusType.Aspect);
                    Beer2Minus?.SetSelectedColor(ColorConstants.SelectorHome.SelectorTransparence(ColorConstants.Procent50));

                    Beer2Minus.Tag = new
                    {
                        Model = model,
                        View = Beer2Add,
                        Image1 = Beer2Image,
                        Image2 = Beer2Image2,
                        Counter = Beer2Counter
                    };

                    Beer2Minus.Click -= BeerMinus_Click;
                    Beer2Minus.Click += BeerMinus_Click;
                }
            }

            private void BeerAdd_Click(object sender, EventArgs e)
            {
                var view = sender as IView;

                dynamic data = view?.Tag;

                if (Convert.ToInt32(data?.Model.Quantity) <= 0)
                {
                    _baseViewModel.ShowError("Quantity = 0");
                    return;
                }

                if (view != null) view.Visibility = ViewState.Invisible;
                if (data != null)
                {
                    var image1 = data.Image1 as IImage;

                    if (!image1.IsNull())
                        if (image1 != null)
                            image1.Visibility = ViewState.Invisible;
                }

                var image2 = data?.Image2 as IImage;

                if (!image2.IsNull())
                {
                    image2.SetImageFromUrl((data?.Model as IBeerContent)?.ImagePath);
                    image2.Visibility = ViewState.Visible;
                }

                AddOrder(data?.Model as IBeerContent, true);
                ((IView)data?.View).Visibility = ViewState.Visible;

                UpdateCounter(data.Counter as IText, data.Model.Id);
            }

            private void PlusText_Click(object sender, EventArgs e)
            {
                var view = sender as IView;

                dynamic data = view?.Tag;

                var model = data?.Model as IBeerContent;

                if (ProductManager.Instance.GetItem().FirstOrDefault(x => model != null && x.Id == model.Id)?
                        .Quantity <= Convert.ToInt32(OrderManager.Instance.GetItem()
                        .FirstOrDefault(x => model != null && x.IdProduct == model.Id)
                        ?.Quantity)) return;
                AddOrder(model, true);
                if (model != null) UpdateCounter(data?.Counter as IText, model.Id);
            }

            private void BeerMinus_Click(object sender, EventArgs e)
            {
                var view = sender as IView;

                dynamic data = view?.Tag;

                if (data == null) return;
                var model = data.Model;
                var views = data.View;

                var counter = data.Counter as IText;

                var image1 = data.Image1 as IImage;
                var image2 = data.Image2 as IImage;

                AddOrder(model, false);

                UpdateCounter(counter, model.Id);

                if (OrderManager.Instance.GetQuantityProduct(model.Id) > 0) return;

                if (!image1.IsNull())
                    image1.Visibility = ViewState.Visible;
                if (!image2.IsNull())
                    image2.Visibility = ViewState.Invisible;

                (views as IView).Visibility = ViewState.Visible;

                OrderManager.Instance.RemoveOrder(model.Id);
            }

            private static void UpdateCounter(IText text, int productId)
            {
                text.Text = OrderManager.Instance.GetItem()?.FirstOrDefault(x => x.IdProduct == productId)?.Quantity == "0" ?
                        "1" :
                        OrderManager.Instance.GetItem()?.FirstOrDefault(x => x.IdProduct == productId)?.Quantity;
            }

            private static void AddOrder(IBeerContent model, bool isIncriment)
            {
                OrderManager.Instance.AddOrder(new OrderContent
                {
                    IdProduct = model.Id,
                    OrderName = model.NameBeer,
                    Quantity = "1",
                    ImagePath = model.ImagePath,
                    Price = model.Price,
                    PriceBar = model.PriceBar
                }, isIncriment);
            }

            public void OnCreate() { }
        }

        #endregion
    }
}
