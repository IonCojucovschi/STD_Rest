//
//  FeedbackManager.cs
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
using Core.Models.Contract;
using Core.Models.DAL.Feedback;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Page;
using Int.Core.Network.Singleton;
using Splat;

namespace Core.Helpers.Manager.Feedback
{
    public class FeedbackManager : Singleton<FeedbackManager>
    {

        private static Core.Services.MockServices.RealServices.IFeedback GetService =>
                           Locator.Current.GetService<Core.Services.MockServices.RealServices.IFeedback>(App.Instance.IsMock ? App.ServiceContractMock : App.ServiceContract);


        private readonly IList<IFeedback> _feedbacks = new List<IFeedback>
        {
            new FeedbackModel { Id = 1, Name = RFeedback.GoodText, FeedbackType = FeedbackType.Good
                     , Color = ColorConstants.FeedbackGood, NameCategory = RFeedback.ServiceTextFeedback,
                    ImagePath = DrawableConstants.GoodFeedbackIcon, ImagePathCategory = DrawableConstants.ServicesFeedbackIcon },

                new FeedbackModel { Id = 2, Name = RFeedback.BadText, FeedbackType = FeedbackType.Bad
                    , Color = ColorConstants.FeedbackBad, NameCategory = RFeedback.EventsTextFeedback,
                    ImagePath = DrawableConstants.BadFeedbackIcon, ImagePathCategory = DrawableConstants.EventsFeedbackIcon },

                new FeedbackModel { Id = 3, Name = RFeedback.GreatText, FeedbackType = FeedbackType.Great,
                    Color = ColorConstants.FeedbackGreat, NameCategory = RFeedback.BeerTextFeedback,
                    ImagePath = DrawableConstants.GreatFeedbackIcon, ImagePathCategory = DrawableConstants.BeerFeedbackIcon },
        };

        private readonly IList<IFeedback> _feedbacksStatus = new List<IFeedback>
        {
            new FeedbackModel { Id = 1, Name = RFeedback.TerribleText, FeedbackType = FeedbackType.Terrible,
                    ImagePath = DrawableConstants.TerribleFeedbackIcon, ImagePathCategory = DrawableConstants.TerribleFeedbackIcon },
                new FeedbackModel { Id = 2, Name = RFeedback.BadText, FeedbackType = FeedbackType.Bad,
                    ImagePath = DrawableConstants.BadFeedbackIcon, ImagePathCategory = DrawableConstants.EventsFeedbackIcon },
            new FeedbackModel { Id = 3, Name = RFeedback.OkayText, FeedbackType = FeedbackType.Ok,
                    ImagePath = DrawableConstants.OkFeedbackIcon, ImagePathCategory = DrawableConstants.OkFeedbackIcon },
                new FeedbackModel { Id = 4, Name = RFeedback.GoodText, FeedbackType = FeedbackType.Good,
                    ImagePath = DrawableConstants.GoodFeedbackIcon, ImagePathCategory = DrawableConstants.ServicesFeedbackIcon },
                new FeedbackModel { Id = 5, Name = RFeedback.GreatText, FeedbackType = FeedbackType.Great,
                    ImagePath = DrawableConstants.GreatFeedbackIcon, ImagePathCategory = DrawableConstants.BeerFeedbackIcon }
        };

        public IList<IFeedback> GetItem()
        {
            return _feedbacksStatus;
        }

        public void UpdateFeedbackItem(int id)
        {
            if (LastService) return;

            ResetFeedbackCollection();

            foreach (var item in _feedbacksStatus.Where(x => x.Id == id))
            {
                item.Selected = true;
                History.Add(item);
            }

            IdNextService += 1;
        }

        public IList<IFeedback> History { get; set; } = new List<IFeedback>();

        public void ResetSelected()
        {
            ResetFeedbackCollection();
            _idNextService = 1;
            LastService = false;
        }

        private void ResetFeedbackCollection()
        {
            foreach (var item in _feedbacksStatus)
                item.Selected = false;
        }

        private int _idNextService = 1;

        public int IdNextService
        {
            get => _idNextService;

            set
            {
                LastService = false;

                if (_idNextService < _feedbacks.Count)
                    _idNextService = value;
                else LastService |= _idNextService == _feedbacks.Count;
            }
        }

        public bool LastService { get; set; }

        public IFeedback GetCurrentItem()
        {
            return _feedbacks.FirstOrDefault(x => x.Id == IdNextService);
        }

        public void GetFeedback(Action<IList<Core.Models.DTO.Feedback.Get.FeedbackModel>> success, Action<string> error)
        {
            GetService.GetFeedback(success, error);
        }

        public void PostFeedback(Action success, Action<string> error)
        {
            if (History == null || History.Count <= 0)
            {
                error?.Invoke("NULL");
                return;
            }

            var data = new Models.DTO.Feedback.Get.FeedbackServerModel
            {
                Service = (int)History.ElementAtOrDefault(0).FeedbackType,
                Event = (int)History.ElementAtOrDefault(1).FeedbackType,
                Beer = (int)History.ElementAtOrDefault(2).FeedbackType,

                DeviceToken = Plugin.DeviceInfo.CrossDeviceInfo.Current.Id
            };

            History.Clear();

            GetService.PostFeedback(data, success, error);
        }

        public void GetCategoryItem(Action<IList<IFeedback>> success, Action<string> error)
        {
            if (_feedbacks == null || _feedbacks.Count <= 0)
            {
                error?.Invoke("NULL");
                return;
            };

            GetFeedback((obj) =>
            {
                if (obj == null || obj.Count <= 0)
                {
                    error?.Invoke("NULL");
                    return;
                };

                _feedbacks.ElementAtOrDefault(0).Rating = obj.ElementAtOrDefault(0).Service;
                _feedbacks.ElementAtOrDefault(1).Rating = obj.ElementAtOrDefault(0).Event;
                _feedbacks.ElementAtOrDefault(2).Rating = obj.ElementAtOrDefault(0).Beer;

                success?.Invoke(_feedbacks);

            }, (obj) =>
            {
                error?.Invoke(obj);
            });
        }
    }
}
