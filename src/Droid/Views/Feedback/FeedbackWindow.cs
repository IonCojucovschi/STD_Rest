//
//  FeedbackWindow.cs
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
using Droid.Views.Base;
using Core.ViewModels.Views;
using Int.Droid.Factories.Adapter.RecyclerView;
using Android.Views;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;
using Android.Widget;
using Core.Services.MockServices.RealServices;
using Core.Models.Contract;

namespace Droid.Views.Feedback
{
    public partial class FeedbackWindow : ProjectBaseWindow<FeedbackWindowViewModel>
    {
        protected override int LayoutId => Resource.Layout.give_feedback_window;


        public override void Show()
        {

            ListViewCategory.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                            new ServicesFeedbackListCellViewHolder(inflater,
                                              parent,
                                              (ModelView as FeedbackWindowViewModel).CellModel2)));

            ListViewEmoji.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                                   new EmojiFeedbackListCellViewHolder(inflater,
                                              parent, (ModelView as FeedbackWindowViewModel).CellModel1)));
            base.Show();

        }
    }

    public class ServicesFeedbackListCellViewHolder : ComponentViewHolder<Core.Models.Contract.ICategory>
    {
        public ServicesFeedbackListCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                                  ICrossCellViewHolder<Core.Models.Contract.ICategory> cellModel)
            : base(inflator.Inflate(Resource.Layout.service_item_feedback, parent, false), cellModel) { }

        [CrossView(nameof(FeedbackWindowViewModel.FeedbackListCategoryCell.CellContentRootView))]
        [InjectView(Resource.Id.wrapp_cell_content)]
        public RelativeLayout CellContentRootView { get; set; }

        [CrossView(nameof(FeedbackWindowViewModel.FeedbackListCategoryCell.CategoryImage))]
        [InjectView(Resource.Id.image_service_feedback)]
        public ImageView ServiceImage { get; set; }

        [CrossView(nameof(FeedbackWindowViewModel.FeedbackListCategoryCell.CategoryText))]
        [InjectView(Resource.Id.service_name_text)]
        public TextView ServiceText { get; set; }
    }

    public class EmojiFeedbackListCellViewHolder : ComponentViewHolder<Core.Models.Contract.IFeedback>
    {
        public EmojiFeedbackListCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                               ICrossCellViewHolder<Core.Models.Contract.IFeedback> cellModel)
            : base(inflator.Inflate(Resource.Layout.emoji_item_feedback, parent, false), cellModel) { }

        //[CrossView(nameof(FeedbackWindowViewModel.StatusFeedbackListCell.CellContentRootView))]
        //[InjectView(Resource.Id.cell_emoji_content_wrapper)]
        //public LinearLayout CellContentRootView { get; set; }

        //[CrossView(nameof(FeedbackWindowViewModel.StatusFeedbackListCell.ServiceImage))]
        //[InjectView(Resource.Id.image_status_feedback)]
        //public ImageView ServiceImage { get; set; }

        //[CrossView(nameof(FeedbackWindowViewModel.StatusFeedbackListCell.ServiceText))]
        //[InjectView(Resource.Id.status_text)]
        //public TextView ServiceText { get; set; }

    }
}
