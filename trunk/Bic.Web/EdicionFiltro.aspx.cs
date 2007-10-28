using System;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.Domain.Exception;
using Bic.Framework;
using Bic.Framework.Exception;

namespace Bic.Web
{
	/// <summary>
	/// Descripci�n breve de EdicionFiltro.
	/// </summary>
	public class EdicionFiltro : BasePage
	{
		protected TextBox txtNombre;
		protected DropDownList ddlAtributo;
		protected DropDownList ddlDescripcion;
		protected DropDownList ddlOperador;
		protected TextBox txtValor;

		protected Button btnAceptar;
		protected ValidationSummary valSummary;
		protected CustomValidator valNombre;
		protected Button btnCancelar;


		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				this.ddlAtributo.DataSource = BICContext.Instance.AtributoService.Select(Proyecto.Id);
				this.ddlAtributo.DataBind();
				
				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Filtro f = BICContext.Instance.FiltroService.Retrieve(id);
					this.txtNombre.Text = Server.HtmlDecode(f.Nombre);
					this.txtValor.Text = Server.HtmlDecode(f.Valor);
					this.ddlDescripcion.SelectedValue = f.Columna.Id.ToString();
					this.ddlAtributo.SelectedValue = f.Atributo.Id.ToString();
					this.ddlOperador.SelectedValue = f.Operador;
				} 

				Atributo a = BICContext.Instance.AtributoService.Retrieve(long.Parse(this.ddlAtributo.SelectedValue));
				this.ddlDescripcion.DataSource = a.ColumnasDescripciones;
				this.ddlDescripcion.DataBind();

				this.ddlOperador.Items.Add(new ListItem("<", "<"));
				this.ddlOperador.Items.Add(new ListItem("<=", "<="));
				this.ddlOperador.Items.Add(new ListItem("=", "="));
				this.ddlOperador.Items.Add(new ListItem(">", ">"));
				this.ddlOperador.Items.Add(new ListItem(">=", ">="));
				this.ddlOperador.Items.Add(new ListItem("Empieza con", "Empieza con"));
				this.ddlOperador.Items.Add(new ListItem("Termina con", "Termina con"));
				this.ddlOperador.Items.Add(new ListItem("Contiene", "Contiene"));
				this.ddlOperador.DataBind();
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
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.ddlAtributo.SelectedIndexChanged += new EventHandler(this.ddlAtributo_SelectedIndexChanged);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			long id = (long) ViewState["id"];
			string nombre = StringUtils.TrimSpecialCharacters(this.txtNombre.Text);
			string operador = this.ddlOperador.SelectedValue;
			string valor = StringUtils.TrimSpecialCharacters(this.txtValor.Text);
			Atributo atributo = BICContext.Instance.AtributoService.Retrieve(long.Parse(this.ddlAtributo.SelectedValue));
			Columna desc = BICContext.Instance.TablaService.ObtenerColumna(long.Parse(this.ddlDescripcion.SelectedValue));
			Filtro f;

			try 
			{
				if (id == -1)
				{				
					f = new Filtro();
				} 
				else 
				{
					f = BICContext.Instance.FiltroService.Retrieve(id);
				}

				f.Columna = desc;
				f.Atributo = atributo;
				f.Nombre = nombre;
				f.Valor = valor;
				try
				{
					f.Operador = operador;
				}
				catch (OperadorInvalidoException oie)
				{
					throw new ServiceException(oie.Message);
				}
				f.Proyecto = Proyecto;
				BICContext.Instance.FiltroService.Save(f);
				Response.Redirect("ListaFiltro.aspx");
			} 
			catch (ServiceException se)
			{
				this.valNombre.IsValid = false;
				this.valNombre.ErrorMessage = se.Message;
			}	
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaFiltro.aspx");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAFiltros();
		}

		private void ddlAtributo_SelectedIndexChanged(object sender, EventArgs e)
		{
			Atributo a = BICContext.Instance.AtributoService.Retrieve(long.Parse(this.ddlAtributo.SelectedValue));
			this.ddlDescripcion.DataSource = a.ColumnasDescripciones;
			this.ddlDescripcion.DataBind();
		}
	}
}
