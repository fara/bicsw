using System;
using System.Collections;
using ar.com.bic.domain.catalogo;
using ar.com.bic.domain.interfaces;
using ar.com.bic.domain.exception;

namespace ar.com.bic.domain
{
	/// <summary>
	/// Descripción breve de Atributo.
	/// </summary>
	public class Atributo : ITablaMapeable, ICamino
	{
		private long id;
		private string nombre;
		private Columna columnaId;
		private ArrayList columnasDescripciones = new ArrayList();
		private Tabla tablaLookup;
		private Proyecto proyecto;
		//private Atributo hijo;
		private IList padres = new ArrayList();

		public Atributo() {}

		public Atributo(string nombre, Columna columnaId, Tabla tablaLkp, Proyecto proyecto) 
		{
			this.Nombre = nombre;
			this.columnaId = columnaId;
			this.TablaLookup = tablaLkp;
			this.Proyecto = proyecto;
		}

		public Atributo Hijo
		{
			get { return null; }
		}

		public void AgregarPadre(Atributo padre)
		{
			this.padres.Add(padre);
		}


		public long Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public Columna ColumnaId
		{
			get { return this.columnaId; }
			set { this.columnaId = value; }
		}

		public ArrayList ColumnasDescripciones
		{
			get { return new ArrayList(columnasDescripciones); }
		}

		public Tabla TablaLookup
		{
			get { return tablaLookup; }
			set { tablaLookup = value; }
		}

		public Proyecto Proyecto
		{
			get { return proyecto; }
			set { proyecto = value; }
		}

		public void AgregarColumnaDescripcion(Columna value)
		{
			this.columnasDescripciones.Add(value);
		}

		public IList ObtenerTablas()
		{
			return this.columnaId.ObtenerTablas();
		}

		public Columna Columna
		{
			get { return this.columnaId; }
		}

		public Camino GeneraCamino(Tabla tabla)
		{
			Camino camino;

            
			if(!tabla.Tenes(this.columnaId))
			{
				try
				{
					camino = this.Hijo.GeneraCamino(tabla);
					camino.AgregarAtributo(this);
				}
					// Si no tiene hijos cancela por referencia nula.
					// Capturo la excepcion.
				catch(NullReferenceException nre)
				{	
					// Subo de nivel de Excepcion a una excepcion del dominio.
					// Mando un excepcion de hijo inexistente.
					throw new NoExisteHijoException("El atributo no tiene hijos, es el ultimo en la jerarquia",nre);
				}
			}	
			else
			{
				camino = new Camino();
				camino.AtributoFact = this;
			}



			return camino;
		}


	}
}
