namespace Tarek.Controls
{
    partial class ActivityBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.tmAnim = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            //
            //tmAnim
            //
            this.tmAnim.Interval = 300;
            //
            //ActivityBar
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ActivityBar";
            this.Size = new System.Drawing.Size(110, 20);
            this.ResumeLayout(false);
        }

        #endregion

        internal System.Windows.Forms.Timer tmAnim;
    }
}
