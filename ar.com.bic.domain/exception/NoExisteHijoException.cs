using System;

namespace ar.com.bic.domain.exception
{
	/// <summary>
	/// Descripci�n breve de NoExisteHijoException.
	/// </summary>
	public class NoExisteHijoException : Exception
	{
		public NoExisteHijoException(string mensaje): base(mensaje)
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}
		public NoExisteHijoException(string mensaje,Exception ex): base(mensaje,ex)
		{
			//TODO Escribir en la propiedad message
		}
	}
}
