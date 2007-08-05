using System;
using Spring.Context;
using Spring.Context.Support;

namespace ar.com.bic.application
{
	/// <summary>
	/// BICContext es un service locator que expone los servicios a la capa de presentaci�n.
	/// </summary>
	public class BICContext
	{
		private static BICContext instance = new BICContext();
		public static BICContext Instance 
		{
			get { return instance; }
		}

		private IApplicationContext ctx;
		private BICContext()
		{
			this.ctx = ContextRegistry.GetContext();		
		}

		/// <summary>
		/// Obtiene una implementaci�n de UsuarioService
		/// </summary>
		public UsuarioService UsuarioService 
		{
			get { return (UsuarioService)ctx["usuarioService"]; }
		}

		/// <summary>
		/// Obtiene una implementaci�n de ProyectoService
		/// </summary>
		public ProyectoService ProyectoService 
		{
			get { return (ProyectoService)ctx["proyectoService"]; }
		}

		/// <summary>
		/// Obtiene una implementaci�n de AtributoService
		/// </summary>
		public AtributoService AtributoService 
		{
			get { return (AtributoService)ctx["atributoService"]; }
		}


	}
}
