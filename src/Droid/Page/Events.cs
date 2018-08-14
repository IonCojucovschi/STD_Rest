//
// Splash.cs
//
// Author:
//       Songurov Fiodor <songurov@gmail.com>
//
// Copyright (c) 2017 Songurov Fiodor
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


using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Core.Models.Contract;
using Core.ViewModels;
using Droid.Page.Base;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    [Activity(Label = "Events", Theme = "@style/AppTheme",
              LaunchMode = LaunchMode.SingleTop,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class Events : NavigationBasePage<EventsViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.events;


        protected override void InitViews()
        {
            base.InitViews();

            ListView?.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                          new EventsListTagCellViewHolder(inflater,
                                              parent,
                                              ModelView.CellModel1)));
            ListSubTagView?.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                                    new EventsListSubTagCellViewHolder(inflater,
                                              parent,
                                              ModelView.CellModel2)));
            ListEventNameView?.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                                       new EventNameCellViewHolder(inflater,
                                              parent,
                                              ModelView.CellModel3)));

        }
    }


    public class EventsListTagCellViewHolder : ComponentViewHolder<IEvent>
    {
        public EventsListTagCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                           ICrossCellViewHolder<IEvent> cellModel)
            : base(inflator.Inflate(Resource.Layout.item_list_tags1, parent, false), cellModel) { }

        [CrossView(nameof(EventsViewModel.EventsListTagCell.NameText))]
        [InjectView(Resource.Id.tag1_text_value)]
        public TextView TagText { get; set; }

        [CrossView(nameof(EventsViewModel.EventsListTagCell.CellContentRootView))]
        [InjectView(Resource.Id.wrapp_item_content)]
        public LinearLayout CellContentRootView { get; set; }

    }

    public class EventsListSubTagCellViewHolder : ComponentViewHolder<IEvent>
    {
        public EventsListSubTagCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                              ICrossCellViewHolder<IEvent> cellModel)
            : base(inflator.Inflate(Resource.Layout.item_list_tag2, parent, false), cellModel) { }

        [CrossView(nameof(EventsViewModel.EventsListSubTagCell.EventImage))]
        [InjectView(Resource.Id.tag2_event_image)]
        public ImageView EventImage { get; set; }

        [CrossView(nameof(EventsViewModel.EventsListSubTagCell.ImageDateTimeBackground))]
        [InjectView(Resource.Id.date_image_background)]
        public ImageView ImageDateTimeBackground { get; set; }

        [CrossView(nameof(EventsViewModel.EventsListSubTagCell.NameText))]
        [InjectView(Resource.Id.tag2_name_value)]
        public TextView NameText { get; set; }

        [CrossView(nameof(EventsViewModel.EventsListSubTagCell.SeparatorDateTime))]
        [InjectView(Resource.Id.image_date_separator)]
        public ImageView SeparatorDateTime { get; set; }

        [CrossView(nameof(EventsViewModel.EventsListSubTagCell.ContainerDateDetails))]
        [InjectView(Resource.Id.full_data_detail_container)]
        public LinearLayout ContainerDateDetails { get; set; }

        [CrossView(nameof(EventsViewModel.EventsListSubTagCell.ContainerDateText))]
        [InjectView(Resource.Id.container_date_text)]
        public TextView ContainerDateText { get; set; }

        [CrossView(nameof(EventsViewModel.EventsListSubTagCell.EventHourTime))]
        [InjectView(Resource.Id.hour_time_event)]
        public TextView EventHourTime { get; set; }

        [CrossView(nameof(EventsViewModel.EventsListSubTagCell.ContainerTimeText))]
        [InjectView(Resource.Id.container_time_text)]
        public TextView ContainerTimeText { get; set; }

        [CrossView(nameof(EventsViewModel.EventsListSubTagCell.CellContentRootView))]
        [InjectView(Resource.Id.wrapper_tag2_content)]
        public RelativeLayout CellContentRootView { get; set; }

    }

    public class EventNameCellViewHolder : ComponentViewHolder<IEvent>
    {
        public EventNameCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                       ICrossCellViewHolder<IEvent> cellModel)
            : base(inflator.Inflate(Resource.Layout.item_name_event_list, parent, false), cellModel) { }

        [CrossView(nameof(EventsViewModel.EventNameListCell.NameText))]
        [InjectView(Resource.Id.event_name_text)]
        public TextView NameText { get; set; }

        [CrossView(nameof(EventsViewModel.EventNameListCell.ContainerDateDetails))]
        [InjectView(Resource.Id.full_data_detail_container)]
        public LinearLayout ContainerDateDetails { get; set; }

        [CrossView(nameof(EventsViewModel.EventNameListCell.ContainerDateText))]
        [InjectView(Resource.Id.container_date_text)]
        public TextView ContainerDateText { get; set; }

        [CrossView(nameof(EventsViewModel.EventNameListCell.EventTime))]
        [InjectView(Resource.Id.hour_time_item_event)]
        public TextView EventTime { get; set; }


        [CrossView(nameof(EventsViewModel.EventNameListCell.ContainerTimeText))]
        [InjectView(Resource.Id.container_time_text)]
        public TextView ContainerTimeText { get; set; }

        [CrossView(nameof(EventsViewModel.EventNameListCell.EventImage))]
        [InjectView(Resource.Id.event_image)]
        public ImageView NameImage { get; set; }

        [CrossView(nameof(EventsViewModel.EventNameListCell.CellContentRootView))]
        [InjectView(Resource.Id.event_cell_root_view)]
        public LinearLayout CellContentRootView { get; set; }

    }

}
