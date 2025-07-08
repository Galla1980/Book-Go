using DAL_327LG;
using Services_327LG.Composite_327LG;
using Services_327LG.Observer_327LG;
using System.Net;

namespace BLL_327LG
{
    public class BLLFamilia_327LG
    {
        private DALFamilia_327LG dalFamilia_327LG;
        LanguageManager_327LG LM_327LG;
        public BLLFamilia_327LG()
        {
            dalFamilia_327LG = new DALFamilia_327LG();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
        }

        public List<BEFamilia_327LG> ObtenerFamilias_327LG()
        {
            return dalFamilia_327LG.ObtenerFamilias_327LG();
        }

        public void CrearFamilia_327LG(string nombre)
        {
            if ((dalFamilia_327LG.ObtenerFamilias_327LG().Any(x => x.Nombre_327LG == nombre))) throw new Exception(LM_327LG.ObtenerString("exception.nombre_repetido"));
            dalFamilia_327LG.CrearFamilia_327LG(nombre);
        }

        public void AsignarPermiso_327LG(BEPermiso_327LG permiso, BEFamilia_327LG familia)
        {
            if (FamiliaContienePermiso_327LG(familia, permiso)) throw new Exception(LM_327LG.ObtenerString("exception.permiso_ya_asignado"));
            foreach (BEFamilia_327LG comp in dalFamilia_327LG.ObtenerFamilias_327LG())
            {
                if(FamiliaContieneFamilia_327LG(comp, familia))
                {
                    if(FamiliaContienePermiso_327LG(comp, permiso)) throw new Exception(LM_327LG.ObtenerString("exception.permiso_ya_asignado_en_familia"));
                }
            }
            dalFamilia_327LG.AsignarPermiso_327LG(permiso, familia);
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
            if(familiaBase == familiaAgregada) throw new Exception(LM_327LG.ObtenerString("exception.familia_base_misma_familia_agregada"));
            if (FamiliaContieneFamilia_327LG(familiaBase, familiaAgregada)) throw new Exception(LM_327LG.ObtenerString("exception.familia_ya_asignada"));
            if (FamiliaContieneFamilia_327LG(familiaAgregada, familiaBase)) throw new Exception(LM_327LG.ObtenerString("exception.familiaagregada_tiene_familiabase"));
            if (HayPermisosRepetidos_327LG(familiaBase,familiaAgregada)) throw new Exception(LM_327LG.ObtenerString("exception.familia_tiene_permiso"));
            List<BEFamilia_327LG> familiasConRepetidos = PermisoRepetidoEntreFamilias(familiaBase, familiaAgregada);
            if (familiasConRepetidos.Count> 0) throw new Exception(LM_327LG.ObtenerString("exception.permiso_repetido_entre_familias") + string.Join(",", familiasConRepetidos.Select(f => f.Nombre_327LG)));
            dalFamilia_327LG.AsignarFamilia_327LG(familiaBase, familiaAgregada);
        }

        private List<BEFamilia_327LG> PermisoRepetidoEntreFamilias(BEFamilia_327LG familiaBase, BEFamilia_327LG familiaAgregada)
        {
            List<BEPermiso_327LG> permisosAgregada = ObtenerPermisosDeFamilia_327LG(familiaAgregada);
            List<BEFamilia_327LG> familiasConRepetidos = new List<BEFamilia_327LG>();
            foreach (BEFamilia_327LG posibleAncestro in dalFamilia_327LG.ObtenerFamilias_327LG())
            {
                if (FamiliaContieneFamilia_327LG(posibleAncestro, familiaBase))
                {
                    List<BEPermiso_327LG> permisosAncestro = ObtenerPermisosDeFamilia_327LG(posibleAncestro);
                    if (permisosAgregada.Any(p => permisosAncestro.Any(a => a.Codigo_327LG == p.Codigo_327LG)))
                    {
                        familiasConRepetidos.Add(posibleAncestro);
                    }
                }
            }
            return familiasConRepetidos;
        }

        public bool FamiliaContieneFamilia_327LG(BEFamilia_327LG familiaBase, BEFamilia_327LG familiaAgregada)
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
    }
}
