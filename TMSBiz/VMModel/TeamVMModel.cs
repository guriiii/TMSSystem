using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSBiz.VMModel
{
    public class TeamVMModel
    {
        public int ID { get; set; }
        public string TeamName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Nullable<int> CoachID { get; set; }
        public string CoachName { get; set; }
    }
}
