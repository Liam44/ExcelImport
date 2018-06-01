using System;
using System.Collections.Generic;
using Tarek_BLL.Tables;
using Tarek_DAL;
using Tarek_DAL.Data;

namespace Tarek_BLL
{
    public class WorkBook
    {
        private ExcelDataSet.WorkbooksRow WorkbookRow { get; set; } = null;

        public int Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Imported { get; set; }

        public Dictionary<string, WorkSheet> WorkSheets { get; set; }

        public bool Save()
        {
            if (WorkbookRow == null)
            {
                Id = Workbook_BLL.Create(Name, Created, Modified);
                WorkbookRow = WorkBook_DAL.GetDataRow(Id);
                Imported = WorkbookRow.Imported;
            }

            foreach (string wsName in WorkSheets.Keys)
            {
                WorkSheet worksheet = WorkSheets[wsName];

                worksheet.Save(Id);

                // Delete all worksheets those are empty
                if (worksheet.Cells.Count == 0) {
                    WorkSheets.Remove(wsName);
                }
            }

            return Id != Constants.Constants.UNDEFINED_ID;
        }

        public WorkBook()
        {
            Id = Constants.Constants.UNDEFINED_ID;
            WorkSheets = new Dictionary<string, WorkSheet>();
        }

        public WorkBook(int id)
        {
            WorkbookRow = WorkBook_DAL.GetDataRow(id);

            Id = id;
            Name = WorkbookRow.Name;
            Size = 0;
            Created = WorkbookRow.Created;
            Modified = WorkbookRow.Modified;
            Imported = WorkbookRow.Imported;
            WorkSheets = new Dictionary<string, WorkSheet>();

            foreach (int worksheetId in Worksheet_BLL.Worksheets(Id))
            {
                WorkSheet workSheet = new WorkSheet(worksheetId);
                WorkSheets.Add(workSheet.Name, workSheet);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
