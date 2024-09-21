using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Person
    {
        private static int _AutoId = 1;
        public int personId { get; set; }

        public string name { get; set; }

        public DateTime dateOfBirth { get; set; }

        public string address { get; set; }

        public float height { get; set; }

        public float weight { get; set; }

        public Person()
        {
            
        }

        public Person(string Name, string Address, DateTime DOB ,  float Height, float Weight)
        {
            personId = _AutoId++;
            name = Name;
            address = Address;
            dateOfBirth = DOB;
            height = Height;
            weight = Weight;
        }

        public virtual string ToString()
        {
            return $"| PersonInfo | PersonId <{personId}> | Name <{name}> Address <{address}> DOB <{dateOfBirth}> Height <{height}>(cm) Weight <{weight}>(kg) |"; ;
        }
    }
}
