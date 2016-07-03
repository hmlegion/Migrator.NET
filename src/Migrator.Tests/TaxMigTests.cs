using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Migrator.Tests.Data;
using NUnit.Framework;

namespace Migrator.Tests
{
	[TestFixture]
	class TaxMigTests
	{
		private Migrator _migrator;

		[SetUp]
		public void SetUp()
		{
			var provider = "SQLite";
			var connectionString = "Data Source=tax_data.db;Version=3";
			var asm = Assembly.GetExecutingAssembly();
			_migrator = new Migrator(provider, connectionString, asm, true);

		}

		[Test]
		public void MigTest()
		{
			_migrator.MigrationsTypes.Clear();
			var tp = typeof(Acc20160702154759);
			_migrator.MigrationsTypes.Add(tp);
			var ver = MigrationLoader.GetMigrationVersion(tp);

			//migrator.MigrateToLastVersion();
			_migrator.MigrateTo(ver);

			Console.WriteLine();

			Assert.IsTrue(1.Equals(1));
			
		}
	}
}
