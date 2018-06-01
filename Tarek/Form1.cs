using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tarek.Extensions;
using Tarek_BLL;
using Tarek_BLL.Errors;
using Tarek_BLL.Tables;

namespace Tarek
{
    public partial class Form1 : Form
    {
        #region Properties

        private bool Loading { get; set; } = false;
        private WorkBook OpenedFile { get; set; }
        private TextBox TextBox { get; set; }
        private ListViewHitTestInfo EditedListViewItem { get; set; }

        private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();

            TextBox = new TextBox
            {
                Parent = LvWorksheet
            };
            TextBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            TextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TextBox.LostFocus += new EventHandler(TextBox_LostFocus);
            TextBox.Hide();
            LvWorksheet.MouseDoubleClick += new MouseEventHandler(LvWorksheet_MouseDoubleClick);

            EnableSaving(false);
            EnableExport(false);
            EnableDelete(false);
            BtnClose.Enabled = false;
        }

        #endregion

        #region Event handlers

        #region Buttons

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (!UnloadWorkBook())
            {
                return;
            }

            CboFiles.SelectedIndex = -1;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete(true);
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            WaitingMessage.WaitingMessage waitingMessage = null;

            try
            {
                if (BtnSave.Enabled)
                {
                    if (MessageBox.Show("Do you want to save changes before exporting data?" + Environment.NewLine +
                                        "All changes will otherwise be discarded!",
                                        "Usaved changes",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Save();
                    }
                }

                string fileName = Path.Combine(new FileInfo(Application.ExecutablePath.Replace("/", "\\")).Directory.FullName, OpenedFile.Name);

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (ExcelPackage pck = new ExcelPackage(new FileInfo(fileName)))
                {
                    waitingMessage = new WaitingMessage.WaitingMessage("Please wait while data are being exported." + Environment.NewLine +
                                                                       "This may take few seconds",
                                                                       "Exporting data",
                                                                       2);

                    int amountWorksheets = OpenedFile.WorkSheets.Count;
                    int indexWs = 0;

                    foreach (WorkSheet ws in OpenedFile.WorkSheets.Values)
                    {
                        pck.Workbook.Worksheets.Add(ws.Name);

                        int amountCells = ws.Cells.Count;
                        int indexCell = 0;

                        waitingMessage.Controller.ReinitPercent();

                        ExcelWorksheet worksheet = pck.Workbook.Worksheets[ws.Name];
                        foreach (Cell cell in ws.Cells.Values)
                        {
                            worksheet.Cells[cell.Row, ColumnToInt(cell.Column)].Value = cell.CurrentValue;

                            indexCell += 100;
                            waitingMessage.SetPercent(indexCell / amountCells, 1);
                        }

                        indexWs += 100;
                        waitingMessage.SetPercent(indexWs / amountWorksheets);
                    }

                    saveFileDialog.FileName = OpenedFile.Name;
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                    if (fileInfo.Exists)
                    {
                        fileInfo.IsReadOnly = false;
                        fileInfo.Delete();
                    }

                    pck.SaveAs(fileInfo);

                    Process.Start(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                ErrorManagement.Log(ex);
            }
            finally
            {
                if (waitingMessage != null)
                {
                    waitingMessage.CloseMessage();
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        #endregion

        #region ComboBoxes

        private void CboFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loading = true;

            if (!UnloadWorkBook())
            {
                return;
            }

            if (CboFiles.SelectedIndex == -1)
            {
                return;
            }

            OpenedFile = new WorkBook((int)CboFiles.SelectedValue);

            LoadWorkBook();

            Loading = false;
        }

        private void CboWorkSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            WaitingMessage.WaitingMessage waitingMessage = null;

            LvWorksheet.Clear();

            if (CboWorkSheets.SelectedIndex == -1)
            {
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                LvWorksheet.Columns.Add(string.Empty);

                List<string> columns = new List<string> { " " };
                WorkSheet workSheet = OpenedFile.WorkSheets[((ItemData)CboWorkSheets.SelectedItem).Name];

                waitingMessage = new WaitingMessage.WaitingMessage("Loading worksheet",
                                                                   "Please wait while the worksheet is loading." + Environment.NewLine +
                                                                   "This may take few seconds...",
                                                                   0);

                // First loop to create as many columns in the ListView as there were in the Excel file
                foreach (KeyValuePair<int, string> kvp in workSheet.Cells.Keys)
                {
                    string column = kvp.Value;

                    if (!columns.Contains(column))
                    {
                        LvWorksheet.Columns.Add(column, column, -1, HorizontalAlignment.Center, string.Empty);
                        columns.Add(column);
                    }
                }

                // and as many items as there were rows in the file
                Dictionary<int, List<Cell>> cells = workSheet.Cells.Values
                                                                   .GroupBy(c => c.Row)
                                                                   .OrderBy(cgb => cgb.Key)
                                                                   .ToDictionary(cgb => cgb.Key,
                                                                                 cgb => cgb.Select(c => c)
                                                                                           .ToList());

                foreach (int row in cells.Keys)
                {
                    ListViewItem lvi = new ListViewItem(row.ToString());

                    for (int noColumn = 1; noColumn < columns.Count; noColumn += 1)
                    {
                        lvi.SubItems.Add(string.Empty);
                    }

                    LvWorksheet.Items.Add(lvi);

                    foreach (Cell cell in cells[row])
                    {
                        cell.ListViewItem = lvi;
                    }
                }

                // Second loop to actually fill in the ListView with the data read from the Excel file
                int index = 0;
                foreach (Cell cell in workSheet.Cells.Values)
                {
                    ListViewItem lvi = cell.ListViewItem;
                    lvi.SubItems[columns.IndexOf(cell.Column)].Text = cell.OriginalValue;
                    lvi.SubItems[columns.IndexOf(cell.Column)].Tag = cell;
                    lvi.Checked = cell.Included;

                    index += 1;
                }

                // Ajust the columns width
                LvWorksheet.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                LblWSNameTxt.Text = workSheet.Name;
                LblAmountRowsTxt.Text = LvWorksheet.Items.Count.ToString();
                LblOriginalAmountRowsTxt.Text = LvWorksheet.Items[LvWorksheet.Items.Count - 1].Text;
                LblAmountColumnsTxt.Text = (LvWorksheet.Columns.Count - 1).ToString();
            }
            catch (Exception ex)
            {
                ErrorManagement.Log(ex);
            }
            finally
            {
                if (waitingMessage != null)
                {
                    waitingMessage.CloseMessage();
                }

                EnableSaving(false);
                EnableExport(true);
                EnableDelete(true);

                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region Forms

        private void Form1_Load(object sender, EventArgs e)
        {
            CboFiles.DisplayMember = nameof(ItemData.Name);
            CboFiles.ValueMember = nameof(ItemData.Id);

            CboWorkSheets.DisplayMember = nameof(ItemData.Name);
            CboWorkSheets.ValueMember = nameof(ItemData.Id);

            List<ItemData> workbooks = Workbook_BLL.Workbooks().Select(kvp => new ItemData { Id = kvp.Key, Name = kvp.Value }).ToList();
            CboFiles.DataSource = workbooks;
        }

        #endregion

        #region ListViews

        private void LvWorksheet_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach (ListViewItem.ListViewSubItem subitem in e.Item.SubItems)
            {
                Cell cell = (Cell)(subitem.Tag);

                if (cell != null)
                {
                    cell.Included = e.Item.Checked;
                }
            }

            EnableSaving(true);
        }

        private void LvWorksheet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditedListViewItem = LvWorksheet.HitTest(e.X, e.Y);

            // A side-effect of the double click is the change of the checkbox value
            // It thus needs to be "reset" to the previous value
            EditedListViewItem.Item.Checked = !EditedListViewItem.Item.Checked;

            if (EditedListViewItem.SubItem.Tag == null)
            {
                return;
            }

            TextBox.Bounds = EditedListViewItem.SubItem.Bounds;
            TextBox.Text = EditedListViewItem.SubItem.Text;
            TextBox.Show();
            TextBox.Focus();
        }

        #endregion

        #region TextBoxes

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Cancel the previous changes
            if (e.Control && e.KeyCode == Keys.Z)
            {
                TextBox.Text = ((Cell)EditedListViewItem.SubItem.Tag).OriginalValue;

                TextBox_LostFocus(sender, new EventArgs());
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Enter)
            {
                if (e.KeyChar == (char)Keys.Escape)
                {
                    // Avoids the cell value to be edited
                    TextBox.Text = EditedListViewItem.SubItem.Text;
                }

                e.Handled = true;
                TextBox_LostFocus(sender, new EventArgs());
            }
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            EditedListViewItem.SubItem.Text = TextBox.Text;

            Cell cell = (Cell)EditedListViewItem.SubItem.Tag;
            cell.CurrentValue = TextBox.Text;

            if (string.Compare(cell.OriginalValue, TextBox.Text, false) == 0)
            {
                // Restored to original value
                EditedListViewItem.SubItem.Font = new Font(EditedListViewItem.SubItem.Font, FontStyle.Regular);
            }
            else
            {
                EditedListViewItem.Item.UseItemStyleForSubItems = false;
                EditedListViewItem.SubItem.Font = new Font(EditedListViewItem.SubItem.Font, FontStyle.Bold);
            }

            TextBox.Hide();

            EnableSaving(OpenedFile.Id == Tarek_BLL.Constants.Constants.UNDEFINED_ID ||
                         OpenedFile.WorkSheets[((ItemData)CboWorkSheets.SelectedItem).Name]
                                   .Cells
                                   .Where(kvp => string.Compare(kvp.Value.CurrentValue,
                                                                kvp.Value.OriginalValue,
                                                                false) != 0)
                                   .Count() > 0);
        }

        #endregion

        #region MenuItems

        private void TsmiFDelete_Click(object sender, EventArgs e)
        {
            Delete(true);
        }

        private void TsmiFOpen_Click(object sender, EventArgs e)
        {
            WaitingMessage.WaitingMessage waitingMessage = null;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    //Load a dictionary from a file
                    FileInfo file = new FileInfo(fileName);

                    using (var pck = new ExcelPackage(file))
                    {
                        OpenedFile = new WorkBook
                        {
                            Name = file.Name,
                            Created = file.CreationTime,
                            Modified = file.LastWriteTime,
                            Size = file.Length
                        };

                        waitingMessage = new WaitingMessage.WaitingMessage("Opening Excel file",
                                                                           "Please waiting while the file is being parsed." + Environment.NewLine +
                                                                           "This may take few seconds...",
                                                                           2);

                        int amountWorksheets = pck.Workbook.Worksheets.Count;
                        int wsIndex = 0;

                        foreach (ExcelWorksheet ws in pck.Workbook.Worksheets)
                        {
                            WorkSheet workSheet = new WorkSheet { Name = ws.Name };
                            OpenedFile.WorkSheets.Add(ws.Name, workSheet);

                            //Cells only contains references to cells with actual data
                            var allCells = ws.Cells;
                            var cells = allCells.Where(c => c.Value != null)
                                                .OrderBy(c => c.Start.Row)
                                                .ThenBy(c => c.Start.Column);

                            int amountCells = cells.Count();
                            int cellIndex = 0;

                            waitingMessage.Controller.ReinitPercent();

                            foreach (ExcelRangeBase excelCell in cells)
                            {
                                int intColumn = excelCell.Start.Column;
                                string strColumn = ColumnToString(intColumn - 1);
                                int row = excelCell.Start.Row;

                                Cell cell = new Cell
                                {
                                    Included = true,
                                    Column = strColumn,
                                    Row = row,
                                    OriginalValue = allCells[row, intColumn].Value.ToString(),
                                    CurrentValue = allCells[row, intColumn].Value.ToString()
                                };

                                workSheet.Cells.Add(new KeyValuePair<int, string>(row, strColumn), cell);

                                cellIndex += 100;
                                waitingMessage.SetPercent(cellIndex / amountCells, 1);
                            }

                            wsIndex += 100;
                            waitingMessage.SetPercent(wsIndex / amountWorksheets);
                        }

                        waitingMessage.CloseMessage();

                        LoadWorkBook();

                        EnableSaving(true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (waitingMessage != null)
                    {
                        waitingMessage.CloseMessage();
                    }

                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void TsmiFSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void TsmiFQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #endregion

        #region Helpers

        private string ColumnToString(int column)
        {
            var value = "";

            while (column >= letters.Length)
            {
                value += letters[column / letters.Length - 1];
                column = column / letters.Length;
            }

            value += letters[column];

            return value;
        }

        private int ColumnToInt(string column)
        {
            int result = 0;

            foreach (char c in column.Reverse())
            {
                result = result * letters.Length + letters.IndexOf(c) + 1;
            }

            return result;
        }

        private void EnableDelete(bool enabled)
        {
            BtnDelete.Enabled = enabled;
            TsmiFDelete.Enabled = enabled;
        }

        private void EnableExport(bool enabled)
        {
            BtnExport.Enabled = enabled;
        }

        private void EnableSaving(bool enabled)
        {
            BtnSave.Enabled = enabled;
            TsmiFSave.Enabled = enabled;
        }

        private List<ItemData> GetWorkbooks()
        {
            return OpenedFile.WorkSheets.Values.Select(ws => new ItemData { Id = ws.Id, Name = ws.Name }).ToList();
        }

        private void LoadWorkBook()
        {
            LblWBNameTxt.Text = OpenedFile.Name;
            LblSizeTxt.Text = OpenedFile.Size == 0 ? string.Empty : OpenedFile.Size.ToReadableLength();
            LblCreatedTxt.Text = OpenedFile.Created.ToString();
            LblModifiedTxt.Text = OpenedFile.Modified.ToString();
            LblImportedTxt.Text = OpenedFile.Imported?.ToString();
            LblAmountSheetsTxt.Text = OpenedFile.WorkSheets.Count().ToString();

            LoadWorkSheets();

            BtnClose.Enabled = true;
        }

        private void LoadWorkSheets()
        {
            CboWorkSheets.DataSource = GetWorkbooks();
            CboWorkSheets.SelectedIndex = 0;
        }

        private void Delete(bool confirm)
        {
            WaitingMessage.WaitingMessage waitingMessage = null;

            try
            {
                if (confirm &&
                    MessageBox.Show("Are you sure you want to DEFINITIVELY delete the opened workbook?",
                                    "Delete a workbook",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                waitingMessage = new WaitingMessage.WaitingMessage("Please wait while data are being erased from the database." + Environment.NewLine +
                                                                   "This may take few seconds...",
                                                                   "Delete a workbook",
                                                                   0);

                if (!Workbook_BLL.Delete(OpenedFile.Id))
                {
                    return;
                }

                CboFiles.DataSource = GetWorkbooks();

                UnloadWorkBook();
            }
            catch (Exception ex)
            {
                ErrorManagement.Log(ex);
            }
            finally
            {
                if (waitingMessage != null)
                {
                    waitingMessage.CloseMessage();
                }
            }
        }

        private void Save()
        {
            List<ListViewItem> rowsToBeRemoved = OpenedFile.WorkSheets.Values
                                                                      .Select(w => w.Cells.Values
                                                                                          .Where(c => !c.Included)
                                                                                          .Select(c => c.ListViewItem)
                                                                                          .Distinct())
                                                                      .SelectMany(l => l)
                                                                      .ToList();

            int amountDeletedRows = rowsToBeRemoved.Count();

            if (amountDeletedRows > 0)
            {
                if (MessageBox.Show("Are you sure you want to DEFINITIVELY delete unselected row" + (amountDeletedRows > 1 ? "s" : string.Empty) + "?",
                                    "Delete rows",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            OpenedFile.Save();

            if (OpenedFile.WorkSheets.Count == 0)
            {
                if (MessageBox.Show(OpenedFile.Name + " is now empty." + Environment.NewLine +
                                    "Do you want to delete it?",
                                    "Empty workbook",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Delete(false);
                }
            }

            LblImportedTxt.Text = OpenedFile.Imported?.ToString();

            // Deletes from the ListView all cells deleted from the selected worksheet
            foreach (ListViewItem lvi in rowsToBeRemoved)
            {
                lvi.Remove();
            }

            EnableSaving(false);
        }

        private void UnloadWorksheet()
        {
            CboWorkSheets.SelectedIndex = -1;
            LvWorksheet.Clear();

            LblWSNameTxt.Text = string.Empty;
            LblAmountRowsTxt.Text = string.Empty;
            LblOriginalAmountRowsTxt.Text = string.Empty;
            LblAmountColumnsTxt.Text = string.Empty;
        }

        private bool UnloadWorkBook()
        {
            if (Loading)
            {
                return true;
            }

            if (BtnSave.Enabled)
            {
                if (MessageBox.Show("Unsave changes",
                                    "Do you want to save changes before closing the workbook?",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }

                BtnSave_Click(BtnSave, new EventArgs());
            }

            LblWBNameTxt.Text = string.Empty;
            LblSizeTxt.Text = string.Empty;
            LblCreatedTxt.Text = string.Empty;
            LblModifiedTxt.Text = string.Empty;
            LblImportedTxt.Text = string.Empty;
            LblAmountSheetsTxt.Text = string.Empty;

            CboFiles.SelectedIndex = -1;

            UnloadWorksheet();

            CboWorkSheets.DataSource = null;

            OpenedFile = null;

            BtnClose.Enabled = false;
            EnableSaving(false);
            EnableExport(false);
            EnableDelete(false);

            return true;
        }

        #endregion

        #region Listview ItemData

        private class ItemData
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        #endregion
    }
}
