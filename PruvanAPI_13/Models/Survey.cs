using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruvanAPI_13.Models
{
    public class Survey
    {
        public Survey() { }
        public string SurveyName { get; set; }
        public string InspFirstName { get; set; }
        public string InspLastName { get; set; }
        public DateTime InspDate { get; set; }
    }
}