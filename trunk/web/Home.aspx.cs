using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ar.com.bic.application;
using ar.com.bic.domain;

namespace bic
{
	/// <summary>
	/// Descripci�n breve de Home.
	/// </summary>
	public class Home : System.Web.UI.Page
	{

		protected System.Web.UI.WebControls.Label lblUsuario;
		protected System.Web.UI.WebControls.Label lblProyecto;

		private long ProyectoId
		{
			get { return (long) Session["proyectoId"]; }
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				this.lblUsuario.Text = Session["usuario"].ToString();
				this.lblProyecto.Text = BICContext.Instance.ProyectoService.retrieve(ProyectoId).Nombre;
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
