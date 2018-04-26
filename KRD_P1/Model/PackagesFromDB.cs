using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KRD_P1.View;
using Newtonsoft.Json;

namespace KRD_P1.Model
{
    public class PackagesFromDB
    {
        public Package GetPackage(int id)
        {
            string uri = "http://localhost:51000/package/" + id;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var package = reader.ReadToEnd();
                Package _package = Newtonsoft.Json.JsonConvert.DeserializeObject<Package>(package);
                return _package;
            }
        }

        public List<Package> GetPackages()
        {
            string uri = "http://localhost:51000/package/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var packages = reader.ReadToEnd();
                List<Package> _packages = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Package>>(packages);
                return _packages;
            }
        }

        public List<Package> FindPackages(string PackageId = "")
        {
            var packages = GetPackages();
            return packages.Where(package => package.ID.ToString().Contains(PackageId)).ToList();
        }

        public async Task<Package> UpdatePackage(Package package)
        {
            string uri = "http://localhost:51000/package/";
            HttpClient client = new HttpClient();


            Dictionary<string, string> values =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(package));

            var content = new FormUrlEncodedContent(values);

            var response = await client.PutAsync(uri, content);
            return null;
        }

        public async Task<Package> AddPackage(Package package)
        {
            string uri = "http://localhost:51000/package/";
            HttpClient client = new HttpClient();


            Dictionary<string, string> values =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(package));

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(uri, content);
            var result = response.Content.ReadAsStringAsync();
            try
            {
                var returnedPackages = JsonConvert.DeserializeObject<Package>(result.Result);
                return returnedPackages;
            }
            catch (Exception) { }

            return null;
        }
        public void DeletePackage(int id)
        {
            string uri = "http://localhost:51000/package/" + id;
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync(uri);
        }
    }
}
