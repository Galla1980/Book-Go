using Services_327LG;
using Services_327LG.Singleton_327LG;
using DAL_327LG;
using System.Diagnostics.CodeAnalysis;
using System.Runtime;
using Services_327LG.Observer_327LG;

namespace BLL_327LG
{
    public class BLLUsuario_327LG
    {
        DALUsuario_327LG dalUsuario_327LG;
        LanguageManager_327LG LM_327LG;
        BLLPerfil_327LG bllPerfil_327LG;
        BLLEvento_327LG bllEvento_327LG;
        public BLLUsuario_327LG()
        {
            dalUsuario_327LG = new DALUsuario_327LG();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            bllPerfil_327LG = new BLLPerfil_327LG();
            bllEvento_327LG = new BLLEvento_327LG();
        }

        public LoginResult_327LG IniciarSesion_327LG(string usuario, string contraseña)
        {
            
            var user = ObtenerUsuarios_327LG().Where(x => x.userName_327LG.Equals(usuario)).FirstOrDefault();
            ValidarUsuario_327LG(user);
            string contrasena = Encriptador_327LG.Encriptar_327LG(contraseña);
            return ValidarContraseña_327LG(contraseña, user);
        }

        public LoginResult_327LG ValidarContraseña_327LG(string contraseña, Usuario_327LG? user)
        {
            if (!Encriptador_327LG.Encriptar_327LG(contraseña).Equals(user.password_327LG))
            {
                user.intento_327LG++;
                ActualizarIntentos_327LG(user);
                if (user.intento_327LG == 3)
                {
                    ActualizarBloqueo_327LG(user.dni_327LG, true);
                    throw new LoginException_327LG(LoginResult_327LG.UserBlocked);
                }
                throw new LoginException_327LG(LoginResult_327LG.InvalidPassword);
            }
            else
            {
                SessionManager_327LG.Instancia.LogIn_327LG(user);
                user.intento_327LG = 0;
                ActualizarIntentos_327LG(user);
                bllEvento_327LG.RegistrarEvento_327LG(user.dni_327LG, "Gestión de usuarios", "Inicio de sesión exitoso", 1);
                return LoginResult_327LG.ValidUser;
            }
        }

        public static void ValidarUsuario_327LG(Usuario_327LG? user)
        {
            if (user == null)
                throw new LoginException_327LG(LoginResult_327LG.InvalidUsername);
            if (user.bloqueado_327LG)
                throw new LoginException_327LG(LoginResult_327LG.UserBlocked);
            if (!user.activo_327LG)
                throw new LoginException_327LG(LoginResult_327LG.UserDisabled);
        }

        public List<Usuario_327LG> ObtenerUsuarios_327LG()
        {
            List<Usuario_327LG> listaUsuarios = dalUsuario_327LG.ObtenerUsuarios_327LG();
            foreach (var item in listaUsuarios)
            {
                foreach (var item2 in bllPerfil_327LG.ObtenerPerfiles_327LG())
                {
                    if(item2.Codigo_327LG == item.rol_327LG.Codigo_327LG)
                    {
                        item.rol_327LG = item2;
                    }
                }
                
            }
            return listaUsuarios;
        }

        public void ModificarUsuario_327LG(Usuario_327LG user)
        {
            dalUsuario_327LG.ActualizarUsuario_327LG(user);
        }

        public void CambiarIdioma_327LG(Usuario_327LG user)
        {
            dalUsuario_327LG.CambiarIdioma_327LG(user);
        }

        private void ActualizarIntentos_327LG(Usuario_327LG user)
        {
            dalUsuario_327LG.ActualizarIntentos_327LG(user);
        }

        public Usuario_327LG ConsultaIndividual_327LG(string dni)
        {
            Usuario_327LG usuario = dalUsuario_327LG.ConsultaIndividual_327LG(dni);
            
                foreach (var item2 in bllPerfil_327LG.ObtenerPerfiles_327LG())
                {
                    if (item2.Codigo_327LG == usuario.rol_327LG.Codigo_327LG)
                    {
                        usuario.rol_327LG = item2;
                    }
                }
            return usuario;
        }

        public void ActualizarBloqueo_327LG(string dni, bool bloqueo)
        {
            Usuario_327LG user = dalUsuario_327LG.ObtenerUsuarios_327LG().Find(x => x.dni_327LG == dni);
            if (user == null) throw new Exception("No se encontró el usuario");
            if (bloqueo == true)
            {
                user.bloqueado_327LG = true;
                dalUsuario_327LG.ActualizarBloqueo_327LG(user);
            }
            else
            {
                user.bloqueado_327LG = false;
                user.intento_327LG = 0;
                string contraseña = user.dni_327LG+user.apellido_327LG;
                user.password_327LG = Encriptador_327LG.Encriptar_327LG(contraseña);
                dalUsuario_327LG.ActualizarContraseña_327LG(user);
                dalUsuario_327LG.ActualizarBloqueo_327LG(user);
            }
           
        }
        public void ActualizarActivo_327LG(Usuario_327LG user)
        {
            
            if (user == null) throw new Exception("No se encontró el usuario");
            user.activo_327LG = !user.activo_327LG;
            dalUsuario_327LG.ActualizarActivo_327LG(user);
        }
        public void AgregarUsuario_327LG(Usuario_327LG usuario_327LG)
        {
            dalUsuario_327LG.AgregarUsuario_327LG(usuario_327LG);
        }

        public void CerrarSesion_327LG()
        {
            CambiarIdioma_327LG(SessionManager_327LG.Instancia.Usuario);
            SessionManager_327LG.Instancia.LogOut_327LG();
        }

        public void CambiarContraseña_327LG(Usuario_327LG user, string nuevaContraseña)
        {
            user.password_327LG = Encriptador_327LG.Encriptar_327LG(nuevaContraseña);
            dalUsuario_327LG.ActualizarContraseña_327LG(user);
        }
    }
}
