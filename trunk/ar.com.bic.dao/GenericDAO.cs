using System;
using System.Collections;
using Spring.Data.NHibernate.Support;

namespace ar.com.bic.dao
{
	/// <summary>
	/// Este dao contiene los m�todos gen�ricos a todas las entidades. 
	/// Si se necesita un m�todo espec�fico de una entidad se deber� crear
	/// el dao espec�fico.
	/// </summary>
	public class GenericDAO : HibernateDaoSupport 
	{
		public GenericDAO()
		{
		}

		/// <summary>
		/// Persiste un objeto a trav�s de NHibernate
		/// </summary>
		/// <param name="persistentObject">el objecto a grabar</param>
		public void Save(Object persistentObject)  
		{
			HibernateTemplate.SaveOrUpdate(persistentObject);
		}

		/// <summary>
		/// Obtiene un objeto de la session de NHibernate
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <param name="id">El id de objeto</param>
		/// <returns>El objeto obtenido</returns>
		public Object Retrieve(Type entityType, long id) 
		{			
			return HibernateTemplate.Get(entityType, id);
		}

		/// <summary>
		/// Obtiene todos los objetos de un tipo de la sesi�n de NHibernate
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <returns>Una coleccion de los objetos</returns>
		public ICollection Select(Type entityType) 
		{
			return HibernateTemplate.Find("from " + entityType.Name);
		}

		/// <summary>
		/// Elimina un objeto de la sesi�n de Hibernate
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <param name="id">El id del objeto </param>
		public void Delete(Type entityType, long id) 
		{
			HibernateTemplate.Delete("from " + entityType.Name + " o where o.id =" + id);
		}
	}
}
