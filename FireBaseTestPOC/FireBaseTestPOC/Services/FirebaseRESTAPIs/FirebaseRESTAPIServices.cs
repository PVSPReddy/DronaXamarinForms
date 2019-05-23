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

        static FirebaseRESTAPIServices(){}

        public static async Task<HttpResponseMessage> PatchDataToFirebaseAsync(HttpClient client, Uri requestUri, HttpContent requestObject)
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
                //// If you want to use the timeout you set
                ////response = await client.SendRequestAsync(request).AsTask(cancellationToken);
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
            return httpResponseMessage;
        }

        public static async Task<HttpResponseMessage> PostDataToFirebaseAsync(HttpClient client, Uri requestUri, HttpContent requestObject)
        {
            var method = new HttpMethod("POST");
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
                //// If you want to use the timeout you set
                ////response = await client.SendRequestAsync(request).AsTask(cancellationToken);
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
            return httpResponseMessage;
        }
    }
}