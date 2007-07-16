using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ar.com.bic.application;
using ar.com.bic.domain;

namespace bic
{
	/// <summary>
	/// Descripci�n breve de WebForm1.
	/// </summary>
	public class ListaUsuario : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgUsuarios;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			listUsuarios();
		}

		#region C�digo generado por el Dise�ador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Dise�ador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// M�todo necesario para admitir el Dise�ador. No se puede modificar
		/// el contenido del m�todo con el editor de c�digo.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgUsuarios.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgUsuarios_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void dgUsuarios_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			long id = (long) this.dgUsuarios.DataKeys[e.Item.ItemIndex];
			BICContext.Instance.UsuarioService.delete(id);
			listUsuarios();
		}

		private void listUsuarios()
		{
			dgUsuarios.DataSource = BICContext.Instance.UsuarioService.select();
			dgUsuarios.DataBind();
		}
	}
}
