namespace Tarek
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.TsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiFOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiFSave = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiFQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.GbWorkbook = new System.Windows.Forms.GroupBox();
            this.LblModified = new System.Windows.Forms.Label();
            this.LblCreated = new System.Windows.Forms.Label();
            this.LblImported = new System.Windows.Forms.Label();
            this.LblAmountSheets = new System.Windows.Forms.Label();
            this.LblSize = new System.Windows.Forms.Label();
            this.LblModifiedTxt = new System.Windows.Forms.Label();
            this.LblImportedTxt = new System.Windows.Forms.Label();
            this.LblCreatedTxt = new System.Windows.Forms.Label();
            this.LblAmountSheetsTxt = new System.Windows.Forms.Label();
            this.LblSizeTxt = new System.Windows.Forms.Label();
            this.LblWBNameTxt = new System.Windows.Forms.Label();
            this.LblWBName = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.CboFiles = new System.Windows.Forms.ComboBox();
            this.CboWorkSheets = new System.Windows.Forms.ComboBox();
            this.LblWorkSheets = new System.Windows.Forms.Label();
            this.LvWorksheet = new System.Windows.Forms.ListView();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LblSavedFiles = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            this.GbWorksheet = new System.Windows.Forms.GroupBox();
            this.LblWSName = new System.Windows.Forms.Label();
            this.LblAmountRows = new System.Windows.Forms.Label();
            this.LblOriginalAmountRows = new System.Windows.Forms.Label();
            this.LblAmountColumns = new System.Windows.Forms.Label();
            this.LblOriginalAmountRowsTxt = new System.Windows.Forms.Label();
            this.LblAmountColumnsTxt = new System.Windows.Forms.Label();
            this.LblAmountRowsTxt = new System.Windows.Forms.Label();
            this.LblWSNameTxt = new System.Windows.Forms.Label();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.TsmiFDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuBar.SuspendLayout();
            this.GbWorkbook.SuspendLayout();
            this.GbWorksheet.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiFile});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1139, 24);
            this.MenuBar.TabIndex = 0;
            this.MenuBar.Text = "File";
            // 
            // TsmiFile
            // 
            this.TsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiFOpen,
            this.TsmiFDelete,
            this.TsmiFSave,
            this.toolStripSeparator1,
            this.TsmiFQuit});
            this.TsmiFile.Name = "TsmiFile";
            this.TsmiFile.Size = new System.Drawing.Size(37, 20);
            this.TsmiFile.Text = "&File";
            // 
            // TsmiFOpen
            // 
            this.TsmiFOpen.Name = "TsmiFOpen";
            this.TsmiFOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.TsmiFOpen.Size = new System.Drawing.Size(180, 22);
            this.TsmiFOpen.Text = "&Open";
            this.TsmiFOpen.Click += new System.EventHandler(this.TsmiFOpen_Click);
            // 
            // TsmiFSave
            // 
            this.TsmiFSave.Name = "TsmiFSave";
            this.TsmiFSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.TsmiFSave.Size = new System.Drawing.Size(180, 22);
            this.TsmiFSave.Text = "&Save";
            this.TsmiFSave.Click += new System.EventHandler(this.TsmiFSave_Click);
            // 
            // TsmiFQuit
            // 
            this.TsmiFQuit.Name = "TsmiFQuit";
            this.TsmiFQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.TsmiFQuit.Size = new System.Drawing.Size(180, 22);
            this.TsmiFQuit.Text = "&Quit";
            this.TsmiFQuit.Click += new System.EventHandler(this.TsmiFQuit_Click);
            // 
            // GbWorkbook
            // 
            this.GbWorkbook.Controls.Add(this.LblModified);
            this.GbWorkbook.Controls.Add(this.LblCreated);
            this.GbWorkbook.Controls.Add(this.LblImported);
            this.GbWorkbook.Controls.Add(this.LblAmountSheets);
            this.GbWorkbook.Controls.Add(this.LblSize);
            this.GbWorkbook.Controls.Add(this.LblModifiedTxt);
            this.GbWorkbook.Controls.Add(this.LblImportedTxt);
            this.GbWorkbook.Controls.Add(this.LblCreatedTxt);
            this.GbWorkbook.Controls.Add(this.LblAmountSheetsTxt);
            this.GbWorkbook.Controls.Add(this.LblSizeTxt);
            this.GbWorkbook.Controls.Add(this.LblWBNameTxt);
            this.GbWorkbook.Controls.Add(this.LblWBName);
            this.GbWorkbook.Location = new System.Drawing.Point(12, 27);
            this.GbWorkbook.Name = "GbWorkbook";
            this.GbWorkbook.Size = new System.Drawing.Size(362, 127);
            this.GbWorkbook.TabIndex = 1;
            this.GbWorkbook.TabStop = false;
            this.GbWorkbook.Text = "File details";
            // 
            // LblModified
            // 
            this.LblModified.AutoSize = true;
            this.LblModified.Location = new System.Drawing.Point(6, 73);
            this.LblModified.Name = "LblModified";
            this.LblModified.Size = new System.Drawing.Size(72, 13);
            this.LblModified.TabIndex = 6;
            this.LblModified.Text = "Last modified:";
            // 
            // LblCreated
            // 
            this.LblCreated.AutoSize = true;
            this.LblCreated.Location = new System.Drawing.Point(6, 54);
            this.LblCreated.Name = "LblCreated";
            this.LblCreated.Size = new System.Drawing.Size(73, 13);
            this.LblCreated.TabIndex = 4;
            this.LblCreated.Text = "Creation date:";
            // 
            // LblImported
            // 
            this.LblImported.AutoSize = true;
            this.LblImported.Location = new System.Drawing.Point(6, 92);
            this.LblImported.Name = "LblImported";
            this.LblImported.Size = new System.Drawing.Size(51, 13);
            this.LblImported.TabIndex = 8;
            this.LblImported.Text = "Imported:";
            // 
            // LblAmountSheets
            // 
            this.LblAmountSheets.AutoSize = true;
            this.LblAmountSheets.Location = new System.Drawing.Point(6, 111);
            this.LblAmountSheets.Name = "LblAmountSheets";
            this.LblAmountSheets.Size = new System.Drawing.Size(92, 13);
            this.LblAmountSheets.TabIndex = 10;
            this.LblAmountSheets.Text = "Amount of sheets:";
            // 
            // LblSize
            // 
            this.LblSize.AutoSize = true;
            this.LblSize.Location = new System.Drawing.Point(6, 35);
            this.LblSize.Name = "LblSize";
            this.LblSize.Size = new System.Drawing.Size(47, 13);
            this.LblSize.TabIndex = 2;
            this.LblSize.Text = "File size:";
            // 
            // LblModifiedTxt
            // 
            this.LblModifiedTxt.AutoSize = true;
            this.LblModifiedTxt.Location = new System.Drawing.Point(104, 73);
            this.LblModifiedTxt.Name = "LblModifiedTxt";
            this.LblModifiedTxt.Size = new System.Drawing.Size(0, 13);
            this.LblModifiedTxt.TabIndex = 7;
            // 
            // LblImportedTxt
            // 
            this.LblImportedTxt.AutoSize = true;
            this.LblImportedTxt.Location = new System.Drawing.Point(104, 92);
            this.LblImportedTxt.Name = "LblImportedTxt";
            this.LblImportedTxt.Size = new System.Drawing.Size(0, 13);
            this.LblImportedTxt.TabIndex = 9;
            // 
            // LblCreatedTxt
            // 
            this.LblCreatedTxt.AutoSize = true;
            this.LblCreatedTxt.Location = new System.Drawing.Point(104, 54);
            this.LblCreatedTxt.Name = "LblCreatedTxt";
            this.LblCreatedTxt.Size = new System.Drawing.Size(0, 13);
            this.LblCreatedTxt.TabIndex = 5;
            // 
            // LblAmountSheetsTxt
            // 
            this.LblAmountSheetsTxt.AutoSize = true;
            this.LblAmountSheetsTxt.Location = new System.Drawing.Point(104, 111);
            this.LblAmountSheetsTxt.Name = "LblAmountSheetsTxt";
            this.LblAmountSheetsTxt.Size = new System.Drawing.Size(0, 13);
            this.LblAmountSheetsTxt.TabIndex = 11;
            // 
            // LblSizeTxt
            // 
            this.LblSizeTxt.AutoSize = true;
            this.LblSizeTxt.Location = new System.Drawing.Point(104, 35);
            this.LblSizeTxt.Name = "LblSizeTxt";
            this.LblSizeTxt.Size = new System.Drawing.Size(0, 13);
            this.LblSizeTxt.TabIndex = 3;
            // 
            // LblWBNameTxt
            // 
            this.LblWBNameTxt.AutoSize = true;
            this.LblWBNameTxt.Location = new System.Drawing.Point(104, 16);
            this.LblWBNameTxt.Name = "LblWBNameTxt";
            this.LblWBNameTxt.Size = new System.Drawing.Size(0, 13);
            this.LblWBNameTxt.TabIndex = 1;
            // 
            // LblWBName
            // 
            this.LblWBName.AutoSize = true;
            this.LblWBName.Location = new System.Drawing.Point(6, 16);
            this.LblWBName.Name = "LblWBName";
            this.LblWBName.Size = new System.Drawing.Size(55, 13);
            this.LblWBName.TabIndex = 0;
            this.LblWBName.Text = "File name:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.xls;*.xlsx";
            this.openFileDialog.Filter = "Excel files|*.xls;*.xlsx";
            this.openFileDialog.Title = "Please select a file to be imported:";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.OverwritePrompt = false;
            // 
            // CboFiles
            // 
            this.CboFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboFiles.FormattingEnabled = true;
            this.CboFiles.Location = new System.Drawing.Point(12, 284);
            this.CboFiles.Name = "CboFiles";
            this.CboFiles.Size = new System.Drawing.Size(362, 21);
            this.CboFiles.TabIndex = 4;
            this.CboFiles.SelectedIndexChanged += new System.EventHandler(this.CboFiles_SelectedIndexChanged);
            // 
            // CboWorkSheets
            // 
            this.CboWorkSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboWorkSheets.FormattingEnabled = true;
            this.CboWorkSheets.Location = new System.Drawing.Point(462, 27);
            this.CboWorkSheets.Name = "CboWorkSheets";
            this.CboWorkSheets.Size = new System.Drawing.Size(224, 21);
            this.CboWorkSheets.TabIndex = 6;
            this.CboWorkSheets.SelectedIndexChanged += new System.EventHandler(this.CboWorkSheets_SelectedIndexChanged);
            // 
            // LblWorkSheets
            // 
            this.LblWorkSheets.AutoSize = true;
            this.LblWorkSheets.Location = new System.Drawing.Point(389, 30);
            this.LblWorkSheets.Name = "LblWorkSheets";
            this.LblWorkSheets.Size = new System.Drawing.Size(67, 13);
            this.LblWorkSheets.TabIndex = 5;
            this.LblWorkSheets.Text = "Worksheets:";
            // 
            // LvWorksheet
            // 
            this.LvWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvWorksheet.CheckBoxes = true;
            this.LvWorksheet.FullRowSelect = true;
            this.LvWorksheet.GridLines = true;
            this.LvWorksheet.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LvWorksheet.HideSelection = false;
            this.LvWorksheet.Location = new System.Drawing.Point(380, 54);
            this.LvWorksheet.MultiSelect = false;
            this.LvWorksheet.Name = "LvWorksheet";
            this.LvWorksheet.Size = new System.Drawing.Size(747, 440);
            this.LvWorksheet.TabIndex = 7;
            this.LvWorksheet.UseCompatibleStateImageBehavior = false;
            this.LvWorksheet.View = System.Windows.Forms.View.Details;
            this.LvWorksheet.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LvWorksheet_ItemChecked);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(809, 500);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LblSavedFiles
            // 
            this.LblSavedFiles.AutoSize = true;
            this.LblSavedFiles.Location = new System.Drawing.Point(12, 268);
            this.LblSavedFiles.Name = "LblSavedFiles";
            this.LblSavedFiles.Size = new System.Drawing.Size(62, 13);
            this.LblSavedFiles.TabIndex = 3;
            this.LblSavedFiles.Text = "Saved files:";
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.Location = new System.Drawing.Point(1052, 500);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 11;
            this.BtnClose.Text = "&Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExport.Location = new System.Drawing.Point(890, 500);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(75, 23);
            this.BtnExport.TabIndex = 9;
            this.BtnExport.Text = "&Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // GbWorksheet
            // 
            this.GbWorksheet.Controls.Add(this.LblWSNameTxt);
            this.GbWorksheet.Controls.Add(this.LblAmountRowsTxt);
            this.GbWorksheet.Controls.Add(this.LblAmountColumnsTxt);
            this.GbWorksheet.Controls.Add(this.LblOriginalAmountRowsTxt);
            this.GbWorksheet.Controls.Add(this.LblAmountColumns);
            this.GbWorksheet.Controls.Add(this.LblOriginalAmountRows);
            this.GbWorksheet.Controls.Add(this.LblAmountRows);
            this.GbWorksheet.Controls.Add(this.LblWSName);
            this.GbWorksheet.Location = new System.Drawing.Point(12, 160);
            this.GbWorksheet.Name = "GbWorksheet";
            this.GbWorksheet.Size = new System.Drawing.Size(362, 105);
            this.GbWorksheet.TabIndex = 2;
            this.GbWorksheet.TabStop = false;
            this.GbWorksheet.Text = "Selected worksheet";
            // 
            // LblWSName
            // 
            this.LblWSName.AutoSize = true;
            this.LblWSName.Location = new System.Drawing.Point(7, 20);
            this.LblWSName.Name = "LblWSName";
            this.LblWSName.Size = new System.Drawing.Size(38, 13);
            this.LblWSName.TabIndex = 0;
            this.LblWSName.Text = "Name:";
            // 
            // LblAmountRows
            // 
            this.LblAmountRows.AutoSize = true;
            this.LblAmountRows.Location = new System.Drawing.Point(7, 43);
            this.LblAmountRows.Name = "LblAmountRows";
            this.LblAmountRows.Size = new System.Drawing.Size(83, 13);
            this.LblAmountRows.TabIndex = 2;
            this.LblAmountRows.Text = "Amount of rows:";
            // 
            // LblOriginalAmountRows
            // 
            this.LblOriginalAmountRows.AutoSize = true;
            this.LblOriginalAmountRows.Location = new System.Drawing.Point(7, 66);
            this.LblOriginalAmountRows.Name = "LblOriginalAmountRows";
            this.LblOriginalAmountRows.Size = new System.Drawing.Size(120, 13);
            this.LblOriginalAmountRows.TabIndex = 4;
            this.LblOriginalAmountRows.Text = "Original amount of rows:";
            // 
            // LblAmountColumns
            // 
            this.LblAmountColumns.AutoSize = true;
            this.LblAmountColumns.Location = new System.Drawing.Point(6, 89);
            this.LblAmountColumns.Name = "LblAmountColumns";
            this.LblAmountColumns.Size = new System.Drawing.Size(100, 13);
            this.LblAmountColumns.TabIndex = 6;
            this.LblAmountColumns.Text = "Amount of columns:";
            // 
            // LblOriginalAmountRowsTxt
            // 
            this.LblOriginalAmountRowsTxt.AutoSize = true;
            this.LblOriginalAmountRowsTxt.Location = new System.Drawing.Point(133, 66);
            this.LblOriginalAmountRowsTxt.Name = "LblOriginalAmountRowsTxt";
            this.LblOriginalAmountRowsTxt.Size = new System.Drawing.Size(0, 13);
            this.LblOriginalAmountRowsTxt.TabIndex = 5;
            // 
            // LblAmountColumnsTxt
            // 
            this.LblAmountColumnsTxt.AutoSize = true;
            this.LblAmountColumnsTxt.Location = new System.Drawing.Point(133, 89);
            this.LblAmountColumnsTxt.Name = "LblAmountColumnsTxt";
            this.LblAmountColumnsTxt.Size = new System.Drawing.Size(0, 13);
            this.LblAmountColumnsTxt.TabIndex = 7;
            // 
            // LblAmountRowsTxt
            // 
            this.LblAmountRowsTxt.AutoSize = true;
            this.LblAmountRowsTxt.Location = new System.Drawing.Point(133, 43);
            this.LblAmountRowsTxt.Name = "LblAmountRowsTxt";
            this.LblAmountRowsTxt.Size = new System.Drawing.Size(0, 13);
            this.LblAmountRowsTxt.TabIndex = 3;
            // 
            // LblWSNameTxt
            // 
            this.LblWSNameTxt.AutoSize = true;
            this.LblWSNameTxt.Location = new System.Drawing.Point(133, 20);
            this.LblWSNameTxt.Name = "LblWSNameTxt";
            this.LblWSNameTxt.Size = new System.Drawing.Size(0, 13);
            this.LblWSNameTxt.TabIndex = 1;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDelete.Location = new System.Drawing.Point(971, 500);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 10;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // TsmiDelete
            // 
            this.TsmiFDelete.Name = "TsmiDelete";
            this.TsmiFDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
            this.TsmiFDelete.Size = new System.Drawing.Size(180, 22);
            this.TsmiFDelete.Text = "&Delete";
            this.TsmiFDelete.Click += new System.EventHandler(this.TsmiFDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1139, 535);
            this.Controls.Add(this.GbWorksheet);
            this.Controls.Add(this.LblSavedFiles);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.LvWorksheet);
            this.Controls.Add(this.LblWorkSheets);
            this.Controls.Add(this.CboWorkSheets);
            this.Controls.Add(this.CboFiles);
            this.Controls.Add(this.GbWorkbook);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Excel files";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.GbWorkbook.ResumeLayout(false);
            this.GbWorkbook.PerformLayout();
            this.GbWorksheet.ResumeLayout(false);
            this.GbWorksheet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem TsmiFile;
        private System.Windows.Forms.ToolStripMenuItem TsmiFOpen;
        private System.Windows.Forms.ToolStripMenuItem TsmiFDelete;
        private System.Windows.Forms.ToolStripMenuItem TsmiFSave;
        private System.Windows.Forms.ToolStripMenuItem TsmiFQuit;
        private System.Windows.Forms.GroupBox GbWorkbook;
        private System.Windows.Forms.Label LblWBName;
        private System.Windows.Forms.Label LblWBNameTxt;
        private System.Windows.Forms.Label LblSize;
        private System.Windows.Forms.Label LblSizeTxt;
        private System.Windows.Forms.Label LblCreated;
        private System.Windows.Forms.Label LblCreatedTxt;
        private System.Windows.Forms.Label LblModified;
        private System.Windows.Forms.Label LblModifiedTxt;
        private System.Windows.Forms.Label LblAmountSheets;
        private System.Windows.Forms.Label LblAmountSheetsTxt;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label LblSavedFiles;
        private System.Windows.Forms.ComboBox CboFiles;
        private System.Windows.Forms.Label LblWorkSheets;
        private System.Windows.Forms.ComboBox CboWorkSheets;
        private System.Windows.Forms.ListView LvWorksheet;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label LblImported;
        private System.Windows.Forms.Label LblImportedTxt;
        private System.Windows.Forms.GroupBox GbWorksheet;
        private System.Windows.Forms.Label LblAmountColumns;
        private System.Windows.Forms.Label LblOriginalAmountRows;
        private System.Windows.Forms.Label LblAmountRows;
        private System.Windows.Forms.Label LblWSName;
        private System.Windows.Forms.Label LblWSNameTxt;
        private System.Windows.Forms.Label LblAmountRowsTxt;
        private System.Windows.Forms.Label LblAmountColumnsTxt;
        private System.Windows.Forms.Label LblOriginalAmountRowsTxt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

