using System;
using System.Collections;
using Bic.Domain;
using Bic.Domain.Catalogo;

namespace Bic.Application.DTO
{
	/// <summary>
	/// Summary description for ReporteDTO.
	/// </summary>
	public class ReporteDTO
	{
		private string nombre;
		private IList atributos;
		private IList metricas; 
		private IList filtros; 
		private Conexion conexion;

		public string Nombre
		{
			get { return this.nombre; }
		}
		public IList Atributos
		{
			get { return this.atributos; }
		}
		public IList Metricas
		{
			get { return this.metricas; }
		}
		public IList Filtros
		{
			get { return this.filtros; }
		}
		public Conexion Conexion 
		{
			get { return this.conexion; }
		}

		public ReporteDTO(Reporte rep)
		{
			this.nombre = rep.Nombre;
			this.atributos = rep.Atributos;
			this.metricas = rep.Metricas; 
			this.filtros = rep.Filtros; 
			this.conexion = rep.Proyecto.Conexion;
		}
	}
}
