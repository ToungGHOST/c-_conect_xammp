using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ATM
{
    public partial class Form1 : Form
    {
        MySqlConnection connect = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Connect()
        {
            connect.Open();
            string Query = "SELECT * FROM ghost.atm WHERE user = '" + textBox1.Text + "' AND pass = '" + textBox2.Text + "';";
            command = new MySqlCommand(Query, connect);
                    mdr = command.ExecuteReader();

            
            if (mdr.Read())
            {
                string Connect2 = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection MyConn2 = new MySqlConnection(Connect2);

                MyConn2.Open();
                  textBox3.Text =mdr.GetValue(3).ToString(); 
                MessageBox.Show("Your Money!");
            }
            else
            {

                MessageBox.Show("Try Again!!.");
            }
            connect.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Add()
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please enter the amount!");
            }
            else
            {
                int sum1 = Int32.Parse(textBox4.Text);
                int sum2 = Int32.Parse(textBox3.Text);
                int sum = sum1 + sum2;
                textBox3.Text = sum.ToString();
                connect.Open();
            string Query = "UPDATE ghost.atm SET Money='" + this.textBox3.Text + "'where user='" + this.textBox1.Text + "';";
                command = new MySqlCommand(Query, connect);
                mdr = command.ExecuteReader();
                MessageBox.Show("Deposit Money Succes!");
                connect.Close();
            }
           
           



        }

        private void Remove()
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please enter the amount!");
            }
            else
            {
                int sum1 = Int32.Parse(textBox4.Text);
                int sum2 = Int32.Parse(textBox3.Text);
                int sum = sum2 - sum1;
                textBox3.Text = sum.ToString();
                connect.Open();
                string Query = "UPDATE ghost.atm SET Money='" + this.textBox3.Text+"'where user='" + this.textBox1.Text + "';";
                command = new MySqlCommand(Query, connect);
                mdr = command.ExecuteReader();
                MessageBox.Show(" Withdraw Money Success!");
                connect.Close();

            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Remove();
        }
    }
}
