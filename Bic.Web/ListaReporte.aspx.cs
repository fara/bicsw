using System;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain.Exception;

namespace Bic.Web
{
	/// <summary>
	/// Descripci�n breve de ListaReporte.
	/// </summary>
	public class ListaReporte : BasePage
	{
		#region Web Controls

		protected DataGrid dgReportes;
		protected Button btnNuevo;
		protected CustomValidator valEliminar;

		#endregion

		#region Event handlers

		private void Page_Load(object sender, EventArgs e)
		{
			this.BaseLoad();

			if (!Page.IsPostBack) 
			{
				this.ListReportes();
			}
		}


		private void dgReportes_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[2];
				LinkButton myDeleteButton; 
				myDeleteButton = (LinkButton) myTableCell.Controls[0];
				myDeleteButton.Attributes.Add("onclick", 
					"return confirm('�Est� seguro que desea eliminar el reporte?');");

			}
		}


		private void dgReportes_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{

				long id = (long) this.dgReportes.DataKeys[e.Item.ItemIndex];

				if (e.CommandName.Equals("Borrar"))
				{				
					BICContext.Instance.ReporteService.Delete(id);
					this.dgReportes.CurrentPageIndex = 0;
				}
				else if(e.CommandName.Equals("Ejecutar"))
				{
					ReportManager.GetInstance(this.Session).Reporte = BICContext.Instance.ReporteService.Retrieve(id);
					Response.Redirect("Reportes/AdministracionReportes.aspx");
				}
			
				this.ListReportes();
			}
		}

		private void dgReportes_PageChanger(object source, DataGridPageChangedEventArgs e)
		{
			this.dgReportes.CurrentPageIndex = e.NewPageIndex;
			ListReportes();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			Response.Redirect("EdicionReporte.aspx?id=-1");
		}


		#endregion       

		#region Private methods

		private void ListReportes()
		{
			dgReportes.DataSource = BICContext.Instance.ReporteService.Select(Proyecto.Id);
			dgReportes.DataBind();
		}


		#endregion		

		#region Protected methods

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAReportes();
		}


		#endregion		

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
			this.dgReportes.ItemCommand += new DataGridCommandEventHandler(this.dgReportes_ItemCommand);
			this.dgReportes.ItemCreated += new DataGridItemEventHandler(this.dgReportes_ItemCreated);
			this.dgReportes.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgReportes_PageChanger);
		}
		#endregion
	}
}
