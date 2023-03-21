using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using helloWorld2.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using helloWorld2.Data;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AutoMapper;

namespace helloWorld2
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            // ------- Using System and the JsonPropertyName attribute ------//
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextDapper dapper = new DataContextDapper(config);

            string computersJson = File.ReadAllText("ComputersSnake.json");

            // JsonSerializerOptions options = new JsonSerializerOptions(){
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            // };

            //Deserializing with System
            IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);

            if(computersSystem != null)
            {
                Console.WriteLine("JsonPropertyNameAttribute Method");
                Console.WriteLine(computersSystem.Count());
                // foreach(Computer computer in computersSystem){
                //     Console.WriteLine(computer.Motherboard);
                // }
            }

            // ------- End Using System and the JsonPropertyName attribute ------//


            // ------- Using Auto Mapper ------//

            Mapper mapper = new Mapper(new MapperConfiguration((cfg)=> {
                cfg.CreateMap<ComputerSnake, Computer>()
                    .ForMember(destination => destination.ComputerId, options => 
                    options.MapFrom(source => source.computer_id))

                    .ForMember(destination => destination.CPUCores, options => 
                    options.MapFrom(source => source.cpu_cores))

                    .ForMember(destination => destination.HasLTE, options => 
                    options.MapFrom(source => source.has_lte))

                    .ForMember(destination => destination.HasWifi, options => 
                    options.MapFrom(source => source.has_wifi))

                    .ForMember(destination => destination.Motherboard, options => 
                    options.MapFrom(source => source.motherboard))

                    .ForMember(destination => destination.VideoCard, options => 
                    options.MapFrom(source => source.video_card))

                    .ForMember(destination => destination.ReleaseDate, options => 
                    options.MapFrom(source => source.release_date))

                    .ForMember(destination => destination.Price, options => 
                    options.MapFrom(source => source.price));
            }));

            JsonSerializerOptions options = new JsonSerializerOptions(){
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            // //Deserializing with System
            IEnumerable<ComputerSnake>? computersSnSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computersJson, options);

            if(computersSnSystem != null)
            {
                IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computersSnSystem);

                Console.WriteLine("AutoMapper Method");
                Console.WriteLine(computerResult.Count());
                // foreach(Computer computer in computerResult){
                //     Console.WriteLine(computer.Motherboard);
                // }
            }

            // //Deserializing with System
            // IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);

            // if(computersSystem != null)
            // {
            //     foreach(Computer computer in computersSystem){
            //         Console.WriteLine(computer.Motherboard);
            //     }
            // }

            // //Deserializing with newtonSoft
            // IEnumerable<Computer>? computersNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            // //Deserializing with System
            // IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

            // if(computersNewtonSoft != null) {
            //     foreach(Computer computer in computersNewtonSoft){
            //         // Console.WriteLine(computer.Motherboard);

            //         string sql = @"INSERT INTO TutorialAppSchema.Computer(
            //             Motherboard,
            //             HasWifi,
            //             HasLTE,
            //             ReleaseDate,
            //             Price,
            //             VideoCard   
            //         ) VALUES ( '" + escapeSingleQuote(computer.Motherboard)
            //         + "','" + computer.HasWifi
            //         + "','" + computer.HasLTE
            //         + "','" + computer.ReleaseDate
            //         + "','" + computer.Price
            //         + "','" + escapeSingleQuote(computer.VideoCard)
            //         + "')";

            //         dapper.ExecuteSql(sql);
            //     }
            // }

            // JsonSerializerSettings settings = new JsonSerializerSettings()
            // {
            //     ContractResolver = new CamelCasePropertyNamesContractResolver()
            // };


            // //Serializing with newtonsoft
            // string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersNewtonSoft, settings);

            // File.WriteAllText("computersCopyNewtonsoft.txt", computersCopyNewtonsoft);


            // //Serialize with System
            // string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);

            // File.WriteAllText("computersCopySystem.txt", computersCopySystem);

        }

        static string escapeSingleQuote(string input){
            string output = input.Replace("'", "''");
            
            return output;
        }
    }
}


