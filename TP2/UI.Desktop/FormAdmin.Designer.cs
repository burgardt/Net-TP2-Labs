namespace UI.Desktop
{
    partial class FormAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdmin));
            this.tssArchivo = new System.Windows.Forms.ToolStripSplitButton();
            this.aBMPersonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMProfesoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMEspecialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMPlanesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMMateriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMComisionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscripcionDeAlumnosACursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDePlanesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbCerrarSesion = new System.Windows.Forms.ToolStripButton();
            this.tspAdmin = new System.Windows.Forms.ToolStrip();
            this.tspAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tssArchivo
            // 
            this.tssArchivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMPersonasToolStripMenuItem,
            this.aBMUsuariosToolStripMenuItem,
            this.aBMProfesoresToolStripMenuItem,
            this.aBMAlumnosToolStripMenuItem,
            this.aBMEspecialidadesToolStripMenuItem,
            this.aBMPlanesToolStripMenuItem,
            this.aBMMateriasToolStripMenuItem,
            this.aBMComisionesToolStripMenuItem,
            this.aBMCursosToolStripMenuItem,
            this.inscripcionDeAlumnosACursosToolStripMenuItem,
            this.reporteDeCursosToolStripMenuItem,
            this.reporteDePlanesToolStripMenuItem});
            this.tssArchivo.Image = ((System.Drawing.Image)(resources.GetObject("tssArchivo.Image")));
            this.tssArchivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssArchivo.Name = "tssArchivo";
            this.tssArchivo.Size = new System.Drawing.Size(64, 22);
            this.tssArchivo.Text = "Archivo";
            // 
            // aBMPersonasToolStripMenuItem
            // 
            this.aBMPersonasToolStripMenuItem.Name = "aBMPersonasToolStripMenuItem";
            this.aBMPersonasToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.aBMPersonasToolStripMenuItem.Text = "ABM Personas";
            this.aBMPersonasToolStripMenuItem.Click += new System.EventHandler(this.aBMCPersonasToolStripMenuItem_Click);
            // 
            // aBMUsuariosToolStripMenuItem
            // 
            this.aBMUsuariosToolStripMenuItem.Name = "aBMUsuariosToolStripMenuItem";
            this.aBMUsuariosToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.aBMUsuariosToolStripMenuItem.Text = "ABM Usuarios";
            this.aBMUsuariosToolStripMenuItem.Click += new System.EventHandler(this.aBMCUsuariosToolStripMenuItem_Click);
            // 
            // aBMProfesoresToolStripMenuItem
            // 
            this.aBMProfesoresToolStripMenuItem.Name = "aBMProfesoresToolStripMenuItem";
            this.aBMProfesoresToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.aBMProfesoresToolStripMenuItem.Text = "ABM Profesores";
            // 
            // aBMAlumnosToolStripMenuItem
            // 
            this.aBMAlumnosToolStripMenuItem.Name = "aBMAlumnosToolStripMenuItem";
            this.aBMAlumnosToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.aBMAlumnosToolStripMenuItem.Text = "ABM Alumnos";
            // 
            // aBMEspecialidadesToolStripMenuItem
            // 
            this.aBMEspecialidadesToolStripMenuItem.Name = "aBMEspecialidadesToolStripMenuItem";
            this.aBMEspecialidadesToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.aBMEspecialidadesToolStripMenuItem.Text = "ABM Especialidades";
            this.aBMEspecialidadesToolStripMenuItem.Click += new System.EventHandler(this.aBMCEspecialidadesToolStripMenuItem_Click);
            // 
            // aBMPlanesToolStripMenuItem
            // 
            this.aBMPlanesToolStripMenuItem.Name = "aBMPlanesToolStripMenuItem";
            this.aBMPlanesToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.aBMPlanesToolStripMenuItem.Text = "ABM Planes ";
            this.aBMPlanesToolStripMenuItem.Click += new System.EventHandler(this.aBMPlanesToolStripMenuItem_Click);
            // 
            // aBMMateriasToolStripMenuItem
            // 
            this.aBMMateriasToolStripMenuItem.Name = "aBMMateriasToolStripMenuItem";
            this.aBMMateriasToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.aBMMateriasToolStripMenuItem.Text = "ABM Materias";
            this.aBMMateriasToolStripMenuItem.Click += new System.EventHandler(this.aBMMateriasToolStripMenuItem_Click);
            // 
            // aBMComisionesToolStripMenuItem
            // 
            this.aBMComisionesToolStripMenuItem.Name = "aBMComisionesToolStripMenuItem";
            this.aBMComisionesToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.aBMComisionesToolStripMenuItem.Text = "ABM Comisiones";
            this.aBMComisionesToolStripMenuItem.Click += new System.EventHandler(this.aBMComisionesToolStripMenuItem_Click);
            // 
            // aBMCursosToolStripMenuItem
            // 
            this.aBMCursosToolStripMenuItem.Name = "aBMCursosToolStripMenuItem";
            this.aBMCursosToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.aBMCursosToolStripMenuItem.Text = "ABM Cursos";
            // 
            // inscripcionDeAlumnosACursosToolStripMenuItem
            // 
            this.inscripcionDeAlumnosACursosToolStripMenuItem.Name = "inscripcionDeAlumnosACursosToolStripMenuItem";
            this.inscripcionDeAlumnosACursosToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.inscripcionDeAlumnosACursosToolStripMenuItem.Text = "Inscripcion de alumnos a cursos";
            // 
            // reporteDeCursosToolStripMenuItem
            // 
            this.reporteDeCursosToolStripMenuItem.Name = "reporteDeCursosToolStripMenuItem";
            this.reporteDeCursosToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.reporteDeCursosToolStripMenuItem.Text = "Reporte de cursos";
            // 
            // reporteDePlanesToolStripMenuItem
            // 
            this.reporteDePlanesToolStripMenuItem.Name = "reporteDePlanesToolStripMenuItem";
            this.reporteDePlanesToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.reporteDePlanesToolStripMenuItem.Text = "Reporte de planes";
            // 
            // tsbCerrarSesion
            // 
            this.tsbCerrarSesion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("tsbCerrarSesion.Image")));
            this.tsbCerrarSesion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCerrarSesion.Name = "tsbCerrarSesion";
            this.tsbCerrarSesion.Size = new System.Drawing.Size(80, 22);
            this.tsbCerrarSesion.Text = "Cerrar Sesion";
            this.tsbCerrarSesion.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // tspAdmin
            // 
            this.tspAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssArchivo,
            this.tsbCerrarSesion});
            this.tspAdmin.Location = new System.Drawing.Point(0, 0);
            this.tspAdmin.Name = "tspAdmin";
            this.tspAdmin.Size = new System.Drawing.Size(284, 25);
            this.tspAdmin.TabIndex = 2;
            this.tspAdmin.Text = "toolStrip1";
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tspAdmin);
            this.IsMdiContainer = true;
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administrador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tspAdmin.ResumeLayout(false);
            this.tspAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSplitButton tssArchivo;
        private System.Windows.Forms.ToolStripMenuItem aBMPersonasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMAlumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMProfesoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMEspecialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMPlanesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMComisionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscripcionDeAlumnosACursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDePlanesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbCerrarSesion;
        private System.Windows.Forms.ToolStrip tspAdmin;
        private System.Windows.Forms.ToolStripMenuItem aBMMateriasToolStripMenuItem;



    }
}