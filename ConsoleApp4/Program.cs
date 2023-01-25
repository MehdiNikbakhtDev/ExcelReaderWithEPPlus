using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string path = @".\1.xlsx";
            #region [چک موجود بودن فایل اکسل]

            if (!File.Exists(path))
            {
                Console.WriteLine("File Not Exist.");
                return;
            }
            #endregion [چک موجود بودن فایل اکسل]

            #region [شروع خواندن اکسل]
            Stream stream = new StreamReader(path).BaseStream;

            var excel = new ExcelPackage(stream);
            var sheet = excel.Workbook.Worksheets.FirstOrDefault();
            var recordList = new List<DataModel>();
            for (int i = 2; i <= sheet.Dimension.End.Row; i++)
            {
                var record = new DataModel();
                record.sharh = sheet.Cells[i, 1].Value.ToString();
                record.count = sheet.Cells[i, 2].Value.ToString().ToInt();
                record.Amount = sheet.Cells[i, 3].Value.ToString().ToLong();
                record.TotalAmount = sheet.Cells[i, 4].Value.ToString().ToLong();
                if (string.IsNullOrEmpty(record.sharh) || !record.count.HasValue || !record.Amount.HasValue || !record.TotalAmount.HasValue)
                    break;

                recordList.Add(record);


            }
            #endregion [پایان خواندن اکسل]
            #region [چاپ فایل اکسل]
            foreach (var item in recordList)
            {
                Console.WriteLine($"Sharh: {item.sharh }\t Amount: {item.Amount}\t Count: {item.count}\t TotalAmount:{item.TotalAmount}");
            }
            #endregion [چاپ فایل اکسل]
            Console.ReadKey();
        }
    }
}
