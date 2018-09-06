using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RESTClient
{
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class RestClient
    {
        // This will hold our URI
        public string EndPoint { get; set; }
        // This will hold our enum created above
        public HttpVerb HttpMethod { get; set; }

        // Constructor
        public RestClient()
        {
            EndPoint = "";
            HttpMethod = HttpVerb.GET;
        }

        // This method returns a string
        public string MakeRequest()
        {
            string strResponseValue = string.Empty;

            // The HttpWebRequest class inherites from the WebRequest class
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);

            request.Method = HttpMethod.ToString();

            // Set the response to null.
            HttpWebResponse response = null;

            // Try the following code
            try
            {
                response = (HttpWebResponse)request.GetResponse();

                // Process the response stream (JSON)
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            // I am aware it may fail, if so the catch block so into action
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            // the finally block is optional.
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }
            // Return the string response value.
            return strResponseValue;
        }
    }
}
