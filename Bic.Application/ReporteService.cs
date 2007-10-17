using System;
using System.Data;
using Bic.Domain;
using Bic.Application.DTO;
using System.Collections;


namespace Bic.Application
{
	public interface ReporteService
	{
		/// <summary>
		/// Persiste un reporte
		/// </summary>
		/// <param name="reporte">EL reporte a ser grabado</param>
		void Save(Reporte reporte); 

		/// <summary>
		/// Obtiene un reporte a trav�s de su id
		/// </summary>
		/// <param name="id">El id de reporte</param>
		/// <returns>El reporte correspondiente</returns>
		Reporte Retrieve(long id);

		/// <summary>
		/// Obtiene todos los reportes
		/// </summary>
		/// <param name="proyectoId">El id de proyecto</param>
		/// <returns>Una coleccion de reportes</returns>
		ICollection Select(long proyectoId);

		/// <summary>
		/// Elimina un reporte
		/// </summary>
		/// <param name="id">El id del reporte</param>
		void Delete(long id);

		/// <summary>
		/// Obtiene el resultado de ejecutar un reporte
		/// </summary>
		/// <param name="id">el id del reporte</param>
		/// <returns></returns>
		DataSet Ejecutar(long id);

		/// <summary>
		/// Obtiene el resultado de ejecutar un reporte que esta en memoria.
		/// </summary>
		/// <param name="reporte">el reporte</param>
		/// <returns></returns>
		DataSet Ejecutar(ReporteDTO reporte);

		/// <summary>
		/// No me caben ni un poco estos comentarios. Para mi estan re al pedo.
		/// </summary>
		/// <param name="reporte"></param>
		/// <returns></returns>
		String GetReportSQL(ReporteDTO reporte);
	}
}
