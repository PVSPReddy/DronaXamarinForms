using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FireBaseTestPOC.Services.FirebaseRESTAPIs
{
    //public class FirebaseRESTAPIServices<T> where T : class
    public static class FirebaseRESTAPIServices
    {
        //public readonly string FirebaseBaseREST_API_URL = "https://mytestfirebproj.firebaseio.com/Users/PersonalDetails.json";
        //FirebaseClient firebase = new FirebaseClient("https://xamarinfirebase-909d2.firebaseio.com/");

        //private HttpClient client;

        static FirebaseRESTAPIServices()
        {
            //client = new HttpClient();
            //client.BaseAddress = new Uri(FirebaseBaseREST_API_URL);
            ////client.BaseAddress = new Uri(Constants.Apiurl);
            ////client.DefaultRequestHeaders.Accept.Clear();
            ////client.DefaultRequestHeaders.Add("X-Parse-Application-Id", Constants.ApplicationID);
            ////client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", Constants.ApiKey);
            //////client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(new UTF8Encoding().GetBytes(Constants.Username +":"+ Constants.Password)));
            ////client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ////client.DefaultRequestHeaders.Add("secret", Constants.ServerSecretCode);
            ////client.DefaultRequestHeaders.Add("securitycode", Constants.ServerSecurityCode);
        }

        public static async Task<HttpResponseMessage> PostDataToFirebaseAsync(HttpClient client, Uri requestUri, HttpContent requestObject)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri);
            request.Content = requestObject;
            //HttpContent httpContent = new StringContent("Your JSON-String", Encoding.UTF8, "application/json-patch+json");
            //string returnVal = "";
            HttpResponseMessage httpResponseMessage = null;
            try
            {
                httpResponseMessage = await client.SendAsync(request);
                //// In case you want to set a timeout
                ////CancellationToken cancellationToken = new CancellationTokenSource(60).Token;
                //response.EnsureSuccessStatusCode();
                //if (response.IsSuccessStatusCode)
                //{
                //    returnVal = await response.Content.ReadAsStringAsync();
                //}
                //else
                //{
                //    returnVal = response.Content.ReadAsStringAsync().Result;
                //}
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
            return httpResponseMessage;
        }

        //public async Task<string> PostDataToFirebaseAsync(HttpClient client, Uri requestUri, T requestObject)
        //{
        //    var method = new HttpMethod("PATCH");
        //    var request = new HttpRequestMessage(method, requestUri);
        //    request.Content = new StringContent(JsonConvert.SerializeObject(requestObject), Encoding.UTF8, "application/json");
        //    //HttpContent httpContent = new StringContent("Your JSON-String", Encoding.UTF8, "application/json-patch+json");
        //    string returnVal = "";
        //    try
        //    {
        //        var response = await client.SendAsync(request);
        //        // In case you want to set a timeout
        //        //CancellationToken cancellationToken = new CancellationTokenSource(60).Token;
        //        response.EnsureSuccessStatusCode();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            returnVal = await response.Content.ReadAsStringAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var msg = ex.Message + "\n" + ex.StackTrace;
        //        returnVal = msg;
        //    }
        //    return returnVal;
        //}

        /*
        public async Task<string> PatchAsync(HttpClient client, Uri requestUri, T requestObject)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri);
            request.Content = new StringContent(JsonConvert.SerializeObject(requestObject), Encoding.UTF8, "application/json");
            //HttpContent httpContent = new StringContent("Your JSON-String", Encoding.UTF8, "application/json-patch+json");
            string returnVal = "";
            try
            {
                var response = await client.SendAsync(request);
                // In case you want to set a timeout
                //CancellationToken cancellationToken = new CancellationTokenSource(60).Token;
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    returnVal = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                returnVal = msg;
            }
            return returnVal;
        }
        */


        /*
        //public async Task<HttpResponseMessage> PatchAsync(HttpClient _client, Uri requestUri, IHttpContent iContent)
        public async Task<HttpResponseMessage> PatchAsync1(HttpClient _client, Uri requestUri, HttpContent iContent)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = iContent
            };
            request.Content = new StringContent("Your JSON-String", Encoding.UTF8, "application/json-patch+json");
            HttpContent httpContent = new StringContent("Your JSON-String", Encoding.UTF8, "application/json-patch+json");
            HttpResponseMessage response = new HttpResponseMessage();
            // In case you want to set a timeout
            //CancellationToken cancellationToken = new CancellationTokenSource(60).Token;
            try
            {
                var dishum1 = await client.SendAsync(request, httpContent);
                var dishum2 = await client.PostAsync()
                //response = await client.SendRequestAsync(request);
                //// If you want to use the timeout you set
                ////response = await client.SendRequestAsync(request).AsTask(cancellationToken);
            }
            catch (TaskCanceledException e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR: " + e.ToString());
            }
            return response;
        }

        public async Task<HttpResponseMessage> PatchAsync2(this HttpClient client, Uri requestUri, HttpContent iContent)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = iContent
            };
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await client.SendAsync(request);
            }
            catch (TaskCanceledException e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR: " + e.ToString());
            }
            return response;
        }

        //var postData = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
        public async Task<string> CreateItemWithPatchAsync(string methodName, T t)
        {
            var postData = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
            //var postData = new StringContent(JsonConvert.SerializeObject(t));
            string returnVal = "";
            try
            {
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
            var request = JsonConvert.SerializeObject(t);
            System.Diagnostics.Debug.WriteLine("Request: " + request + "\n");
            System.Diagnostics.Debug.WriteLine("Response: " + "\n" + ((returnVal != null) ? returnVal : ""));
            return returnVal;
        }
        */

        /*
        public static async Task<string> CreateOrUpdateItemWithPostAsync(string methodName, T t)
        {
            var postData = new StringContent(JsonConvert.SerializeObject(t));
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
            var request = JsonConvert.SerializeObject(t);
            System.Diagnostics.Debug.WriteLine("Request: " + request + "\n");
            System.Diagnostics.Debug.WriteLine("Response: " + "\n" + ((returnVal != null) ? returnVal : ""));
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
            //HttpResponseMessage response = await client.PutAsync($"api/products/{Id}", postData);
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
        */
    }
}