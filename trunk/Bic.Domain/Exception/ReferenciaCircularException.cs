namespace Bic.Domain.Exception
{
	/// <summary>
	/// Descripci�n breve de NoExisteCaminoException.
	/// </summary>
	public class ReferenciaCircularException : System.Exception
	{
		public ReferenciaCircularException(string mensaje): base(mensaje)
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public ReferenciaCircularException(string mensaje, System.Exception ex): base(mensaje,ex)
		{
			//TODO Escribir en la propiedad message
		}
	}
}
