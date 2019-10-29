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
    public class LoginService : ILoginInterface
    {
        TeamMgtSystemEntities _db = new TeamMgtSystemEntities();
        public bool ValidateCredentials(LoginVMModel pr)
        {
            var rec = (from a in _db.Logins
                       where a.Username == pr.Username
                       && a.Password == pr.Password
                       select a).Count() > 0 ? true : false;
            if (rec)
                return true;
            else
                return false;
        }
    }
}
