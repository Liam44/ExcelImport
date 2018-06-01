using System;
using System.Data.OleDb;
using Tarek_DAL.Data;
using Tarek_DAL.Data.ExcelDataSetTableAdapters;
using Tarek_DAL.Exceptions;

namespace Tarek_DAL
{
    public static class WorkSheet_DAL
    {
        private static C_WorksheetTable Table { get; set; } = null;

        public static ExcelDataSet.WorksheetsDataTable GetDataTable()
        {
            try
            {
                if (Table == null)
                {
                    Table = new C_WorksheetTable();

                    if (!Table.Remplir())
                    {
                        throw new ConnexionDbException("WORKSHEETS");
                    }
                }

                return Table.DataTable;
            }
            catch
            {
                throw;
            }
        }

        public static ExcelDataSet.WorksheetsRow GetDataRow(long worksheetId)
        {
            try
            {
                ExcelDataSet.WorksheetsDataTable table = GetDataTable();

                foreach (ExcelDataSet.WorksheetsRow row in table.Select(table.IdColumn.ColumnName + " = " + worksheetId.ToString()))
                {
                    return row;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Update(ExcelDataSet.WorksheetsDataTable table)
        {
            try
            {
                WorksheetsTableAdapter tableAdapter = new WorksheetsTableAdapter();

                tableAdapter.Update(table);
                return true;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Update(ExcelDataSet.WorksheetsRow row)
        {
            try
            {
                WorksheetsTableAdapter adapter = new WorksheetsTableAdapter();

                adapter.Update(row);
                return true;
            }
            catch
            {
                throw;
            }
        }

        private class C_WorksheetTable
        {
            public ExcelDataSet.WorksheetsDataTable DataTable { get; private set; }
            private WorksheetsTableAdapter TableAdapter { get; set; }

            public bool Remplir()
            {
                try
                {
                    TableAdapter.Fill(DataTable);
                    return true;
                }
                catch
                {
                    throw;
                }
            }

            public C_WorksheetTable()
            {
                DataTable = new ExcelDataSet.WorksheetsDataTable();
                TableAdapter = new WorksheetsTableAdapter();
            }
        }
    }
}
