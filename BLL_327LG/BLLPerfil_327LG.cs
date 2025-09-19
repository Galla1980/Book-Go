using DAL_327LG;
using Services_327LG.Composite_327LG;
using Services_327LG.Observer_327LG;
using Services_327LG.Singleton_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLPerfil_327LG
    {
        private DALPerfil_327LG dalPerfil_327LG;
        LanguageManager_327LG LM_327LG;
        BLLEvento_327LG bllEvento_327LG;
        public BLLPerfil_327LG()
        {
            dalPerfil_327LG = new DALPerfil_327LG();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            bllEvento_327LG = new BLLEvento_327LG();
        }

        public void AsignarPermiso_327LG(BEPerfil_327LG perfil, BEPermiso_327LG permiso)
        {
            if (PerfilContienePermiso_327LG(perfil, permiso)) throw new Exception(LM_327LG.ObtenerString("exception.permiso_ya_asignado"));
            foreach (BEPerfil_327LG comp in dalPerfil_327LG.ObtenerPerfiles_327LG())
            {
                if (FamiliaContieneFamilia_327LG(comp, perfil))
                {
                    if (FamiliaContienePermiso_327LG(comp, permiso)) throw new Exception(LM_327LG.ObtenerString("exception.permiso_ya_asignado_en_familia"));
                }
            }
            dalPerfil_327LG.AsignarPermiso_327LG(perfil, permiso);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de perfiles", "Modificación de perfil", 1);
        }

        private bool FamiliaContieneFamilia_327LG(BEPerfil_327LG familiabase, BEPerfil_327LG perfil)
        {
            foreach (BEPerfil_327LG comp in familiabase.ObtenerHijos_327LG())
            {
                if (comp is BEFamilia_327LG f)
                {
                    if (f.Codigo_327LG == perfil.Codigo_327LG) return true;
                    if (FamiliaContieneFamilia_327LG(f, perfil)) return true;
                }
            }
            return false;
        }

        public bool FamiliaContienePermiso_327LG(BEPerfil_327LG familia, BEPermiso_327LG permiso)
        {

            foreach (BEPerfil_327LG comp in familia.ObtenerHijos_327LG())
            {
                if (comp is BEPermiso_327LG p)
                {
                    if (p.Codigo_327LG == permiso.Codigo_327LG)
                    {
                        return true;
                    }
                }
                else if (comp is BEFamilia_327LG f)
                {
                    if (FamiliaContienePermiso_327LG(f, permiso))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool PerfilContienePermiso_327LG(BEPerfil_327LG perfil, BEPermiso_327LG permiso)
        {
            foreach (BEPerfil_327LG comp in perfil.ObtenerHijos_327LG())
            {
                if (comp is BEPermiso_327LG p)
                {
                    if (p.Codigo_327LG == permiso.Codigo_327LG)
                    {
                        return true;
                    }
                }
                else if (comp is BEFamilia_327LG f)
                {
                    if (FamiliaContienePermiso_327LG(f, permiso))
                    {
                        return true;
                    }
                }
            }
            return false; ;
        }

        public void CrearPerfil_327LG(string nombre)
        {
            dalPerfil_327LG.CrearPerfil_327LG(nombre);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de perfiles", "Creación de perfil", 2);
        }

        public List<BEPerfil_327LG> ObtenerPerfiles_327LG()
        {
            return dalPerfil_327LG.ObtenerPerfiles_327LG();
        }

        public void AsignarFamilia_327LG(BEPerfil_327LG perfil, BEFamilia_327LG familia)
        {
            if (FamiliaContieneFamilia_327LG(perfil, familia)) throw new Exception(LM_327LG.ObtenerString("exception.familia_ya_asignada"));
            if (HayPermisosRepetidos_327LG(perfil, familia)) throw new Exception(LM_327LG.ObtenerString("exception.familia_tiene_permiso"));
            if (familia.ObtenerHijos_327LG().Count() <= 0)
            {
                throw new Exception(LM_327LG.ObtenerString("exception.familia_vacia"));
            }
            dalPerfil_327LG.AsignarFamilia_327LG(perfil, familia);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de perfiles", "Modificación de perfil", 1);
        }
        public bool HayPermisosRepetidos_327LG(BEPerfil_327LG perfil, BEFamilia_327LG familiaAgregada)
        {
            List<BEPermiso_327LG> permisosFamiliaBase = ObtenerPermisosDeFamilia_327LG(perfil);
            List<BEPermiso_327LG> permisosFamiliaAgregada = ObtenerPermisosDeFamilia_327LG(familiaAgregada);
            foreach (BEPermiso_327LG permiso in permisosFamiliaAgregada)
            {
                if (permisosFamiliaBase.Any(p => p.Codigo_327LG == permiso.Codigo_327LG))
                {
                    return true;
                }
            }
            return false;
        }

        private List<BEPermiso_327LG> ObtenerPermisosDeFamilia_327LG(BEPerfil_327LG familia)
        {
            List<BEPermiso_327LG> listaPermisos = new List<BEPermiso_327LG>();
            foreach (BEPerfil_327LG comp in familia.ObtenerHijos_327LG())
            {
                if (comp is BEPermiso_327LG p)
                {
                    listaPermisos.Add(p);
                }
                else if (comp is BEFamilia_327LG f)
                {
                    listaPermisos.AddRange(ObtenerPermisosDeFamilia_327LG(f));
                }
            }
            return listaPermisos;
        }

        public void EliminarPerfil_327LG(BEPerfil_327LG perfil)
        {
            dalPerfil_327LG.EliminarPerfil_327LG(perfil);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de perfiles", "Eliminación de perfil", 1);
        }

        public void EliminarComponente_327LG(BEPerfil_327LG perfil, BEPerfil_327LG componente)
        {
            dalPerfil_327LG.EliminarComponente_327LG(perfil, componente);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de perfiles", "Modificación de perfil", 1);
        }
    }
}
