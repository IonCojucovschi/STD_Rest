//
//  UserManager.cs
//
//  Author:
//       Songurov <songurov@gmail.com>
//
//  Copyright (c) 2017 Songurov
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
using System.Linq;
using Core.Models.DAL;
using Core.Services;
using Int.Core.Application.Contract;
using Int.Core.Application.Login.Contract;
using Int.Core.Data.Repository.Akavache.Contract;
using Int.Core.Extensions;
using Int.Core.Network.Singleton;
using Splat;

namespace Core.Helpers.Manager
{
    public class UserManager : Singleton<UserManager>
    {
        private readonly IRepositoryWithId<UserModel> _userAccountRep =
            Service.Instance.ServiceRepository.UnitOfWork.GetFeedRepository<UserModel>();

        private static ILogin GetService =>
            Locator.Current.GetService<ILogin>(App.Instance.IsMock ? App.ServiceContractMock : App.ServiceContract);

        public IUser CurrentUser()
        {
            return _userAccountRep.GetAll()?.FirstOrDefault();
        }

        public void Clear()
        {
            _userAccountRep.RemoveAll();
        }

        public bool IsRememberMe()
        {
            return !CurrentUser().IsNull() &&
                   ((UserModel)CurrentUser()).Remember;
        }

        public void UpdateUser(IUser user)
        {
            var userCurrent = _userAccountRep?.GetAll()?.FirstOrDefault(x => x.Id == 0);
            _userAccountRep?.RemoveAll();

            if (userCurrent.IsNull())
                userCurrent = new UserModel();

            userCurrent.UpdateObject(user);

            if (userCurrent == null) return;
            userCurrent.Id = 0;
            _userAccountRep?.Add(userCurrent);
        }

        public void Login(Action<string> success, Action<string> error)
        {
            GetService.OnLogin(success, error);
        }

        public void RecoverPassword(Action<string> success, Action<string> error)
        {
            GetService.OnRecoveryPassword(success, error);
        }

        public void ChangePassword(Action<string> success, Action<string> error)
        {
            GetService.OnChangePassword(success, error);
        }
    }
}
