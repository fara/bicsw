namespace Bic.Domain.Exception
{
	/// <summary>
	/// Descripci�n breve de FiltroInvalidoException.
	/// </summary>
	public class FiltroInvalidoException : System.Exception
	{
		public FiltroInvalidoException(string mensaje): base(mensaje)
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public FiltroInvalidoException(string mensaje, System.Exception ex): base(mensaje,ex)
		{
			//TODO Escribir en la propiedad message
		}
	}
}
