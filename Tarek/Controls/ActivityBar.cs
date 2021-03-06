﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tarek.Controls
{
    public partial class ActivityBar : UserControl
    {
        private List<PictureBox> mBoxes = new List<PictureBox>();
        private int mCount;
        private int intNbPictureBoxes = 10;

        private void ActivityBar_Load(object sender, EventArgs e)
        {
            if (mBoxes.Count == 0)
                for (int index = 0; index < intNbPictureBoxes; index++)
                    mBoxes.Add(CreateBox(index));

            mCount = 0;
            tmAnim.Tick += new EventHandler(TmAnim_Tick);
        }

        private PictureBox CreateBox(int index)
        {
            PictureBox box = new PictureBox();

            SetPosition(box, index);
            box.BorderStyle = BorderStyle.Fixed3D;
            box.Parent = this;
            box.Visible = true;

            return box;
        }

        private void GrayDisplay()
        {
            foreach (PictureBox pb in mBoxes)
                pb.BackColor = BackColor;

            mCount = 0;
        }

        private void SetPosition(PictureBox box, int index)
        {
            int width = 10;
            int espace = width + (this.Width - intNbPictureBoxes * width) / (intNbPictureBoxes - 1);
            int left = (this.Width - (intNbPictureBoxes - 1) * espace - width) / 2;
            int height = 10;
            int top = (this.Height - height) / 2;

            box.Height = height;
            box.Width = width;
            box.Top = top;
            box.Left = left + index * espace;

        }

        private void TmAnim_Tick(object sender, EventArgs e)
        {
            mBoxes[(mCount + 1) % intNbPictureBoxes].BackColor = Color.LightGreen;
            mBoxes[mCount % intNbPictureBoxes].BackColor = BackColor;

            mCount = (mCount + 1) % intNbPictureBoxes;
        }

        public void Start()
        {
            mBoxes.First().BackColor = Color.LightGreen;
            tmAnim.Enabled = true;
        }

        public void Stop()
        {
            tmAnim.Enabled = false;
            GrayDisplay();
        }

        private void ActivityBar_Resize(object sender, EventArgs e)
        {
            for (int index = 0; index < mBoxes.Count; index += 1)
                SetPosition(mBoxes[index], index);
        }

        public ActivityBar(int nbPictureBoxes = -1)
        {
            // Cet appel est requis par le concepteur.
            InitializeComponent();

            // Initialisation du nombre de PictureBoxes (10 par défaut)
            if (nbPictureBoxes > 0)
                intNbPictureBoxes = nbPictureBoxes;
            else
                intNbPictureBoxes = 10;

            Load += new EventHandler(ActivityBar_Load);
            Resize += new EventHandler(ActivityBar_Resize);
        }
    }
}
