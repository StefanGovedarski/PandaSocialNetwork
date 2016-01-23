using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PandaClassLibrary
{
    public enum GenderType
    {
        Male,
        Female
    }

    public class Panda
    {
        private string name;
        private string email;
        private GenderType gender;
        private int id;

        private Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public Panda(string name, string email, GenderType gender)
        {
            if (VerifyEmail(email))
            {
                this.name = name;
                this.email = email;
                this.gender = gender;
            }
            else
                throw new InvalidPandaEmailException();
            
        }

        public string Name { get { return name; } set { name = value; } }
        public string Email { get { return email; } set { email = value; } }
        public GenderType Gender { get { return gender; } set { gender = value; } }
        

        public bool IsMale()
        {
            return GenderType.Male == gender;
        }

        public bool IsFemale()
        {
            return GenderType.Female == gender;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Name, Email, Gender);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + Email.GetHashCode();
                hash = hash * 23 + Gender.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Panda)
            {
                Panda obj1 = this;
                Panda obj2 = (Panda)obj;

                if (obj1.Name == obj2.Name && obj1.Email == obj2.Email && obj1.Gender == obj2.Gender)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private bool VerifyEmail(string email)
        {
            Match match = regex.Match(email);
            if (!match.Success)
                return false;
            else
                return true;
                
        }
    }
}
