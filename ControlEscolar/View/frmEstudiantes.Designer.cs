namespace ControlEscolar.View
{
    partial class frmEstudiantes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstudiantes));
            lblTitulo = new Label();
            scEstudiantes = new SplitContainer();
            grpboxAltaEdicion = new GroupBox();
            cbxEstatus = new ComboBox();
            btnGuardar = new Button();
            pctQuestion = new PictureBox();
            dtpFechaBaja = new DateTimePicker();
            dtpFechaAlta = new DateTimePicker();
            lblDatosObligatorios = new Label();
            lblFechaBaja = new Label();
            lblEstatus = new Label();
            lblFechaAlta = new Label();
            txtNControl = new TextBox();
            lblNoControl = new Label();
            nudSemestre = new NumericUpDown();
            lblSemestre = new Label();
            lblFechaNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            txtCurp = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtNombre = new TextBox();
            lblCurp = new Label();
            lblTelefono = new Label();
            lblCorreo = new Label();
            lblNombre = new Label();
            dgvEstudiantes = new DataGridView();
            cmsEstudiantes = new ContextMenuStrip(components);
            editarEstudianteToolStripMenuItem = new ToolStripMenuItem();
            grpBxFiltros = new GroupBox();
            chkSoloActivos = new CheckBox();
            lblTotalRegistros = new Label();
            btnActualizar = new Button();
            txtBusqueda = new TextBox();
            lblBusquedaTexto = new Label();
            cbxTipoFecha = new ComboBox();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            lblFechaFin = new Label();
            lblFechaInico = new Label();
            lblTipoFecha = new Label();
            grpbxHerramientas = new GroupBox();
            label1 = new Label();
            btnMasiva = new Button();
            btnCaptura = new Button();
            ttInfo = new ToolTip(components);
            ofdArchivo = new OpenFileDialog();
            btnExportar = new Button();
            ((System.ComponentModel.ISupportInitialize)scEstudiantes).BeginInit();
            scEstudiantes.Panel1.SuspendLayout();
            scEstudiantes.Panel2.SuspendLayout();
            scEstudiantes.SuspendLayout();
            grpboxAltaEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctQuestion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSemestre).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).BeginInit();
            cmsEstudiantes.SuspendLayout();
            grpBxFiltros.SuspendLayout();
            grpbxHerramientas.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.BackColor = Color.Sienna;
            lblTitulo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ControlLightLight;
            lblTitulo.Location = new Point(1, -1);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1049, 33);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Control de estudiantes";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // scEstudiantes
            // 
            scEstudiantes.Location = new Point(1, 31);
            scEstudiantes.Name = "scEstudiantes";
            // 
            // scEstudiantes.Panel1
            // 
            scEstudiantes.Panel1.Controls.Add(grpboxAltaEdicion);
            // 
            // scEstudiantes.Panel2
            // 
            scEstudiantes.Panel2.Controls.Add(dgvEstudiantes);
            scEstudiantes.Panel2.Controls.Add(grpBxFiltros);
            scEstudiantes.Panel2.Controls.Add(grpbxHerramientas);
            scEstudiantes.Size = new Size(1049, 685);
            scEstudiantes.SplitterDistance = 377;
            scEstudiantes.TabIndex = 1;
            // 
            // grpboxAltaEdicion
            // 
            grpboxAltaEdicion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpboxAltaEdicion.BackColor = Color.FromArgb(255, 224, 192);
            grpboxAltaEdicion.Controls.Add(cbxEstatus);
            grpboxAltaEdicion.Controls.Add(btnGuardar);
            grpboxAltaEdicion.Controls.Add(pctQuestion);
            grpboxAltaEdicion.Controls.Add(dtpFechaBaja);
            grpboxAltaEdicion.Controls.Add(dtpFechaAlta);
            grpboxAltaEdicion.Controls.Add(lblDatosObligatorios);
            grpboxAltaEdicion.Controls.Add(lblFechaBaja);
            grpboxAltaEdicion.Controls.Add(lblEstatus);
            grpboxAltaEdicion.Controls.Add(lblFechaAlta);
            grpboxAltaEdicion.Controls.Add(txtNControl);
            grpboxAltaEdicion.Controls.Add(lblNoControl);
            grpboxAltaEdicion.Controls.Add(nudSemestre);
            grpboxAltaEdicion.Controls.Add(lblSemestre);
            grpboxAltaEdicion.Controls.Add(lblFechaNacimiento);
            grpboxAltaEdicion.Controls.Add(dtpFechaNacimiento);
            grpboxAltaEdicion.Controls.Add(txtCurp);
            grpboxAltaEdicion.Controls.Add(txtTelefono);
            grpboxAltaEdicion.Controls.Add(txtCorreo);
            grpboxAltaEdicion.Controls.Add(txtNombre);
            grpboxAltaEdicion.Controls.Add(lblCurp);
            grpboxAltaEdicion.Controls.Add(lblTelefono);
            grpboxAltaEdicion.Controls.Add(lblCorreo);
            grpboxAltaEdicion.Controls.Add(lblNombre);
            grpboxAltaEdicion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpboxAltaEdicion.Location = new Point(3, 4);
            grpboxAltaEdicion.Name = "grpboxAltaEdicion";
            grpboxAltaEdicion.Size = new Size(350, 678);
            grpboxAltaEdicion.TabIndex = 0;
            grpboxAltaEdicion.TabStop = false;
            grpboxAltaEdicion.Text = "Alta o Edicion";
            // 
            // cbxEstatus
            // 
            cbxEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEstatus.FormattingEnabled = true;
            cbxEstatus.Location = new Point(20, 497);
            cbxEstatus.Name = "cbxEstatus";
            cbxEstatus.Size = new Size(240, 28);
            cbxEstatus.TabIndex = 23;
            cbxEstatus.SelectedIndexChanged += cbxEstatus_SelectedIndexChanged_1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(197, 609);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // pctQuestion
            // 
            pctQuestion.ErrorImage = null;
            pctQuestion.Image = Properties.Resources._1579793_help_question_questions_support_icon1;
            pctQuestion.Location = new Point(266, 373);
            pctQuestion.Name = "pctQuestion";
            pctQuestion.Size = new Size(25, 31);
            pctQuestion.SizeMode = PictureBoxSizeMode.Zoom;
            pctQuestion.TabIndex = 21;
            pctQuestion.TabStop = false;
            ttInfo.SetToolTip(pctQuestion, "T/M-Año de ingreso-Número de alumno");
            // 
            // dtpFechaBaja
            // 
            dtpFechaBaja.Format = DateTimePickerFormat.Short;
            dtpFechaBaja.Location = new Point(21, 550);
            dtpFechaBaja.Name = "dtpFechaBaja";
            dtpFechaBaja.Size = new Size(135, 27);
            dtpFechaBaja.TabIndex = 20;
            // 
            // dtpFechaAlta
            // 
            dtpFechaAlta.Format = DateTimePickerFormat.Short;
            dtpFechaAlta.Location = new Point(19, 430);
            dtpFechaAlta.Name = "dtpFechaAlta";
            dtpFechaAlta.Size = new Size(135, 27);
            dtpFechaAlta.TabIndex = 19;
            // 
            // lblDatosObligatorios
            // 
            lblDatosObligatorios.AutoSize = true;
            lblDatosObligatorios.Location = new Point(21, 609);
            lblDatosObligatorios.Name = "lblDatosObligatorios";
            lblDatosObligatorios.Size = new Size(149, 20);
            lblDatosObligatorios.TabIndex = 17;
            lblDatosObligatorios.Text = "* Datos obligatorios";
            // 
            // lblFechaBaja
            // 
            lblFechaBaja.AutoSize = true;
            lblFechaBaja.Location = new Point(19, 527);
            lblFechaBaja.Name = "lblFechaBaja";
            lblFechaBaja.Size = new Size(82, 20);
            lblFechaBaja.TabIndex = 16;
            lblFechaBaja.Text = "Fecha baja";
            // 
            // lblEstatus
            // 
            lblEstatus.AutoSize = true;
            lblEstatus.Location = new Point(19, 474);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(71, 20);
            lblEstatus.TabIndex = 15;
            lblEstatus.Text = "Estatus *";
            // 
            // lblFechaAlta
            // 
            lblFechaAlta.AutoSize = true;
            lblFechaAlta.Location = new Point(19, 407);
            lblFechaAlta.Name = "lblFechaAlta";
            lblFechaAlta.Size = new Size(93, 20);
            lblFechaAlta.TabIndex = 14;
            lblFechaAlta.Text = "Fecha Alta *";
            // 
            // txtNControl
            // 
            txtNControl.Location = new Point(19, 377);
            txtNControl.MaxLength = 20;
            txtNControl.Name = "txtNControl";
            txtNControl.Size = new Size(241, 27);
            txtNControl.TabIndex = 13;
            // 
            // lblNoControl
            // 
            lblNoControl.AutoSize = true;
            lblNoControl.Location = new Point(19, 345);
            lblNoControl.Name = "lblNoControl";
            lblNoControl.Size = new Size(122, 20);
            lblNoControl.TabIndex = 12;
            lblNoControl.Text = "No. de Control *";
            // 
            // nudSemestre
            // 
            nudSemestre.Location = new Point(168, 301);
            nudSemestre.Maximum = new decimal(new int[] { 13, 0, 0, 0 });
            nudSemestre.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSemestre.Name = "nudSemestre";
            nudSemestre.Size = new Size(150, 27);
            nudSemestre.TabIndex = 11;
            nudSemestre.Value = new decimal(new int[] { 13, 0, 0, 0 });
            // 
            // lblSemestre
            // 
            lblSemestre.AutoSize = true;
            lblSemestre.Location = new Point(168, 271);
            lblSemestre.Name = "lblSemestre";
            lblSemestre.Size = new Size(85, 20);
            lblSemestre.TabIndex = 10;
            lblSemestre.Text = "Semestre *";
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(13, 269);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(142, 20);
            lblFechaNacimiento.TabIndex = 9;
            lblFechaNacimiento.Text = "Fecha nacimiento *";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(19, 301);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(135, 27);
            dtpFechaNacimiento.TabIndex = 8;
            // 
            // txtCurp
            // 
            txtCurp.Location = new Point(13, 230);
            txtCurp.MaxLength = 18;
            txtCurp.Name = "txtCurp";
            txtCurp.Size = new Size(231, 27);
            txtCurp.TabIndex = 7;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(13, 169);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(231, 27);
            txtTelefono.TabIndex = 6;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(12, 115);
            txtCorreo.MaxLength = 100;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(232, 27);
            txtCorreo.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(13, 58);
            txtNombre.MaxLength = 255;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(231, 27);
            txtNombre.TabIndex = 4;
            // 
            // lblCurp
            // 
            lblCurp.AutoSize = true;
            lblCurp.Location = new Point(12, 202);
            lblCurp.Name = "lblCurp";
            lblCurp.Size = new Size(59, 20);
            lblCurp.TabIndex = 3;
            lblCurp.Text = "CURP *";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(12, 143);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(81, 20);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Telefono *";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(12, 90);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(67, 20);
            lblCorreo.TabIndex = 1;
            lblCorreo.Text = "Correo *";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 33);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(150, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre Completo *";
            // 
            // dgvEstudiantes
            // 
            dgvEstudiantes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEstudiantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstudiantes.ContextMenuStrip = cmsEstudiantes;
            dgvEstudiantes.Location = new Point(8, 211);
            dgvEstudiantes.Name = "dgvEstudiantes";
            dgvEstudiantes.RowHeadersWidth = 51;
            dgvEstudiantes.Size = new Size(651, 422);
            dgvEstudiantes.TabIndex = 2;
            // 
            // cmsEstudiantes
            // 
            cmsEstudiantes.ImageScalingSize = new Size(20, 20);
            cmsEstudiantes.Items.AddRange(new ToolStripItem[] { editarEstudianteToolStripMenuItem });
            cmsEstudiantes.Name = "cmsEstudiantes";
            cmsEstudiantes.Size = new Size(191, 28);
            // 
            // editarEstudianteToolStripMenuItem
            // 
            editarEstudianteToolStripMenuItem.Name = "editarEstudianteToolStripMenuItem";
            editarEstudianteToolStripMenuItem.Size = new Size(190, 24);
            editarEstudianteToolStripMenuItem.Text = "Editar estudiante";
            editarEstudianteToolStripMenuItem.Click += editarEstudianteToolStripMenuItem_Click;
            // 
            // grpBxFiltros
            // 
            grpBxFiltros.BackColor = Color.FromArgb(255, 224, 192);
            grpBxFiltros.Controls.Add(chkSoloActivos);
            grpBxFiltros.Controls.Add(lblTotalRegistros);
            grpBxFiltros.Controls.Add(btnActualizar);
            grpBxFiltros.Controls.Add(txtBusqueda);
            grpBxFiltros.Controls.Add(lblBusquedaTexto);
            grpBxFiltros.Controls.Add(cbxTipoFecha);
            grpBxFiltros.Controls.Add(dtpFechaInicio);
            grpBxFiltros.Controls.Add(dtpFechaFin);
            grpBxFiltros.Controls.Add(lblFechaFin);
            grpBxFiltros.Controls.Add(lblFechaInico);
            grpBxFiltros.Controls.Add(lblTipoFecha);
            grpBxFiltros.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpBxFiltros.Location = new Point(8, 80);
            grpBxFiltros.Name = "grpBxFiltros";
            grpBxFiltros.Size = new Size(657, 125);
            grpBxFiltros.TabIndex = 1;
            grpBxFiltros.TabStop = false;
            grpBxFiltros.Text = "Filtros";
            // 
            // chkSoloActivos
            // 
            chkSoloActivos.AutoSize = true;
            chkSoloActivos.Location = new Point(424, 89);
            chkSoloActivos.Name = "chkSoloActivos";
            chkSoloActivos.Size = new Size(117, 24);
            chkSoloActivos.TabIndex = 29;
            chkSoloActivos.Text = "Solo Activos";
            chkSoloActivos.UseVisualStyleBackColor = true;
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.AutoSize = true;
            lblTotalRegistros.Location = new Point(6, 86);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(18, 20);
            lblTotalRegistros.TabIndex = 28;
            lblTotalRegistros.Text = "0";
            // 
            // btnActualizar
            // 
            btnActualizar.ForeColor = Color.Black;
            btnActualizar.Image = (Image)resources.GetObject("btnActualizar.Image");
            btnActualizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnActualizar.Location = new Point(547, 87);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 29);
            btnActualizar.TabIndex = 27;
            btnActualizar.Text = "Actualizar";
            btnActualizar.TextAlign = ContentAlignment.MiddleRight;
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(183, 88);
            txtBusqueda.MaxLength = 15;
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(235, 27);
            txtBusqueda.TabIndex = 24;
            // 
            // lblBusquedaTexto
            // 
            lblBusquedaTexto.AutoSize = true;
            lblBusquedaTexto.Location = new Point(30, 89);
            lblBusquedaTexto.Name = "lblBusquedaTexto";
            lblBusquedaTexto.Size = new Size(147, 20);
            lblBusquedaTexto.TabIndex = 26;
            lblBusquedaTexto.Text = "Busqueda por texto";
            // 
            // cbxTipoFecha
            // 
            cbxTipoFecha.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTipoFecha.FormattingEnabled = true;
            cbxTipoFecha.Location = new Point(89, 41);
            cbxTipoFecha.Name = "cbxTipoFecha";
            cbxTipoFecha.Size = new Size(103, 28);
            cbxTipoFecha.TabIndex = 24;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(295, 39);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(135, 27);
            dtpFechaInicio.TabIndex = 25;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(516, 39);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(135, 27);
            dtpFechaFin.TabIndex = 24;
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(436, 44);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(74, 20);
            lblFechaFin.TabIndex = 2;
            lblFechaFin.Text = "Fecha Fin";
            // 
            // lblFechaInico
            // 
            lblFechaInico.AutoSize = true;
            lblFechaInico.Location = new Point(198, 44);
            lblFechaInico.Name = "lblFechaInico";
            lblFechaInico.Size = new Size(91, 20);
            lblFechaInico.TabIndex = 1;
            lblFechaInico.Text = "Fecha Inicio";
            // 
            // lblTipoFecha
            // 
            lblTipoFecha.AutoSize = true;
            lblTipoFecha.Location = new Point(6, 39);
            lblTipoFecha.Name = "lblTipoFecha";
            lblTipoFecha.Size = new Size(84, 20);
            lblTipoFecha.TabIndex = 0;
            lblTipoFecha.Text = "Tipo Fecha";
            // 
            // grpbxHerramientas
            // 
            grpbxHerramientas.BackColor = Color.FromArgb(255, 224, 192);
            grpbxHerramientas.Controls.Add(btnExportar);
            grpbxHerramientas.Controls.Add(label1);
            grpbxHerramientas.Controls.Add(btnMasiva);
            grpbxHerramientas.Controls.Add(btnCaptura);
            grpbxHerramientas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpbxHerramientas.Location = new Point(8, 4);
            grpbxHerramientas.Name = "grpbxHerramientas";
            grpbxHerramientas.Size = new Size(657, 70);
            grpbxHerramientas.TabIndex = 0;
            grpbxHerramientas.TabStop = false;
            grpbxHerramientas.Text = "Herramientas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(296, 39);
            label1.Name = "label1";
            label1.Size = new Size(165, 17);
            label1.TabIndex = 2;
            label1.Text = "Ruta de archivo a importar";
            // 
            // btnMasiva
            // 
            btnMasiva.Location = new Point(172, 36);
            btnMasiva.Name = "btnMasiva";
            btnMasiva.Size = new Size(110, 29);
            btnMasiva.TabIndex = 1;
            btnMasiva.Text = "Carga Masiva";
            btnMasiva.UseVisualStyleBackColor = true;
            btnMasiva.Click += btnMasiva_Click;
            // 
            // btnCaptura
            // 
            btnCaptura.Location = new Point(23, 36);
            btnCaptura.Name = "btnCaptura";
            btnCaptura.Size = new Size(143, 29);
            btnCaptura.TabIndex = 0;
            btnCaptura.Text = "Mostrar Captura";
            btnCaptura.UseVisualStyleBackColor = true;
            btnCaptura.Click += btnCaptura_Click;
            // 
            // ofdArchivo
            // 
            ofdArchivo.FileName = "Carga masiva de estudiantes";
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(495, 33);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(129, 29);
            btnExportar.TabIndex = 3;
            btnExportar.Text = "Exportar Excel";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // frmEstudiantes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 715);
            Controls.Add(scEstudiantes);
            Controls.Add(lblTitulo);
            Name = "frmEstudiantes";
            Text = "frmEstudiantes";
            Load += frmEstudiantes_Load;
            scEstudiantes.Panel1.ResumeLayout(false);
            scEstudiantes.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scEstudiantes).EndInit();
            scEstudiantes.ResumeLayout(false);
            grpboxAltaEdicion.ResumeLayout(false);
            grpboxAltaEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctQuestion).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSemestre).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).EndInit();
            cmsEstudiantes.ResumeLayout(false);
            grpBxFiltros.ResumeLayout(false);
            grpBxFiltros.PerformLayout();
            grpbxHerramientas.ResumeLayout(false);
            grpbxHerramientas.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private SplitContainer scEstudiantes;
        private GroupBox grpboxAltaEdicion;
        private Label lblNombre;
        private Label lblCurp;
        private Label lblTelefono;
        private Label lblCorreo;
        private TextBox txtCurp;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtNombre;
        private Label lblFechaNacimiento;
        private DateTimePicker dtpFechaNacimiento;
        private NumericUpDown nudSemestre;
        private Label lblSemestre;
        private TextBox txtNControl;
        private Label lblNoControl;
        private PictureBox pctQuestion;
        private DateTimePicker dtpFechaBaja;
        private DateTimePicker dtpFechaAlta;
        private Label lblDatosObligatorios;
        private Label lblFechaBaja;
        private Label lblEstatus;
        private Label lblFechaAlta;
        private ToolTip ttInfo;
        private ComboBox cbxEstatus;
        private Button btnGuardar;
        private GroupBox grpbxHerramientas;
        private Label label1;
        private Button btnMasiva;
        private Button btnCaptura;
        private GroupBox grpBxFiltros;
        private Label lblTipoFecha;
        private Label lblFechaFin;
        private Label lblFechaInico;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private ComboBox cbxTipoFecha;
        private Button btnActualizar;
        private TextBox txtBusqueda;
        private Label lblBusquedaTexto;
        private OpenFileDialog ofdArchivo;
        private DataGridView dgvEstudiantes;
        private Label lblTotalRegistros;
        private ContextMenuStrip cmsEstudiantes;
        private ToolStripMenuItem editarEstudianteToolStripMenuItem;
        private CheckBox chkSoloActivos;
        private Button btnExportar;
    }
}