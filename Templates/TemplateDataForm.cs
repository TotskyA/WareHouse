using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WarehouseApp.Templates
{
    public abstract partial class TemplateDataForm : Form
    {
        public TemplateDataForm(bool deletion_allowed)
        {
            InitializeComponent();
            loadData();
            if(!deletion_allowed)
            {
                buttonDelete.Visible = false;
            }
        }

        protected abstract void gridColumnView();
        protected abstract string selectDataQuery();
        protected abstract string likeString();
        protected abstract void openCreateForm();
        protected abstract void openUpdateForm();
        protected abstract string deleteQuery();

        protected void loadData ()
        {
            if (!Classes.Connection.IsConnected())
            {
                MessageBox.Show("Connection Error: " + Classes.Connection.ConnectionError);
                return;
            }

            MySqlCommand command = new MySqlCommand(selectDataQuery(), Classes.Connection.GetConnection());
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

            gridColumnView();

            if (textBoxSearch.Text.Length != 0)
            {
                (dataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format(likeString(), textBoxSearch.Text);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            (dataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format(likeString(), textBoxSearch.Text);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            openCreateForm();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите редактируемую запись!");
                return;
            }
            openUpdateForm();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!Classes.Connection.IsConnected())
            {
                MessageBox.Show("Соединение с базой данных было прервано!");
                return;
            }
            if (dataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите удаляемую запись!");
                return;
            }
            if (MessageBox.Show("Удалить выбранную запись", "Удаление...", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            MySqlCommand command = new MySqlCommand(deleteQuery(), Classes.Connection.GetConnection());
            command.Parameters.AddWithValue("@id", dataGridView.SelectedRows[0].Cells[0].Value.ToString());
            try
            {
                command.ExecuteNonQuery();
                loadData();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
            }
        }
    }
}
