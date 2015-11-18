namespace UI.Desktop
{
    partial class ComisionDesktop
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
            this.tlpComisionDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.lblId = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblAnioEspecialidad = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cbxAnioEspecialidad = new System.Windows.Forms.ComboBox();
            this.cbxPlan = new System.Windows.Forms.ComboBox();
            this.tlpComisionDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpComisionDesktop
            // 
            this.tlpComisionDesktop.ColumnCount = 3;
            this.tlpComisionDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.11111F));
            this.tlpComisionDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.88889F));
            this.tlpComisionDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpComisionDesktop.Controls.Add(this.lblId, 0, 0);
            this.tlpComisionDesktop.Controls.Add(this.lblDescripcion, 0, 1);
            this.tlpComisionDesktop.Controls.Add(this.lblAnioEspecialidad, 0, 2);
            this.tlpComisionDesktop.Controls.Add(this.lblPlan, 0, 3);
            this.tlpComisionDesktop.Controls.Add(this.btnAceptar, 1, 4);
            this.tlpComisionDesktop.Controls.Add(this.btnCancelar, 2, 4);
            this.tlpComisionDesktop.Controls.Add(this.txtID, 1, 0);
            this.tlpComisionDesktop.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlpComisionDesktop.Controls.Add(this.cbxAnioEspecialidad, 1, 2);
            this.tlpComisionDesktop.Controls.Add(this.cbxPlan, 1, 3);
            this.tlpComisionDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpComisionDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlpComisionDesktop.Name = "tlpComisionDesktop";
            this.tlpComisionDesktop.RowCount = 5;
            this.tlpComisionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComisionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComisionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComisionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComisionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpComisionDesktop.Size = new System.Drawing.Size(366, 134);
            this.tlpComisionDesktop.TabIndex = 0;
            // 
            // lblId
            // 
            this.lblId.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(85, 6);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(40, 32);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblAnioEspecialidad
            // 
            this.lblAnioEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAnioEspecialidad.AutoSize = true;
            this.lblAnioEspecialidad.Location = new System.Drawing.Point(14, 59);
            this.lblAnioEspecialidad.Name = "lblAnioEspecialidad";
            this.lblAnioEspecialidad.Size = new System.Drawing.Size(89, 13);
            this.lblAnioEspecialidad.TabIndex = 2;
            this.lblAnioEspecialidad.Text = "Año Especialidad";
            // 
            // lblPlan
            // 
            this.lblPlan.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(75, 86);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(28, 13);
            this.lblPlan.TabIndex = 3;
            this.lblPlan.Text = "Plan";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(128, 109);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(258, 109);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Control;
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Location = new System.Drawing.Point(109, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(113, 20);
            this.txtID.TabIndex = 6;
            // 
            // txtDescripcion
            // 
            this.tlpComisionDesktop.SetColumnSpan(this.txtDescripcion, 2);
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcion.Location = new System.Drawing.Point(109, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(254, 20);
            this.txtDescripcion.TabIndex = 7;
            // 
            // cbxAnioEspecialidad
            // 
            this.cbxAnioEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxAnioEspecialidad.FormattingEnabled = true;
            this.cbxAnioEspecialidad.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbxAnioEspecialidad.Location = new System.Drawing.Point(109, 55);
            this.cbxAnioEspecialidad.Name = "cbxAnioEspecialidad";
            this.cbxAnioEspecialidad.Size = new System.Drawing.Size(113, 21);
            this.cbxAnioEspecialidad.TabIndex = 8;
            // 
            // cbxPlan
            // 
            this.cbxPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxPlan.FormattingEnabled = true;
            this.cbxPlan.Location = new System.Drawing.Point(109, 82);
            this.cbxPlan.Name = "cbxPlan";
            this.cbxPlan.Size = new System.Drawing.Size(113, 21);
            this.cbxPlan.TabIndex = 9;
            // 
            // ComisionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(366, 134);
            this.Controls.Add(this.tlpComisionDesktop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ComisionDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ComisionDesktop";
            this.Load += new System.EventHandler(this.ComisionDesktop_Load);
            this.Controls.SetChildIndex(this.tlpComisionDesktop, 0);
            this.tlpComisionDesktop.ResumeLayout(false);
            this.tlpComisionDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpComisionDesktop;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblAnioEspecialidad;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cbxAnioEspecialidad;
        private System.Windows.Forms.ComboBox cbxPlan;
    }
}