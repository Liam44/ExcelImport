using System.Collections.Generic;
using Tarek_DAL;
using Tarek_DAL.Data;

namespace Tarek_BLL.Tables
{
    static class Cell_BLL
    {
        static ExcelDataSet.CellsDataTable Table { get; set; } = Cell_DAL.GetDataTable();

        public static int Create(string column, int row, string value, int worksheetId)
        {
            try
            {
                ExcelDataSet.CellsRow cellRow = Table.NewCellsRow();

                cellRow.Column = column;
                cellRow.Row = row;
                cellRow.Value = value;
                cellRow.WorksheetId = worksheetId;

                Table.AddCellsRow(cellRow);

                if (!Cell_DAL.Update(Table))
                {
                    return Constants.Constants.UNDEFINED_ID;
                }

                return cellRow.Id;
            }
            catch
            {
                throw;
            }
        }

        public static List<int> Cells(int worksheetId)
        {
            try
            {
                List<int> result = new List<int>();

                foreach (ExcelDataSet.CellsRow row in Table.Select(Table.WorksheetIdColumn.ColumnName + " = " + worksheetId.ToString()))
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
                ExcelDataSet.CellsRow row = Cell_DAL.GetDataRow(id);

                if (row == null)
                {
                    return true;
                }

                row.Delete();
                return Cell_DAL.Update(Table);
            }
            catch
            {
                throw;
            }
        }
    }
}
