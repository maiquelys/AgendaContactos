using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmContacto : Form
    {
        private ContactoNegocio contactoNegocio = new ContactoNegocio();
        private GrupoNegocio grupoNegocio = new GrupoNegocio();
        private int idSeleccionado = 0;
        private bool cargando = false;

        public FrmContacto()
        {
            InitializeComponent();
        }

        private void FrmContacto_Load(object sender, EventArgs e)
        {
            try
            {
                CargarGrupos();
                CargarContactos();
                CargarResumen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrupos()
        {
            cargando = true;

            DataTable grupos = grupoNegocio.Listar();
            cboGrupo.DisplayMember = "Nombre";
            cboGrupo.ValueMember = "IdGrupo";
            cboGrupo.DataSource = grupos;

            DataTable filtro = grupos.Copy();
            DataRow todos = filtro.NewRow();
            todos["IdGrupo"] = 0;
            todos["Nombre"] = "Todos";
            filtro.Rows.InsertAt(todos, 0);
            cboFiltroGrupo.DisplayMember = "Nombre";
            cboFiltroGrupo.ValueMember = "IdGrupo";
            cboFiltroGrupo.DataSource = filtro;

            cargando = false;
        }

        private void CargarContactos()
        {
            DataTable tabla;
            string texto = txtBuscar.Text.Trim();
            int idGrupo = ObtenerFiltro();

            if (texto.Length > 0)
            {
                tabla = contactoNegocio.Buscar(texto);
            }
            else if (idGrupo > 0)
            {
                tabla = contactoNegocio.FiltrarPorGrupo(idGrupo);
            }
            else
            {
                tabla = contactoNegocio.Listar();
            }

            dgvContactos.DataSource = tabla;
            if (dgvContactos.Columns.Count > 0)
            {
                dgvContactos.Columns["IdContacto"].Visible = false;
                dgvContactos.Columns["IdGrupo"].Visible = false;
            }
        }

        private void CargarResumen()
        {
            dgvResumen.DataSource = grupoNegocio.ContarContactosPorGrupo();
        }

        private int ObtenerFiltro()
        {
            if (cboFiltroGrupo.SelectedValue == null)
            {
                return 0;
            }
            return Convert.ToInt32(cboFiltroGrupo.SelectedValue);
        }

        private Contacto ConstruirContacto()
        {
            int idGrupo = 0;
            if (cboGrupo.SelectedValue != null)
            {
                idGrupo = Convert.ToInt32(cboGrupo.SelectedValue);
            }

            Contacto contacto = new Contacto();
            contacto.IdContacto = idSeleccionado;
            contacto.Nombre = txtNombre.Text;
            contacto.Telefono = txtTelefono.Text;
            contacto.Correo = txtCorreo.Text;
            contacto.IdGrupo = idGrupo;
            return contacto;
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            idSeleccionado = 0;
            if (cboGrupo.Items.Count > 0)
            {
                cboGrupo.SelectedIndex = 0;
            }
            dgvContactos.ClearSelection();
            txtNombre.Focus();
        }

        private void Refrescar()
        {
            CargarContactos();
            CargarResumen();
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Contacto contacto = ConstruirContacto();
                contacto.IdContacto = 0;
                contactoNegocio.Guardar(contacto);
                MessageBox.Show("Contacto guardado correctamente.", "Agenda",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                contactoNegocio.Modificar(ConstruirContacto());
                MessageBox.Show("Contacto modificado correctamente.", "Agenda",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado <= 0)
                {
                    MessageBox.Show("Seleccione un contacto de la lista para eliminarlo.", "Agenda",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show("¿Seguro que desea eliminar este contacto?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    contactoNegocio.Eliminar(idSeleccionado);
                    MessageBox.Show("Contacto eliminado correctamente.", "Agenda",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refrescar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboFiltroGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando)
            {
                return;
            }

            try
            {
                CargarContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvContactos.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["IdContacto"].Value);
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
            txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
            cboGrupo.SelectedValue = Convert.ToInt32(fila.Cells["IdGrupo"].Value);
        }
    }
}