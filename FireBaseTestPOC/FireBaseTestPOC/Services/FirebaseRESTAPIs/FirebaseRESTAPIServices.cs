using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FireBaseTestPOC.Services.FirebaseRESTAPIs
{
    public class FirebaseRESTAPIServices<T> where T : class
    {
        public static readonly string FirebaseBaseREST_API_URL = "https://mytestfirebproj.firebaseio.com/Users/PersonalDetails.json";
        //FirebaseClient firebase = new FirebaseClient("https://xamarinfirebase-909d2.firebaseio.com/");

        static HttpClient client;

        static FirebaseRESTAPIServices()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(FirebaseBaseREST_API_URL);
            //client.BaseAddress = new Uri(Constants.Apiurl);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Add("X-Parse-Application-Id", Constants.ApplicationID);
            //client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", Constants.ApiKey);
            ////client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(new UTF8Encoding().GetBytes(Constants.Username +":"+ Constants.Password)));
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("secret", Constants.ServerSecretCode);
            //client.DefaultRequestHeaders.Add("securitycode", Constants.ServerSecurityCode);
        }

        //var postData = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
        public static async Task<string> CreateItemWithPatchAsync(string methodName, T t)
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