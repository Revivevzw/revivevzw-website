using System;
using System.Collections.Generic;

namespace Revivevzw.DataAccess
{
    public partial class Splashinfo
    {
        public int Id { get; set; }
        public string TitelNl { get; set; }
        public string TitelFr { get; set; }
        public string TitelUk { get; set; }
        public string ShowOnWeb { get; set; }
        public DateTime? EndDate { get; set; }
        public string InfoUrl { get; set; }
        public string Opmerking { get; set; }
        public string Deleted { get; set; }
        public DateTime? Dcreated { get; set; }
        public DateTime? Dchanged { get; set; }
        public string Whochanged { get; set; }
    }
}
