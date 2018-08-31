using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace CRUDWITHJSONINWCF_Client.Models
{
    public class ProductServiceClient
    {
        private string BASE_URL = "http://localhost:24491/ServiceProduct.svc/";
        public List<Product> findall()
        {
            try {
                var wc = new WebClient();
             
                var json = wc.DownloadString(BASE_URL + "findall");
                var js = new JavaScriptSerializer();
                 
                return js.Deserialize<List <Product>>(json);
            }
            catch {
                return null ;
            }
        }
        public Product find(string id)
        {
            try
            {
                var wc = new WebClient();
                string url = string.Format(BASE_URL + "find/{0}",id);
                var json = wc.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<Product>(json);

            }
            catch {
                return null;
            }
        }

        public bool Create(Product product )
        {
            try
            {
                DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(Product));
                MemoryStream ms = new MemoryStream();
                ds.WriteObject(ms, product);
                string data = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
                WebClient wc = new WebClient();
                wc.Headers["Content-type"] = "application/json";
                wc.Encoding = Encoding.UTF8;
                wc.UploadString(BASE_URL + "create", "POST", data);
                return true;

            }
            catch
            {
                return false ;
            }
        }
        public bool edit(Product product) {
            try
            {
                DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(Product));
                MemoryStream ms = new MemoryStream();
                dcjs.WriteObject(ms, product);
                string data = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
                WebClient wc = new WebClient();
                wc.Headers["Content-type"] = "application/json";
                wc.Encoding = Encoding.UTF8;
                wc.UploadString(BASE_URL + "edit", "PUT", data);
                return true;
            }
            catch { return false;
            }
        }
        public bool delete(Product product)
        { try {
                DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(Product));
                MemoryStream ms = new MemoryStream();
                dcjs.WriteObject(ms, product);
                string data = Encoding.UTF8.GetString(ms.ToArray(), 0,(int) ms.Length);
                WebClient wc = new WebClient();
                wc.Headers["Content-type"] = "application/json";
                wc.Encoding = Encoding.UTF8;
                wc.UploadString(BASE_URL + "delete", "DELETE");
                return true; }
            catch { return false; }
        }
    }
   
}