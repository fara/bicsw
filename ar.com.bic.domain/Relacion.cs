using System;
using ar.com.bic.domain.catalogo;

namespace ar.com.bic.domain
{
	/// <summary>
	/// Descripci�n breve de Relacion.
	/// </summary>
	public class Relacion
	{

		Atributo hijo;

		public Relacion()
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public Camino GeneraCamino(Tabla tabla)
		{
			Camino camino = this.hijo.GeneraCamino(tabla);

			camino.AgregarRelacion(this);

			return camino;
		}
	}
}
