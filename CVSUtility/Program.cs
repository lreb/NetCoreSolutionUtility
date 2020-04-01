using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CVSUtility
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				using (var reader = new StreamReader(@"C:\Users\1421574\Downloads\gdl_report.csv", System.Text.Encoding.Default))
				using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
				{
					csv.Configuration.Delimiter = "	";
					var good = new List<CSVFormat>();
					var bad = new List<string>();
					var isRecordBad = false;
					csv.Configuration.BadDataFound = context =>
					{
						isRecordBad = true;
						bad.Add(context.RawRecord);
					};
					var records = csv.GetRecords<CSVFormat>().ToList();
					Console.WriteLine(JsonConvert.SerializeObject(records));
					
					Console.ReadLine();
				}
			}
			catch (UnauthorizedAccessException e)
			{
				throw new Exception(e.Message);
			}
			catch (FieldValidationException e)
			{
				throw new Exception(e.Message);
			}
			catch (CsvHelperException e)
			{
				throw new Exception(e.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				Console.ReadLine();
				throw new Exception(e.Message);
			}
			
		}
	}
}
