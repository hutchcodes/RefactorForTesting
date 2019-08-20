using Refactoring.Logging;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Refactoring.Services
{
    class WebServiceBase
    {
        private string _baseUrl;
        public WebServiceBase(string baseUr)
        {
            _baseUrl = baseUr;
        }

        private IRestClient GetRestClient()
        {
            return new RestClient
            {
                BaseUrl = new Uri(_baseUrl),
            };
        }

        public IRestRequest GetRestRequest(string resource, Method method = Method.GET, DataFormat requestFormat = DataFormat.Json)
        {
            var request = new RestRequest()
            {
                Resource = resource,
                Method = method,
                RequestFormat = requestFormat
            };

            return request;
        }

        public T Execute<T>(IRestRequest request) where T : new()
        {
            return Execute<T>(GetRestClient(), request);
        }
        public T Execute<T>(IRestClient client, IRestRequest request) where T : new()
        {
            LogRequest<T>(request);

            var response = client.Execute<T>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                LogResult(response);

                return response.Data;
            }

            return default(T);
        }

        private void LogResult<T>(IRestResponse<T> response) where T : new()
        {
            Logger.LogMessage($"Result was {response.StatusCode}");
        }

        private void LogRequest<T>(IRestRequest request) where T : new()
        {
            Logger.LogMessage($"Requested {request.Method} at {request.Resource}");
        }
    }
}
