using System.Collections.Generic;
using System.Linq;
using Nethereum.Util;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;

namespace Web3ChecksumConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var records = ReadCsv();
            var finalRecords = new List<Records>();
            AddressUtil util = new AddressUtil();
            records.ForEach(x => finalRecords.Add( new Records(util.ConvertToChecksumAddress(x.Record))));
            WriteCsv(finalRecords);

        }

        private static void WriteCsv(List<Records> finalRecords)
        {
            string filePath = @"C:\Users\Potti\source\repos\ConversionFiles\ConvertedAddress.csv";

            if (File.Exists(filePath))
                using (TextWriter writer = new StreamWriter(filePath))
                {
                    CsvWriter writerx = new CsvWriter(writer);
                    writerx.WriteRecords<Records>(finalRecords);
                }
        }

        private static List<Records> ReadCsv()
        {
            string filePath = @"C:\Users\Potti\source\repos\ConversionFiles\address.csv";
            if (File.Exists(filePath))
            {
                using (StreamReader stream = new StreamReader(filePath))
                {
                    CsvReader reader = new CsvReader(stream, new Configuration
                    {
                        TrimOptions = TrimOptions.Trim,
                        HasHeaderRecord = true,
                        HeaderValidated = null
                    });
                    reader.Configuration.RegisterClassMap<RecordMapper>();

                    return reader.GetRecords<Records>().ToList();
                }
            }
            else
            {
                return null;
            }
        }
    }

    class Records
    {
        public string Record { get; set; }

        public Records(string record)
        {
            Record = record;
        }

        public Records()
        {

        }
    }

    sealed class RecordMapper : ClassMap<Records>
    {
        public RecordMapper()
        {
            Map(x => x.Record).Index(0);
        }
    }
}
