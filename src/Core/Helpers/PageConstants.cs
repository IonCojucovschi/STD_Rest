//
//  PageConstants.cs
//
//  Author:
//       Songurov <songurov@gmail.com>
//
//  Copyright (c) 2018 Songurov
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

#if __ANDROID__
using Droid.Page;
using Droid.Views.Feedback;
#else
using iOS.Storyboard;
#endif

namespace Core.Helpers
{
    public static class PageConstants
    {
        public static string PageName => nameof(Splash);
        public static string PageNameHome => nameof(Home);

        public static string PageNameBeerList => nameof(BeerList);
        public static string PageNameCall => nameof(Call);
        public static string PageNameFoodList => nameof(FoodList);
        public static string PageNameFeedback => nameof(Feedback);
        public static string PageNameFeedbackGive => nameof(FeedbackGive);

        public static string PageNameCode => nameof(Code);

        public static string PageNameOrder => nameof(Order);
        public static string PageNameOrderBar => nameof(OrderBar);
        public static string PageNameOrderTable => nameof(OrderTable);

        public static string PageNameOrders => nameof(Orders);

        public static string PageNameEvents => nameof(Events);
        public static string PageNameEventDetails => nameof(EventDetails);

        public static string PageNameSign => nameof(Sign);
        public static string PageNameCreateAccount => nameof(CreateAccount);

        //Views Window
    }
}
