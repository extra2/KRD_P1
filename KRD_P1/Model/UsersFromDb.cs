using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace KRD_P1
{
    public class UsersFromDb : IUsersProvider
    {
        public User GetUser(int id)
        {
            string uri = "http://localhost:51000/user/" + id;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var user = reader.ReadToEnd();
                User _user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(user);
                return _user;
            }
        }

        public List<User> GetUsers()
        {
            string uri = "http://localhost:51000/user/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var user = reader.ReadToEnd();
                List<User> _user = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(user);
                return _user;
            }
        }

        public List<User> FindUsers(string Name = "")
        {
            var users = GetUsers();
            return users.Where(user => user.Name.Contains(Name)).ToList();
        }

        public async Task<User> UpdateUser(User user)
        {
            string uri = "http://localhost:51000/user/";    
            HttpClient client = new HttpClient();


            Dictionary<string, string> values =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(user));

            var content = new FormUrlEncodedContent(values);

            var response = await client.PutAsync(uri, content);
            return null;
        }

        public void DeleteUser(int id)
        {
            string uri = "http://localhost:51000/user/" + id;
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync(uri);


            // var responseString = response.Content.ReadAsStringAsync();
        }

        public async Task<User> AddUser(User user)
        {
            string uri = "http://localhost:51000/user/";
            HttpClient client = new HttpClient();


            Dictionary<string, string> values =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(user));

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(uri, content);
            var result = response.Content.ReadAsStringAsync();
            try
            {
                var returnedUser = JsonConvert.DeserializeObject<User>(result.Result);
                return returnedUser;
            }
            catch (Exception) { }

            return null;
        }
    }
}