using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using helloWorld2.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using helloWorld2.Data;
using Microsoft.Extensions.Configuration;

namespace helloWorld2
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextDapper dapper = new DataContextDapper(config);
            DataContextEF entityFramework = new DataContextEF(config);

            DateTime rightnow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");

            // Instance of Model
            Computer myComputer = new Computer() {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };

            entityFramework.Add(myComputer);
            entityFramework.SaveChanges();

            string sql = @"INSERT INTO TutorialAppSchema.Computer(
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES ('" + myComputer.Motherboard
            + "','" + myComputer.HasWifi
            + "','" + myComputer.HasLTE
            + "','" + myComputer.ReleaseDate
            + "','" + myComputer.Price
            + "','" + myComputer.VideoCard
            +"')";

            // int result = dapper.ExecuteSqlWithRowCount(sql);
            bool result = dapper.ExecuteSql(sql);

            // Console.WriteLine(result);


            // Selecting and displaying our data using dapper. 
            string sqlSelect = @"SELECT 
            Motherboard,
                Computer.ComputerId,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
            FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            Console.WriteLine("'ComputerId', 'Motherboard','HasWifi','HasLTE',' + 'ReleaseDate','Price','VideoCard'");
            
            foreach(Computer singleComputer in computers){
                Console.WriteLine("'"+ singleComputer.ComputerId
                + "','" + singleComputer.Motherboard
                + "','" + singleComputer.HasWifi
                + "','" + singleComputer.HasLTE
                + "','" + singleComputer.ReleaseDate
                + "','" + singleComputer.Price
                + "','" + singleComputer.VideoCard
                +"'");
            }

            //Selecting and displaying our data using entity framework.

            IEnumerable<Computer>? computersEF = entityFramework.Computer?.ToList<Computer>();

            Console.WriteLine("'ComputerId','Motherboard','HasWifi','HasLTE',' + 'ReleaseDate','Price','VideoCard'");

            if(computersEF != null){
                foreach(Computer singleComputer in computersEF){
                    Console.WriteLine("'"+ singleComputer.ComputerId
                    + "','" + singleComputer.Motherboard
                    + "','" + singleComputer.HasWifi
                    + "','" + singleComputer.HasLTE
                    + "','" + singleComputer.ReleaseDate
                    + "','" + singleComputer.Price
                    + "','" + singleComputer.VideoCard
                    +"'");
                }
            }
        }
    }
}


