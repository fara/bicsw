using System;
using System.Collections;
using Spring.Data.NHibernate.Support;
using ar.com.bic.domain;

namespace ar.com.bic.dao
{
	/// <summary>
	/// Descripci�n breve de UsuarioDAO.
	/// </summary>
	public class UsuarioDAO : HibernateDaoSupport 
	{
		public UsuarioDAO()
		{
		}

		/// <summary>
		/// Persiste un usuario a trav�s de NHibernate
		/// </summary>
		/// <param name="unUsuario">el Usuario a grabar</param>
		public void save(Usuario unUsuario)  
		{
			HibernateTemplate.SaveOrUpdate(unUsuario);
		}

		/// <summary>
		/// Obtiene un usuario de la session de NHibernate
		/// </summary>
		/// <param name="id">El id de usuario</param>
		/// <returns>El usuario obtenido</returns>
		public Usuario retrieve(long id) 
		{			
			return (Usuario) HibernateTemplate.Get(typeof(Usuario), id);
		}

		/// <summary>
		/// Obtiene todos los usuarios de la sesi�n de NHibernate
		/// </summary>
		/// <returns>Una coleccion de usuarios</returns>
		public ICollection select() 
		{
			return HibernateTemplate.Find("from Usuario");
		}

		/// <summary>
		/// Elimina un usuario de la sesi�n de Hibernate
		/// </summary>
		/// <param name="id">El id de usuario</param>
		public void delete(long id) 
		{
			HibernateTemplate.Delete("from Usuario u where u.id =" + id);
		}
	}
}
