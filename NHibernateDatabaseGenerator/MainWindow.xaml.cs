﻿using System.Reflection;
using System.Windows;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace NHibernateDatabaseGenerator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnOpenDialog_Click(object sender, RoutedEventArgs e)
		{
			// Configure open file dialog box
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
				{
					DefaultExt = ".dll",
					Filter = "Assemblies (.dll)|*.dll"
				};

			// Show open file dialog box
			bool? result = dlg.ShowDialog();

			// Process open file dialog box results
			if (result == true)
			{
				// Open document
				txtFileName.Text = dlg.FileName;
			}

		}

		private void btnGenerateDBScript_Click(object sender, RoutedEventArgs e)
		{
			Assembly assembly = Assembly.LoadFrom(txtFileName.Text);

			IPersistenceConfigurer databaseConfig = null;
			string fileName = "Domain Database Script - {0}.sql";

			if (rdbSqlServer.IsChecked != null)
				if (rdbSqlServer.IsChecked.Value)
				{
					databaseConfig = MsSqlConfiguration.MsSql2005;
					fileName = string.Format(fileName, "Sql Server 2005");
				}
				else if (rdbOracle.IsChecked != null)
					if (rdbOracle.IsChecked.Value)
					{
						databaseConfig = OracleDataClientConfiguration.Oracle9;
						fileName = string.Format(fileName, "Oracle 9g");
					}

			Fluently.Configure()
				.Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
				.Database(databaseConfig)//.ConnectionString("Data Source=.\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True"))
				.ExposeConfiguration(config =>
				{
					SchemaExport se = new SchemaExport(config);
					se.SetOutputFile(fileName);
					se.Create(false, false);
					MessageBox.Show(string.Format("Script successful created! See the '{0}' file.", fileName));
				}).BuildConfiguration();
		}
	}
}
