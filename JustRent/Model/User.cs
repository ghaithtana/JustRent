using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRent.Model
{
    class User
    {
        protected int u_id;
        protected String username;
        protected String password;
        protected int gender;
        protected DateTime birthdate;
        protected String country;

        public User(int u_id,String username,String password,int gender,DateTime birthdate,String country)
        {
            setU_ID(u_id);
            setUsername(username.ToLower());
            setPassword(password);
            setGender(gender);
            setBirthdate(birthdate);
            setCountry(country);
        }
        public User(String username, String password, int gender, DateTime birthdate, String country)
        {
            setUsername(username.ToLower());
            setPassword(password);
            setGender(gender);
            setBirthdate(birthdate);
            setCountry(country);
        }
        public int getU_ID()
        {
            return u_id;
        }

        public void setU_ID(int id)
        {
            this.u_id = id;
        }
        public String getUsername()
        {
            return username;
        }

        public void setUsername(String username)
        {
            this.username = username;
        }
        public String getPassword()
        {
            return password;
        }
        public void setPassword(String password)
        {
            this.password = password;
        }
        public int getGender()
        {
            return gender;
        }
        public void setGender(int gender)
        {
            this.gender = gender;
        }
        public DateTime getbirthdate()
        {
            return birthdate;
        }
        public void setBirthdate(DateTime birthdate)
        {
            this.birthdate = birthdate;
        }
        public String getCountry()
        {
            return country;
        }
        public void setCountry(String Country)
        {
            this.country = Country;
        }
    }
}
