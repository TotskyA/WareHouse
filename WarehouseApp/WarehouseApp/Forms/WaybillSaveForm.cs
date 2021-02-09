using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    public partial class WaybillSaveForm : Templates.TemplateSaveForm
    {
        Action callback;

        public WaybillSaveForm(Action callback)
        {
            InitializeComponent();
            this.callback = callback;
            Text = "Создание накладной";
            loadProviders();
            dateTimePickerDateCreated.Value = DateTime.Now;
        }

        public WaybillSaveForm(Dictionary<string, object> data, Action callback)
        {
            InitializeComponent();
            this.callback = callback;
            object id, date_created, id_provider;
            if (!data.TryGetValue("id", out id) || !data.TryGetValue("date_created", out date_created) ||
                !data.TryGetValue("id_provider", out id_provider))
            {
                MessageBox.Show("Получены некорректные входные данные!");
                return;
            }

            loadProviders();
            comboBoxProvider.SelectedValue = id_provider;
            dateTimePickerDateCreated.Value = (DateTime)date_created;
            Text = "Редактирование накладной № " + id.ToString();
            Id = id;
        }

        private void loadProviders()
        {
            if (!Classes.Connection.IsConnected())
            {
                MessageBox.Show("Соединение с базой данных было прервано!");
                return;
            }

            string sqlQuery = "select id, title from provider order by title asc";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, Classes.Connection.GetConnection());
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            comboBoxProvider.DataSource = dataSet.Tables[0];
            comboBoxProvider.DisplayMember = "title";
            comboBoxProvider.ValueMember = "id";
        }

        protected override bool validateData()
        {
            if (comboBoxProvider.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите поставщика!");
                return false;
            }
            if (dateTimePickerDateCreated.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Дата не может быть больше текущей!");
                return false;
            }
            return true;
        }

        protected override string createQuery()
        {
            return "insert into waybill(date_created, id_provider) " +
                "values(@date_created, @id_provider)";
        }

        protected override string updateQuery()
        {
            return "update waybill set date_created = @date_created, id_provider = @id_provider where id = @id";
        }

        protected override void prepareCreateParams(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@date_created", dateTimePickerDateCreated.Value.Date);
            command.Parameters.AddWithValue("@id_provider", comboBoxProvider.SelectedValue);
        }
        protected override void prepareUpdateParams(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@date_created", dateTimePickerDateCreated.Value.Date);
            command.Parameters.AddWithValue("@id_provider", comboBoxProvider.SelectedValue);
            command.Parameters.AddWithValue("@id", Id);
        }
        protected override void Callback()
        {
            callback();
        }
    }
}
