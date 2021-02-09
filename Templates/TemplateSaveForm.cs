using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WarehouseApp.Templates
{
    public abstract partial class TemplateSaveForm : Form
    {

        protected object Id { get; set; }

        public TemplateSaveForm()
        {
            InitializeComponent();
        }

        protected abstract bool validateData();
        protected abstract string createQuery();
        protected abstract string updateQuery();
        protected abstract void prepareCreateParams(MySqlCommand command);
        protected abstract void prepareUpdateParams(MySqlCommand command);
        protected abstract void Callback();

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!Classes.Connection.IsConnected())
            {
                MessageBox.Show("Соединение с базой данных было прервано!");
                return;
            }
            if (!validateData()) return;
            MySqlCommand command = new MySqlCommand(getQuery(), Classes.Connection.GetConnection());
            prepareParams(command);
            try
            {
                command.ExecuteNonQuery();
                Callback();
                Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Во время сохранения данных произошли ошибки: " + ex.Message);
            }
        }

        private void prepareParams (MySqlCommand command)
        {
            if(Id == null)
            {
                prepareCreateParams(command);
            }
            else
            {
                prepareUpdateParams(command);
            }
        }

        private string getQuery ()
        {
            if (Id == null)
            {
                return createQuery();
            }
            else
            {
                return updateQuery();
            }
        }

    }
}
