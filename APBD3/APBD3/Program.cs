using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using APBD3.Controllers;
using APBD3.Models;
using CsvHelper.Configuration;
using ServiceStack;
using ServiceStack.Text;
using CsvReader = CsvHelper.CsvReader;

namespace APBD3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };

            using var streamReader = File.OpenText("C:\\Users\\mrdef\\OneDrive\\Рабочий стол\\C#\\cwiczenia3_jd-Hurr1\\apbd-3-stac\\APBD3\\APBD3\\dane.csv");
            using var csvReader = new CsvReader(streamReader, csvConfig);

            var list = new List<Student>();
            string value;
            string[] array;
            bool isCorrect = true;
            int columnEmpty = 0, row = 0;

            while (csvReader.Read())
            {
                for (int i = 0; csvReader.TryGetField<string>(i, out value); i++)
                {

                    array = value.Split(",");
                    for (int j = 0; j < array.Length; j++)
                    {
                        if (array[j] == "" || array[j].Contains("Name"))
                        {
                            isCorrect = false;
                            columnEmpty = j;
                            break;
                        }
                    }

                    if (isCorrect)
                    {
                        list.Add(
                            new Student(array[0], array[1],
                                array[2], array[3],
                                Int32.Parse(Regex.Match(array[4], @"\d+").Value), array[5],
                                array[6], array[7], array[8]
                            )
                        );
                    }

                    row++;

                    isCorrect = true;
                }


            }

            List<Student> uniqueLst = RemoveDuplicatesIterative(list);

            StudentsController.Students = uniqueLst;
            streamReader.Close();
            CreateHostBuilder(args).Build().Run();

            StreamWriter data = new StreamWriter("C:\\Users\\mrdef\\OneDrive\\Рабочий стол\\C#\\cwiczenia3_jd-Hurr1\\apbd-3-stac\\APBD3\\APBD3\\dane.csv");
            var csv = CsvSerializer.SerializeToCsv(StudentsController.Students);
            data.Write(csv);
            data.Close();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        public static List<Student> RemoveDuplicatesIterative(List<Student> items)
        {
            List<Student> result = new List<Student>();
            for (int i = 0; i < items.Count; i++)
            {
                bool duplicate = false;
                for (int z = 0; z < i; z++)
                {
                    if (items[z].CompareTo(items[i]) == 0)
                    {
                        duplicate = true;
                        break;
                    }
                }

                if (!duplicate)
                {
                    result.Add(items[i]);
                }
            }

            return result;
        }
        
        
    }
}

