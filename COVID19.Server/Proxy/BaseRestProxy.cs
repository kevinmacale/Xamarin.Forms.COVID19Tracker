using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace COVID19.Server.Proxy
{
    public abstract class BaseRestProxy
    {
        private readonly string _baseURL;

        public BaseRestProxy(string baseURL)
        {
            _baseURL = baseURL;
        }

        public readonly JsonSerializerSettings JsonSerializeSettings = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            },
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.None,
        };
        public HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            if (string.IsNullOrEmpty(uri)) return default;
            using (var client = GetHttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"{_baseURL}{uri}").ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var deserializedObj = JsonConvert.DeserializeObject(content, typeof(T), JsonSerializeSettings);
                        return (T)deserializedObj;
                    }
                    else
                    {
                        throw new HttpRequestException($"Error occured : {typeof(T).Name}");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<T> PostAsync<T>(string uri, object param = null)
        {
            if (string.IsNullOrEmpty(uri)) return default;
            StringContent stringContent = null;
            if (param != null)
            {
                var serializeObj = JsonConvert.SerializeObject(param);
                stringContent = new StringContent(serializeObj, Encoding.UTF8, "application/json");
            }

            using (var client = GetHttpClient())
            {
                try
                {
                    var response = await client.PostAsync($"{_baseURL}{uri}", stringContent).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var deserializedObj = JsonConvert.DeserializeObject(content, typeof(T), JsonSerializeSettings);
                        return (T)deserializedObj;
                    }
                    else
                    {
                        throw new HttpRequestException($"Error occured : {typeof(T).Name}");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task PutAsync(string uri, object param = null)
        {
            if (string.IsNullOrEmpty(uri)) return;
            StringContent stringContent = null;
            if (param != null)
            {
                var serializeObj = JsonConvert.SerializeObject(param);
                stringContent = new StringContent(serializeObj, Encoding.UTF8, "application/json");
            }

            using (var client = GetHttpClient())
            {
                try
                {
                    var fullUrl = $"{_baseURL}{uri}";
                    var response = await client.PostAsync(fullUrl, stringContent).ConfigureAwait(false);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
