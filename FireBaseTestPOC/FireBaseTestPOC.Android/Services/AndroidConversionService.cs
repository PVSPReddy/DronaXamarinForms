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

        public async Task<byte[]> GetBytesFromStream(Stream streamData)
        {
            byte[] byteResponse = null;
            Stream streamResponse = new MemoryStream();
            try
            {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = streamData.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return byteResponse;
        }
    }
}

