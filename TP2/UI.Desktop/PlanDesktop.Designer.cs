namespace UI.Desktop
{
    partial class PlanDesktop
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
            this.tlpPlanDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cbxEspecialidad = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlpPlanDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPlanDesktop
            // 
            this.tlpPlanDesktop.ColumnCount = 3;
            this.tlpPlanDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanDesktop.Controls.Add(this.lblID, 0, 0);
            this.tlpPlanDesktop.Controls.Add(this.lblDescripcion, 0, 1);
            this.tlpPlanDesktop.Controls.Add(this.lblEspecialidad, 0, 2);
            this.tlpPlanDesktop.Controls.Add(this.txtID, 1, 0);
            this.tlpPlanDesktop.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlpPlanDesktop.Controls.Add(this.cbxEspecialidad, 1, 2);
            this.tlpPlanDesktop.Controls.Add(this.btnAceptar, 1, 3);
            this.tlpPlanDesktop.Controls.Add(this.btnCancelar, 2, 3);
            this.tlpPlanDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlanDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlpPlanDesktop.Name = "tlpPlanDesktop";
            this.tlpPlanDesktop.RowCount = 4;
            this.tlpPlanDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlanDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlanDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlanDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlanDesktop.Size = new System.Drawing.Size(384, 109);
            this.tlpPlanDesktop.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(52, 6);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(7, 32);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(3, 59);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.lblEspecialidad.TabIndex = 2;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(76, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.tlpPlanDesktop.SetColumnSpan(this.txtDescripcion, 2);
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcion.Location = new System.Drawing.Point(76, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(305, 20);
            this.txtDescripcion.TabIndex = 6;
            // 
            // cbxEspecialidad
            // 
            this.tlpPlanDesktop.SetColumnSpan(this.cbxEspecialidad, 2);
            this.cbxEspecialidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxEspecialidad.FormattingEnabled = true;
            this.cbxEspecialidad.Location = new System.Drawing.Point(76, 55);
            this.cbxEspecialidad.Name = "cbxEspecialidad";
            this.cbxEspecialidad.Size = new System.Drawing.Size(305, 21);
            this.cbxEspecialidad.TabIndex = 7;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(88, 82);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(244, 82);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // PlanDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 109);
            this.Controls.Add(this.tlpPlanDesktop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "PlanDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Plan";
            this.Load += new System.EventHandler(this.PlanDesktop_Load);
            this.Controls.SetChildIndex(this.tlpPlanDesktop, 0);
            this.tlpPlanDesktop.ResumeLayout(false);
            this.tlpPlanDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPlanDesktop;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cbxEspecialidad;
        private System.Windows.Forms.Button btnCancelar;
    }
}