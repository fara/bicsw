using System;

namespace Bic.Domain.Exception
{
	/// <summary>
	/// Descripci�n breve de ReporteInvalidoException.
	/// </summary>
	public class ReporteInvalidoException : System.Exception
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
