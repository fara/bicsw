using System.Collections;
using Bic.Domain;
using Bic.Domain.Dao;
using Bic.Framework.Exception;

namespace Bic.Application.Impl
{
	/// <summary>
	/// Implementaci�n de MetricaService
	/// </summary>
	public class MetricaServiceImpl : BaseService, MetricaService
	{
		private IProyectoDAO proyectoDAO;
		public IProyectoDAO ProyectoDAO 
		{
			get { return this.proyectoDAO; }
			set { this.proyectoDAO = value; }
		}

		public MetricaServiceImpl()
		{
		}

		/// <summary>
		/// Implementacion de MetricaService.save
		/// </summary>
		public void Save(Metrica unMetrica) 
		{
			IList metricas = this.ProyectoDAO.SelectMetricas(unMetrica.Proyecto.Id);
			if (metricas.Contains(unMetrica)) 
			{
				throw new ServiceException("No se puede crear la metrica ya que existe una con el mismo nombre.");
			}
			this.GenericDAO.Save(unMetrica);
		}

		/// <summary>
		/// Implementacion de MetricaService.retrieve
		/// </summary>
		public Metrica Retrieve(long id) 
		{
			return (Metrica) this.GenericDAO.Retrieve(typeof(Metrica), id); 
		}

		/// <summary>
		/// Implementacion de MetricaService.select
		/// </summary>
		public ICollection Select(long proyectoId) 
		{
			return this.ProyectoDAO.SelectMetricas(proyectoId);
		}

		/// <summary>
		/// Implementacion de MetricaService.delete
		/// </summary>
		public void Delete(long id)
		{
			Metrica met = Retrieve(id);
			Proyecto p = met.Proyecto;
			if (p.PuedeEliminarMetrica(met)) 
			{
				this.GenericDAO.Delete(typeof(Metrica), id);
			}
			else 
			{
				throw new ServiceException("No se puede eliminar la m�trica ya que est� siendo utilizada por un reporte.");
			}
		}

	}
}
