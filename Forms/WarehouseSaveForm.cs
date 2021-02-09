using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    public partial class WarehouseSaveForm : Templates.TemplateSaveForm
    {
        Action callback;
        int id_waybill;
        DateTime waybill_date;
        decimal amount;


        public WarehouseSaveForm(Action callback, int id_waybill, DateTime waybill_date)
        {
            InitializeComponent();
            this.callback = callback;
            this.id_waybill = id_waybill;
            this.waybill_date = waybill_date;
            Text = "Добавление продукции в накладную";
            loadProductionTypes();
        }

        public WarehouseSaveForm(Dictionary<string, object> data, Action callback)
        {
            InitializeComponent();
            this.callback = callback;
            object id, id_production_type, id_production, id_waybill, amount, shelf_life, is_defective;
            if (!data.TryGetValue("id", out id) || !data.TryGetValue("id_production_type", out id_production_type) || !data.TryGetValue("id_production", out id_production) ||
                !data.TryGetValue("id_waybill", out id_waybill) || !data.TryGetValue("amount", out amount) || !data.TryGetValue("shelf_life",out  shelf_life) || !data.TryGetValue("is_defective", out is_defective))
            {
                MessageBox.Show("Получены некорректные входные данные!");
                return;
            }

            this.id_waybill = (int)id_waybill;

            loadProductionTypes();
            comboBoxProductionType.SelectedValue = id_production_type;
            comboBoxProduction.SelectedValue = id_production;
            if(shelf_life != null)
            {
                dateTimePickerShelfLife.Value = (DateTime)shelf_life;
            }
            else
            {
                checkBoxIsShelfLife.Checked = true;
            }
            checkBoxIsDefective.Checked = (Convert.ToInt32(is_defective) == 0) ? false : true;

            textBoxAmount.Text = amount.ToString();
            Text = "Редактирование продукции в накладной № " + id_waybill.ToString();
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
            decimal amount;
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
            decimal amount;
            if (!decimal.TryParse(textBoxAmount.Text, out amount) || amount <= 0)
            {
                return;
            }
            decimal price = (decimal)dtable.Rows[comboBoxProduction.SelectedIndex][3];
            labelFullprice.Text = (price * amount).ToString() + " руб.";
        }

        protected override bool validateData()
        {
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
            if(!checkBoxIsShelfLife.Checked && dateTimePickerShelfLife.Value.Date < waybill_date)
            {
                MessageBox.Show("Дата истечения срока годности не может быть меньше даты поставки!");
                return false;
            }

            return true;
        }

        protected override string createQuery()
        {
            return "insert into warehouse(id_production, id_waybill, amount, shelf_life, is_defective) " +
                "values(@id_production, @id_waybill, @amount, @shelf_life, @is_defective)";
        }

        protected override string updateQuery()
        {
            return "update warehouse set id_production = @id_production, id_waybill = @id_waybill, amount = @amount, shelf_life = @shelf_life, is_defective = @is_defective where id = @id";
        }

        void prepareParams(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@id_production", comboBoxProduction.SelectedValue);
            command.Parameters.AddWithValue("@id_waybill", id_waybill);
            command.Parameters.AddWithValue("@amount", amount);
            if (checkBoxIsShelfLife.Checked)
            {
                command.Parameters.AddWithValue("@shelf_life", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@shelf_life", dateTimePickerShelfLife.Value.Date);
            }
            command.Parameters.AddWithValue("@is_defective", (checkBoxIsDefective.Checked) ? 1 : 0);
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

        private void checkBoxIsShelfLife_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxIsShelfLife.Checked)
            {
                dateTimePickerShelfLife.Visible = false;
            }
            else
            {
                dateTimePickerShelfLife.Visible = true;
            }
        }
    }
}
