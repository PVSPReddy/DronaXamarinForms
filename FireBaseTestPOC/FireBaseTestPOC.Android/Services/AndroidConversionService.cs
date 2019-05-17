using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FireBaseTestPOC.Droid.Services
{
    public class AndroidConversionService : ContentPage
    {
        public AndroidConversionService(){}

        public async Task<Stream> GetStreamFromLocalFileURL(string fileURL)
        {
            Stream streamResponse = new MemoryStream();
            string _uuuri = fileURL;
            try
            {
                FileStream fs = new FileStream(fileURL, FileMode.Open, FileAccess.Read);
                using (System.IO.Stream stream = new FileStream(fileURL, FileMode.Open, FileAccess.Read))
                {
                    streamResponse = stream;
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return streamResponse;
        }
    }
}

