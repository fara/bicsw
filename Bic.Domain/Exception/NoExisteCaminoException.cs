namespace Bic.Domain.Exception
{
	/// <summary>
	/// Descripci�n breve de NoExisteCaminoException.
	/// </summary>
	public class NoExisteCaminoException : System.Exception
	{
		public NoExisteCaminoException(string mensaje): base(mensaje)
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public NoExisteCaminoException(string mensaje, System.Exception ex): base(mensaje,ex)
		{
			//TODO Escribir en la propiedad message
		}
	}
}
