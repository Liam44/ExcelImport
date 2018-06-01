using System.Windows.Forms;
using Tarek_BLL.Tables;
using Tarek_DAL;
using Tarek_DAL.Data;

namespace Tarek_BLL
{
    public class Cell
    {
        private ExcelDataSet.CellsRow CellRow { get; set; } = null;

        public int Id { get; set; }
        public bool Included { get; set; }
        public string Column { get; set; }
        public int Row { get; set; }
        public string OriginalValue { get; set; }
        public string CurrentValue { get; set; }
        public int WorksheetId { get; set; }

        public ListViewItem ListViewItem { get; set; }

        internal bool Save(int worksheetId)
        {
            bool result = false;

            if (CellRow == null)
            {
                Id = Cell_BLL.Create(Column, Row, CurrentValue, worksheetId);
                CellRow = Cell_DAL.GetDataRow(Id);

                result = true;
            }
            else if (Included)
            {
                CellRow.Value = CurrentValue;
                result = Cell_DAL.Update(CellRow);
            }
            else
            {
                result = Cell_BLL.Delete(Id);
            }

            OriginalValue = CurrentValue;

            return result;
        }

        public Cell()
        {

        }

        public Cell(int id)
        {
            CellRow = Cell_DAL.GetDataRow(id);

            Id = id;
            Column = CellRow.Column;
            Row = CellRow.Row;
            CurrentValue = CellRow.Value;
            OriginalValue = CellRow.Value;
            WorksheetId = CellRow.WorksheetId;
            Included = true;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1} - {2}",
                                 Row.ToString(),
                                 Column,
                                 CurrentValue);
        }
    }
}
