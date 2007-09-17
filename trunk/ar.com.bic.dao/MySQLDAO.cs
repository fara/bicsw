using System;
using System.Collections;
using System.Data;
using ar.com.bic.domain.catalogo;
using MySql.Data.MySqlClient;

namespace ar.com.bic.dao
{
	/// <summary>
	/// Este DAO se encarga de leer la información del catalogo de la BD
	/// </summary>
	public class MySQLDAO
	{

		private static readonly string GET_CATALOGO_SQL = "SELECT table_name, table_schema FROM `information_schema`.`COLUMNS` where table_schema = ?database";
		private static readonly string GET_COLUMNAS_SQL = "SELECT column_name, data_type FROM `information_schema`.`COLUMNS` where table_schema = ?database and table_name= ?tablename";

		public MySQLDAO()
		{
		}

		public Catalogo GetCatalogo(string server, string database, string user, string password)
		{
			string connStr = String.Format("Server={0};Database={1};Uid={2};Pwd={3}", 
				new object[]{server, database, user, password});
			MySqlConnection con = new MySqlConnection(connStr);

			using (con)
			{
				con.Open();

				DataSet ds = new DataSet();

				MySqlCommand cmd = new MySqlCommand(GET_CATALOGO_SQL, con);
				cmd.Parameters.Add("?database", database);

				MySqlDataAdapter da = new MySqlDataAdapter(cmd);
				da.Fill(ds);

				string nombreTablaAnterior = string.Empty;
				Catalogo cat = new Catalogo();
				Tabla t = null;

				if (ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
				{	
					t = new Tabla(ds.Tables[0].Rows[0].ItemArray[0].ToString(), ds.Tables[0].Rows[0].ItemArray[3].ToString());
					nombreTablaAnterior = t.Nombre;
				}

				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					t.Nombre = dr.ItemArray[0].ToString();
					t.NombreBD = dr.ItemArray[1].ToString();
					if (!t.Nombre.Equals(nombreTablaAnterior))
					{
						cat.AgregarTabla(t);
						t = new Tabla(t.Nombre, t.NombreBD);
					}
					nombreTablaAnterior = t.Nombre;
				}
				con.Close();
				return cat;
			}
		}

		public IList GetColumnas(string server, string database, string user, string password, string tableName)
		{
			string connStr = String.Format("Server={0};Database={1};Uid={2};Pwd={3}", 
				new object[]{server, database, user, password});
			MySqlConnection con = new MySqlConnection(connStr);

			using (con)
			{
				con.Open();

				DataSet ds = new DataSet();

				MySqlCommand cmd = new MySqlCommand(GET_COLUMNAS_SQL, con);
				cmd.Parameters.Add("?database", database);
				cmd.Parameters.Add("?tablename", tableName);

				MySqlDataAdapter da = new MySqlDataAdapter(cmd);
				da.Fill(ds);

				IList ret = new ArrayList();
				
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					Columna col = new Columna(dr.ItemArray[0].ToString(), dr.ItemArray[1].ToString());
					ret.Add(col);
				}
				con.Close();
				return ret;
			}
		}


		public string ProbarConexion(string servidor, string esquema, string usuario, string password)
		{
			MySqlConnection con = null;
			try
			{
				string connStr = String.Format("Server={0};Database={1};Uid={2};Pwd={3}", 
					new object[]{servidor, esquema, usuario, password});
				con =  new MySqlConnection(connStr);

				using (con)
				{
					con.Open();
				}
			} 
			catch (Exception ex)
			{
				return ex.Message;
			}
			finally
			{
				con.Close();
			}
			return "Ok";
		}
	}
}
