using System.Collections.Generic;
using Tarek_DAL;
using Tarek_DAL.Data;

namespace Tarek_BLL.Tables
{
    static class Worksheet_BLL
    {
        static ExcelDataSet.WorksheetsDataTable Table { get; set; } = WorkSheet_DAL.GetDataTable();

        public static int Create(string name, int workbookId)
        {
            try
            {
                ExcelDataSet.WorksheetsRow row = Table.NewWorksheetsRow();

                row.Name = name;
                row.WorkbookId = workbookId;

                Table.AddWorksheetsRow(row);

                if (!WorkSheet_DAL.Update(Table))
                {
                    return Constants.Constants.UNDEFINED_ID;
                }

                return row.Id;
            }
            catch
            {
                throw;
            }
        }

        public static List<int> Worksheets(int workbookId)
        {
            try
            {
                List<int> result = new List<int>();

                foreach (ExcelDataSet.WorksheetsRow row in Table.Select(Table.WorkbookIdColumn.ColumnName + " = " + workbookId.ToString()))
                {
                    result.Add(row.Id);
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                ExcelDataSet.WorksheetsRow row = WorkSheet_DAL.GetDataRow(id);

                if (row == null)
                {
                    return true;
                }

                row.Delete();
                return WorkSheet_DAL.Update(Table);
            }
            catch
            {
                throw;
            }
        }
    }
}
