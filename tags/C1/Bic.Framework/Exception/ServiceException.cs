namespace Bic.Framework.Exception
{
	/// <summary>
	/// Descripci�n breve de ServiceException.
	/// </summary>
	public class ServiceException : System.Exception
	{
		public ServiceException()
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public ServiceException(string mensaje): base(mensaje)
		{}
	}
}
