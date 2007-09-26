using System.Collections;
using Bic.Domain.Catalogo;
using Bic.Domain.Interfaces;

namespace Bic.Domain
{
	/// <summary>
	/// Descripci�n breve de Metrica.
	/// </summary>
	public class Metrica : ITablaMapeable
	{

		#region Miembros privados
		
		private string nombre;
		private string funcion;
		private Hecho hecho;
			
		#endregion

		public Metrica(string nombre, string funcion, Hecho hecho)
		{
			this.nombre = nombre;
			this.funcion = funcion;
			this.hecho = hecho;
		}

		#region Metodos Publicos
			
		public IList ObtenerTablas()
		{
			return this.hecho.ObtenerTablas();
		}
		
		public Columna Columna
		{
			get { return this.hecho.Columna; }
		}

		#endregion

	}
}
