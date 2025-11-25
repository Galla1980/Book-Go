using Microsoft.Data.SqlClient;
using Services_327LG;
using Services_327LG.Composite_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALUsuario_327LG : DALAbstracta_327LG
    {
     

        public Usuario_327LG ConsultaIndividual_327LG(string dni)
        {
            Usuario_327LG user = null;
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                SqlCommand cmd_327LG = new SqlCommand("SELECT * FROM Usuario_327LG WHERE DNI_327LG = @dni", con_327LG);
                cmd_327LG.Parameters.AddWithValue("@dni", dni);
                con_327LG.Open();
                using (SqlDataReader dr_327LG = cmd_327LG.ExecuteReader())
                {
                    if (dr_327LG.Read())
                    {
                        user = new Usuario_327LG(dr_327LG["dni_327LG"].ToString(), dr_327LG["apellido_327LG"].ToString(), dr_327LG["nombre_327LG"].ToString(),
                            dr_327LG["userName_327LG"].ToString(), dr_327LG["password_327LG"].ToString(),new BEPerfil_327LG(Convert.ToInt32(dr_327LG["rol_327LG"])), dr_327LG["email_327LG"].ToString(),
                            Convert.ToBoolean(dr_327LG["bloqueado_327LG"]), Convert.ToBoolean(dr_327LG["activo_327LG"]), Convert.ToInt32(dr_327LG["intento_327LG"]), dr_327LG["IdiomaPref_327LG"].ToString());
                    }
                }
            }
            return user;
        }
        public List<Usuario_327LG> ObtenerUsuarios_327LG()
        {
            List<Usuario_327LG> listaUsuarios_327LG = new List<Usuario_327LG>();
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                SqlCommand cmd_327LG = new SqlCommand("SELECT * FROM Usuario_327LG",con_327LG);
                con_327LG.Open();
                using (SqlDataReader dr_327LG = cmd_327LG.ExecuteReader()) 
                {
                    while (dr_327LG.Read())
                    {
                        Usuario_327LG user = new Usuario_327LG(dr_327LG["dni_327LG"].ToString(), dr_327LG["apellido_327LG"].ToString(), dr_327LG["nombre_327LG"].ToString(),
                            dr_327LG["userName_327LG"].ToString(), dr_327LG["password_327LG"].ToString(), new BEPerfil_327LG(Convert.ToInt32(dr_327LG["rol_327LG"])), dr_327LG["email_327LG"].ToString(),
                            Convert.ToBoolean(dr_327LG["bloqueado_327LG"]), Convert.ToBoolean(dr_327LG["activo_327LG"]), Convert.ToInt32(dr_327LG["intento_327LG"]), dr_327LG["IdiomaPref_327LG"].ToString());
                        listaUsuarios_327LG.Add(user);
                    }
                }
            }
            return listaUsuarios_327LG;
        }
        public void ActualizarBloqueo_327LG(Usuario_327LG user)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                SqlCommand cmd_327LG = new SqlCommand("UPDATE Usuario_327LG SET Bloqueado_327LG = @Bloqueado, Intento_327LG = @Intento where DNI_327LG = @dni", con_327LG);
                cmd_327LG.Parameters.AddWithValue("@Bloqueado", user.bloqueado_327LG);
                cmd_327LG.Parameters.AddWithValue("@Intento", user.intento_327LG);
                cmd_327LG.Parameters.AddWithValue("@dni", user.dni_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
            
        }

        public void ActualizarIntentos_327LG(Usuario_327LG user)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                SqlCommand cmd_327LG = new SqlCommand("UPDATE Usuario_327LG SET Intento_327LG = @Intento where DNI_327LG = @dni", con_327LG);
                cmd_327LG.Parameters.AddWithValue("@Intento", user.intento_327LG);
                cmd_327LG.Parameters.AddWithValue("@dni", user.dni_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void ActualizarContraseña_327LG(Usuario_327LG user)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                SqlCommand cmd_327LG = new SqlCommand("UPDATE Usuario_327LG SET Password_327LG = @Password where DNI_327LG = @dni", con_327LG);
                cmd_327LG.Parameters.AddWithValue("@Password", user.password_327LG);
                cmd_327LG.Parameters.AddWithValue("@dni", user.dni_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void ActualizarUsuario_327LG(Usuario_327LG user)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                SqlCommand cmd_327LG = new SqlCommand("UPDATE Usuario_327LG SET Apellido_327LG = @Apellido, Nombre_327LG = @Nombre, Username_327LG = @Username, " +
                    "Rol_327LG = @Rol, Email_327LG = @Email, Password_327LG = @Password   where DNI_327LG = @dni", con_327LG);
                cmd_327LG.Parameters.AddWithValue("@dni", user.dni_327LG);
                cmd_327LG.Parameters.AddWithValue("@Apellido", user.apellido_327LG);
                cmd_327LG.Parameters.AddWithValue("@Nombre", user.nombre_327LG);
                cmd_327LG.Parameters.AddWithValue("@Username", user.userName_327LG);
                cmd_327LG.Parameters.AddWithValue("@Rol", user.rol_327LG.Codigo_327LG);
                cmd_327LG.Parameters.AddWithValue("@Email", user.email_327LG);
                cmd_327LG.Parameters.AddWithValue("@Password", user.password_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void AgregarUsuario_327LG(Usuario_327LG usuario_327LG)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                SqlCommand cmd_327LG = new SqlCommand("INSERT INTO Usuario_327LG (DNI_327LG, Apellido_327LG, Nombre_327LG, Username_327LG, Password_327LG, Rol_327LG," +
                    " Email_327LG, Bloqueado_327LG, Activo_327LG, Intento_327LG, IdiomaPref_327LG) VALUES (@dni, @apellido, @nombre, @username, @password, @rol, @email, @bloqueado," +
                    " @activo, @intento, @idioma)", con_327LG);
                cmd_327LG.Parameters.AddWithValue("@dni", usuario_327LG.dni_327LG);
                cmd_327LG.Parameters.AddWithValue("@apellido", usuario_327LG.apellido_327LG);
                cmd_327LG.Parameters.AddWithValue("@nombre", usuario_327LG.nombre_327LG);
                cmd_327LG.Parameters.AddWithValue("@username", usuario_327LG.userName_327LG);
                cmd_327LG.Parameters.AddWithValue("@password", usuario_327LG.password_327LG);
                cmd_327LG.Parameters.AddWithValue("@rol", usuario_327LG.rol_327LG.Codigo_327LG);
                cmd_327LG.Parameters.AddWithValue("@email", usuario_327LG.email_327LG);
                cmd_327LG.Parameters.AddWithValue("@bloqueado", usuario_327LG.bloqueado_327LG);
                cmd_327LG.Parameters.AddWithValue("@activo", usuario_327LG.activo_327LG);
                cmd_327LG.Parameters.AddWithValue("@intento", usuario_327LG.intento_327LG);
                cmd_327LG.Parameters.AddWithValue("@idioma", usuario_327LG.IdiomaPref_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void ActualizarActivo_327LG(Usuario_327LG user)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                SqlCommand cmd_327LG = new SqlCommand("UPDATE Usuario_327LG SET Activo_327LG = @Activo where DNI_327LG = @dni", con_327LG);
                cmd_327LG.Parameters.AddWithValue("@Activo", user.activo_327LG);
                cmd_327LG.Parameters.AddWithValue("@dni", user.dni_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void CambiarIdioma_327LG(Usuario_327LG user)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                SqlCommand cmd_327LG = new SqlCommand("UPDATE Usuario_327LG SET IdiomaPref_327LG = @Idioma where DNI_327LG = @dni", con_327LG);
                cmd_327LG.Parameters.AddWithValue("@Idioma", user.IdiomaPref_327LG);
                cmd_327LG.Parameters.AddWithValue("@dni", user.dni_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }
    }
}
