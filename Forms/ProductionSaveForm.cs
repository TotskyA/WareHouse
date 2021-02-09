using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    public partial class ProductionSaveForm : Templates.TemplateSaveForm
    {
        Action callback;
        decimal price;

        public ProductionSaveForm(Action callback)
        {
            InitializeComponent();
            this.callback = callback;
            Text = "Добавление продукции";
            loadProductionTypes();
            loadUnits();
        }

        public ProductionSaveForm(Dictionary<string, object> data, Action callback)
        {
            InitializeComponent();
            this.callback = callback;
            object id, title, price, id_production_type, id_unit;
            if (!data.TryGetValue("id", out id) || !data.TryGetValue("title", out title) || !data.TryGetValue("price", out price) ||
                !data.TryGetValue("id_production_type", out id_production_type) || !data.TryGetValue("id_unit", out id_unit))
            {
                MessageBox.Show("Получены некорректные входные данные!");
                return;
            }

            loadProductionTypes();
            loadUnits();

            textBoxTitle.Text = title.ToString();
            textBoxPrice.Text = price.ToString();
            comboBoxProductionType.SelectedValue = id_production_type;
            comboBoxUnit.SelectedValue = id_unit;
            Text = "Редактирование продукции '" + title.ToString() + "'";
            Id = id;
        }

        private void loadProductionTypes ()
        {
            if (!Classes.Connection.IsConnected())
            {
                MessageBox.Show("Соединение с базой данных было прервано!");
                return;
            }

            string sqlQuery = "select id, title from production_type order by title asc";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, Classes.Connection.GetConnection());
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            comboBoxProductionType.DataSource = dataSet.Tables[0];
            comboBoxProductionType.DisplayMember = "title";
            comboBoxProductionType.ValueMember = "id";
        }

        private void loadUnits()
        {
            if (!Classes.Connection.IsConnected())
            {
                MessageBox.Show("Соединение с базой данных было прервано!");
                return;
            }

            string sqlQuery = "select id, title from unit order by title asc";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, Classes.Connection.GetConnection());
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            comboBoxUnit.DataSource = dataSet.Tables[0];
            comboBoxUnit.DisplayMember = "title";
            comboBoxUnit.ValueMember = "id";
        }

        protected override bool validateData()
        {
            if (textBoxTitle.Text.Length == 0)
            {
                MessageBox.Show("Заполните наименование продукции!");
                return false;
            }
            if (!decimal.TryParse(textBoxPrice.Text, out price) || price < 0)
            {
                MessageBox.Show("Стоимость продукции должна быть положительным числом!");
                return false;
            }
            return true;
        }

        protected override string createQuery()
        {
            return "insert into production(title, price, id_production_type, id_unit) " +
                "values(@title, @price, @id_production_type, @id_unit)";
        }

        protected override string updateQuery()
        {
            return "update production set title = @title, price = @price, id_production_type = @id_production_type, id_unit = @id_unit where id = @id";
        }

        protected override void prepareCreateParams(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@title", textBoxTitle.Text);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@id_production_type", comboBoxProductionType.SelectedValue);
            command.Parameters.AddWithValue("@id_unit", comboBoxUnit.SelectedValue);
        }
        protected override void prepareUpdateParams(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@title", textBoxTitle.Text);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@id_production_type", comboBoxProductionType.SelectedValue);
            command.Parameters.AddWithValue("@id_unit", comboBoxUnit.SelectedValue);
            command.Parameters.AddWithValue("@id", Id);
        }
        protected override void Callback()
        {
            callback();
        }
    }
}
