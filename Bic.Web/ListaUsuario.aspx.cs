using System;
using System.Web.UI.WebControls;
using Bic.Application;

namespace Bic.Web
{
	/// <summary>
	/// Descripci�n breve de WebForm1.
	/// </summary>
	public class ListaUsuario : BasePage
	{
		protected Button btnNuevo;
		protected DataGrid dgUsuarios;
	
		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				ListarUsuarios();
			}
			
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
			this.dgUsuarios.ItemCreated += new DataGridItemEventHandler(this.dgUsuarios_ItemCreated);
			this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);
			this.Load += new EventHandler(this.Page_Load);
			this.dgUsuarios.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgUsuarios_PageChanger);
		}
		#endregion


		private void dgUsuarios_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[3];
				LinkButton myDeleteButton; 
				myDeleteButton = (LinkButton) myTableCell.Controls[0];
				myDeleteButton.Attributes.Add("onclick", 
					"return confirm('�Est� seguro que desea eliminar el usuario?');");

			}
		}

		private void dgUsuarios_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				long id = (long) this.dgUsuarios.DataKeys[e.Item.ItemIndex];
				BICContext.Instance.UsuarioService.Delete(id);
				this.dgUsuarios.CurrentPageIndex = 0;
				ListarUsuarios();
			}
		}

		private void dgUsuarios_PageChanger(object source, DataGridPageChangedEventArgs e)
		{
			this.dgUsuarios.CurrentPageIndex = e.NewPageIndex;
			ListarUsuarios();
		}

		private void ListarUsuarios()
		{
			dgUsuarios.DataSource = BICContext.Instance.UsuarioService.Select();
			dgUsuarios.DataBind();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			Response.Redirect("EdicionUsuario.aspx?id=-1");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAUsuarios();
		}
	}
}
