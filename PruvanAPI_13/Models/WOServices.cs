using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruvanAPI_13.Models
{
    public class WOServices
    {
        public WOServices() { }
        public WOServices(string servicename)
        {
            this.serviceName = servicename;
        }
        public WOServices(string ServiceName, string SurveyID )
        {
            this.serviceName = ServiceName;
            this.survey = SurveyID;
        }
        public string serviceName { get; set; }
        public string survey { get; set; }
        public string instructions { get; set; }
        public string options { get; set; }
        public string source_service { get; set; }
        public string source_service_id { get; set; }
    }
}
