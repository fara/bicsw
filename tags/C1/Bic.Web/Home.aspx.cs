using System;

namespace Bic.Web
{
	/// <summary>
	/// Descripci�n breve de Home.
	/// </summary>
	public class Home : BasePage
	{

		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
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
		}
		#endregion

		protected override bool TienePermisosSuficientes()
		{
			return true;
		}
	}
}
