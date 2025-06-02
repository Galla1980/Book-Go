using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_327LG.Singleton_327LG
{
    public class SessionManager_327LG
    {
        private static SessionManager_327LG instancia;
        private static object Lock = new object();

        private Usuario_327LG user;
        private SessionManager_327LG() { }

        public static SessionManager_327LG Instancia
        {
            get
            {
                lock (Lock)
                {
                    if (instancia == null)
                    {
                        instancia = new SessionManager_327LG();
                    }
                    return instancia;
                }
            }
        }

        public Usuario_327LG Usuario
        {
            get { return user; }
        }

        public void LogIn_327LG(Usuario_327LG usuario)
        {
            user = usuario;
        }

        public void LogOut_327LG()
        {
            user = null;
        }

        public bool IsLoggedIn_327LG()
        {
            return user != null;
        }
    }
}

