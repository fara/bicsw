using System;

namespace ar.com.bic.domain.exception
{
	/// <summary>
	/// Descripci�n breve de ReporteInvalidoException.
	/// </summary>
	public class ReporteInvalidoException : Exception
	{
		public ReporteInvalidoException()
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}
		public ReporteInvalidoException(String mensaje): base(mensaje)
		{
			//
			//TODO llamar a la superclase
			//
		}
	}
}
