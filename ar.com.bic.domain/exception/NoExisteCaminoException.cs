using System;
using ar.com.bic.domain.catalogo;


namespace ar.com.bic.domain.exception
{
	/// <summary>
	/// Descripci�n breve de NoExisteCaminoException.
	/// </summary>
	public class NoExisteCaminoException : Exception
	{
		public NoExisteCaminoException(string mensaje): base(mensaje)
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public NoExisteCaminoException(string mensaje,Exception ex): base(mensaje,ex)
		{
			//TODO Escribir en la propiedad message
		}
	}
}
