/*
Names: Tofig Gasimov, Christian Le
Date: 9/26/2021
Purpose: Creating User Class
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    //Creating User Class
    public class User
    {
        //Creating User Class instance variables 
        private int userID;
        private string firstName;
        private string lastName;
        private string phone;
        private string street;
        private string city;
        private string state;
        private string zip;
        private string email;
        private String orgId;
        private string description;
        static int tot = 0;
        static User[] userArray = new User[tot];

        //Creating Default constructor
        public User()
        {
            tot++;
        }

        //Creating Overloaded constructor
        public User(int id, string fname, string lname, string email, string phone, string street, string city, string state, string zip, string description, String orgID)
        {
            this.firstName = fname;
            this.userID = id;
            this.lastName = lname;
            this.phone = phone;
            this.email = email;
            this.street = street;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.orgId = orgID;
            this.description = description;
            tot++;

        }

        //Creating public properties to access the private instance variables such as get/set accessor methods
        public int UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }
        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public String Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public String Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        public String Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
            }
        }
        public String City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
        public String State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        public String Zip
        {
            get
            {
                return zip;
            }
            set
            {
                zip = value;
            }
        }
        public String Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public String OrgID
        {
            get
            {
                return orgId;
            }
            set
            {
                orgId = value;
            }
        }

    }
}