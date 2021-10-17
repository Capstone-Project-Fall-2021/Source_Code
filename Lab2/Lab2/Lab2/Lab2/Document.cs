/*
Names: Tofig Gasimov, Christian Le
Date: 9/26/2021
Purpose: Creating Story Class
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    //Creating Document (Story) class
    public class Document
    {
        //Creating instance variables for Document class
        private int userID;
        private int textID;
        private string date;
        private string title;
        private string source;
        private string body;
        static int totDoc;
        static Document[] docArray = new Document[totDoc];

        //Creating deafult constructor
        public Document()
        {
            totDoc++;
        }

        //Creating Overloaded Constructor
        public Document(int txtId, String date, string title, string source, string body, int id)
        {
            this.textID = txtId;
            this.date = date;
            this.title = title;
            this.source = source;
            this.body = body;
            this.userID = id;
            totDoc++;

        }

        //Creating public properties to access the private instance variables such as get/set accessor methods
        public int TextId
        {
            get
            {
                return textID;
            }
            set
            {
                textID = value;
            }
        }
        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public String Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        public String Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
            }
        }
        public String Body
        {
            get
            {
                return body;
            }
            set
            {
                body = value;
            }
        }
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
    }
}