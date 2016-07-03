using System.Data;
using Migrator.Framework;

namespace Migrator.Tests.Data
{
	[Migration(1)]
	public class FirstTestMigration : Migration
	{
		override public void Up()
		{
		}
		override public void Down()
		{
		}
	}

	[Migration(2)]
	public class SecondTestMigration : IMigration
	{
		private ITransformationProvider _transformationProvider;

		public string Name
		{
			get { return StringUtils.ToHumanName(GetType().Name); }
		}

		/// <summary>
		/// Defines tranformations to port the database to the current version.
		/// </summary>
		public void Up() {}

		/// <summary>
		/// This is run after the Up transaction has been committed
		/// </summary>
		public virtual void AfterUp()
		{
		}

		/// <summary>
		/// Defines transformations to revert things done in <c>Up</c>.
		/// </summary>
		public void Down() {}

		/// <summary>
		/// This is run after the Down transaction has been committed
		/// </summary>
		public virtual void AfterDown()
		{
		}

		/// <summary>
		/// Represents the database.
		/// <see cref="ITransformationProvider"></see>.
		/// </summary>
		/// <seealso cref="ITransformationProvider">Migration.Framework.ITransformationProvider</seealso>
		public ITransformationProvider Database
		{
			get { return _transformationProvider; }
			set { _transformationProvider = value; }
		}

		/// <summary>
		/// This gets called once on the first migration object.
		/// </summary>
		public virtual void InitializeOnce(string[] args)
		{
		}
	}

	[Migration(20080805151232)]
	public class Acc20160702154759 : Migration
	{
		private const string TableName = "acc";

		public override void Up()
		{
			Database.AddTable(TableName,
//				new Column("acc_id", DbType.String, ColumnProperty.PrimaryKey | ColumnProperty.Unique | ColumnProperty.NotNull | ColumnProperty.Indexed),
				new Column("acc_id", DbType.String, ColumnProperty.PrimaryKey | ColumnProperty.Unique | ColumnProperty.NotNull),
				//				new Column("acc_id", DbType.String, ColumnProperty.NotNull),
				new Column("book_id", DbType.String, ColumnProperty.Null),
				new Column("name", DbType.String, ColumnProperty.Null)
				);

			//			Database.Commit();

			//			string[] pks = {"acc_id"};
			//			Database.AddPrimaryKey(String.Format("PK_{0}", TableName), TableName, pks);

			//			var connectionString = "Data Source=tax_data.db;Version=3";
			//			var provider = ProviderFactory.Create("SQLite", connectionString);
			//			provider.AddPrimaryKey(String.Format("PK_{0}", TableName), TableName, pks);

			//			Database.AddColumn(TableName,"acc_id",DbType.Single,ColumnProperty.PrimaryKey | ColumnProperty.NotNull);
		}

		public override void Down()
		{
			Database.RemoveTable(TableName);
		}
	}
}