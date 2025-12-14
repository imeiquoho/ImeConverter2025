using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImeConverter2025
{
    partial class TemperatureConverter
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlMain;
        private Panel pnlFooter;

        private Label lblTitle;
        private ComboBox cbFrom;
        private ComboBox cbTo;

        private Label lblFrom;
        private Label lblTo;

        private TextBox txtInput;
        private Label lblResult;
        private Label lblFormula;

        private Button btnTheme;
        private Button btnAbout;

        private Button btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9;
        private Button btnDec, btnSign, btnBack, btnClear;

        private Label lblBrand;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.btnTheme = new Button();
            this.btnAbout = new Button();

            this.pnlMain = new Panel();
            this.cbFrom = new ComboBox();
            this.cbTo = new ComboBox();
            this.lblFrom = new Label();
            this.lblTo = new Label();
            this.txtInput = new TextBox();
            this.lblResult = new Label();
            this.lblFormula = new Label();

            this.btn0 = new Button();
            this.btn1 = new Button();
            this.btn2 = new Button();
            this.btn3 = new Button();
            this.btn4 = new Button();
            this.btn5 = new Button();
            this.btn6 = new Button();
            this.btn7 = new Button();
            this.btn8 = new Button();
            this.btn9 = new Button();
            this.btnDec = new Button();
            this.btnSign = new Button();
            this.btnBack = new Button();
            this.btnClear = new Button();

            this.pnlFooter = new Panel();
            this.lblBrand = new Label();

            this.SuspendLayout();

            // ========= Form =========
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Text = "Ime Converter 2025 – Smart Temperature Lab";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(740, 520);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.BackColor = Color.FromArgb(20, 24, 32);
            this.ForeColor = Color.White;

            // ========= Header =========
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 60;
            this.pnlHeader.Padding = new Padding(12, 10, 12, 10);
            this.pnlHeader.BackColor = Color.FromArgb(30, 34, 44);

            this.lblTitle.Text = "Ime Converter 2025 – Smart Temperature Lab";
            this.lblTitle.AutoSize = false;
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            this.lblTitle.Dock = DockStyle.Left;
            this.lblTitle.Width = 480;
            this.lblTitle.Font = new Font("Orbitron", 12F, FontStyle.Bold);

            this.btnTheme.Text = "Light Mode";
            this.btnTheme.Width = 110;
            this.btnTheme.Height = 34;
            this.btnTheme.Anchor = AnchorStyles.Right;
            this.btnTheme.Location = new Point(590, 13);
            this.btnTheme.FlatStyle = FlatStyle.Flat;
            this.btnTheme.FlatAppearance.BorderSize = 0;
            this.btnTheme.BackColor = Color.FromArgb(70, 130, 180);
            this.btnTheme.ForeColor = Color.White;

            this.btnAbout.Text = "About";
            this.btnAbout.Width = 90;
            this.btnAbout.Height = 34;
            this.btnAbout.Anchor = AnchorStyles.Right;
            this.btnAbout.Location = new Point(490, 13);
            this.btnAbout.FlatStyle = FlatStyle.Flat;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.BackColor = Color.FromArgb(90, 90, 110);
            this.btnAbout.ForeColor = Color.White;

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnAbout);
            this.pnlHeader.Controls.Add(this.btnTheme);

            // ========= Main =========
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Padding = new Padding(16);
            this.pnlMain.BackColor = Color.FromArgb(25, 29, 38);

            // From/To Labels and ComboBoxes
            this.lblFrom.Text = "From";
            this.lblFrom.Location = new Point(20, 20);
            this.lblFrom.AutoSize = true;

            this.cbFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbFrom.Location = new Point(80, 16);
            this.cbFrom.Width = 180;
            this.cbFrom.FlatStyle = FlatStyle.Flat;
            this.cbFrom.BackColor = Color.FromArgb(40, 44, 52);
            this.cbFrom.ForeColor = Color.White;
            this.cbFrom.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbFrom.DrawItem += new DrawItemEventHandler(this.ComboBox_DrawItem);

            this.lblTo.Text = "To";
            this.lblTo.Location = new Point(280, 20);
            this.lblTo.AutoSize = true;

            this.cbTo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbTo.Location = new Point(320, 16);
            this.cbTo.Width = 180;
            this.cbTo.FlatStyle = FlatStyle.Flat;
            this.cbTo.BackColor = Color.FromArgb(40, 44, 52);
            this.cbTo.ForeColor = Color.White;
            this.cbTo.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbTo.DrawItem += new DrawItemEventHandler(this.ComboBox_DrawItem);

            // Input
            this.txtInput.Location = new Point(20, 70);
            this.txtInput.Width = 220;
            this.txtInput.BackColor = Color.FromArgb(50, 54, 62);
            this.txtInput.ForeColor = Color.White;
            this.txtInput.BorderStyle = BorderStyle.FixedSingle;

            // Result
            this.lblResult.Location = new Point(260, 70);
            this.lblResult.Width = 240;
            this.lblResult.Height = 36;
            this.lblResult.TextAlign = ContentAlignment.MiddleLeft;
            this.lblResult.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblResult.ForeColor = Color.Gold;
            this.lblResult.Text = "0.00";

            // Formula
            this.lblFormula.Location = new Point(20, 110);
            this.lblFormula.Width = 480;
            this.lblFormula.Height = 24;
            this.lblFormula.Text = "Formula: —";
            this.lblFormula.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblFormula.ForeColor = Color.LightSteelBlue;

            // Keypad
            int x0 = 560, y0 = 20, w = 48, h = 44, pad = 8;
            Button[] digits = { btn7, btn8, btn9, btn4, btn5, btn6, btn1, btn2, btn3, btn0 };
            foreach (Button b in digits)
            {
                b.BackColor = Color.FromArgb(60, 64, 74);
                b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                b.Tag = "digit";
            }

            this.btnDec.Text = ".";
            this.btnSign.Text = "+/-";
            this.btnBack.Text = "Back";
            this.btnClear.Text = "Clear";

            Button[] edits = { btnDec, btnSign, btnBack, btnClear };
            foreach (Button b in edits)
            {
                b.BackColor = Color.FromArgb(90, 94, 104);
                b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            // Layout positions
            this.btn7.SetBounds(x0, y0, w, h);
            this.btn8.SetBounds(x0 + w + pad, y0, w, h);
            this.btn9.SetBounds(x0 + 2 * (w + pad), y0, w, h);

            this.btn4.SetBounds(x0, y0 + h + pad, w, h);
            this.btn5.SetBounds(x0 + w + pad, y0 + h + pad, w, h);
            this.btn6.SetBounds(x0 + 2 * (w + pad), y0 + h + pad, w, h);

            this.btn1.SetBounds(x0, y0 + 2 * (h + pad), w, h);
            this.btn2.SetBounds(x0 + w + pad, y0 + 2 * (h + pad), w, h);
            this.btn3.SetBounds(x0 + 2 * (w + pad), y0 + 2 * (h + pad), w, h);

            this.btn0.SetBounds(x0, y0 + 3 * (h + pad), w, h);
            this.btnDec.SetBounds(x0 + w + pad, y0 + 3 * (h + pad), w, h);
            this.btnSign.SetBounds(x0 + 2 * (w + pad), y0 + 3 * (h + pad), w, h);

            this.btnBack.SetBounds(x0, y0 + 4 * (h + pad), w, h);
            this.btnClear.SetBounds(x0 + w + pad, y0 + 4 * (h + pad), w * 2 + pad, h);

            // Add to main
            this.pnlMain.Controls.Add(this.lblFrom);
            this.pnlMain.Controls.Add(this.cbFrom);
            this.pnlMain.Controls.Add(this.lblTo);
            this.pnlMain.Controls.Add(this.cbTo);
            this.pnlMain.Controls.Add(this.txtInput);
            this.pnlMain.Controls.Add(this.lblResult);
            this.pnlMain.Controls.Add(this.lblFormula);

            this.pnlMain.Controls.Add(this.btn7);
            this.pnlMain.Controls.Add(this.btn8);
            this.pnlMain.Controls.Add(this.btn9);
            this.pnlMain.Controls.Add(this.btn4);
            this.pnlMain.Controls.Add(this.btn5);
            this.pnlMain.Controls.Add(this.btn6);
            this.pnlMain.Controls.Add(this.btn1);
            this.pnlMain.Controls.Add(this.btn2);
            this.pnlMain.Controls.Add(this.btn3);
            this.pnlMain.Controls.Add(this.btn0);
            this.pnlMain.Controls.Add(this.btnDec);
            this.pnlMain.Controls.Add(this.btnSign);
            this.pnlMain.Controls.Add(this.btnBack);
            this.pnlMain.Controls.Add(this.btnClear);

            // ========= Footer =========
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Height = 40;
            this.pnlFooter.Padding = new Padding(10, 5, 10, 5);
            this.pnlFooter.BackColor = Color.FromArgb(30, 34, 44);

            this.lblBrand.Text = "Ime’s Smart Converter v1.0";
            this.lblBrand.AutoSize = false;
            this.lblBrand.Dock = DockStyle.Right;
            this.lblBrand.TextAlign = ContentAlignment.MiddleRight;
            this.lblBrand.Width = 300;
            this.lblBrand.ForeColor = Color.LightBlue;

            this.pnlFooter.Controls.Add(this.lblBrand);

            // Add panels to form
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);

            this.ResumeLayout(false);
        }
    }
}
