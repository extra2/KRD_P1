using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using KRD_P1.View;

namespace KRD_P1
{
    class XMLProvider
    {
        public string UsersToXML(List<User> users)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;

            XmlSerializer serializer = new XmlSerializer(users.GetType());
            tw = new XmlTextWriter(sw);
            serializer.Serialize(tw, users);
            return sw.ToString();
        }

        public List<User> XMLToUsers(string xml)
        {
            StringReader strReader = null;
            XmlTextReader xmlReader = null;
            Object obj = null;
            try
            {
                strReader = new StringReader(xml);
                var serializer = new XmlSerializer(typeof(List<User>));
                xmlReader = new XmlTextReader(strReader);
                obj = serializer.Deserialize(xmlReader);
            }
            catch (Exception) { }
            finally
            {
                xmlReader?.Close();
                strReader?.Close();
            }
            return (List<User>)obj;
        }
        public void AddLoginToXML(UsersLogin usersLogin)
        {
            var sw = new StringWriter();
            XmlTextWriter tw = null;
            var loginList = GetLoginsFromXML();
            var serializer = new XmlSerializer(loginList.GetType());
            tw = new XmlTextWriter(sw);
            // add ID to new user
            var maxID = loginList.Count > 0 ? loginList.Max(i => i.ID) + 1 : 1;
            usersLogin.ID = maxID;
            loginList.Add(usersLogin);

            serializer.Serialize(tw, loginList);
            File.Delete("login.xml");
            File.WriteAllText("login.xml", sw.ToString());
        }

        public UsersLogin Login(string login, string password)
        {
            var obj = GetLoginsFromXML();
            var role = obj.FirstOrDefault(u => u.Login == login && u.Password == password);
            return role;

        }

        public List<UsersLogin> GetLoginsFromXML()
        {
            var xml = File.ReadAllText("login.xml");
            StringReader strReader = null;
            XmlTextReader xmlReader = null;
            List<UsersLogin> obj = null;
            try
            {
                strReader = new StringReader(xml);
                var serializer = new XmlSerializer(typeof(List<UsersLogin>));
                xmlReader = new XmlTextReader(strReader);
                obj = (List<UsersLogin>)serializer.Deserialize(xmlReader);
            }
            catch (Exception) { }
            finally
            {
                xmlReader?.Close();
                strReader?.Close();
            }
            return obj ?? new List<UsersLogin>();
        }

        public void PackageToXML(List<Package> packages)
        {

            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;

            XmlSerializer serializer = new XmlSerializer(packages.GetType());
            tw = new XmlTextWriter(sw);
            serializer.Serialize(tw, packages);
            File.WriteAllText("packages.xml", sw.ToString());
        }

        public List<Package> XMLToPackages()
        {
            var xml = File.ReadAllText("packages.xml");
            StringReader strReader = null;
            XmlTextReader xmlReader = null;
            Object obj = null;
            try
            {
                strReader = new StringReader(xml);
                var serializer = new XmlSerializer(typeof(List<Package>));
                xmlReader = new XmlTextReader(strReader);
                obj = serializer.Deserialize(xmlReader);
            }
            catch (Exception) { }
            finally
            {
                xmlReader?.Close();
                strReader?.Close();
            }

            obj = obj ?? new List<Package>();
            return (List<Package>)obj;
        }
    }
}