using System;
using System.Data.OleDb;
using Tarek_DAL.Data;
using Tarek_DAL.Data.ExcelDataSetTableAdapters;
using Tarek_DAL.Exceptions;

namespace Tarek_DAL
{
    public static class WorkBook_DAL
    {
        private static C_WorkbookTable Table { get; set; } = null;

        public static ExcelDataSet.WorkbooksDataTable GetDataTable()
        {
            try
            {
                if (Table == null)
                {
                    Table = new C_WorkbookTable();

                    if (!Table.Remplir())
                    {
                        throw new ConnexionDbException("WORKBOOKS");
                    }
                }

                return Table.DataTable;
            }
            catch
            {
                throw;
            }
        }

        public static ExcelDataSet.WorkbooksRow GetDataRow(long workbookId)
        {
            try
            {
                ExcelDataSet.WorkbooksDataTable table = GetDataTable();

                foreach (ExcelDataSet.WorkbooksRow row in table.Select(table.IdColumn.ColumnName + " = " + workbookId.ToString()))
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

        public static bool Update(ExcelDataSet.WorkbooksDataTable    table)
        {
            try
            {
                Table.TableAdapter.Update(table);
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

        public static bool Update(ExcelDataSet.WorkbooksRow row)
        {
            try
            {
                WorkbooksTableAdapter adapter = new WorkbooksTableAdapter();

                adapter.Update(row);
                return true;
            }
            catch
            {
                throw;
            }
        }

        private class C_WorkbookTable
        {
            public ExcelDataSet.WorkbooksDataTable DataTable { get; private set; }
            public WorkbooksTableAdapter TableAdapter { get; set; }

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

            public C_WorkbookTable()
            {
                DataTable = new ExcelDataSet.WorkbooksDataTable();
                TableAdapter = new WorkbooksTableAdapter();
            }
        }
    }
}
