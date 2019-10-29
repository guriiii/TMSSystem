using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSBiz.Interface;
using TMSBiz.Service;
using TMSBiz.VMModel;
using TMSData;

namespace TMSBiz.Service
{
    public class CoachService : ICoachInterface
    {
        TeamMgtSystemEntities _db = new TeamMgtSystemEntities();
        public bool DelCoach(int ID)
        {
            bool isUpdate = false;
            try
            {

                var _coach = (from a in _db.Coaches where a.ID == ID select a).FirstOrDefault();
                if (_coach != null)
                {
                    _db.Coaches.Attach(_coach);
                    _db.Coaches.Remove(_coach);
                    _db.SaveChanges();
                    isUpdate = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isUpdate;
        }

        public List<CoachVMModel> GetCoachList()
        {
            try
            {
                var rec = (from a in _db.Coaches
                           select new CoachVMModel
                           {
                               ID = a.ID,
                               CoachName = a.CoachName
                           }).ToList();
                return rec;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<CoachVMModel> CoachListGetByID(int ID)
        {
            try
            {
                var rec = (from a in _db.Coaches
                           where a.ID == ID
                           select new CoachVMModel
                           {
                               ID = a.ID,
                               CoachName = a.CoachName
                           }).ToList();
                return rec;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool AddEditCoachMaster(CoachVMModel pr)
        {
            bool isUpdate = false;
            try
            {
                if (pr.ID == 0)
                {
                    Coach _coach = new Coach();
                    _coach.CoachName = pr.CoachName;
                    _db.Coaches.Add(_coach);
                    _db.SaveChanges();
                    isUpdate = true;
                }
                else
                {
                    var _coach = _db.Coaches.Where(x => x.ID == pr.ID).FirstOrDefault();
                    if (_coach != null)
                    {
                        _coach.CoachName = pr.CoachName;
                        _db.SaveChanges();
                        isUpdate = true;
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return isUpdate;
        }
    }
}
