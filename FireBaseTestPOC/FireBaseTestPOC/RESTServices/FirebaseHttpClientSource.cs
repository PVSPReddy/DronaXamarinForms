using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FireBaseTestPOC.Services.FirebaseRESTAPIs;
using Newtonsoft.Json;

#region
namespace FireBaseTestPOC.RESTServices
{
    public static class FirebaseHttpClientSource<T> where T : class
    {
        public static readonly string FirebaseBaseREST_API_URL = "https://mytestfirebproj.firebaseio.com/Users/PersonalDetails.json";
        static HttpClient client;
        //private  FirebaseRESTAPIServices firebaseRESTAPIServices;

        static FirebaseHttpClientSource()
        {
            //firebaseRESTAPIServices = new FirebaseRESTAPIServices();

            client = new HttpClient();
            client.BaseAddress = new Uri(FirebaseBaseREST_API_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Add("X-Parse-Application-Id", Constants.ApplicationID);
            //client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", Constants.ApiKey);
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<string> FireBasePostDataAsync(string methodName, T t)
        {
            var postData = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
            //var postData = new StringContent(JsonConvert.SerializeObject(t));
            string returnVal = "";
            try
            {
                var response = await FirebaseRESTAPIServices.PostDataToFirebaseAsync(client, new Uri(FirebaseBaseREST_API_URL), postData);
                if (response.IsSuccessStatusCode)
                {
                    returnVal = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    returnVal = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                returnVal = null;
            }
            return returnVal;
        }

        public static async Task<string> FireBasePatchDataAsync(string methodName, T t)
        {
            var postData = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
            //var postData = new StringContent(JsonConvert.SerializeObject(t));
            string returnVal = "";
            try
            {
                var response = await FirebaseRESTAPIServices.PatchDataToFirebaseAsync(client, new Uri(FirebaseBaseREST_API_URL), postData);
                if (response.IsSuccessStatusCode)
                {
                    returnVal = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    returnVal = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                returnVal = null;
            }
            return returnVal;
        }

        public static async Task<string> CreateOrUpdateItemWithPostAsync(string methodName, T t)
        {
            var postData = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
            string returnVal = "";
            try
            {
                //var postData = new StringContent(JsonConvert.SerializeObject(t));

                HttpResponseMessage response = await client.PostAsync(methodName, postData);

                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    returnVal = await response.Content.ReadAsStringAsync();
                    //t = JsonConvert.DeserializeObject<T>(str);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                returnVal = null;
            }

            try
            {
                var req = JsonConvert.SerializeObject(t);
                var resp = returnVal;

                var printString = "MethodName: " + methodName + "\n" + "Request Object: \n" + req + "\n" + "ResponseObject: \n " + resp;
                System.Diagnostics.Debug.WriteLine(printString);
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }

            return returnVal;
        }



        public static async Task<T> RetriveDataWithPostAsync(string methodName)
        {
            //var jsonString = JsonConvert.SerializeObject("{}"); 
            var postData = new StringContent("");
            T t = null;
            HttpResponseMessage response = await client.PostAsync(methodName, postData);

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                t = JsonConvert.DeserializeObject<T>(str);
            }
            return t;
        }

        public static async Task<T> RetriveDataWithGetAsync(string methodName)
        {
            T t = null;
            HttpResponseMessage response = await client.GetAsync(methodName);
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                t = JsonConvert.DeserializeObject<T>(str);
            }
            return t;
        }

        public static async Task<string> UpdateItemWithPutAsync(T t, string methodNameWithIdParam)
        {
            var postData = new StringContent(JsonConvert.SerializeObject(t));
            var status = "";
            HttpResponseMessage response = await client.PutAsync(methodNameWithIdParam, postData);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                status = "Success";
            }
            else
            {
                status = "Failed";
            }
            return status;
        }

        public static async Task<string> DestroyItemWithDeleteAsync(string methodNameWithIdParam)
        {
            var status = "";
            HttpResponseMessage response = await client.DeleteAsync(methodNameWithIdParam);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                status = "Success";
            }
            else
            {
                status = "Failed";
            }
            return status;
        }

        /*
        public static HttpClient GetHttpClient()
        {
            // if a proxy is enabled set it up here
            //string host = Java.Lang.JavaSystem.GetProperty("http.proxyHost").TrimEnd('/');
            //string port = Java.Lang.JavaSystem.GetProperty("http.proxyPort");
            System.Net.Http.HttpClientHandler httpClientHandler = null;
            httpClientHandler = new System.Net.Http.HttpClientHandler
            {
                Proxy = GetCSharpWebProxy(),
                UseProxy = true
            };
            if (httpClientHandler != null)
                return new System.Net.Http.HttpClient(httpClientHandler);
            else
                return new System.Net.Http.HttpClient();
        }
        */

        //this is working
        /*
        public static IWebProxy GetCSharpWebProxy()
        {
            //var proxyURI = new System.Uri(string.Format("{0}:{1}", "your specific proxy host", 80));
            //System.Net.ICredentials credentials = new System.Net.NetworkCredential("username", "password");
            //System.Net.IWebProxy proxy = new System.Net.WebProxy(proxyURI, true, null, credentials);

            Uri proxyUri = new Uri("192.168.1.10");//new Uri("192.168.1.10:8888");
            IWebProxy webProxy = WebRequest.DefaultWebProxy;
            webProxy.Credentials = CredentialCache.DefaultCredentials;
            webProxy.GetProxy(proxyUri);
            webProxy.IsBypassed(proxyUri);
            return webProxy;
        }
        */

        /*
        public System.Net.WebProxy GetCSharpWebProxy()
        {
            var proxyURI = new System.Uri(string.Format("{0}:{1}", "your specific proxy host", 80));
            System.Net.ICredentials credentials = new System.Net.NetworkCredential("username", "password");
            System.Net.WebProxy proxy = new System.Net.WebProxy(proxyURI, true, null, credentials);
            return proxy;
        }
        */
    }

    /*
    //public class WebProxy : IWebProxy
    //{
    //    public ICredentials Credentials { get; set; }
    //    public Uri proxyUriData;

    //    public WebProxy(Uri proxyUri, bool isBypassed, object obj, ICredentials credientials)
    //    {
    //        Credentials = credientials;
    //    }

    //    public Uri GetProxy(Uri destination)
    //    {
    //        retunr 
    //        //throw new NotImplementedException();
    //    }

    //    public bool IsBypassed(Uri host)
    //    {
    //        return true;
    //        //throw new NotImplementedException();
    //    }
    //}
    */
}

#endregion