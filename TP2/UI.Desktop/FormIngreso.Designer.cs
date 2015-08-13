namespace UI.Desktop
{
    partial class FormIngreso
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblClave, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtClave, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblIdUsuario, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtIdUsuario, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblBienvenida, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnIngresar, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(267, 123);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblClave
            // 
            this.lblClave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(41, 72);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(34, 13);
            this.lblClave.TabIndex = 1;
            this.lblClave.Text = "Clave";
            // 
            // txtClave
            // 
            this.txtClave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtClave.Location = new System.Drawing.Point(81, 69);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(147, 20);
            this.txtClave.TabIndex = 3;
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(3, 46);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(72, 13);
            this.lblIdUsuario.TabIndex = 0;
            this.lblIdUsuario.Text = "ID de Usuario";
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIdUsuario.Location = new System.Drawing.Point(81, 43);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(147, 20);
            this.txtIdUsuario.TabIndex = 2;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBienvenida.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblBienvenida, 3);
            this.lblBienvenida.Location = new System.Drawing.Point(21, 13);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(224, 13);
            this.lblBienvenida.TabIndex = 4;
            this.lblBienvenida.Text = " Bienvenido al Sistema de Gestión Académica";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(81, 95);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // FormIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 123);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso";
            this.Load += new System.EventHandler(this.FormIngreso_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnIngresar;

    }
}