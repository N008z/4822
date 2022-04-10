using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _4822
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public static string sqlConnection = "server=localhost;uid=root;pwd=;database=premier_league";
        MySqlConnection sqlConnect = new MySqlConnection(sqlConnection);
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        DataTable table = new DataTable();
        string sqlQuery;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tbQuery_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            sqlConnect.Open();
            DataTable dtPlayer = new DataTable();
            sqlQuery = tbQuery.Text;
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtPlayer);
            dgvPlayer.DataSource = dtPlayer;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dgvPlayer.DataSource = null;
            dgvPlayer.Rows.Clear();
            sqlConnect.Close();
            dgvPlayer.DataSource = table;
        }
    }
}
