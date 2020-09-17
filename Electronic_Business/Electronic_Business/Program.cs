using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Data;
using System.Net.WebSockets;

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
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");
                    connection.Open();
                    Console.WriteLine(connection.State);
                    cmd.CommandText = "Search_Customers";
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    
                
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
