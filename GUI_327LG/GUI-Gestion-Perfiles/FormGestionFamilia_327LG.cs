using BLL_327LG;
using Services_327LG.Composite_327LG;
using Services_327LG.Observer_327LG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_327LG.GUI_Gestion_Perfiles
{
    public partial class FormGestionFamilia_327LG : Form, IObserverIdioma_327LG
    {
        LanguageManager_327LG LM_327LG;
        BLLPermiso_327LG bllPermiso_327LG;
        BLLFamilia_327LG bllFamilia_327LG;

        private TreeNode nodoSeleccionadoBase;
        private TreeNode nodoSeleccionadoAgregar;
        public FormGestionFamilia_327LG()
        {
            InitializeComponent();

            bllPermiso_327LG = new BLLPermiso_327LG();
            bllFamilia_327LG = new BLLFamilia_327LG();

            LM_327LG = LanguageManager_327LG.Instance_327LG;
            LM_327LG.AgregarObservador_327LG(this);

        }
        private void FormGestionFamilia_327LG_Load(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormGestionFamilia_327LG");
            CargarGrillas_327LG();
        }

        private void btnAgregarFam_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormGestionFamilia_327LG");
                string nombre = txtNombreFam.Text.Trim();
                if (nombre == string.Empty) throw new Exception(LM_327LG.ObtenerString("exception.nombre_vacio"));
                bllFamilia_327LG.CrearFamilia_327LG(nombre);
                CargarGrillas_327LG();
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
        private void btnAsignarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstPermisos.SelectedItems.Count <= 0) throw new Exception(LM_327LG.ObtenerString("exception.permiso_no_seleccionado"));
                if (nodoSeleccionadoBase == null) throw new Exception(LM_327LG.ObtenerString("exception.familia_no_seleccionada"));
                if (!(nodoSeleccionadoBase.Tag is BEFamilia_327LG)) throw new Exception(LM_327LG.ObtenerString("exception.debe_seleccionar_familia"));
                BEFamilia_327LG familiabase = (BEFamilia_327LG)nodoSeleccionadoBase.Tag;
                BEPermiso_327LG permiso = (BEPermiso_327LG)lstPermisos.SelectedItem;
                bllFamilia_327LG.AsignarPermiso_327LG(permiso, familiabase);
                CargarGrillas_327LG();
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnAsignarFam_Click(object sender, EventArgs e)
        {
            try
            {
                if(nodoSeleccionadoBase == null)throw new Exception(LM_327LG.ObtenerString("exception.familiabase_no_seleccionada"));
                if(nodoSeleccionadoAgregar == null)throw new Exception(LM_327LG.ObtenerString("exception.familiaagregada_no_seleccionada"));
                if (!(nodoSeleccionadoBase.Tag is BEFamilia_327LG) || !(nodoSeleccionadoAgregar.Tag is BEFamilia_327LG)) throw new Exception(LM_327LG.ObtenerString("exception.debe_seleccionar_familia_base"));
                BEFamilia_327LG familiaBase = (BEFamilia_327LG)nodoSeleccionadoBase.Tag;
                BEFamilia_327LG familiaAgregada = (BEFamilia_327LG)nodoSeleccionadoAgregar.Tag;
                bllFamilia_327LG.AsignarFamilia_327LG(familiaBase, familiaAgregada);
                CargarGrillas_327LG();
            }
            catch(Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        public void Actualizar_327LG()
        {
            throw new NotImplementedException();
        }

        private void CargarGrillas_327LG()
        {
            lstPermisos.Items.Clear();
            foreach (BEPermiso_327LG item in bllPermiso_327LG.ObtenerPermisos_327LG())
            {
                lstPermisos.Items.Add(item);
            }

            tvwFamilias.Nodes.Clear();
            tvwFamSel.Nodes.Clear();
            List<BEFamilia_327LG> familias = bllFamilia_327LG.ObtenerFamilias_327LG();
            foreach (BEFamilia_327LG familia in familias)
            {
                TreeNode nodo = NuevoNodo_327LG(familia);
                tvwFamilias.Nodes.Add(nodo);
                nodo.Expand();
                TreeNode nodo2 = NuevoNodo_327LG(familia);
                tvwFamSel.Nodes.Add(nodo2);
                nodo2.Expand();

            }

            nodoSeleccionadoAgregar = null;
            nodoSeleccionadoBase = null;
        }

        private TreeNode NuevoNodo_327LG(BEPerfil_327LG pNodo)
        {
            TreeNode nodo = new TreeNode(pNodo.Nombre_327LG);
            nodo.Tag = pNodo;
            if (pNodo is BEFamilia_327LG f)
            {
                List<BEPerfil_327LG> listaComponentes = f.ObtenerHijos_327LG();
                if (listaComponentes != null)
                {
                    foreach (BEPerfil_327LG comp in listaComponentes)
                    {
                        nodo.Nodes.Add(NuevoNodo_327LG(comp));
                    }
                }
            }
            return nodo;
        }

        private void tvwFamilias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (nodoSeleccionadoBase != null)
            {
                nodoSeleccionadoBase.BackColor = Color.White;
                nodoSeleccionadoBase.ForeColor = Color.Black;
            }
            nodoSeleccionadoBase = e.Node;
            nodoSeleccionadoBase.BackColor = SystemColors.Highlight;
            nodoSeleccionadoBase.ForeColor = SystemColors.HighlightText;

        }
        private void tvwFamSel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (nodoSeleccionadoAgregar != null)
            {
                nodoSeleccionadoAgregar.BackColor = Color.White;
                nodoSeleccionadoAgregar.ForeColor = Color.Black;
            }
            nodoSeleccionadoAgregar = e.Node;
            nodoSeleccionadoAgregar.BackColor = SystemColors.Highlight;
            nodoSeleccionadoAgregar.ForeColor = SystemColors.HighlightText;
        }

    }
}
