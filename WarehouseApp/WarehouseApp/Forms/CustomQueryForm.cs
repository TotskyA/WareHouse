using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WarehouseApp.Forms
{
    public partial class CustomQueryForm : Form
    {
        public CustomQueryForm()
        {
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBoxQueryCode.Text = "";
        }

        private void buttonExec_Click(object sender, EventArgs e)
        {
            if (!Classes.Connection.IsConnected())
            {
                MessageBox.Show("Connection Error: " + Classes.Connection.ConnectionError);
                return;
            }

            MySqlCommand command = new MySqlCommand(richTextBoxQueryCode.Text, Classes.Connection.GetConnection());
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при получении данных: " + ex.Message);
            }
        }
    }
}
