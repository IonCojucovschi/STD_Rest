//
//  EventsViewModel.cs
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
using Core.Extensions;
using Core.Helpers;
using Core.Helpers.Manager.Event;
using Core.Models.Contract;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels
{
    public class EventsViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => REvents.Events;

        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.Menu;

        [CrossView]
        public IListView ListView { get; set; }

        [CrossView]
        public IListView ListSubTagView { get; set; }

        [CrossView]
        public IListView ListEventNameView { get; set; }

        [CrossView]
        public IView BackroundContent { get; set; }

        [CrossView]
        public IText MonthText { get; set; }

        [CrossView]
        public IImage LeftArrow { get; set; }

        [CrossView]
        public IImage RightArrow { get; set; }

        [CrossView]
        public IText IntervalEventsDate { get; set; }

        public virtual ICrossCellViewHolder<IEvent> CellModel1 { get; protected set; }

        public virtual ICrossCellViewHolder<IEvent> CellModel2 { get; protected set; }

        public virtual ICrossCellViewHolder<IEvent> CellModel3 { get; protected set; }


        public override void OnCreate()
        {
            base.OnCreate();

            EventManager.Instance.GetEvent();
        }
        public override void UpdateData()
        {
            base.UpdateData();

            CellModel1 = new EventsListTagCell(this);
            CellModel2 = new EventsListSubTagCell(this);
            CellModel3 = new EventNameListCell(this);

            BackroundContent?.SetBackgroundColor(ColorConstants.BackroundContent);

            ListView?.UpdateDataSource(EventManager.Instance.GetTagItem());
            ListView?.Orientation(OrientationListView.Horizontal);

            ListSubTagView?.UpdateDataSource(EventManager.Instance.GetMainItemPerDateTime);
            ListSubTagView?.Orientation(OrientationListView.Horizontal);

            ListEventNameView?.UpdateDataSource(EventManager.Instance.GetItemPerDateTime);
            ListEventNameView?.RowCountLimit(3);

            InitViews();
        }

        private void InitViews()
        {
            if (LeftArrow != null)
            {
                LeftArrow.Click -= LeftArrow_Click;
                LeftArrow.Click += LeftArrow_Click;
                LeftArrow?.SetImageFromResource(DrawableConstants.LeftEventArrow);
            }

            if (RightArrow != null)
            {
                RightArrow.Click -= RightArrow_Click;
                RightArrow.Click += RightArrow_Click;
                RightArrow?.SetImageFromResource(DrawableConstants.RightEventArrow);
            }

            if (MonthText != null)
            {
                MonthText.Text = EventManager.Instance.IsDay == EventType.Day ? EventManager.Instance.CurrentDateTime.ToString("MMMM") : FormatDateTime(EventManager.Instance.CurrentDateTime);

                MonthText.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size28);
                MonthText.SetTextColor(ColorConstants.WhiteColor);
            }

            if (IntervalEventsDate == null) return;
#if __ANDROID__
            IntervalEventsDate.Text = EventManager.Instance.IsDay == EventType.Day ? "today events".ToUpperInvariant() : "month events".ToUpperInvariant();
#else
            if (EventManager.Instance.IsDay == EventType.Day)
                IntervalEventsDate.Text = "   today events   ".ToUpperInvariant();
            else
                IntervalEventsDate.Text = "   month events   ".ToUpperInvariant();
#endif

            IntervalEventsDate?.SetBackgroundColor(ColorConstants.TransparentColor, 4, ColorConstants.WhiteColor.SelectorTransparence(ColorConstants.Procent70), 1);
            IntervalEventsDate.SetTextColor(ColorConstants.WhiteColor.SelectorTransparence(ColorConstants.Procent70));
            IntervalEventsDate.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size12);
            IntervalEventsDate.SetSelectedColor(ColorConstants.WhiteColor);

            IntervalEventsDate.Click -= IntervalMonth_Click;
            IntervalEventsDate.Click += IntervalMonth_Click;
        }

        private static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.Day + " " + dateTime.ToString("MMM");
        }

        private void LeftArrow_Click(object s, EventArgs e)
        {
            AddOrRemoveDayOrMonth();
        }

        private void RightArrow_Click(object s, EventArgs e)
        {
            AddOrRemoveDayOrMonth(true);
        }

        private void AddOrRemoveDayOrMonth(bool minusOrPlus = false)
        {
            EventManager.Instance.CurrentDateTime = EventManager.Instance.IsDay != EventType.Day ? EventManager.Instance.CurrentDateTime.AddDays(minusOrPlus ? 1 : -1) : EventManager.Instance.CurrentDateTime.AddMonths(minusOrPlus ? 1 : -1);

            if (EventManager.Instance.IsDay != EventType.Month)
                EventManager.Instance.GetEvent();

            UpdateData();
        }

        private void IntervalMonth_Click(object s, EventArgs e)
        {
            IsDay();
        }

        private void IsDay()
        {
            EventManager.Instance.IsDay = EventManager.Instance.IsDay == EventType.Day ? EventType.Month : EventType.Day;

            if (EventManager.Instance.IsDay != EventType.Month)
                EventManager.Instance.GetEvent();

            UpdateView();
        }

        private void UpdateView()
        {
            UpdateData();
        }

        public class EventsListTagCell : ICrossCellViewHolder<IEvent>
        {
            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IText NameText { get; set; }

            private readonly ProjectBaseViewModel _baseViewModel;

            public EventsListTagCell(ProjectBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            public void Bind(IEvent model)
            {
                if (NameText == null) return;
                var color = model?.ColorTag;

#if __ANDROID__
                NameText.Text = "#" + model?.Tag;
#else
                NameText.Text = "#" + model?.Tag + "     ";
#endif

                NameText.SetFont(FontsConstant.OpenSansRegular);
                NameText.SetTextColor(ColorConstants.WhiteColor);

                if (model != null)
                    NameText.SetBackgroundColor(!model.SelectedTag ? ColorConstants.TransparentColor : color, 4, color, 1);


                NameText.Tag = new { View = NameText, Model = model };

                NameText.Click -= Name_Click;
                NameText.Click += Name_Click;
            }

            private void Name_Click(object s, EventArgs e)
            {
                dynamic @object = (s as IView)?.Tag;

                var model = @object?.Model as IEvent;
                var view = @object?.View;

                if (model != null && model.SelectedTag)
                    view.SetBackgroundColor(model.ColorTag, 4, model.ColorTag, 1);
                else
                    view?.SetBackgroundColor(ColorConstants.TransparentColor, 4, model.ColorTag, 1);

                if (model != null) EventManager.Instance.UpdateTagSelected(model.Id);

                _baseViewModel.UpdateData();
            }

            public void OnCreate() { }
        }

        public class EventsListSubTagCell : ICrossCellViewHolder<IEvent>
        {
            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IImage EventImage { get; set; }

            [CrossView]
            public IImage ImageDateTimeBackground { get; set; }

            [CrossView]
            public IText NameText { get; set; }

            [CrossView]
            public IImage SeparatorDateTime { get; set; }


            [CrossView]
            public IView ContainerDateDetails { get; set; }

            [CrossView]
            public IText ContainerDateText { get; set; }

            [CrossView]
            public IText ContainerTimeText { get; set; }

            [CrossView]  ///must delete this property
            public IText EventHourTime { get; set; }


            private readonly ProjectBaseViewModel _baseViewModel;

            public EventsListSubTagCell(ProjectBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            public void Bind(IEvent model)
            {
                EventImage?.SetImageFromUrl(model.ImagePathView);
                EventImage?.SetBackgroundColor(ColorConstants.TransparentColor, 5);

                ImageDateTimeBackground?.SetImageFromResource(DrawableConstants.EventDateBackgroundImage);

                if (model.IsDay != EventType.Day)
                {
                    if (EventHourTime != null)
                        EventHourTime.Visibility = ViewState.Visible;
                    ContainerDateText.Visibility = ViewState.Invisible;
                    ContainerTimeText.Visibility = ViewState.Invisible;
                }
                else
                {
                    if (EventHourTime != null)
                        EventHourTime.Visibility = ViewState.Invisible;
                    ContainerDateText.Visibility = ViewState.Visible;
                    ContainerTimeText.Visibility = ViewState.Visible;
                }

                if (NameText != null)
                {
                    NameText.Text = model.Name;
                    NameText.SetFont(FontsConstant.RobotoBold, FontsConstant.Size12);
                    NameText.SetTextColor(ColorConstants.WhiteColor);
                }

                if (EventHourTime != null)
                {
                    EventHourTime.Text = model.EventDateTime.ToString("hh:mm");
                    EventHourTime.SetTextColor(ColorConstants.SelectorHome);
                    EventHourTime.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
                    MainTime();
                }

                if (ContainerDateText != null)
                {
                    ContainerDateText.Text = EventManager.Instance.IsDay == EventType.Day ? FormatDateTime(model.EventDateTime) : "";
                    ContainerDateText.SetTextColor(ColorConstants.WhiteColor);
                    ContainerDateText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size12);
                }

                if (ContainerTimeText != null)
                {
                    ContainerTimeText.Text = model.EventDateTime.ToString("hh:mm");
                    ContainerTimeText.SetTextColor(ColorConstants.SelectorHome);
                    ContainerTimeText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size12);
                    SecondTime();
                }

                SeparatorDateTime?.SetImageFromResource(DrawableConstants.SeparatorLineEvent);

                CellContentRootView.Tag = model;
                CellContentRootView.Click -= Cell_Click;
                CellContentRootView.Click += Cell_Click;
            }

            private void SecondTime()
            {
                if (EventManager.Instance.IsDay != EventType.Day)
                    ContainerTimeText.Visibility = ViewState.Invisible;
                else
                    ContainerTimeText.Visibility = ViewState.Visible;
            }

            private void MainTime()
            {
                if (EventManager.Instance.IsDay == EventType.Day)
                    EventHourTime.Visibility = ViewState.Invisible;
                else
                    EventHourTime.Visibility = ViewState.Visible;
            }

            private void Cell_Click(object send, EventArgs eventArgs)
            {
                if ((send as IView)?.Tag is IEvent model) EventManager.Instance.GetDetailsMain(model.Id);

                _baseViewModel.GoPage(PageConstants.PageNameEventDetails);
            }


            public void OnCreate() { }
        }

        public class EventNameListCell : ICrossCellViewHolder<IEvent>
        {
            [CrossView]
            public IImage EventImage { get; set; }

            [CrossView]
            public IText NameText { get; set; }

            [CrossView] ///must dellete this property
            public IText EventTime { get; set; }

            [CrossView]
            public IView ContainerDateDetails { get; set; }

            [CrossView]
            public IText ContainerDateText { get; set; }

            [CrossView]
            public IText ContainerTimeText { get; set; }

            [CrossView]
            public IView CellContentRootView { get; set; }

            private readonly ProjectBaseViewModel _baseViewModel;

            public EventNameListCell(ProjectBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            public void Bind(IEvent model)
            {
                EventImage?.SetImageFromUrl(model.ImagePathView);
                EventImage?.SetBackgroundColor(ColorConstants.TransparentColor, 5);

                if (model.IsDay != EventType.Day)
                {
                    if (EventTime != null)
                        EventTime.Visibility = ViewState.Visible;

                    ContainerDateText.Visibility = ViewState.Invisible;
                    ContainerTimeText.Visibility = ViewState.Invisible;
                }
                else
                {
                    if (EventTime != null)
                        EventTime.Visibility = ViewState.Invisible;

                    ContainerDateText.Visibility = ViewState.Visible;
                    ContainerTimeText.Visibility = ViewState.Visible;
                }

                if (NameText != null)
                {
                    NameText.Text = model.Name;
                    NameText.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size18);
                    NameText.SetTextColor(ColorConstants.WhiteColor);
                }

                if (EventTime != null)
                {
                    EventTime.Text = model.EventDateTime.ToString("hh:mm");
                    EventTime.SetFont(FontsConstant.OpenSansBold);
                    EventTime.SetTextColor(ColorConstants.SelectorHome);

                    if (EventManager.Instance.IsDay == EventType.Day)
                        EventTime.Visibility = ViewState.Invisible;
                    else
                        EventTime.Visibility = ViewState.Visible;
                }


                if (ContainerDateText != null)
                {
                    ContainerDateText.Text = EventManager.Instance.IsDay == EventType.Day ? FormatDateTime(model.EventDateTime) : "";
                    ContainerDateText.SetFont(FontsConstant.OpenSansBold);
                    ContainerDateText.SetTextColor(ColorConstants.WhiteColor);
                }

                if (ContainerTimeText != null)
                {
                    ContainerTimeText.Text = model.EventDateTime.ToString("hh:mm");
                    ContainerTimeText.SetFont(FontsConstant.OpenSansBold);
                    ContainerTimeText.SetTextColor(ColorConstants.SelectorHome);

                    if (EventManager.Instance.IsDay != EventType.Day)
                        ContainerTimeText.Visibility = ViewState.Invisible;
                    else
                        ContainerTimeText.Visibility = ViewState.Visible;
                }

                CellContentRootView.Tag = model;
                CellContentRootView.Click -= Cell_Click;
                CellContentRootView.Click += Cell_Click;
            }

            private void Cell_Click(object send, EventArgs eventArgs)
            {
                if ((send as IView)?.Tag is IEvent model) EventManager.Instance.GetDetailsSecond(model.Id);

                _baseViewModel.GoPage(PageConstants.PageNameEventDetails);
            }

            public void OnCreate()
            {
            }
        }
    }
}
