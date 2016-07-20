/*using System.Net.Http;

namespace web_editor_seo.Services
{
    public class RestClient
    {
        public Get()
        {
            using (var client = new HttpClient())
{
    var baseUri = "http://playapi.azurewebsites.net/api/products";
    client.BaseAddress = new Uri(baseUri);
    client.DefaultRequestHeaders.Accept.Clear();
    var response = await client.GetAsync(baseUri);
    if (response.IsSuccessStatusCode)
    {
        var responseJson = await response.Content.ReadAsStringAsync();
        //do something with the response here. Typically use JSON.net to deserialise it and work with it
    }
}
        }
        public HttpResponseMessage GetResponse(string path = "/", string query = "")
        {
            var request = CreateHttpRequest(path, query);
        
            using (var client = CreateHttpClient(path, query))
            {
                client.Timeout = TimeSpan.FromMilliseconds(TimeoutMs);
                var result = client.SendAsync(request).Result;
                return result;
            }
        }

        public void AddCookie(string name, string value)
        {
            var cookieUriBuilder = new UriBuilder { Scheme = Scheme, Path = "/", Host = Host };
            var cookie = new Cookie(name, value, "/", Host);
            _cookies.Add(cookieUriBuilder.Uri, cookie);
        }

        private static string GetIpAddress(string host)
        {
            return Dns.GetHostAddressesAsync(host).Result[0].ToString();
        }

        private HttpRequestMessage CreateHttpRequest(string path, string query="")
        {
            if (string.IsNullOrEmpty(IpAddress))
            {
                IpAddress = GetIpAddress(Host);
            }      

            var uriBuilder = new UriBuilder { Scheme = Scheme, Path = path, Host = IpAddress, Query = query.TrimStart('?') };
            
            var result = new HttpRequestMessage();
            result.RequestUri = uriBuilder.Uri;      
            result.Headers.Host = Host;
            
            foreach (var headerKey in _requestHeaders.Keys)
            {
                result.Headers.Add(headerKey, _requestHeaders[headerKey]);
            }
            
            return result;
        }
    }
}
*/