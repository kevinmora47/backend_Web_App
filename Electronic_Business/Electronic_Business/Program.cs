using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Electronic_Business
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ds = new DataSet();
            var da = new SqlDataAdapter();
            var cmd = new SqlCommand();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "dbis.database.windows.net";
            builder.UserID = "kmorav";
            builder.Password = "Jksbwn66";
            builder.InitialCatalog = "DBIS";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                using (cmd = new SqlCommand("Search_Customers", connection)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    Console.WriteLine(connection.State);
                    string cadena = "";
                    //da.SelectCommand = cmd;
                    //da.Fill(ds);

                    using (var recordset = cmd.ExecuteReader())
                    {
                        while (recordset.Read())
                        {
                            // asignamos los valores del recordset mediante un 
                            // método en el que formateamos los valores recibidos
                            cadena += recordset.ToString();
                            System.Diagnostics.Debug.WriteLine("\nQuery data example:");
                            System.Diagnostics.Debug.WriteLine("CADENA "+cadena);
                            System.Diagnostics.Debug.WriteLine("=========================================\n");
                        }
                        Console.WriteLine(cadena);
                    }

                }
                    
                    
                
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
