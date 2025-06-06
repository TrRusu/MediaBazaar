﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace BorderedGroupBox
{
    public class BorderedGroupBox : GroupBox
    {
        private Color _borderColor = Color.Black;
        private int _borderWidth = 2;
        private int _borderRadius = 5;
        private int _textIndent = 10;

        public BorderedGroupBox() : base()
        {
            InitializeComponent();
            this.Paint += this.BorderedGroupBox_Paint;
        }

        public BorderedGroupBox(int width, int radius, Color color) : base()
        {
            this._borderWidth = Math.Max(1, width);
            this._borderColor = color;
            this._borderRadius = Math.Max(0, radius);
            InitializeComponent();
            this.Paint += this.BorderedGroupBox_Paint;
        }

        public Color BorderColor
        {
            get => this._borderColor;
            set
            {
                this._borderColor = value;
                DrawGroupBox();
            }
        }

        public int BorderWidth
        {
            get => this._borderWidth;
            set
            {
                if (value > 0)
                {
                    this._borderWidth = Math.Min(value, 10);
                    DrawGroupBox();
                }
            }
        }

        public int BorderRadius
        {
            get => this._borderRadius;
            set
            {   // Setting a radius of 0 produces square corners...
                if (value >= 0)
                {
                    this._borderRadius = value;
                    this.DrawGroupBox();
                }
            }
        }

        public int LabelIndent
        {
            get => this._textIndent;
            set
            {
                this._textIndent = value;
                this.DrawGroupBox();
            }
        }

        private void BorderedGroupBox_Paint(object sender, PaintEventArgs e) =>
            DrawGroupBox(e.Graphics);

        private void DrawGroupBox() =>
            this.DrawGroupBox(this.CreateGraphics());

        private void DrawGroupBox(Graphics g)
        {
            Brush textBrush = new SolidBrush(this.ForeColor);
            SizeF strSize = g.MeasureString(this.Text, this.Font);

            Brush borderBrush = new SolidBrush(this.BorderColor);
            Pen borderPen = new Pen(borderBrush, (float)this._borderWidth);
            Rectangle rect = new Rectangle(this.ClientRectangle.X,
                                            this.ClientRectangle.Y + (int)(strSize.Height / 2),
                                            this.ClientRectangle.Width - 1,
                                            this.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

            Brush labelBrush = new SolidBrush(this.BackColor);

            // Clear text and border
            g.Clear(this.BackColor);

            // Drawing Border (added "Fix" from Jim Fell, Oct 6, '18)
            int rectX = (0 == this._borderWidth % 2) ? rect.X + this._borderWidth / 2 : rect.X + 1 + this._borderWidth / 2;
            int rectHeight = (0 == this._borderWidth % 2) ? rect.Height - this._borderWidth / 2 : rect.Height - 1 - this._borderWidth / 2;
            // NOTE DIFFERENCE: rectX vs rect.X and rectHeight vs rect.Height
            g.DrawRoundedRectangle(borderPen, rectX, rect.Y, rect.Width, rectHeight, (float)this._borderRadius);

            // Draw text
            if (this.Text.Length > 0)
            {
                // Do some work to ensure we don't put the label outside
                // of the box, regardless of what value is assigned to the Indent:
                int width = (int)rect.Width, posX;
                posX = (this._textIndent < 0) ? Math.Max(0 - width, this._textIndent) : Math.Min(width, this._textIndent);
                posX = (posX < 0) ? rect.Width + posX - (int)strSize.Width : posX;
                g.FillRectangle(labelBrush, posX, 0, strSize.Width, strSize.Height);
                g.DrawString(this.Text, this.Font, textBrush, posX, 0);
            }
        }

        #region Component Designer generated code
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        /// <summary>Required method for Designer support - Don't modify!</summary>
        private void InitializeComponent() => components = new System.ComponentModel.Container();
        #endregion
    }
}