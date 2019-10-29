using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSBiz.Service;
using TMSBiz.VMModel;


namespace TMSBiz.Interface
{
    public interface ICoachInterface
    {
        List<CoachVMModel> GetCoachList();
        bool AddEditCoachMaster(CoachVMModel pr);
        bool DelCoach(int ID);
        List<CoachVMModel> CoachListGetByID(int ID);
    }
}
