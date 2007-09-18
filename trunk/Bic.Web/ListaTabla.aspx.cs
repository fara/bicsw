using System;
using System.Web.UI.WebControls;
using Bic.Application;

namespace Bic.Web
{
	/// <summary>
	/// Descripci�n breve de ListaTabla.
	/// </summary>
	public class ListaTabla : BasePage
	{
		protected Label lblUsuario;
		protected Label lblProyecto;
		protected DataGrid dgTablas;
		protected Button btnNuevo;

		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				this.lblUsuario.Text = Usuario.Nombre;
				this.lblProyecto.Text = Proyecto.Nombre;
				ListTablas();
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
			this.Load += new EventHandler(this.Page_Load);
			this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);
			this.dgTablas.ItemCommand += new DataGridCommandEventHandler(this.dgTablas_ItemCommand);
			this.dgTablas.ItemCreated += new DataGridItemEventHandler(this.dgTablas_ItemCreated);
		}
		#endregion

		private void dgTablas_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[4];
				LinkButton myDeleteButton; 
				myDeleteButton = (LinkButton) myTableCell.Controls[0];
				myDeleteButton.Attributes.Add("onclick", 
					"return confirm('�Est� seguro que desea eliminar la tabla?');");

			}
		}

		private void dgTablas_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			long id = (long) this.dgTablas.DataKeys[e.Item.ItemIndex];
			BICContext.Instance.TablaService.Delete(id);
			ListTablas();
		}

		private void ListTablas()
		{
			dgTablas.DataSource = BICContext.Instance.TablaService.Select(Proyecto.Id);
			dgTablas.DataBind();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			Response.Redirect("EdicionTabla.aspx?id=-1");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederATablas();
		}
	}
}
