/*
Names: Tofig Gasimov, Christian Le
Date: 9/26/2021
Purpose: Creating Organization Class for future references
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    //Creating Org class
    public class Organization
    {
        //Creating instance variables for Org class
        private int organizationId;
        private string organizationName;
        private string street;
        private string city;
        private string state;
        private string zip;
        private string organizationEmail;
        private string organizationPhone;
        static int orgtot = 0;
        static Organization[] orgArray = new Organization[orgtot];

        //Creating default constructor
        public Organization()
        {
            orgtot++;
        }
        //Creating overloaded constructor
        public Organization(int orgId, string orgName, string street, string city, string state, string zip, string email, string phone)
        {
            this.organizationId = orgId;
            this.organizationName = orgName;
            this.street = street;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.organizationEmail = email;
            this.organizationPhone = phone;
            orgtot++;
        }

        //Creating public properties to access the private instance variables such as get/set accessor methods
        public int OrganzationId
        {
            get
            {
                return organizationId;
            }
            set
            {
                organizationId = value;
            }

        }
        public string OrganizationName
        {
            get
            {
                return organizationName;
            }
            set
            {
                organizationName = value;
            }

        }
        public string OrganizationStreet
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
        public string OrganizationCity
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
        public string OrganizationState
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
        public string OrganizationZip
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
        public string OrganizationPhone
        {
            get
            {
                return organizationPhone;
            }
            set
            {
                organizationPhone = value;
            }

        }
        public string OrganizationEmail
        {
            get
            {
                return organizationEmail;
            }
            set
            {
                organizationEmail = value;
            }

        }
    }
}