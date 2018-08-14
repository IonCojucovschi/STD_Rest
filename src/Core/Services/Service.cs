//
// Service.cs
//
// Author:
//       Sogurov Fiodor <f.songurov@software-dep.net>
//
// Copyright (c) 2016 Songurov
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

using Core.Helpers.Manager;
using Core.Models.DAL;
using Core.Models.Repository;
using Core.ViewModels;
using Core.ViewModels.Beer;
using Int.Core.Data.Repository.Akavache.Contract;
using Int.Core.Data.Service;
using Int.Data.Service;

namespace Core.Services
{
    internal sealed class Service : BaseService<Service>, IService
    {
        #region Repository

        private readonly IRepository<UserModel> _userData = new UserRepository();

        #endregion

        public override void Start()
        {
            base.Start();

            AddRepository();

            var a = UserManager.Instance.CurrentUser() as UserModel;

            if (a?.Orders == null)
                UserManager.Instance.UpdateUser(new UserModel { });

            RegisterViewModel();
        }

        private void AddRepository()
        {
            ServiceRepository.UnitOfWork.Add(typeof(UserModel), _userData);
        }

        private void RegisterViewModel()
        {
            ServiceViewModel.RegisterViewModel(new SplashViewModel());

            ServiceViewModel.RegisterViewModel(new BeerListViewModel());
            ServiceViewModel.RegisterViewModel(new CodeViewModel());
            ServiceViewModel.RegisterViewModel(new CallViewModel());
            ServiceViewModel.RegisterViewModel(new HomeViewModel());

            ServiceViewModel.RegisterViewModel(new EventsViewModel());
            ServiceViewModel.RegisterViewModel(new EventDetailsViewModel());

            ServiceViewModel.RegisterViewModel(new FoodViewModel());

            ServiceViewModel.RegisterViewModel(new OrderViewModel());
            ServiceViewModel.RegisterViewModel(new OrderBarViewModel());
            ServiceViewModel.RegisterViewModel(new OrderTableViewModel());
            ServiceViewModel.RegisterViewModel(new OrdersViewModel());

            ServiceViewModel.RegisterViewModel(new FeedbackViewModel());
            ServiceViewModel.RegisterViewModel(new FeedbackGiveViewModel());


            ServiceViewModel.RegisterViewModel(new SignViewModel());
            ServiceViewModel.RegisterViewModel(new CreateAccountViewModel());

        }
    }
}
