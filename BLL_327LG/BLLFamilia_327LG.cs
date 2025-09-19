using DAL_327LG;
using Services_327LG.Composite_327LG;
using Services_327LG.Observer_327LG;
using Services_327LG.Singleton_327LG;
using System.Net;

namespace BLL_327LG
{
    public class BLLFamilia_327LG
    {
        private DALFamilia_327LG dalFamilia_327LG;
        BLLPerfil_327LG bllPerfil_327LG;
        LanguageManager_327LG LM_327LG;
        BLLEvento_327LG bllEvento_327LG;
        public BLLFamilia_327LG()
        {
            dalFamilia_327LG = new DALFamilia_327LG();
            bllPerfil_327LG = new BLLPerfil_327LG();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            bllEvento_327LG = new BLLEvento_327LG();
        }

        public List<BEFamilia_327LG> ObtenerFamilias_327LG()
        {
            return dalFamilia_327LG.ObtenerFamilias_327LG();
        }

        public void CrearFamilia_327LG(string nombre)
        {
            if ((dalFamilia_327LG.ObtenerFamilias_327LG().Any(x => x.Nombre_327LG == nombre))) throw new Exception(LM_327LG.ObtenerString("exception.nombre_repetido"));
            dalFamilia_327LG.CrearFamilia_327LG(nombre);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de perfiles", "Creación de familia", 2);

        }

        public void AsignarPermiso_327LG(BEPermiso_327LG permiso, BEFamilia_327LG familia)
        {
            if (FamiliaContienePermiso_327LG(familia, permiso)) throw new Exception(LM_327LG.ObtenerString("exception.permiso_ya_asignado"));
            foreach (BEFamilia_327LG comp in dalFamilia_327LG.ObtenerFamilias_327LG())
            {
                if (FamiliaContieneFamilia_327LG(comp, familia))
                {
                    if (FamiliaContienePermiso_327LG(comp, permiso)) throw new Exception(LM_327LG.ObtenerString("exception.permiso_ya_asignado_en_familia"));
                }
            }
            foreach (BEPerfil_327LG perfil in bllPerfil_327LG.ObtenerPerfiles_327LG())
            {
                if (FamiliaContieneFamilia_327LG(perfil, familia)) throw new Exception(LM_327LG.ObtenerString("exception.familia_asignada_perfil"));
            }
            dalFamilia_327LG.AsignarPermiso_327LG(permiso, familia);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de perfiles", "Modificación de familia", 1);

        }

        public bool FamiliaContienePermiso_327LG(BEFamilia_327LG familia, BEPermiso_327LG permiso)
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

        public void AsignarFamilia_327LG(BEFamilia_327LG familiaBase, BEFamilia_327LG familiaAgregada)
        {
            if (familiaBase == familiaAgregada) throw new Exception(LM_327LG.ObtenerString("exception.familia_base_misma_familia_agregada"));
            if (FamiliaContieneFamilia_327LG(familiaBase, familiaAgregada)) throw new Exception(LM_327LG.ObtenerString("exception.familia_ya_asignada"));
            if (FamiliaContieneFamilia_327LG(familiaAgregada, familiaBase)) throw new Exception(LM_327LG.ObtenerString("exception.familiaagregada_tiene_familiabase"));
            if (HayPermisosRepetidos_327LG(familiaBase, familiaAgregada)) throw new Exception(LM_327LG.ObtenerString("exception.familia_tiene_permiso"));
            List<BEFamilia_327LG> familiasConRepetidos = ComponentesRepetidos_327LG(familiaBase, familiaAgregada);
            foreach (BEPerfil_327LG perfil in bllPerfil_327LG.ObtenerPerfiles_327LG())
            {
                if (FamiliaContieneFamilia_327LG(perfil, familiaBase)) throw new Exception(LM_327LG.ObtenerString("exception.familia_asignada_perfil"));
            }
            if (familiaAgregada.ObtenerHijos_327LG().Count() <= 0)
            {
                throw new Exception(LM_327LG.ObtenerString("exception.familia_vacia"));
            }
            if (familiasConRepetidos.Count > 0) throw new Exception(LM_327LG.ObtenerString("exception.permiso_repetido_entre_familias") + string.Join(",", familiasConRepetidos.Select(f => f.Nombre_327LG)));
            dalFamilia_327LG.AsignarFamilia_327LG(familiaBase, familiaAgregada);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de perfiles", "Modificación de familia", 1);
        }

