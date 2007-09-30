using System;
using System.Web.UI.WebControls;
using Bic.Application;

namespace Bic.Web
{
	/// <summary>
	/// Descripci�n breve de ListaMetrica.
	/// </summary>
	public class ListaMetrica : BasePage
	{
		protected DataGrid dgMetricas;
		protected Button btnNuevo;

		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				ListMetricas();
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
			this.dgMetricas.ItemCommand += new DataGridCommandEventHandler(this.dgMetricas_ItemCommand);
			this.dgMetricas.ItemCreated += new DataGridItemEventHandler(this.dgMetricas_ItemCreated);
		}
		#endregion

		private void dgMetricas_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[3];
				LinkButton myDeleteButton; 
				myDeleteButton = (LinkButton) myTableCell.Controls[0];
				myDeleteButton.Attributes.Add("onclick", 
					"return confirm('�Est� seguro que desea eliminar la metrica?');");

			}
		}

		private void dgMetricas_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			long id = (long) this.dgMetricas.DataKeys[e.Item.ItemIndex];
			BICContext.Instance.MetricaService.Delete(id);
			ListMetricas();
		}

		private void ListMetricas()
		{
			dgMetricas.DataSource = BICContext.Instance.MetricaService.Select(Proyecto.Id);
			dgMetricas.DataBind();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			Response.Redirect("EdicionMetrica.aspx?id=-1");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAMetricas();
		}
	}
}
