using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Tarek.Controls;
using Tarek_BLL.Errors;

namespace WaitingMessage
{
    public partial class WaitingMessage : Form
    {
        private Thread thrMessage;
        private F_Message frmMessage;

        internal void CloseMessage()
        {
            try
            {
                if (thrMessage != null)
                    switch (thrMessage.ThreadState)
                    {
                        case ThreadState.Running:
                        case ThreadState.WaitSleepJoin:
                            {
                                if (!thrMessage.Join(100))
                                {
                                    frmMessage.Cancel();
                                    thrMessage.Abort();
                                }

                                break;
                            }
                        default:
                            {
                                if (!frmMessage.Visible)
                                {
                                    frmMessage.Cancel();
                                    thrMessage.Abort();
                                }

                                break;
                            }
                    }
            }
            catch (ThreadAbortException ex)
            {
                ErrorManagement.Log(ex);
            }
            catch (Exception ex)
            {
                ErrorManagement.Log(ex);
            }

        }

        internal IController Controller
        {
            get
            {
                return frmMessage.Controller;
            }
        }

        internal void SetPercent(int percent, int progressBar = 0)
        {
            frmMessage.Controller.SetPercent(percent, progressBar);
        }

        internal void SetMessage(string texte)
        {
            frmMessage.Controller.SetText(texte);
        }

        internal void SetVisible(bool visible)
        {
            frmMessage.Controller.SetVisible(visible);
        }

        public override string ToString()
        {
            return frmMessage.Text + " => " + frmMessage.DisplayedText;
        }

        internal WaitingMessage(string message,
                                string title = "",
                                int amountProgressBars = 1,
                                bool cancelButton = false)
        {
            try
            {
                frmMessage = new F_Message(message, title, amountProgressBars, cancelButton);
                thrMessage = new Thread(frmMessage.ShowMe);
                thrMessage.Start();
            }
            catch (ThreadAbortException ex)
            {
                ErrorManagement.Log(ex);
            }
            catch (Exception ex)
            {
                ErrorManagement.Log(ex);
            }
        }

        private class F_Message : Form, IClient
        {
            private Label Label { get; set; }
            private List<ProgressBar> ProgressBars { get; set; }
            private ActivityBar ActivityBar { get; set; }
            private Button CancelBtn { get; set; }

            private Controller mController;

            private const int PADDING_TOP = 12;
            private const int PADDING_BOTTOM = 12;
            private const int PADDING_LEFT = 6;
            private const int PADDING_RIGHT = 6;
            private const int PADDING_MIDDLE = 6;

            #region IClient

            public void Start(IController controller)
            {
                ActivityBar.Start();
            }

            public void Display()
            {
                if (ProgressBars != null)
                {
                    foreach (ProgressBar pb in ProgressBars)
                    {
                        pb.Value = mController.Percent(ProgressBars.IndexOf(pb));
                    }
                }
            }

            public void SetText(string text)
            {
                Label.Text = text;
            }

            public void Failed(Exception e)
            {
                ActivityBar.Stop();
                MessageBox.Show(e.ToString());
            }

            public void Completed(bool cancelled)
            {
                try
                {
                    ActivityBar.Stop();
                }
                catch (Exception ex)
                {
                    ErrorManagement.Log(ex);
                }
            }

            public void SetVisible(bool visible)
            {
                Visible = visible;
            }

            #endregion

            #region Controller management

            protected internal IController Controller
            {
                get
                {
                    return mController;
                }
            }

            protected internal void Cancel()
            {
                mController.Cancel();
                Cursor.Current = Cursors.Default;
            }

            #endregion

            protected internal string DisplayedText
            {
                get
                {
                    return Label.Text;
                }
            }

            protected internal F_Message(string message,
                                         string title,
                                         int amountProgressBars,
                                         bool cancelButton)
            {
                mController = new Controller(this);

                Label = new Label
                {
                    Top = PADDING_TOP,
                    Left = PADDING_LEFT,
                    Text = message,
                    AutoSize = true,
                    Name = "Label"
                };
                Controls.Add(Label);

                int Top = Label.Top + Label.Height;

                ProgressBars = new List<ProgressBar>();
                for (int index = 0; index < amountProgressBars; index += 1)
                {
                    ProgressBar pb = new ProgressBar
                    {
                        Top = Top + PADDING_MIDDLE,
                        Left = PADDING_LEFT,
                        Width = Label.Width,
                        Value = 0,
                        Minimum = 0,
                        Maximum = 100
                    };
                    Top += pb.Height;
                    Controls.Add(pb);
                    ProgressBars.Add(pb);
                }

                ActivityBar = new ActivityBar(20)
                {
                    Top = Top + PADDING_MIDDLE,
                    Left = PADDING_LEFT,
                    Width = Label.Width
                };
                Top += ActivityBar.Height;
                Controls.Add(ActivityBar);

                if (cancelButton)
                {
                    CancelBtn = new Button
                    {
                        Text = "&Cancel",
                        Top = Top + PADDING_MIDDLE
                    };
                    Top += CancelBtn.Height;
                    CancelBtn.Click += CmdCancel_Click;
                    Controls.Add(CancelBtn);
                    CancelButton = CancelBtn;
                }

                ClientSize = new Size(PADDING_LEFT + Label.Width + PADDING_RIGHT, Top + PADDING_BOTTOM);

                if (cancelButton)
                    CancelBtn.Left = ClientSize.Width - CancelBtn.Width - PADDING_RIGHT;

                FormBorderStyle = FormBorderStyle.FixedDialog;
                MinimizeBox = false;
                MaximizeBox = false;
                StartPosition = FormStartPosition.CenterScreen;
                ShowInTaskbar = false;
                ShowIcon = true;
                Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
                Text = title;

                // Events handling
                Activated += new EventHandler(F_Message_Activated);
                GotFocus += new EventHandler(F_Message_GotFocus);
                Shown += new EventHandler(F_Message_Shown);
            }

            protected internal void ShowMe()
            {
                try
                {
                    ShowDialog();
                }
                catch (ThreadAbortException)
                {
                }
                catch (InvalidOperationException)
                {
                }
            }

            private const int CS_NOCLOSE = 0x200;

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
                    return cp;
                }
            }

            private void F_Message_Activated(object sender, EventArgs e)
            {
                try
                {
                    Refresh();
                }
                catch (ThreadAbortException)
                {
                    Close();
                }
                catch (InvalidOperationException)
                {
                    Close();
                }
            }

            private void F_Message_GotFocus(object sender, EventArgs e)
            {
                Refresh();
            }

            private void F_Message_Shown(object sender, EventArgs e)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    mController.Start(new TacheDeportee());
                }
                catch (ThreadAbortException)
                {
                }
                catch (Exception ex)
                {
                    ErrorManagement.Log(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }

            private void CmdCancel_Click(object sender, EventArgs e)
            {
                Cancel();
            }
        }

        private class TacheDeportee : ITacheDeportee
        {
            private IController mController;

            public void Initialize(IController controller)
            {
                mController = controller;
            }

            public void Start()
            {
                try
                {
                    while (mController.Running)
                    {
                        mController.Display();
                        Thread.Sleep(100);
                    }
                }
                catch (Exception ex)
                {
                    ErrorManagement.Log(ex);
                }
            }
        }
    }
}
