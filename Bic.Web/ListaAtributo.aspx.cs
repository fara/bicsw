using System;
using System.Collections;
using Bic.Framework.Exception;
using System.Web.UI.WebControls;
using Bic.Application;

namespace Bic.Web
{
	/// <summary>
	/// Descripci�n breve de ListaAtributo.
	/// </summary>
	public class ListaAtributo : BasePage
	{
		protected DataGrid dgAtributos;
		protected Button btnNuevo;
		protected CustomValidator valEliminar;
		protected CustomValidator valTablas;

		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				ListAtributos();
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
			this.dgAtributos.ItemCommand += new DataGridCommandEventHandler(this.dgAtributos_ItemCommand);
			this.dgAtributos.ItemCreated += new DataGridItemEventHandler(this.dgAtributos_ItemCreated);
			this.dgAtributos.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgAtributos_PageChanger);
			this.Page.PreRender+=new EventHandler(page_PreRenderEventHandler);
		}
		#endregion

		private void dgAtributos_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[4];
				LinkButton myDeleteButton; 
				myDeleteButton = (LinkButton) myTableCell.Controls[0];
				myDeleteButton.Attributes.Add("onclick", 
					"return confirm('�Est� seguro que desea eliminar el atributo?');");

			}
		}

		private void dgAtributos_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				long id = (long) this.dgAtributos.DataKeys[e.Item.ItemIndex];
				try 
				{
					BICContext.Instance.AtributoService.Delete(id);
					this.dgAtributos.CurrentPageIndex = 0;
					ListAtributos();
				}
				catch (ServiceException se) 
				{
					this.valEliminar.IsValid = false;
					this.valEliminar.ErrorMessage = se.Message;
				}	
			}
		}

		private void dgAtributos_PageChanger(object source, DataGridPageChangedEventArgs e)
		{
			this.dgAtributos.CurrentPageIndex = e.NewPageIndex;
			ListAtributos();
		}

		private void ListAtributos()
		{
			dgAtributos.DataSource = BICContext.Instance.AtributoService.Select(Proyecto.Id);
			dgAtributos.DataBind();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			ICollection ds = BICContext.Instance.TablaService.Select(Proyecto.Id);
			if( ds.Count == 0)
			{
				this.valTablas.IsValid = false;
				this.valTablas.ErrorMessage = "No existen Tablas sobre las cuales crear Atributos.";
			}
			else
			{
				Response.Redirect("EdicionAtributo.aspx?id=-1");
			}
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAAtributos();
		}
	}
}
