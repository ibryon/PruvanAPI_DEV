using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruvanAPI_13.Models
{
    public class PicturesResponse
    {
        public PicturesResponse() { }
        public PicturesResponse(bool Status, string ErrMsg)
        {
            this.status = Status;
            this.error = ErrMsg;
        }
        public bool status { get; set; }
        public string error { get; set; }
    }
}