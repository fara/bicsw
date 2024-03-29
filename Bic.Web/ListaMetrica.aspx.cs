using System;
using System.Collections;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Framework.Exception;

namespace Bic.Web
{
	/// <summary>
	/// Descripci�n breve de ListaMetrica.
	/// </summary>
	public class ListaMetrica : BasePage
	{
		protected DataGrid dgMetricas;
		protected Button btnNuevo;
		protected CustomValidator valEliminar;
		protected CustomValidator valHechos;

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
			this.dgMetricas.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgMetricas_PageChanger);
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
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				long id = (long) this.dgMetricas.DataKeys[e.Item.ItemIndex];
				try 
				{
					BICContext.Instance.MetricaService.Delete(id);
					this.dgMetricas.CurrentPageIndex = 0;
					ListMetricas();
				}
				catch (ServiceException se) 
				{
					this.valEliminar.IsValid = false;
					this.valEliminar.ErrorMessage = se.Message;
				}			
			}
		}

		private void dgMetricas_PageChanger(object source, DataGridPageChangedEventArgs e)
		{
			this.dgMetricas.CurrentPageIndex = e.NewPageIndex;
			ListMetricas();
		}

		private void ListMetricas()
		{
			dgMetricas.DataSource = BICContext.Instance.MetricaService.Select(Proyecto.Id);
			dgMetricas.DataBind();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			ICollection ds = BICContext.Instance.HechoService.Select(Proyecto.Id);
			if( ds.Count == 0)
			{
				this.valHechos.IsValid = false;
				this.valHechos.ErrorMessage = "No existen Hechos sobre los cuales se pueden crear M�tricas.";
			}
			else
			{
				Response.Redirect("EdicionMetrica.aspx?id=-1");
			}
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAMetricas();
		}
	}
}
