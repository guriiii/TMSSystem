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
    public class TeamService : ITeamInterface
    {
        TeamMgtSystemEntities _db = new TeamMgtSystemEntities();
        public bool DelTeam(int ID)
        {
            bool isUpdate = false;
            try
            {

                var _team = (from a in _db.Teams where a.ID == ID select a).FirstOrDefault();
                if (_team != null)
                {
                    _db.Teams.Attach(_team);
                    _db.Teams.Remove(_team);
                    _db.SaveChanges();
                    isUpdate = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isUpdate;
        }

        public List<TeamVMModel> GetTeamList()
        {
            try
            {
                var rec = (from a in _db.Teams
                           join c in _db.Coaches on a.CoachID equals c.ID
                           select new TeamVMModel
                           {
                               ID = a.ID,
                               TeamName = a.TeamName,
                               City = a.City,
                               State = a.State,
                               CoachName = c.CoachName

                           }).ToList();
                return rec;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<TeamVMModel> TeamListGetByID(int ID)
        {
            try
            {
                var rec = (from a in _db.Teams
                           join c in _db.Coaches on a.CoachID equals c.ID
                           where a.ID == ID
                           select new TeamVMModel
                           {
                               ID = a.ID,
                               TeamName = a.TeamName,
                               City = a.City,
                               State = a.State,
                               CoachName = c.CoachName,
                               CoachID = a.CoachID

                           }).ToList();
                return rec;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool AddEditTeamMaster(TeamVMModel pr)
        {
            bool isUpdate = false;
            try
            {
                if (pr.ID == 0)
                {
                    Team _team = new Team();
                    _team.TeamName = pr.TeamName;
                    _team.City = pr.City;
                    _team.State = pr.State;
                    _team.CoachID = pr.CoachID;
                    _db.Teams.Add(_team);
                    _db.SaveChanges();
                    isUpdate = true;
                }
                else
                {
                    var _team = _db.Teams.Where(x => x.ID == pr.ID).FirstOrDefault();
                    if (_team != null)
                    {
                        _team.TeamName = pr.TeamName;
                        _team.City = pr.City;
                        _team.State = pr.State;
                        _team.CoachID = pr.CoachID;
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

