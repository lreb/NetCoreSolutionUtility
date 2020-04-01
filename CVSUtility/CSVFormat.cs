using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVSUtility
{
	internal class CSVFormat
	{
        public string Requestor { get; set; }
        
        public DateTime? CreatedOn { get; set; }
        [Name("FIA Number")]
        public string FIANumber { get; set; }
        
        [Name("Impact Value")]
        public decimal? ImpactValue { get; set; }
    }
}
