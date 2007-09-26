using System;

namespace Bic.Domain.Exception
{
	/// <summary>
	/// Descripci�n breve de TablaCandidataException.
	/// </summary>
	public class NoExisteTablaCandidataException : System.Exception
	{
		public NoExisteTablaCandidataException()
		{
		}

		public NoExisteTablaCandidataException(String mensaje): base(mensaje)
		{
			//TODO Escribir en la propiedad message
		}

	}
}
