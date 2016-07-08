
using System;
using System.Data;
using Migrator.Framework;

namespace Migrator.Providers.SQLite
{
	public class SQLiteDialect : Dialect
	{
	    public SQLiteDialect()
	    {
	        RegisterColumnType(DbType.Binary, "BLOB");
            RegisterColumnType(DbType.Byte, "INTEGER");
            RegisterColumnType(DbType.Int16, "INTEGER");
            RegisterColumnType(DbType.Int32, "INTEGER");
            RegisterColumnType(DbType.Int64, "INTEGER");
            RegisterColumnType(DbType.SByte, "INTEGER");
            RegisterColumnType(DbType.UInt16, "INTEGER");
            RegisterColumnType(DbType.UInt32, "INTEGER");
            RegisterColumnType(DbType.UInt64, "INTEGER");
            RegisterColumnType(DbType.Currency, "REAL");
			RegisterColumnType(DbType.Decimal, "REAL");
			RegisterColumnType(DbType.Double, "REAL");
			RegisterColumnType(DbType.Single, "REAL");
			RegisterColumnType(DbType.VarNumeric, "REAL");
            RegisterColumnType(DbType.String, "TEXT");
            RegisterColumnType(DbType.AnsiStringFixedLength, "TEXT");
            RegisterColumnType(DbType.StringFixedLength, "TEXT");
            RegisterColumnType(DbType.DateTime, "DATETIME");
            RegisterColumnType(DbType.Time, "DATETIME");
            RegisterColumnType(DbType.Boolean, "INTEGER");
            RegisterColumnType(DbType.Guid, "UNIQUEIDENTIFIER");
            
            RegisterProperty(ColumnProperty.Identity, "AUTOINCREMENT");
        }

		public override ITransformationProvider GetTransformationProvider(Dialect dialect, string connectionString)
		{
			return new SQLiteTransformationProvider(dialect, connectionString);
		}
        
        public override bool NeedsNotNullForIdentity
        {
            get { return true; }
        }
    }
}