using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CapaPresentacion
{
    partial class FrmContacto
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblGrupo = new Label();
            cboGrupo = new ComboBox();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            lblResumen = new Label();
            dgvResumen = new DataGridView();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblFiltro = new Label();
            cboFiltroGrupo = new ComboBox();
            dgvContactos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvResumen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvContactos).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(20, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(110, 17);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTelefono.Location = new Point(20, 55);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(74, 20);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(110, 52);
            txtTelefono.MaxLength = 10;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(250, 27);
            txtTelefono.TabIndex = 3;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCorreo.Location = new Point(20, 90);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(60, 20);
            lblCorreo.TabIndex = 4;
            lblCorreo.Text = "Correo:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(110, 87);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(250, 27);
            txtCorreo.TabIndex = 5;
            // 
            // lblGrupo
            // 
            lblGrupo.AutoSize = true;
            lblGrupo.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGrupo.Location = new Point(20, 125);
            lblGrupo.Name = "lblGrupo";
            lblGrupo.Size = new Size(57, 20);
            lblGrupo.TabIndex = 6;
            lblGrupo.Text = "Grupo:";
            // 
            // cboGrupo
            // 
            cboGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrupo.Location = new Point(110, 122);
            cboGrupo.Name = "cboGrupo";
            cboGrupo.Size = new Size(250, 28);
            cboGrupo.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(20, 165);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 32);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificar.Location = new Point(130, 165);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(100, 32);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "Modificar";
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(240, 165);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 32);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.Location = new Point(350, 165);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 32);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblResumen
            // 
            lblResumen.AutoSize = true;
            lblResumen.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResumen.Location = new Point(500, 20);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(157, 20);
            lblResumen.TabIndex = 12;
            lblResumen.Text = "Contactos por grupo:";
            // 
            // dgvResumen
            // 
            dgvResumen.AllowUserToAddRows = false;
            dgvResumen.AllowUserToDeleteRows = false;
            dgvResumen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResumen.BackgroundColor = SystemColors.ControlLightLight;
            dgvResumen.ColumnHeadersHeight = 29;
            dgvResumen.Location = new Point(500, 45);
            dgvResumen.Name = "dgvResumen";
            dgvResumen.ReadOnly = true;
            dgvResumen.RowHeadersVisible = false;
            dgvResumen.RowHeadersWidth = 51;
            dgvResumen.Size = new Size(360, 150);
            dgvResumen.TabIndex = 13;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscar.Location = new Point(20, 220);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(119, 20);
            lblBuscar.TabIndex = 14;
            lblBuscar.Text = "Buscar nombre:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(145, 217);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(230, 27);
            txtBuscar.TabIndex = 15;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFiltro.Location = new Point(420, 220);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(129, 20);
            lblFiltro.TabIndex = 16;
            lblFiltro.Text = "Filtrar por grupo:";
            // 
            // cboFiltroGrupo
            // 
            cboFiltroGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltroGrupo.Location = new Point(550, 217);
            cboFiltroGrupo.Name = "cboFiltroGrupo";
            cboFiltroGrupo.Size = new Size(200, 28);
            cboFiltroGrupo.TabIndex = 17;
            cboFiltroGrupo.SelectedIndexChanged += cboFiltroGrupo_SelectedIndexChanged;
            // 
            // dgvContactos
            // 
            dgvContactos.AllowUserToAddRows = false;
            dgvContactos.AllowUserToDeleteRows = false;
            dgvContactos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContactos.BackgroundColor = SystemColors.ButtonHighlight;
            dgvContactos.ColumnHeadersHeight = 29;
            dgvContactos.Location = new Point(20, 260);
            dgvContactos.Name = "dgvContactos";
            dgvContactos.ReadOnly = true;
            dgvContactos.RowHeadersVisible = false;
            dgvContactos.RowHeadersWidth = 51;
            dgvContactos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContactos.Size = new Size(840, 330);
            dgvContactos.TabIndex = 18;
            dgvContactos.CellClick += dgvContactos_CellClick;
            // 
            // FrmContacto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Bisque;
            ClientSize = new Size(884, 611);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblCorreo);
            Controls.Add(txtCorreo);
            Controls.Add(lblGrupo);
            Controls.Add(cboGrupo);
            Controls.Add(btnGuardar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(lblResumen);
            Controls.Add(dgvResumen);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblFiltro);
            Controls.Add(cboFiltroGrupo);
            Controls.Add(dgvContactos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmContacto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agenda de contactos";
            Load += FrmContacto_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResumen).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvContactos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.ComboBox cboGrupo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.DataGridView dgvResumen;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cboFiltroGrupo;
        private System.Windows.Forms.DataGridView dgvContactos;
    }
}