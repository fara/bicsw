using System.Collections;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.Domain.Dao;
using Bic.Framework.Exception;

namespace Bic.Application.Impl
{
	/// <summary>
	/// Implementación de TablaService
	/// </summary>
	public class TablaServiceImpl : BaseService, TablaService
	{
		private IProyectoDAO proyectoDAO;
		public IProyectoDAO ProyectoDAO 
		{
			get { return this.proyectoDAO; }
			set { this.proyectoDAO = value; }
		}

		private ITablaDAO tablaDAO;
		public ITablaDAO TablaDAO 
		{
			get { return this.tablaDAO; }
			set { this.tablaDAO = value; }
		}

		private ICatalogoDAO catalogoDAO;
		public ICatalogoDAO CatalogoDAO 
		{
			get { return this.catalogoDAO; }
			set { this.catalogoDAO = value; }
		}

		public TablaServiceImpl() {}

		/// <summary>
		/// Implementacion de TablaService.save
		/// </summary>
		public void Save(Tabla unaTabla) 
		{
			// valido que no exista
			Tabla t = this.TablaDAO.ObtenerByAlias(unaTabla.Proyecto.Id, unaTabla.Alias);
			if (t != null && !t.Equals(unaTabla)) 
			{
				throw new ServiceException("No se puede crear la tabla ya que existe una con el mismo nombre.");
			}
			if (unaTabla.Id  == 0) // si es una entidad nueva
			{
				// la primera vez que grabo obtengo todas las columnas de la tabla
				IList columnas = this.catalogoDAO.ObtenerColumnas(unaTabla);
				foreach (Columna col in columnas) 
				{
					unaTabla.AgregarColumna(col);
				}
			}
			this.GenericDAO.Save(unaTabla);
		}

		/// <summary>
		/// Implementacion de TablaService.retrieve
		/// </summary>
		public Tabla Retrieve(long id) 
		{
			return (Tabla) this.GenericDAO.Retrieve(typeof(Tabla), id); 
		}

		/// <summary>
		/// Implementacion de TablaService.select
		/// </summary>
		public ICollection Select(long proyectoId) 
		{
			return this.ProyectoDAO.SelectTablas(proyectoId);
		}

		/// <summary>
		/// Implementacion de TablaService.SelectTablasParaHechos
		/// </summary>
		public ICollection SelectTablasParaHechos(long proyectoId) 
		{
			return this.TablaDAO.SelectTablasParaHechos(proyectoId);
		}

		/// <summary>
		/// Implementacion de TablaService.delete
		/// </summary>
		public void Delete(long id)
		{
			Tabla t = (Tabla) this.GenericDAO.Retrieve(typeof(Tabla), id);
			Proyecto p = t.Proyecto;
			if (p.PuedeEliminarTabla(t)) 
			{
				this.GenericDAO.Delete(typeof(Tabla), id);
			} 
			else 
			{
				throw new ServiceException("No se puede eliminar la tabla ya que está siendo utilizada por un atributo y/o un hecho.");
			}
		}		

		/// <summary>
		/// Implementacion de TablaServiceImpl.SelectTablasDisponibles
		/// </summary>
		public IList SelectTablasDisponibles(long idProyecto)
		{
			Proyecto p = (Proyecto) this.GenericDAO.Retrieve(typeof(Proyecto), idProyecto);
			Catalogo c = this.catalogoDAO.ObtenerCatalogo(p.Conexion);
			return c.Tablas;
		}

		/// <summary>
		/// Implementacion de TablaService.ObtenerTablaPorNombre
		/// </summary>
		public Tabla ObtenerTabla(string nombreTabla, long idProyecto)
		{
			return this.tablaDAO.ObtenerByNombre(idProyecto, nombreTabla);
		}

		/// <summary>
		/// Implementacion TablaService.ObtenerColumna
		/// </summary>
		public Columna ObtenerColumna(long id)
		{
			return (Columna) this.GenericDAO.Retrieve(typeof(Columna), id);
		}

		/// <summary>
		/// Implementacion TablaService.SelectColumnasParaHecho
		/// </summary>
		public IList SelectColumnasParaHecho(long idProyecto) 
		{
			return this.tablaDAO.SelectColumnasParaHecho(idProyecto); 
		}
	}
}
