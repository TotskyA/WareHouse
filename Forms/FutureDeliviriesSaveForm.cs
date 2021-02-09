using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    public partial class FutureDeliviriesSaveForm : Templates.TemplateSaveForm
    {
        Action callback;
        decimal amount;


        public FutureDeliviriesSaveForm(Action callback)
        {
            InitializeComponent();
            this.callback = callback;
            Text = "Добавление продукции в будущие поставки";
            loadProductionTypes();
            loadProviders();
        }

        public FutureDeliviriesSaveForm(Dictionary<string, object> data, Action callback)
        {
            InitializeComponent();
            this.callback = callback;
            object id, id_production_type, id_production, id_provider, amount;
            if (!data.TryGetValue("id", out id) || !data.TryGetValue("id_production_type", out id_production_type) || 
                !data.TryGetValue("id_production", out id_production) || !data.TryGetValue("id_provider", out id_provider) || !data.TryGetValue("amount", out amount))
            {
                MessageBox.Show("Получены некорректные входные данные!");
                return;
            }
            loadProductionTypes();
            loadProviders();
            comboBoxProvider.SelectedValue = id_provider;
            comboBoxProductionType.SelectedValue = id_production_type;
            comboBoxProduction.SelectedValue = id_production;
            textBoxAmount.Text = amount.ToString();

            Text = "Редактирование продукции в будущих поставках";
            Id = id;
        }

        private void loadProductionTypes()
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
            comboBoxProductionType.SelectedIndex = -1;
        }

        private void loadProduction(object id_production_type)
        {
            if (!Classes.Connection.IsConnected())
            {
                MessageBox.Show("Соединение с базой данных было прервано!");
                return;
            }

            string sqlQuery = "select production.id, concat_ws(' ', production.title, \"(\", production.price, \"руб.\", unit.title, \")\") as fulltitle, unit.title, production.price from production, unit where id_unit = unit.id and id_production_type = " + id_production_type + " order by production.title asc";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, Classes.Connection.GetConnection());
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            comboBoxProduction.DataSource = dataSet.Tables[0];
            comboBoxProduction.DisplayMember = "fulltitle";
            comboBoxProduction.ValueMember = "id";
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
            comboBoxProvider.SelectedIndex = -1;
        }


        private void comboBoxProductionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxProductionType.SelectedIndex == -1)
            {
                return;
            }
            loadProduction(comboBoxProductionType.SelectedValue);
        }

        private void comboBoxProduction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxProduction.SelectedIndex == -1)
            {
                return;
            }
            DataTable dtable = (DataTable)comboBoxProduction.DataSource;
            labelUnit.Text = dtable.Rows[comboBoxProduction.SelectedIndex][2].ToString();
            if (!decimal.TryParse(textBoxAmount.Text, out amount) || amount <= 0)
            {
                return;
            }
            decimal price = (decimal)dtable.Rows[comboBoxProduction.SelectedIndex][3];
            labelFullprice.Text = (price * amount).ToString() + " руб.";
        }

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxProduction.SelectedIndex == -1)
            {
                return;
            }
            DataTable dtable = (DataTable)comboBoxProduction.DataSource;
            labelUnit.Text = dtable.Rows[comboBoxProduction.SelectedIndex][2].ToString();
            if (!decimal.TryParse(textBoxAmount.Text, out amount) || amount <= 0)
            {
                return;
            }
            decimal price = (decimal)dtable.Rows[comboBoxProduction.SelectedIndex][3];
            labelFullprice.Text = (price * amount).ToString() + " руб.";
        }

        protected override bool validateData()
        {
            if (comboBoxProvider.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите поставщика!");
                return false;
            }
            if (comboBoxProduction.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите продукцию!");
                return false;
            }
            if (!decimal.TryParse(textBoxAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Количество должно быть положительным числом!");
                return false;
            }
            return true;
        }

        protected override string createQuery()
        {
            return "insert into future_deliveries(id_production, id_provider, amount) " +
                "values(@id_production, @id_provider, @amount)";
        }

        protected override string updateQuery()
        {
            return "update future_deliveries set id_production = @id_production, id_provider = @id_provider, amount = @amount where id = @id";
        }

        void prepareParams(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@id_production", comboBoxProduction.SelectedValue);
            command.Parameters.AddWithValue("@id_provider", comboBoxProvider.SelectedValue);
            command.Parameters.AddWithValue("@amount", amount);
        }

        protected override void prepareCreateParams(MySqlCommand command)
        {
            prepareParams(command);
        }
        protected override void prepareUpdateParams(MySqlCommand command)
        {
            prepareParams(command);
            command.Parameters.AddWithValue("@id", Id);
        }
        protected override void Callback()
        {
            callback();
        }
    }
}
