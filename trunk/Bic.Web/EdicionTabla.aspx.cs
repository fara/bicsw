using System;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain.Catalogo;

namespace Bic.Web
{
	/// <summary>
	/// Descripci�n breve de EdicionTabla.
	/// </summary>
	public class EdicionTabla : BasePage
	{
		protected Label lblUsuario;
		protected Label lblProyecto;

		protected TextBox txtAlias;
		protected TextBox txtPeso;
		protected DropDownList ddlNombre;

		protected Button btnAceptar;
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqAlias;
		protected RequiredFieldValidator reqPeso;
		protected ValidationSummary valSummary;
		protected Button btnCancelar;


		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				this.lblUsuario.Text = Usuario.Nombre;
				this.lblProyecto.Text = Proyecto.Nombre;
				object datasource = null;
				
				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Tabla t = BICContext.Instance.TablaService.Retrieve(id);
					this.ddlNombre.SelectedValue = t.Nombre;
					this.txtAlias.Text = t.Alias;
					this.txtPeso.Text = t.Peso.ToString();
					datasource = new Tabla[] {t};
				} 
				else 
				{
					datasource = BICContext.Instance.CatalogoService.SelectTablasDisponibles(Proyecto.Id);
				}

				this.ddlNombre.DataSource = datasource;
				this.ddlNombre.DataBind();

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
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			long id = (long) ViewState["id"];
			string alias = this.txtAlias.Text;
			int peso = Int32.Parse(this.txtPeso.Text);

			if (id == -1)
			{
				Tabla t = BICContext.Instance.CatalogoService.ObtenerTabla(this.ddlNombre.SelectedValue, Proyecto.Id);
				t.Alias = alias;
				t.Peso = peso;
				t.Proyecto = Proyecto;
				BICContext.Instance.TablaService.Save(t);
			} 
			else 
			{
				Tabla t = BICContext.Instance.TablaService.Retrieve(id);
				t.Alias = alias;
				t.Peso = peso;
				BICContext.Instance.TablaService.Save(t);
			}			

			
			Response.Redirect("ListaTabla.aspx");
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaTabla.aspx");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederATablas();
		}
	}
}