        private List<BEFamilia_327LG> ComponentesRepetidos_327LG(BEFamilia_327LG familiaBase, BEFamilia_327LG familiaAgregada)
        {
            List<BEPerfil_327LG> componentesBase = ObtenerTodosLosComponentes_327LG(familiaBase);
            List<BEPerfil_327LG> componentesAgregada = ObtenerTodosLosComponentes_327LG(familiaAgregada);

            List<BEFamilia_327LG> familiasConRepetidos = new List<BEFamilia_327LG>();

            foreach (BEPerfil_327LG compAgregado in componentesAgregada)
            {
                if (componentesBase.Any(compBase => compBase.Codigo_327LG == compAgregado.Codigo_327LG))
                {
                    BEFamilia_327LG familiaContenedora = BuscarContenedora_327LG(familiaBase, compAgregado.Codigo_327LG);
                    if (compAgregado is BEFamilia_327LG famRepetida && !familiasConRepetidos.Any(f => f.Codigo_327LG == famRepetida.Codigo_327LG))
                    {
                        familiasConRepetidos.Add(familiaContenedora);
                    }
                }
            }

            foreach (BEFamilia_327LG posibleAncestro in dalFamilia_327LG.ObtenerFamilias_327LG())
            {
                if (FamiliaContieneFamilia_327LG(posibleAncestro, familiaBase))
                {
                    List<BEPerfil_327LG> componentesAncestro = ObtenerTodosLosComponentes_327LG(posibleAncestro);
                    if (componentesAgregada.Any(compAgregada => componentesAncestro.Any(compAncestro => compAncestro.Codigo_327LG == compAgregada.Codigo_327LG)))
                    {
                        familiasConRepetidos.Add(posibleAncestro);
                    }
                }
            }
            return familiasConRepetidos;
        }

        private BEFamilia_327LG BuscarContenedora_327LG(BEFamilia_327LG familia, int codigo)
        {
            foreach (BEFamilia_327LG hijo in familia.ObtenerHijos_327LG())
            {
                if (hijo.Codigo_327LG == codigo) return familia;

                if (hijo is BEFamilia_327LG f)
                {
                    var resultado = BuscarContenedora_327LG(f, codigo);
                    if (resultado != null) return resultado;
                }
            }
            return null;
        }

        private List<BEPerfil_327LG> ObtenerTodosLosComponentes_327LG(BEFamilia_327LG familia)
        {
            List<BEPerfil_327LG> listaComponentes = new List<BEPerfil_327LG>();
            foreach (BEPerfil_327LG comp in familia.ObtenerHijos_327LG())
            {
                listaComponentes.Add(comp);
                if (comp is BEFamilia_327LG f)
                {
                    listaComponentes.AddRange(ObtenerTodosLosComponentes_327LG(f));
                }
            }
            return listaComponentes;
        }

        public bool FamiliaContieneFamilia_327LG(BEPerfil_327LG familiaBase, BEFamilia_327LG familiaAgregada)
        {
            foreach (BEPerfil_327LG comp in familiaBase.ObtenerHijos_327LG())
            {
                if (comp is BEFamilia_327LG f)
                {
                    if (f.Codigo_327LG == familiaAgregada.Codigo_327LG) return true;
                    if (FamiliaContieneFamilia_327LG(f, familiaAgregada)) return true;
                }
            }
            return false;
        }

        public bool HayPermisosRepetidos_327LG(BEFamilia_327LG familiaBase, BEFamilia_327LG familiaAgregada)
        {
            List<BEPermiso_327LG> permisosFamiliaBase = ObtenerPermisosDeFamilia_327LG(familiaBase);
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

        private List<BEPermiso_327LG> ObtenerPermisosDeFamilia_327LG(BEFamilia_327LG familia)
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

        public void EliminarFamilia_327LG(BEFamilia_327LG familia)
        {
            dalFamilia_327LG.EliminarFamilia(familia);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de perfiles", "Eliminación de familia", 1);

        }

        public void EliminarComponente(BEFamilia_327LG familia, BEPerfil_327LG componente)
        {
            dalFamilia_327LG.EliminarComponente(familia, componente);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de perfiles", "Modificación de familia", 1);
        }
    }
}