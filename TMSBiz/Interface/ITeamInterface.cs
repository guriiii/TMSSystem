using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSBiz.Service;
using TMSBiz.VMModel;

namespace TMSBiz.Interface
{
    public interface ITeamInterface
    {
        List<TeamVMModel> GetTeamList();
        bool AddEditTeamMaster(TeamVMModel pr);
        bool DelTeam(int ID);
        List<TeamVMModel> TeamListGetByID(int ID);
    }
}
