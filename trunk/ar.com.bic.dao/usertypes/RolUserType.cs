using System;
using System.Data;
using ar.com.bic.domain.usuario;
using NHibernate;
using NHibernate.SqlTypes;

namespace ar.com.bic.dao.usertypes
{
	/// <summary>
	/// Descripci�n breve de RolUserType.
	/// </summary>
	public class RolUserType : IUserType
	{
		public object NullSafeGet(IDataReader rs, string[] names, object owner)
		{
			String idRol = rs.GetString(rs.GetOrdinal(names[0]));
			return Rol.ObtenerRol(idRol);
		}

		public void NullSafeSet(IDbCommand cmd, object value, int index)
		{
			if (value == null) 
			{
				cmd.Parameters[index] = DBNull.Value;
			} 
			else 
			{
				cmd.Parameters[index] = ((Rol) value).Id;
			}
		}

		public bool IsMutable
		{
			get { return false; }
		}

		public object DeepCopy(object value)
		{
			return value;
		}

		private static SqlType[] SQL_TYPES = {new StringSqlType()};
		public SqlType[] SqlTypes
		{
			get { return SQL_TYPES; }
		}

		public Type ReturnedType
		{
			get { return typeof(Rol); }
		}

		public new bool Equals(object x , object y)
		{
			if (x == y) return true;
			if (x == null || y == null) return false;
			return x.Equals(y);
		}

		public int GetHashCode(object x)
		{
			return x.GetHashCode();
		}
	}
}