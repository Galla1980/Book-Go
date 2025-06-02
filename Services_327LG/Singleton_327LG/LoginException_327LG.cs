using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_327LG.Singleton_327LG
{
    public class LoginException_327LG : Exception
    {
        public LoginResult_327LG Result;
        public LoginException_327LG(LoginResult_327LG result)
        {
            Result = result;
        }
    }
}
