using System;
using System.Collections;

namespace Bic.Domain.Dao
{
	/// <summary>
	/// Este dao contiene los m�todos gen�ricos a todas las entidades. 
	/// Si se necesita un m�todo espec�fico de una entidad se deber� crear
	/// el dao espec�fico.
	/// </summary>
	public interface IGenericDAO
	{
		/// <summary>
		/// Persiste un objeto a trav�s de NHibernate
		/// </summary>
		/// <param name="persistentObject">el objecto a grabar</param>
		void Save(Object persistentObject);

		/// <summary>
		/// Obtiene un objeto de la session de NHibernate
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <param name="id">El id de objeto</param>
		/// <returns>El objeto obtenido</returns>
		Object Retrieve(Type entityType, long id); 

		/// <summary>
		/// Obtiene un objeto de la session de NHibernate. Y luego lo libera de la sesion
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <param name="id">El id de objeto</param>
		/// <returns>El objeto obtenido</returns>
		Object RetrieveEvicted(Type entityType, long id); 

		/// <summary>
		/// Obtiene todos los objetos de un tipo de la sesi�n de NHibernate
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <returns>Una coleccion de los objetos</returns>
		ICollection Select(Type entityType); 

		/// <summary>
		/// Obtiene todos los objetos de un tipo de la sesi�n de NHibernate
		/// menos el del id pasado
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <param name="id">id</param>
		/// <param name="nombre">el miembro nombre de la entidad</param>
		/// <returns>Una coleccion de los objetos</returns>
		object SelectByNombre(Type entityType, long id, string nombre); 

		
		/// <summary>
		/// Obtiene todos los objetos de un tipo de la sesi�n de NHibernate
		/// menos el del id pasado
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <param name="id">id</param>
		/// <param name="nombre">el miembro nombre de la entidad</param>
		/// <param name="proyecto_id">el id del proyecto al que pertenece</param>
		/// <returns>Una coleccion de los objetos</returns>
		object SelectByNombre(Type entityType, long id, string nombre, long proyecto_id); 

		/// <summary>
		/// Elimina un objeto de la sesi�n de Hibernate
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <param name="id">El id del objeto </param>
		void Delete(Type entityType, long id); 
	}
}
