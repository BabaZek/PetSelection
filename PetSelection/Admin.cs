using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSelection
{
    public class Admin : User
    {
        public Admin()
        {
            
        }
        public Admin(string surname, string name, string middleName, string yearOfBirth, string email, string phoneNumber, string password) : base(surname, name, middleName, yearOfBirth, email, phoneNumber, password)
        {
            Id = 2;
        }
    }
}
