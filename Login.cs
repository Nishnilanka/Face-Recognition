﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MultiFaceRec
{
    public partial class Login : Form
    {

        public string MyConnectionLogin = "datasource=localhost;port=3306;username=root;password='root';database=facerec";

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT * FROM user WHERE user_name = '" + this.txtUserName.Text + "' and password = '" + this.txtPassword.Text + "';";
                //System.Console.WriteLine(Query);
                MySqlConnection myConn = new MySqlConnection(MyConnectionLogin);
                MySqlDataReader myReader;
                myConn.Open();
                MySqlCommand cmdDataBase = new MySqlCommand(Query, myConn);
                myReader = cmdDataBase.ExecuteReader();

                int count = 0;
                while (myReader.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    //MessageBox.Show("Login Succesfule");
                    //Application.Run(new FrmPrincipal());
                    //myConn.Close();
                    var MainForm = new FrmPrincipal();
                    MainForm.Show();
                    this.Hide();
                }

                else if (count > 1)
                {
                    MessageBox.Show("Access denied !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    myConn.Close();
                }

                else
                {
                    MessageBox.Show("Wrong user name and password !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var MainForm = new FrmPrincipal();
                    MainForm.Show();
                    this.Hide();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
