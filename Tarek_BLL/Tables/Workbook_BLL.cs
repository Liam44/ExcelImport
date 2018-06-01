using System;
using System.Collections.Generic;
using Tarek_DAL;
using Tarek_DAL.Data;

namespace Tarek_BLL.Tables
{
    public static class Workbook_BLL
    {
        static ExcelDataSet.WorkbooksDataTable Table { get; set; } = WorkBook_DAL.GetDataTable();

        public static int Create(string name, DateTime created, DateTime modified)
        {
            try
            {
                ExcelDataSet.WorkbooksRow row = Table.NewWorkbooksRow();

                DateTime now = DateTime.Now;

                row.Name = name;
                row.Created = created;
                row.Modified = modified;
                row.Imported = now;

                Table.AddWorkbooksRow(row);

                if (!WorkBook_DAL.Update(Table))
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

        public static Dictionary<int, string> Workbooks()
        {
            try
            {
                Dictionary<int, string> result = new Dictionary<int, string>();

                foreach (ExcelDataSet.WorkbooksRow row in Table.Select())
                {
                    result.Add(row.Id, row.Name);
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
                ExcelDataSet.WorkbooksRow row = WorkBook_DAL.GetDataRow(id);

                if (row == null)
                {
                    return true;
                }

                row.Delete();
                return WorkBook_DAL.Update(Table);
            }
            catch
            {
                throw;
            }
        }
    }
}
