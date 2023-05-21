using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSelection
{
    public class User
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string YearOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }


        public User()
        {
            
        }
        public User(string surname, string name, string middleName, string yearOfBirth, string email, string phoneNumber, string password)
        {
            Id = 1;

            Surname = surname;
            Name = name;
            MiddleName = middleName;
            YearOfBirth = yearOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;         
        }
    }
}