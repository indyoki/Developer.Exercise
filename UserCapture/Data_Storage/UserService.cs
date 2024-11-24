using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Office;
using UserCapture.Models;

namespace UserCapture.Data_Storage
{
    public class UserService
    {
        //List users in file
        public List<UserData> GetUsers()
        {
            var users = new List<UserData>();
            var serializer = new XmlSerializer(typeof(List<UserData>));
            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Data_Storage\\Users.xml")))
            {
                users = serializer.Deserialize(reader) as List<UserData>;
            }
            return users;
        }

        //Edit user or Create new entry 
        public void SaveUser(UserData newUser)
        {
            var users = GetUsers();

            var existingUser = users.FirstOrDefault(x => x.Id == newUser.Id);
            
            if(existingUser == null)
                users.Add(newUser);
            else
            {
                var index = users.IndexOf(existingUser);
                users[index] = newUser;
            }

            SaveXml(users);
        }

        //Delete user
        public void DeleteUser(string userId)
        {
            var users = GetUsers();

            users.Remove(users.FirstOrDefault(x => x.Id == userId));

            SaveXml(users);
        }
        private void SaveXml(List<UserData> users)
        {
            var serializer = new XmlSerializer(typeof(List<UserData>));
            using (var writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "Data_Storage\\Users.xml")))
            {
                serializer.Serialize(writer, users);
            }
        }
    }
}
