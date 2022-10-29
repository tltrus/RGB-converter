using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            RGBtoColor(Convert.ToInt32(tbR.Text), Convert.ToInt32(tbG.Text), Convert.ToInt32(tbB.Text));
        }

        // Получение строки цвета в HEX виде
        private static String ToHexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private static String RGBConverter(System.Drawing.Color c)
        {
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }

        private void tbR_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumberInput(e); // Ввод только цифр 0....9
        }

        private void onlyNumberInput(KeyPressEventArgs e)
        {
            // 48 - это 0
            // 49 - это 1
            // 50 - это 2
            // 51 - это 3
            // 52 - это 4
            // 53 - это 5
            // 54 - это 6
            // 55 - это 7
            // 56 - это 8
            // 57 - это 9

            char number = e.KeyChar;
            if ((number <= 7 || number >= 9) && (number <= 47 || number >= 58)) //цифры
            {
                e.Handled = true;
            }
        }

        private void tbG_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumberInput(e); // Ввод только цифр 0....9
        }

        private void tbB_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumberInput(e); // Ввод только цифр 0....9
        }

        private void tbR_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(tbR.Text) >= 255) tbR.Text = "255";
            int num = Convert.ToInt32(tbR.Text);

            RGBtoColor(num, Convert.ToInt32(tbG.Text), Convert.ToInt32(tbB.Text));
        }

        private void tbG_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(tbG.Text) >= 255) tbG.Text = "255";
            int num = Convert.ToInt32(tbG.Text);

            RGBtoColor(Convert.ToInt32(tbR.Text), num, Convert.ToInt32(tbB.Text));
        }

        private void tbB_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(tbB.Text) >= 255) tbB.Text = "255";
            int num = Convert.ToInt32(tbB.Text);

            RGBtoColor(Convert.ToInt32(tbR.Text), Convert.ToInt32(tbG.Text), num);
        }

        private void RGBtoColor(int r, int g, int b)
        {
            Color col = Color.FromArgb(255, r, g, b);

            tbHexColor.Text = ToHexConverter(col);

            panel1.BackColor = col;

            label5.Text = r.ToString("X2");
            label6.Text = g.ToString("X2");
            label7.Text = b.ToString("X2");
        }

        private void tbR_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tbR.SelectionStart = 0;
                tbR.SelectionLength = tbR.Text.Length;
                tbR.Focus();
            }
        }

        private void tbG_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tbG.SelectionStart = 0;
                tbG.SelectionLength = tbG.Text.Length;
                tbG.Focus();
            }
        }

        private void tbB_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tbB.SelectionStart = 0;
                tbB.SelectionLength = tbB.Text.Length;
                tbB.Focus();
            }
        }

        private void tbHexColor_TextChanged(object sender, EventArgs e)
        {
            var color = System.Drawing.ColorTranslator.FromHtml(tbHexColor.Text);
            tbR.Text = color.R.ToString();
            tbG.Text = color.G.ToString();
            tbB.Text = color.B.ToString();
            panel1.BackColor = Color.FromArgb(255, color.R, color.G, color.B);

            label5.Text = color.R.ToString("X2");
            label6.Text = color.G.ToString("X2");
            label7.Text = color.B.ToString("X2");
        }
    }
}
