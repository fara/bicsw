namespace Bic.Domain.Exception
{
	/// <summary>
	/// Descripci�n breve de OperadorInvalidoException.
	/// </summary>
	public class OperadorInvalidoException : System.Exception
	{
		public OperadorInvalidoException(string mensaje): base(mensaje)
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public OperadorInvalidoException(string mensaje, System.Exception ex): base(mensaje,ex)
		{
			//TODO Escribir en la propiedad message
		}
	}
}
