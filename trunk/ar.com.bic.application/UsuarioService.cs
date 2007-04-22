using System;
using ar.com.bic.domain;

namespace ar.com.bic.application
{
	/// <summary>
	/// Descripci�n breve de UsuarioService.
	/// </summary>
	public interface UsuarioService
	{
		void save(Usuario unUsuario);
		Usuario retrieve(long id);
	}
}
