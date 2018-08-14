//
//  EventDetailsViewModel.cs
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

using Core.Helpers;
using Core.Helpers.Manager.Event;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using System.Linq;
using System.Threading;

namespace Core.ViewModels
{
    public class EventDetailsViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => REvents.Events;
        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.Back;

        private int _incrimentPath;

        [CrossView]
        public IView BackgroundContent { get; set; }

        [CrossView]
        public IView EventImageShadow { get; set; }

        [CrossView]
        public IImage EventImage { get; set; }

        [CrossView]
        public IText TimeEvent { get; set; }

        [CrossView]
        public IImage SeparatorImage { get; set; }

        [CrossView]
        public IText HourEvent { get; set; }

        [CrossView]
        public IImage TimeEventBackground { get; set; }

        [CrossView]
        public IText EventName { get; set; }

        [CrossView]
        public IText EventDescription { get; set; }

        public override void UpdateData()
        {
            base.UpdateData();
            InitViews();
        }

        private void InitViews()
        {
            BackgroundContent?.SetBackgroundColor(ColorConstants.BackroundContent);

            EventImage?.SetImageFromUrl(EventManager.Instance.GetDetails().ImagePathView);
            EventImage?.SetBackgroundColor(ColorConstants.TransparentColor, 5);

            EventImage.Swipe -= Image_Swipe;
            EventImage.Swipe += Image_Swipe;

            if (EventName != null)
            {
                EventName.Text = EventManager.Instance.GetDetails().Name;
                EventName.SetFont(FontsConstant.OpenSansRegular, FontsConstant.Size28);
                EventName.SetTextColor(ColorConstants.WhiteColor);
            }

            if (EventDescription != null)
            {
                EventDescription.Text = EventManager.Instance.GetDetails().Description;

                EventDescription.SetTextColor(ColorConstants.WhiteColor);
                EventDescription.SetFont(FontsConstant.OpenSansRegular);
            }

            if (TimeEvent != null)
            {
                TimeEvent.Text = EventManager.Instance.GetDetails().EventDateTime.ToString("dd") + " " + EventManager.Instance.GetDetails().EventDateTime.ToString("MMMM");
                HourEvent.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size14);
                TimeEvent.SetTextColor(ColorConstants.WhiteColor);
            }

            SeparatorImage?.SetImageFromResource(DrawableConstants.SeparatorLineEvent);

            if (HourEvent != null)
            {
                HourEvent.Text = EventManager.Instance.GetDetails().EventDateTime.ToString("H:mm");
                HourEvent.SetFont(FontsConstant.OpenSansBold, FontsConstant.Size15);
                HourEvent.SetTextColor(ColorConstants.SelectorHome);
            }

            TimeEventBackground?.SetImageFromResource(DrawableConstants.EventDateBackgroundImage);
        }

        private void Image_Swipe(IView sender, SwipeEventArgs eventArgs)
        {
            var a = EventManager.Instance.GetDetails();

            if (a?.Images != null)
            {
                switch (eventArgs.Direction)
                {
                    case GestureDirection.ToLeft:
                        if (_incrimentPath < a.Images.Count())
                            _incrimentPath++;
                        break;
                    case GestureDirection.ToRight when _incrimentPath > 0:
                        _incrimentPath--;
                        break;
                    case GestureDirection.ToRight:
                        _incrimentPath = a.Images.Count() - 1;
                        break;
                }

                if (a.Images?.ElementAtOrDefault(_incrimentPath)?.Path != null)
                {
                    a.ImagePathView = a.Images.ElementAtOrDefault(_incrimentPath)?.Path;
                }
                else
                {
                    _incrimentPath = 0;
                }

                a.ImagePathView = a.Images.ElementAtOrDefault(_incrimentPath)?.Path;
            }

            ThreadPool.QueueUserWorkItem(_ =>
            {
                (sender as IImage)?.SetImageFromUrl(a.ImagePathView);
            });
        }

        public override void GoBack()
        {
            base.GoBack();

            EventManager.Instance.GetDetails().ImagePathView = EventManager.Instance.GetDetails().ImageOriginal;
        }
    }
}
