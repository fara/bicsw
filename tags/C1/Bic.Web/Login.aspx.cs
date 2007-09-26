using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain.Usuario;

namespace Bic.Web
{
	/// <summary>
	/// Descripci�n breve de Login.
	/// </summary>
	public class Login : Page
	{

		protected TextBox txtUsuario;
		protected TextBox txtContrasena;
		protected Button btnIniciar;
		protected CustomValidator valLogin;

		private void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				Session["usuario"] = null;
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
			this.btnIniciar.Click += new EventHandler(this.btnIniciar_Click);
		}
		#endregion

		private void btnIniciar_Click(object sender, EventArgs e)
		{
			string usuario = this.txtUsuario.Text;
			string contrasena = this.txtContrasena.Text;
			Usuario u = BICContext.Instance.UsuarioService.Login(usuario, contrasena);
			if (u != null)
			{
				Session["usuario"] = u;
				if (u.Rol.EsAdministrador())
				{
					Response.Redirect("ListaUsuario.aspx");					
				}
				else
				{
					Response.Redirect("ListaProyecto.aspx");
				}
			} 
			else
			{
				this.valLogin.ErrorMessage = "Usuario o contrase�a inv�lidos. Por favor intente nuevamente.";
				this.valLogin.IsValid = false;
			}

		}
	}
}
