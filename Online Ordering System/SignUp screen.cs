﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Online_Ordering_System
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            Color clr = Color.FromArgb(0, 255, 188, 72);
            Button btn = (Button)sender;
            btn.BackColor = clr;
            btn.ForeColor = Color.White;

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Black;
            btn.BackColor = panel1.BackColor;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void signup_txt_click(object sender, MouseEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = "";

        }

        private void signup_txt_click_pass(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.UseSystemPasswordChar = true;
            txt.Text = "";

        }
    }
}
