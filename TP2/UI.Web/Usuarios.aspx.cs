using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        UsuarioLogic _logic;

        private UsuarioLogic Logic
        {
            get { return _logic; }
            set { _logic = value; }
        }

        private void LoadGrid()
        {
            this._logic = new UsuarioLogic();
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
        }
    }
}