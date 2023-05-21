using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PetSelection
{
    [XmlInclude(typeof(Admin))] // Указывает, что тип Admin должен быть включен при сериализации

    public class UserList
    {
        public List<User> userList { get; set; } = new List<User>();
    }
}
