using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerarSenhas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string CreatePassword()
        {
            int qtd = int.Parse(txtCaracteres.Text);
            string password = string.Empty;
           

            for (int i = 1; i <= qtd; i++)
            {
                Random random = new Random();
                int code = Convert.ToInt32(random.Next(48, 122).ToString());

                if (code >= 48 && code <= 57 || code >= 97 && code <= 122)
                {
                    string caractere = ((char)code).ToString();
                    if (!password.Contains(caractere))
                    {
                        password += caractere;
                    } else
                    {
                        i--;
                    }
                } else
                {
                    i--;
                }
            }
            return password.ToUpper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // lblSenha.Margin
            //  Margins margin = new Margins(0, 0, 0, 0);
            lblSenha.Text = CreatePassword();
        }

        private void txtCaracteres_KeyPress(object sender, KeyPressEventArgs e)
        {
             if(!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
    }
}
