/*
Names: Tofig Gasimov, Christian Le
Date: 9/26/2021
Purpose: Creating Analysis Class for future references
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    //Creating Analysis class
    public class Analysis
    {
        //Creating instance variables for Analysis class
        private int analysisID;
        private string date;
        private string aDescription;
        private string aResults;
        static int aTot;
        static Analysis[] aArray = new Analysis[aTot];

        //Creating Default constructor
        public Analysis()
        {
            aTot++;
        }

        //Creating overloaded constructor
        public Analysis(int aId, string date, string description, string results)
        {
            this.analysisID = aId;
            this.date = date;
            this.aDescription = description;
            this.aResults = results;
            aTot++;

        }

        //Creating public properties to access the private instance variables such as get/set accessor methods
        public int AnalysisId
        {
            get
            {
                return analysisID;
            }
            set
            {
                analysisID = value;
            }
        }
        public String AnalysisDescription
        {
            get
            {
                return aDescription;
            }
            set
            {
                aDescription = value;
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
        public String AnalysisResults
        {
            get
            {
                return aResults;
            }
            set
            {
                aResults = value;
            }
        }

    }
}

