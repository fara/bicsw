using System;
using System.Collections;
using ar.com.bic.domain.interfaces;
using ar.com.bic.domain.esquema;

namespace ar.com.bic.domain
{
	/// <summary>
	/// Descripci�n breve de Hecho.
	/// </summary>
	public class Hecho : ITablaMapeable
	{
		
		private string nombre;
		private Campo CampoHecho;

		public Hecho(string nombre, Campo campo)
		{
			this.nombre = nombre;
			this.CampoHecho = campo;
		}

		#region Metodos Publicos
			
		public ArrayList GetTablas()
		{
			// return this.CampoHecho.Tablas;
			// TODO: el campo no conoce todas las tablas que tambien tienen un campo igual a el.
			// el campo es una representacion del esquema de la bd.
			// esto lo deber�a resolver otro objeto.
			return null;
		}

		public Campo GetCampo()
		{
			return this.CampoHecho;
		}

		#endregion

	}
}
