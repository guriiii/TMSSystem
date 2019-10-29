using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSBiz.Service;
using TMSBiz.VMModel;


namespace TMSBiz.Interface
{
    public interface ILoginInterface
    {
        bool ValidateCredentials(LoginVMModel pr);
    }
}
