using System;
using RestSharp;

namespace Refactoring.Helpers
{
    public interface IHttpHelper
    {
        Uri BaseUrl { get; set; }

        T Execute<T>(IRestClient client, IRestRequest request) where T : new();
        T Execute<T>(IRestRequest request) where T : new();
        IRestRequest GetRestRequest(string resource, Method method = Method.GET, DataFormat requestFormat = DataFormat.Json);
    }
}