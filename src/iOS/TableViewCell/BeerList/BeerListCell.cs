// This file has been autogenerated from a class added in the UI designer.

using System;
using Core.Models.DAL;
using Int.iOS.Factories.Adapter.CellView;
using UIKit;
using Core.ViewModels.Beer;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using System.Collections.Generic;

namespace iOS.Storyboard
{
    public partial class BeerListCell : ComponentTableViewCell<List<IBeerContent>>
    {
        public BeerListCell(IntPtr handle) : base(handle) { }

        protected override UIColor ColorSelector { get => UIColor.Clear; set => base.ColorSelector = value; }
        //Left
        [CrossView(nameof(BeerListViewModel.BeerListCell.MainViewLeft))]
        public UIView view1712 => viewCellLeft;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1WrapperContent))]
        public UIView view11 => viewContentLeft;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Name))]
        public UILabel view12 => lblNameLeft;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Volume))]
        public UILabel view13 => lblAmountLeft;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Price))]
        public UILabel view14 => lblPriceLeft;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Add))]
        public UILabel view16 => lblAddLeft;



        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Image))]
        public UIImageView view15 => imgProductLeft;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Image2))]
        public UIImageView view2812 => imgProductLeft1;


        //Item Add 
        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1AddContent))]
        public UIView view17 => viewAddFuncLeft;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Plus))]
        public UILabel view18 => lblPlusLeft;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Counter))]
        public UILabel view19 => lblCounterLeft;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer1Minus))]
        public UILabel view111 => lblMinusLeft;


        //Right

        [CrossView(nameof(BeerListViewModel.BeerListCell.MainViewRight))]
        public UIView view171 => viewCellRight;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2WrapperContent))]
        public UIView view21 => viewContentRight;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Name))]
        public UILabel view22 => lblNameRight;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Volume))]
        public UILabel view23 => lblAmountRight;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Price))]
        public UILabel view24 => lblPriceRight;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Add))]
        public UILabel view26 => lblAddRight;


        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Image))]
        public UIImageView view25 => imgProductRight;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Image2))]
        public UIImageView view281 => imgProductRight1;

        //Item Add 

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2AddContent))]
        public UIView view27 => viewAddFuncRight;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Plus))]
        public UILabel view28 => lblPlusRight;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Counter))]
        public UILabel view29 => lblCounterRight;

        [CrossView(nameof(BeerListViewModel.BeerListCell.Beer2Minus))]
        public UILabel view222 => lblMinusRight;
    }
}