//
// RestCalls.cs
//
// Author:
//       Songurov Fiodor <songurov@gmail.com>
//
// Copyright (c) 2016 Songurov Fiodor
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

using System;
using Core.Helpers.Manager;
using Core.Models.DAL;
using Core.Models.DTO.Feedback.Get;
using Core.Models.DTO.Notification.Post;
using Core.Models.DTO.Order;
using Core.Models.DTO.Payment;
using Int.Core.Network;
using Int.Core.Network.Contract;
using Int.Core.Wrappers.Callback;
using Newtonsoft.Json;
using RestSharp;

namespace Core.Services
{
    internal sealed class RestCalls : ApiBase<RestCalls>
    {
        protected override string BaseUrl => RestConstants.BaseUrl;

        public IRestCallbackClient GetCategory() =>
            Request(RestConstants.GetCategory);

        public IRestCallbackClient GetCategpryFromProduct() =>
            Request(RestConstants.GetProductFromCategory);

        public IRestCallbackClient GetFeedback() =>
            Request(RestConstants.GetFeedback);

        public IRestCallbackClient GetOrder(string deviceToken) =>
            Request(RestConstants.GetOrder + "/" + deviceToken);

        public IRestCallbackClient GetEvent(long startMonth, long endMonth) =>
            Request(string.Format(RestConstants.GetEvent, startMonth, endMonth));


        public IRestCallbackClient PostOrder(OrderModel model)
        {
            return Request(RestConstants.PostOrder, Method.POST,
                           JsonConvert.SerializeObject(model),
                           RestConstants.MediaTypeJson);
        }

        public IRestCallbackClient PostUpdateOrder(OrderUpdateModel model)
        {
            return Request(RestConstants.PostUpdateOrder, Method.POST,
                           JsonConvert.SerializeObject(model),
                           RestConstants.MediaTypeJson);
        }

        public IRestCallbackClient PostVerifyPayment(PaymentModel model)
        {
            return Request(RestConstants.PostPaymentVerify, Method.POST,
                           JsonConvert.SerializeObject(model),
                           RestConstants.MediaTypeJson);
        }

        public IRestCallbackClient PostCall(CallModel model)
        {
            return Request(RestConstants.PostCall, Method.POST,
                           JsonConvert.SerializeObject(model),
                           RestConstants.MediaTypeJson);
        }

        public IRestCallbackClient PostFeedback(FeedbackServerModel model)
        {
            return Request(RestConstants.PostFeedback, Method.POST,
                           JsonConvert.SerializeObject(model),
                           RestConstants.MediaTypeJson);
        }

        public IRestCallbackClient PostNotification(NotificationModel model)
        {
            return Request(RestConstants.PostNotification, Method.POST,
                           JsonConvert.SerializeObject(model),
                           RestConstants.MediaTypeJson);
        }

        private IRestCallbackClient Request(string url, Method method = Method.GET,
                                            string content = "", string typeMedia = RestConstants.MediaTypeJson,
                                           ParameterType typePar = ParameterType.RequestBody,
                                                 RequestTo requestTo = RequestTo.NoKey,
                                           string additionalFilePath = null)

        {
            MediaType = typeMedia;
            SegmentUrl = url;

            var client = new RestClient(Uri.EscapeUriString(BaseUrl + SegmentUrl));
            var request = new RestRequest(method);
            request.AddHeader("cache-control", "no-cache");

            if (!string.IsNullOrEmpty(MediaType))
                request.AddHeader("Content-Type", MediaType);

            if (requestTo == RequestTo.Key)
                request.AddHeader("Authorization",
                    "Bearer " + (UserManager.Instance.CurrentUser() as UserModel)?.Token);

            if (!string.IsNullOrEmpty(content))
                request.AddParameter(MediaType, content, typePar);

            if (string.IsNullOrWhiteSpace(additionalFilePath)) return GetCallBack(client.Execute(request));
            const string fileName = "file";
            request.AddFile(fileName, additionalFilePath);

            return GetCallBack(client.Execute(request));
        }

        private static IRestCallbackClient GetCallBack(IRestResponse concretClient)
           => new HttpClientWrapper(concretClient.Content, concretClient.ErrorMessage, (int)concretClient.StatusCode);
    }
}

