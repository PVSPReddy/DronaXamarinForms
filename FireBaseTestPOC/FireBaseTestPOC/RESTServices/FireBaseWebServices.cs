using System;
using System.Threading.Tasks;
using FireBaseTestPOC.Models.FirebaseModels;
using FireBaseTestPOC.RESTServices.InterfaceLayer;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FireBaseTestPOC.RESTServices
{
    public class FireBaseWebServices : IFireBaseWebServices
    {
        public FireBaseWebServices(){}

        #region to add user data to firebase
        public async Task<UsersRequestObject> AddUserToDatabase(UsersRequestObject requestObject)
        {
            UsersRequestObject usersRequestObject = null;
            try
            {
                var responseStr = await FirebaseHttpClientSource<UsersRequestObject>.CreateOrUpdateItemWithPostAsync("", requestObject);
                usersRequestObject = JsonConvert.DeserializeObject<UsersRequestObject>(responseStr);
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
            return usersRequestObject;
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}

