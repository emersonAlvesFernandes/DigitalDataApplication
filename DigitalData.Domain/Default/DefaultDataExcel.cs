using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Default
{
    public class DefaultDataExcel
    {
        public string Name { get; set; }

        public DateTime ImportDate  { get; set; }

        public string Extention { get; set; }

        public List<DefaultData> DefaultDataCollection { get; set; }

        public string Base64ByteArray { get; set; }

        public byte[] ToBytes()
        {
            return Convert.FromBase64String(this.Base64ByteArray);
        }

        private IExcelDataReader GetExcelReader()
        {
            //FileStream stream = File.Open(_path, FileMode.Open, FileAccess.Read);
            Stream stream = new MemoryStream(ToBytes());
                                               
            IExcelDataReader reader = null;
            try
            {
                if (Extention.EndsWith(".xls"))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                if (Extention.EndsWith(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                return reader;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IEnumerable<string> getWorksheetNames()
        {
            var reader = this.GetExcelReader();
            var workbook = reader.AsDataSet();
            var sheets = from DataTable sheet in workbook.Tables select sheet.TableName;            
            return sheets;
        }

        private IEnumerable<DataRow> getData(string sheet, bool firstRowIsColumnNames = true)
        {
            var reader = this.GetExcelReader();
            reader.IsFirstRowAsColumnNames = firstRowIsColumnNames;
            var workSheet = reader.AsDataSet().Tables[sheet];
            var rows = from DataRow a in workSheet.Rows select a;
            return rows;
        }

        public void SetDefaultData()
        {
            var sheet1 = this.getWorksheetNames()
                .FirstOrDefault();

            //var defaultData = this.getData("Sheet1");
            var defaultData = this.getData(sheet1);

            this.DefaultDataCollection = 
                new List<DefaultData>();

            foreach (var row in defaultData)
            {
                var album = new DefaultData()
                {
                    Name = row["Nome"].ToString(),
                    Cpf = row["Cpf"].ToString(),
                    Age = Convert.ToInt32(row["Idade"])
                };

                this.DefaultDataCollection.Add(album);
            }            
        }

    }
}
