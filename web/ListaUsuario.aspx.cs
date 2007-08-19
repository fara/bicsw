using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.bic.application;

namespace bic
{
	/// <summary>
	/// Descripci�n breve de WebForm1.
	/// </summary>
	public class ListaUsuario : Page
	{
		protected Button btnNuevo;
		protected DataGrid dgUsuarios;
	
		private void Page_Load(object sender, EventArgs e)
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
			this.dgUsuarios.ItemCommand += new DataGridCommandEventHandler(this.dgUsuarios_ItemCommand);
			this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion


		private void dgUsuarios_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			long id = (long) this.dgUsuarios.DataKeys[e.Item.ItemIndex];
			BICContext.Instance.UsuarioService.Delete(id);
			listUsuarios();
		}

		private void listUsuarios()
		{
			dgUsuarios.DataSource = BICContext.Instance.UsuarioService.Select();
			dgUsuarios.DataBind();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			Response.Redirect("EdicionUsuario.aspx?id=-1");
		}
	}
}
