using System.Collections.Generic;
using System.Linq;
using Tarek_BLL.Tables;
using Tarek_DAL;
using Tarek_DAL.Data;

namespace Tarek_BLL
{
    public class WorkSheet
    {
        private ExcelDataSet.WorksheetsRow WorksheetRow { get; set; } = null;

        public int Id { get; set; }
        public string Name { get; set; }
        public long WorkbookId { get; set; }
        public Dictionary<KeyValuePair<int, string>, Cell> Cells { get; set; }

        public bool Save(int workbookId)
        {
            if (WorksheetRow == null)
            {
                Id = Worksheet_BLL.Create(Name, workbookId);
                WorksheetRow = WorkSheet_DAL.GetDataRow(Id);
                WorkbookId = WorksheetRow.WorkbookId;
            }

            foreach (KeyValuePair<int, string> kvp in Cells.Keys.ToList())
            {
                Cell cell = Cells[kvp];

                if (!cell.Save(Id))
                    return false;

                if (!cell.Included)
                {
                    Cells.Remove(kvp);
                }
            }

            return Id != Constants.Constants.UNDEFINED_ID;
        }

        public WorkSheet()
        {
            Cells = new Dictionary<KeyValuePair<int, string>, Cell>();
        }

        public WorkSheet(int worksheetId)
        {
            WorksheetRow = WorkSheet_DAL.GetDataRow(worksheetId);

            Id = worksheetId;
            Name = WorksheetRow.Name;
            WorkbookId = WorksheetRow.WorkbookId;
            Cells = new Dictionary<KeyValuePair<int, string>, Cell>();

            foreach (int cellId in Cell_BLL.Cells(Id))
            {
                Cell cell = new Cell(cellId);
                Cells.Add(new KeyValuePair<int, string>(cell.Row, cell.Column), cell);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
