using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using HelloWorld2.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Helloword2.Data;

namespace helloWorld2
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContextDapper dapper = new DataContextDapper();

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

            string sql = @"INSERT INTO TutorialAppSchema.Computer(
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES ('"+ myComputer.Motherboard
            + "','" + myComputer.HasWifi
            + "','" + myComputer.HasLTE
            + "','" + myComputer.ReleaseDate
            + "','" + myComputer.Price
            + "','" + myComputer.VideoCard
            +"')";

            // int result = dapper.ExecuteSqlWithRowCount(sql);
            bool result = dapper.ExecuteSql(sql);

            Console.WriteLine(result);

            string sqlSelect = @"SELECT 
            Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
            FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);


            Console.WriteLine("'Motherboard','HasWifi','HasLTE',' + 'ReleaseDate','Price','VideoCard'");
            
            foreach(Computer singleComputer in computers){
                Console.WriteLine("'"+ myComputer.Motherboard
            + "','" + myComputer.HasWifi
            + "','" + myComputer.HasLTE
            + "','" + myComputer.ReleaseDate
            + "','" + myComputer.Price
            + "','" + myComputer.VideoCard
            +"'");
            }
            
            // Console.WriteLine(myComputer.Motherboard);
            // Console.WriteLine(myComputer.HasWifi);
            // Console.WriteLine(myComputer.HasLTE);
            // Console.WriteLine(myComputer.VideoCard);
        }
    }
}


