using System;
using System.Data.OleDb;
using Tarek_DAL.Data;
using Tarek_DAL.Data.ExcelDataSetTableAdapters;
using Tarek_DAL.Exceptions;

namespace Tarek_DAL
{
    public static class Cell_DAL
    {
        private static C_CellTable Table { get; set; } = null;

        public static ExcelDataSet.CellsDataTable GetDataTable()
        {
            try
            {
                if (Table == null)
                {
                    Table = new C_CellTable();

                    if (!Table.Remplir())
                    {
                        throw new ConnexionDbException("CELLS");
                    }
                }

                return Table.DataTable;
            }
            catch
            {
                throw;
            }
        }

        public static ExcelDataSet.CellsRow GetDataRow(int cellId)
        {
            try
            {
                ExcelDataSet.CellsDataTable table = GetDataTable();

                foreach (ExcelDataSet.CellsRow row in table.Select(table.IdColumn.ColumnName + " = " + cellId.ToString()))
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

        public static bool Update(ExcelDataSet.CellsDataTable table)
        {
            try
            {
                CellsTableAdapter tableAdapter = new CellsTableAdapter();

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

        public static bool Update(ExcelDataSet.CellsRow row)
        {
            try
            {
                CellsTableAdapter adapter = new CellsTableAdapter();

                adapter.Update(row);
                return true;
            }
            catch
            {
                throw;
            }
        }

        private class C_CellTable
        {
            public ExcelDataSet.CellsDataTable DataTable { get; private set; }
            private CellsTableAdapter TableAdapter { get; set; }

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

            public C_CellTable()
            {
                DataTable = new ExcelDataSet.CellsDataTable();
                TableAdapter = new CellsTableAdapter();
            }
        }
    }
}
