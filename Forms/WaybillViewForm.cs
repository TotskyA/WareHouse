using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    public partial class WaybillViewForm : Form
    {
        public WaybillViewForm(Dictionary<string, object> data)
        {
            InitializeComponent();
            object id, date_created, provider_title, provider_phone, provider_adress;
            if (!data.TryGetValue("id", out id) || !data.TryGetValue("date_created", out date_created) ||
                !data.TryGetValue("provider_title", out provider_title) || !data.TryGetValue("provider_phone", out provider_phone) ||
                !data.TryGetValue("provider_adress", out provider_adress))
            {
                MessageBox.Show("Получены некорректные входные данные!");
                return;
            }

            Text = "Просмотр накладной № " + id.ToString();
            textBoxWaybillId.Text = id.ToString();
            textBoxWaybillDate.Text = ((DateTime)date_created).ToString("dd.MM.yyyy");
            textBoxWaybillProvider.Text = provider_title.ToString();
            textBoxWaybollProviderPhone.Text = provider_phone.ToString();
            textBoxWaybillProviderAddress.Text = provider_adress.ToString();


            if (!Classes.Connection.IsConnected())
            {
                MessageBox.Show("Connection Error: " + Classes.Connection.ConnectionError);
                return;
            }

            MySqlCommand command = new MySqlCommand("select production.title, concat_ws(' ', warehouse.amount, unit.title), (production.price * warehouse.amount) as fullaprice, production_type.title, waybill.date_created, warehouse.shelf_life, if(warehouse.is_defective = 0, 'Нет', 'Да')  " +
                "from warehouse, production, unit, production_type,waybill " +
                "where production.id = warehouse.id_production and production.id_unit = unit.id and production.id_production_type = production_type.id and warehouse.id_waybill = waybill.id and waybill.id = " + id.ToString() + " order by production.title desc", Classes.Connection.GetConnection());
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

            dataGridView.Columns[0].HeaderText = "Наименование продукции";
            dataGridView.Columns[1].HeaderText = "Количество";
            dataGridView.Columns[2].HeaderText = "Стоимость, итого (руб.)";
            dataGridView.Columns[3].HeaderText = "Категория продукции";
            dataGridView.Columns[4].HeaderText = "Дата поставки";
            dataGridView.Columns[5].HeaderText = "Годен до";
            dataGridView.Columns[6].HeaderText = "Наличие дефектов";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
