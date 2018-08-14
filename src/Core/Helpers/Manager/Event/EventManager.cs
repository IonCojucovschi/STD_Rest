//
//  EventManager.cs
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
using Core.Models.DAL.Events;
using Int.Core.Extensions;
using Int.Core.Helpers;
using Int.Core.Network.Singleton;
using Splat;

namespace Core.Helpers.Manager.Event
{
    public class EventManager : Singleton<EventManager>
    {
        private const string KeyAll = "All";

        private static Services.MockServices.RealServices.IEvents GetService =>
                           Locator.Current.GetService<Services.MockServices.RealServices.IEvents>(App.Instance.IsMock ? App.ServiceContractMock : App.ServiceContract);

        private IEvent _details;

        public EventType IsDay { get; set; } = EventType.Day;

        public DateTime CurrentDateTime { get; set; } = DateTime.Now;

        private static IList<IEvent> EventOriginal { get; set; } = new List<IEvent>();
        private static IList<IEvent> EventMainOriginal { get; set; } = new List<IEvent>();

        private static IList<IEvent> EventFilter { get; set; } = new List<IEvent>();
        private static IList<IEvent> EventMainFilter { get; set; } = new List<IEvent>();

        private IList<IEvent> EventTag { get; set; } = new List<IEvent>();

        public IEnumerable<IEvent> GetItem() => EventFilter;

        public IList<IEvent> GetItemPerDateTime => GetItem()
            .Where(x => IsDay != EventType.Day ?
                        x.EventDateTime.ToString("d") == CurrentDateTime.ToString("d") :
                        x.EventDateTime.Month == CurrentDateTime.Month).ToList();

        public IList<IEvent> GetMainItemPerDateTime => GetMainItem()
            .Where(x => IsDay != EventType.Day ?
                        x.EventDateTime.ToString("d") == CurrentDateTime.ToString("d") :
                        x.EventDateTime.Month == CurrentDateTime.Month).ToList();


        public IEnumerable<IEvent> GetMainItem() => EventMainFilter;
        public IList<IEvent> GetTagItem() => EventTag;

        public void UpdateTagSelected(int idTag)
        {
            if (EventTag != null && GetTag(idTag) == null) return;

            if (EventTag != null)
            {
                foreach (var item in EventTag)
                {
                    if (!item.Tag.Contains(KeyAll) && item.SelectedTag)
                    {
                        var data = GetTag(idTag);
                        if (data.Tag.Contains(KeyAll))
                            return;
                    }
                    else if (EventTag.FirstOrDefault(x => x.Tag.Contains(KeyAll)).SelectedTag)
                    {
                        if (!EventTag.Any(x => x.Tag.Contains(KeyAll) && x.SelectedTag))
                            return;

                        var data = GetTag(idTag);
                        if (!data.Tag.Contains(KeyAll))
                            return;
                    }
                }

                GetTag(idTag).SelectedTag = !GetTag(idTag).SelectedTag;

                ClearFilter();

                if (EventTag.Any(x => x.SelectedTag && x.Tag == KeyAll))
                {
                    FilterAddOriginal();
                    return;
                }
            }

            FilterSecondary();
            FilterMain();
        }

        private IEvent GetTag(int idTag) => EventTag.FirstOrDefault(x => x.Id == idTag);

        private static void ClearFilter()
        {
            EventFilter.Clear();
            EventMainFilter.Clear();
        }

        private static void FilterAddOriginal()
        {
            EventFilter.AddRange(EventOriginal);
            EventMainFilter.AddRange(EventMainOriginal);
        }

        private void FilterSecondary()
        {
            foreach (var item in EventOriginal)
                foreach (var itemTag in EventTag.Where(x => x.SelectedTag))
                    if (item.Tag.Contains(itemTag.Tag))
                    {
                        if (!EventFilter.Any(x => x.Id == item.Id))
                            EventFilter.Add(item);
                    }
        }

        private void FilterMain()
        {
            foreach (var item in EventMainOriginal)
                foreach (var itemTag in EventTag.Where(x => x.SelectedTag))
                    if (item.Tag.Contains(itemTag.Tag))
                    {
                        if (!EventMainFilter.Any(x => x.Id == item.Id))
                            EventMainFilter.Add(item);
                    }
        }

        public void GetDetailsMain(int idEvent)
        {
            _details = EventMainFilter.FirstOrDefault(x => x.Id == idEvent);
        }

        public void GetDetailsSecond(int idEvent)
        {
            _details = EventFilter.FirstOrDefault(x => x.Id == idEvent);
        }

        public IEvent GetDetails() => _details;

        public void GetEvent()
        {
            GetService.GetEvent(CurrentDateTime.FirstDayOfMonth().ToEpoch(), CurrentDateTime.EndOfLastDayOfMonth().ToEpoch(), (objSucces) =>
            {
                SortEvent(objSucces);
                AddTag(objSucces);

            }, (obj) => { });
        }

        private void SortEvent(IEnumerable<Models.DTO.Event.EventModel> objSucces)
        {
            ClearFilter();
            EventMainOriginal.Clear();
            EventOriginal.Clear();

            foreach (var item in objSucces)
            {
                item.Images.Add(new Models.DTO.Image { Path = item.MainImage });

                if (item.Type == 1)
                {
                    EventMainOriginal.Add(new EventModel
                    {
                        Id = item.Id,
                        EventDateTime = item.Date,
                        Description = item.Description,
                        Tag = item.Tag,
                        ImagePathView = item.MainImage,
                        ImageOriginal = item.MainImage,
                        Name = item.Title,
                        Images = item.Images
                    });
                }
                else
                {
                    EventOriginal.Add(new EventModel
                    {
                        Id = item.Id,
                        EventDateTime = item.Date,
                        Description = item.Description,
                        Tag = item.Tag,
                        ImagePathView = item.MainImage,
                        ImageOriginal = item.MainImage,
                        Name = item.Title,
                        Images = item.Images
                    });
                }
            }

            FilterAddOriginal();
        }

        private void AddTag(IEnumerable<Models.DTO.Event.EventModel> objSucces)
        {
            EventTag.Clear();

            dynamic groupTag = objSucces.Select(x => new { Tag = x.Tag.Split(',') });

            var tag = new List<EventModel>();

            var i = 0;

            foreach (var item in groupTag)
                foreach (var items in item.Tag)
                {
                    i++;
                    if (!tag.Exists(x => x.Tag == items))
                        tag.Add(new EventModel { Id = i, Tag = items, ColorTag = ColorHelper.GetColorRandom() });
                }

            if (!tag.Exists(x => x.Tag == KeyAll))
            {

                var incriment = tag.LastOrDefault();

                tag.Add(new EventModel { Id = incriment == null ? 0 : incriment.Id++, Tag = KeyAll, ColorTag = ColorHelper.GetColorRandom() });

            }

            foreach (var item in tag)
            {
                EventTag.Add(item.Tag.Contains(KeyAll)
                    ? new EventModel { Id = item.Id, Tag = item.Tag, ColorTag = item.ColorTag, SelectedTag = true }
                    : new EventModel { Id = item.Id, Tag = item.Tag, ColorTag = item.ColorTag });
            }

            EventTag.MoveModelFirstPosition(KeyAll);
        }
    }
}
