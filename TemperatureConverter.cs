using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ImeConverter2025
{
    public partial class TemperatureConverter : Form
    {
        private bool _darkMode = true;
        private readonly ToolTip _tips = new ToolTip();
        private readonly System.Windows.Forms.Timer _glowTimer = new System.Windows.Forms.Timer();
        private int _glowPhase = 0;

        public TemperatureConverter()
        {
            InitializeComponent();
            InitializeUiBehavior();
            ApplyTheme();           // default dark
            InitDropdowns();
            UpdateFormula();
            ConvertTemperature();
        }

        private void InitializeUiBehavior()
        {
            // tooltips
            _tips.SetToolTip(btnTheme, "Toggle Dark/Light Theme");
            _tips.SetToolTip(btnAbout, "About this app");
            _tips.SetToolTip(btnClear, "Reset input/output");
            _tips.SetToolTip(btnSign, "Toggle + / -");
            _tips.SetToolTip(txtInput, "Type a number, or use the keypad");

            // keyboard live conversion
            txtInput.TextChanged += (s, e) => ConvertTemperature();
            txtInput.KeyPress += TxtInput_KeyPress;

            cbFrom.SelectedIndexChanged += (s, e) => { UpdateFormula(); ConvertTemperature(); };
            cbTo.SelectedIndexChanged += (s, e) => { UpdateFormula(); ConvertTemperature(); };

            // keypad buttons (0–9 share same handler)
            foreach (Control ctl in pnlMain.Controls)
            {
                if (ctl is Button b && b.Tag as string == "digit")
                    b.Click += (s, e) =>
                    {
                        if (txtInput.Text == "0") txtInput.Text = b.Text;
                        else txtInput.AppendText(b.Text);
                    };
            }

            btnDec.Click += (s, e) => { if (!txtInput.Text.Contains(".")) txtInput.AppendText("."); };
            btnSign.Click += (s, e) => ToggleSign();
            btnBack.Click += (s, e) => Backspace();
            btnClear.Click += (s, e) => { txtInput.Text = "0"; txtInput.Focus(); };
            btnTheme.Click += (s, e) => { _darkMode = !_darkMode; ApplyTheme(); };
            btnAbout.Click += (s, e) => new AboutForm().ShowDialog(this);

            // footer glow animation
            _glowTimer.Interval = 90;
            _glowTimer.Tick += (s, e) =>
            {
                _glowPhase = (_glowPhase + 1) % 100;
                int alpha = (int)(120 + 100 * Math.Sin(_glowPhase / 100.0 * Math.PI * 2));
                lblBrand.ForeColor = Color.FromArgb(alpha, 0, 180, 255);
            };
            _glowTimer.Start();
        }

        private void TxtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allow digits, one dot, control keys, one leading minus
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && !txtInput.Text.Contains(".")) return;
            if (e.KeyChar == '-' && txtInput.SelectionStart == 0 && !txtInput.Text.StartsWith("-")) return;
            e.Handled = true; // block everything else
        }

        private void InitDropdowns()
        {
            cbFrom.Items.AddRange(new[] { "Celsius (°C)", "Fahrenheit (°F)", "Kelvin (K)", "Rankine (°R)" });
            cbTo.Items.AddRange(new[] { "Celsius (°C)", "Fahrenheit (°F)", "Kelvin (K)", "Rankine (°R)" });

            cbFrom.SelectedIndex = 0; // C
            cbTo.SelectedIndex = 1;   // F
            txtInput.Text = "0";
        }

        // ==================== Theme Logic ====================
        private void ApplyTheme()
        {
            var accent = Color.FromArgb(0, 180, 255);
            Color back, text, header, footer, main, inputBack, comboBack, comboText;

            if (_darkMode)
            {
                back = Color.FromArgb(18, 24, 38);
                text = Color.White;
                header = Color.FromArgb(24, 34, 56);
                footer = Color.FromArgb(15, 20, 30);
                main = Color.FromArgb(22, 32, 52);
                inputBack = Color.FromArgb(50, 54, 62);
                comboBack = Color.FromArgb(40, 44, 52);
                comboText = Color.White;
                btnTheme.Text = "Light Mode";
            }
            else
            {
                back = Color.WhiteSmoke;
                text = Color.Black;
                header = Color.White;
                footer = Color.White;
                main = Color.White;
                inputBack = Color.White;
                comboBack = Color.White;
                comboText = Color.Black;
                btnTheme.Text = "Dark Mode";
            }

            BackColor = back;
            ForeColor = text;
            pnlHeader.BackColor = header;
            pnlFooter.BackColor = footer;
            pnlMain.BackColor = main;

            lblTitle.ForeColor = accent;
            lblFormula.ForeColor = _darkMode ? Color.FromArgb(180, 220, 255) : Color.FromArgb(20, 60, 100);
            lblResult.ForeColor = _darkMode ? Color.Orange : Color.FromArgb(20, 100, 40);
            txtInput.BackColor = inputBack;
            txtInput.ForeColor = text;

            cbFrom.BackColor = comboBack;
            cbFrom.ForeColor = comboText;
            cbTo.BackColor = comboBack;
            cbTo.ForeColor = comboText;

            lblBrand.ForeColor = _darkMode ? Color.LightBlue : Color.DarkBlue;

            // button colors
            foreach (Control ctl in pnlMain.Controls)
            {
                if (ctl is Button b)
                {
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.BackColor = _darkMode ? Color.FromArgb(60, 64, 74) : Color.Gainsboro;
                    b.ForeColor = text;
                }
            }
        }

        // ==================== ComboBox Draw Handler ====================
        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (e.Index < 0) return;

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color backColor = selected
                ? Color.FromArgb(70, 130, 180)
                : combo.BackColor;

            Color textColor = selected
                ? Color.White
                : combo.ForeColor;

            using (SolidBrush bg = new SolidBrush(backColor))
                e.Graphics.FillRectangle(bg, e.Bounds);

            using (SolidBrush txt = new SolidBrush(textColor))
                e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font, txt, e.Bounds);

            e.DrawFocusRectangle();
        }

        // ==================== Utility Actions ====================
        private void ToggleSign()
        {
            if (txtInput.Text == "0") return;
            if (txtInput.Text.StartsWith("-"))
                txtInput.Text = txtInput.Text.Substring(1);
            else
                txtInput.Text = "-" + txtInput.Text;
        }

        private void Backspace()
        {
            if (txtInput.Text.Length <= 1) txtInput.Text = "0";
            else txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1);
        }

        // ==================== Formula Display ====================
        private void UpdateFormula()
        {
            string from = UnitKey(cbFrom.SelectedIndex);
            string to = UnitKey(cbTo.SelectedIndex);

            string f = "—";
            if (from == to) f = "Identity: y = x";
            else if (from == "C" && to == "F") f = "F = C × 9/5 + 32";
            else if (from == "F" && to == "C") f = "C = (F − 32) × 5/9";
            else if (from == "C" && to == "K") f = "K = C + 273.15";
            else if (from == "K" && to == "C") f = "C = K − 273.15";
            else if (from == "F" && to == "K") f = "K = (F − 32) × 5/9 + 273.15";
            else if (from == "K" && to == "F") f = "F = (K − 273.15) × 9/5 + 32";
            else if (from == "C" && to == "R") f = "R = (C + 273.15) × 9/5";
            else if (from == "R" && to == "C") f = "C = R × 5/9 − 273.15";
            else if (from == "F" && to == "R") f = "R = F + 459.67";
            else if (from == "R" && to == "F") f = "F = R − 459.67";
            else if (from == "K" && to == "R") f = "R = K × 9/5";
            else if (from == "R" && to == "K") f = "K = R × 5/9";

            lblFormula.Text = $"Formula: {f}";
        }

        private string UnitKey(int idx)
        {
            return idx switch
            {
                0 => "C",
                1 => "F",
                2 => "K",
                _ => "R"
            };
        }

        // ==================== Conversion Logic ====================
        private void ConvertTemperature()
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text) || txtInput.Text == "-")
            {
                lblResult.Text = "—";
                return;
            }

            if (!double.TryParse(txtInput.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double x))
            {
                lblResult.Text = "Invalid";
                return;
            }

            string from = UnitKey(cbFrom.SelectedIndex);
            string to = UnitKey(cbTo.SelectedIndex);
            double y = x;

            // normalize input to Kelvin
            double k = from switch
            {
                "C" => x + 273.15,
                "F" => (x - 32) * 5.0 / 9.0 + 273.15,
                "K" => x,
                "R" => x * 5.0 / 9.0,
                _ => x
            };

            // convert from Kelvin to target
            y = to switch
            {
                "K" => k,
                "C" => k - 273.15,
                "F" => (k - 273.15) * 9.0 / 5.0 + 32,
                "R" => k * 9.0 / 5.0,
                _ => k
            };

            lblResult.Text = $"{y:F2}";
        }
    }
}
