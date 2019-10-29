using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSBiz.VMModel
{
    public class PlayerVMModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Gender { get; set; }
        public Nullable<int> TeamID { get; set; }
        public string TeamName { get; set; }
        public string CoachName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Nullable<int> CoachID { get; set; }
    }
}
