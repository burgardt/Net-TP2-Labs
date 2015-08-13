namespace UI.Desktop
{
    partial class PersonaDesktop
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
            this.tlpPersonas = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.cbxDia = new System.Windows.Forms.ComboBox();
            this.cbxMes = new System.Windows.Forms.ComboBox();
            this.cbxAnio = new System.Windows.Forms.ComboBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.cbxPlan = new System.Windows.Forms.ComboBox();
            this.txtInfo = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlpPersonas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPersonas
            // 
            this.tlpPersonas.ColumnCount = 4;
            this.tlpPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.51515F));
            this.tlpPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.27273F));
            this.tlpPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.42424F));
            this.tlpPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.39394F));
            this.tlpPersonas.Controls.Add(this.lblID, 0, 0);
            this.tlpPersonas.Controls.Add(this.lblNombre, 0, 1);
            this.tlpPersonas.Controls.Add(this.lblDireccion, 0, 3);
            this.tlpPersonas.Controls.Add(this.lblFechaNac, 0, 6);
            this.tlpPersonas.Controls.Add(this.cbxDia, 1, 6);
            this.tlpPersonas.Controls.Add(this.cbxMes, 2, 6);
            this.tlpPersonas.Controls.Add(this.cbxAnio, 3, 6);
            this.tlpPersonas.Controls.Add(this.txtID, 1, 0);
            this.tlpPersonas.Controls.Add(this.txtNombre, 1, 1);
            this.tlpPersonas.Controls.Add(this.txtDireccion, 1, 3);
            this.tlpPersonas.Controls.Add(this.lblApellido, 0, 2);
            this.tlpPersonas.Controls.Add(this.txtApellido, 1, 2);
            this.tlpPersonas.Controls.Add(this.lblEmail, 0, 4);
            this.tlpPersonas.Controls.Add(this.lblTelefono, 0, 5);
            this.tlpPersonas.Controls.Add(this.txtEmail, 1, 4);
            this.tlpPersonas.Controls.Add(this.txtTelefono, 1, 5);
            this.tlpPersonas.Controls.Add(this.txtLegajo, 1, 7);
            this.tlpPersonas.Controls.Add(this.lblLegajo, 0, 7);
            this.tlpPersonas.Controls.Add(this.lblTipo, 0, 8);
            this.tlpPersonas.Controls.Add(this.lblPlan, 0, 9);
            this.tlpPersonas.Controls.Add(this.cbxTipo, 1, 8);
            this.tlpPersonas.Controls.Add(this.cbxPlan, 1, 9);
            this.tlpPersonas.Controls.Add(this.txtInfo, 2, 0);
            this.tlpPersonas.Controls.Add(this.btnAceptar, 2, 10);
            this.tlpPersonas.Controls.Add(this.btnCancelar, 3, 10);
            this.tlpPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPersonas.Location = new System.Drawing.Point(0, 0);
            this.tlpPersonas.Name = "tlpPersonas";
            this.tlpPersonas.RowCount = 11;
            this.tlpPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPersonas.Size = new System.Drawing.Size(340, 300);
            this.tlpPersonas.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblID.Location = new System.Drawing.Point(85, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 26);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblNombre.Location = new System.Drawing.Point(59, 26);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 26);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDireccion.Location = new System.Drawing.Point(51, 78);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 26);
            this.lblDireccion.TabIndex = 2;
            this.lblDireccion.Text = "Direccion";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(12, 163);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(91, 13);
            this.lblFechaNac.TabIndex = 3;
            this.lblFechaNac.Text = "Fecha nacimiento";
            this.lblFechaNac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxDia
            // 
            this.cbxDia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxDia.DropDownWidth = 52;
            this.cbxDia.FormattingEnabled = true;
            this.cbxDia.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cbxDia.Location = new System.Drawing.Point(109, 159);
            this.cbxDia.Name = "cbxDia";
            this.cbxDia.Size = new System.Drawing.Size(52, 21);
            this.cbxDia.TabIndex = 5;
            // 
            // cbxMes
            // 
            this.cbxMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxMes.FormattingEnabled = true;
            this.cbxMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Setiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cbxMes.Location = new System.Drawing.Point(167, 159);
            this.cbxMes.Name = "cbxMes";
            this.cbxMes.Size = new System.Drawing.Size(103, 21);
            this.cbxMes.TabIndex = 6;
            // 
            // cbxAnio
            // 
            this.cbxAnio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxAnio.FormattingEnabled = true;
            this.cbxAnio.Items.AddRange(new object[] {
            "1970",
            "1971",
            "1972",
            "1973",
            "1974",
            "1975",
            "1976",
            "1977",
            "1978",
            "1979",
            "1980",
            "1981",
            "1982",
            "1983",
            "1984",
            "1985",
            "1986",
            "1987",
            "1988",
            "1989",
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005"});
            this.cbxAnio.Location = new System.Drawing.Point(276, 159);
            this.cbxAnio.Name = "cbxAnio";
            this.cbxAnio.Size = new System.Drawing.Size(61, 21);
            this.cbxAnio.TabIndex = 7;
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Location = new System.Drawing.Point(109, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(52, 20);
            this.txtID.TabIndex = 8;
            // 
            // txtNombre
            // 
            this.tlpPersonas.SetColumnSpan(this.txtNombre, 2);
            this.txtNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombre.Location = new System.Drawing.Point(109, 29);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(161, 20);
            this.txtNombre.TabIndex = 9;
            // 
            // txtDireccion
            // 
            this.tlpPersonas.SetColumnSpan(this.txtDireccion, 3);
            this.txtDireccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDireccion.Location = new System.Drawing.Point(109, 81);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(228, 20);
            this.txtDireccion.TabIndex = 10;
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(59, 58);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 11;
            this.lblApellido.Text = "Apellido";
            this.lblApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtApellido
            // 
            this.tlpPersonas.SetColumnSpan(this.txtApellido, 2);
            this.txtApellido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtApellido.Location = new System.Drawing.Point(109, 55);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(161, 20);
            this.txtApellido.TabIndex = 12;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblEmail.Location = new System.Drawing.Point(71, 104);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 26);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(54, 136);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 14;
            this.lblTelefono.Text = "Telefono";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.tlpPersonas.SetColumnSpan(this.txtEmail, 3);
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Location = new System.Drawing.Point(109, 107);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(228, 20);
            this.txtEmail.TabIndex = 15;
            // 
            // txtTelefono
            // 
            this.tlpPersonas.SetColumnSpan(this.txtTelefono, 2);
            this.txtTelefono.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTelefono.Location = new System.Drawing.Point(109, 133);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(161, 20);
            this.txtTelefono.TabIndex = 16;
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(109, 186);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(50, 20);
            this.txtLegajo.TabIndex = 17;
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblLegajo.Location = new System.Drawing.Point(64, 183);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(39, 26);
            this.lblLegajo.TabIndex = 18;
            this.lblLegajo.Text = "Legajo";
            this.lblLegajo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTipo.Location = new System.Drawing.Point(75, 209);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 27);
            this.lblTipo.TabIndex = 19;
            this.lblTipo.Text = "Tipo";
            this.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPlan
            // 
            this.lblPlan.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(75, 243);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(28, 13);
            this.lblPlan.TabIndex = 20;
            this.lblPlan.Text = "Plan";
            this.lblPlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxTipo
            // 
            this.tlpPersonas.SetColumnSpan(this.cbxTipo, 2);
            this.cbxTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "Profesor",
            "Alumno",
            "Administrativo"});
            this.cbxTipo.Location = new System.Drawing.Point(109, 212);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(161, 21);
            this.cbxTipo.TabIndex = 23;
            // 
            // cbxPlan
            // 
            this.tlpPersonas.SetColumnSpan(this.cbxPlan, 2);
            this.cbxPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxPlan.FormattingEnabled = true;
            this.cbxPlan.Location = new System.Drawing.Point(109, 239);
            this.cbxPlan.Name = "cbxPlan";
            this.cbxPlan.Size = new System.Drawing.Size(161, 21);
            this.cbxPlan.TabIndex = 24;
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtInfo.AutoSize = true;
            this.txtInfo.Location = new System.Drawing.Point(167, 6);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(95, 13);
            this.txtInfo.TabIndex = 25;
            this.txtInfo.Text = "Campo no editable";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAceptar.Location = new System.Drawing.Point(195, 270);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 26;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.Location = new System.Drawing.Point(276, 270);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(61, 23);
            this.btnCancelar.TabIndex = 27;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // PersonaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 300);
            this.Controls.Add(this.tlpPersonas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "PersonaDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Persona";
            this.Controls.SetChildIndex(this.tlpPersonas, 0);
            this.tlpPersonas.ResumeLayout(false);
            this.tlpPersonas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPersonas;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.ComboBox cbxDia;
        private System.Windows.Forms.ComboBox cbxMes;
        private System.Windows.Forms.ComboBox cbxAnio;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.ComboBox cbxPlan;
        private System.Windows.Forms.Label txtInfo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}