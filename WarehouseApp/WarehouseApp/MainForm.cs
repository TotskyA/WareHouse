using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.Forms;

namespace WarehouseApp
{
    public partial class MainForm : Form
    {
        private ConnectionForm connectionForm;
        bool deletion_allowed = true;
        public MainForm(ConnectionForm form, int mode)
        {
            InitializeComponent();
            connectionForm = form;
            loadWaybillData();
            loadWarehouseFullData();
            loadFDData();

            if(mode == 0)
            {
                Text = "База данных 'Склад', режим Кладовщик";
                buttonDeleteWaybill.Visible = false;
                buttonDeleteWarehouse.Visible = false;
                deletion_allowed = false;
            }
            else if(mode == 1)
            {
                Text = "База данных 'Склад', режим Директор";
            }
            else
            {
                Text = "База данных 'Склад', режим Завхоз";
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            connectionForm.Show();
        }

        private void единицыИзмеренияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitForm frm = new UnitForm(deletion_allowed);
            frm.ShowDialog();
        }

        private void типыПродукцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductionTypeForm frm = new ProductionTypeForm(deletion_allowed);
            frm.ShowDialog();
        }

        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProviderForm frm = new ProviderForm(deletion_allowed);
            frm.ShowDialog();
        }

        private void продукцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductionForm frm = new ProductionForm(deletion_allowed);
            frm.ShowDialog();
        }

        private void buttonCreateWaybill_Click(object sender, EventArgs e)
        {
            (new WaybillSaveForm(new Action(() => { loadWaybillData(); loadWarehouseFullData(); }))).ShowDialog();
        }

        private void buttonUpdateWaybill_Click(object sender, EventArgs e)
        {
            if (dataGridViewWaybill.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите редактируемую запись!");
                return;
            }
            (new WaybillSaveForm(
                new Dictionary<string, object>()
                {
                    ["id"] = dataGridViewWaybill.SelectedRows[0].Cells[0].Value,
                    ["date_created"] = dataGridViewWaybill.SelectedRows[0].Cells[1].Value,
                    ["id_provider"] = dataGridViewWaybill.SelectedRows[0].Cells[5].Value,
                },
                new Action(() => { loadWaybillData(); loadWarehouseFullData(); }))
            ).ShowDialog();
        }

        private void buttonDeleteWaybill_Click(object sender, EventArgs e)
        {
            if (dataGridViewWaybill.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите удаляемую запись!");
                return;
            }
            if (MessageBox.Show("Удалить выбранную запись", "Удаление...", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            MySqlCommand command = new MySqlCommand("delete from waybill where id = @id", Classes.Connection.GetConnection());
            command.Parameters.AddWithValue("@id", dataGridViewWaybill.SelectedRows[0].Cells[0].Value.ToString());
            try
            {
                command.ExecuteNonQuery();
                loadWaybillData();
                loadWarehouseFullData();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
            }
        }

        private void textBoxSearchWaybill_TextChanged(object sender, EventArgs e)
        {
            (dataGridViewWaybill.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert([id], System.String) like '%{0}%' OR Convert([date_created], System.String) like '%{0}%' OR title like '%{0}%' OR phone like '%{0}%' OR address like '%{0}%'", textBoxSearchWaybill.Text);
        }

        private void buttonClearWaybill_Click(object sender, EventArgs e)
        {
            textBoxSearchWaybill.Text = "";
        }

        protected void loadWaybillData()
        {
            if (!Classes.Connection.IsConnected())
            {
                MessageBox.Show("Connection Error: " + Classes.Connection.ConnectionError);
                return;
            }

            MySqlCommand command = new MySqlCommand("select waybill.id, waybill.date_created, provider.title, provider.phone, provider.address, waybill.id_provider from waybill, provider where provider.id = waybill.id_provider order by date_created desc", Classes.Connection.GetConnection());
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewWaybill.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при получении данных: " + ex.Message);
            }

            dataGridViewWaybill.Columns[0].HeaderText = "№ Накладной";
            dataGridViewWaybill.Columns[1].HeaderText = "Дата создания";
            dataGridViewWaybill.Columns[2].HeaderText = "Наименование поставщика";
            dataGridViewWaybill.Columns[3].HeaderText = "Телефон поставщика";
            dataGridViewWaybill.Columns[4].HeaderText = "Адрес поставщика";
            dataGridViewWaybill.Columns[5].Visible = false;

            if (textBoxSearchWaybill.Text.Length != 0)
            {
                (dataGridViewWaybill.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert([waybill.id], System.String) like '%{0}%' OR provider.title like '%{0}%' OR provider.phone like '%{0}%' OR provider.address like '%{0}%'", textBoxSearchWaybill.Text);
            }
        }

        protected void loadWarehouseData(object id_waybill)
        {
            if (!Classes.Connection.IsConnected())
            {
                MessageBox.Show("Connection Error: " + Classes.Connection.ConnectionError);
                return;
            }

            MySqlCommand command = new MySqlCommand("select warehouse.id, production.title, production.price, warehouse.amount, (production.price * warehouse.amount) as fullaprice, unit.title, production_type.title, waybill.date_created, warehouse.shelf_life, if(warehouse.is_defective = 0, 'Нет', 'Да'), warehouse.is_defective, " +
                "warehouse.id_waybill, production_type.id, production.id, waybill.date_created " +
                "from warehouse, production, unit, production_type, waybill " +
                "where production.id = warehouse.id_production and production.id_unit = unit.id and production.id_production_type = production_type.id and  warehouse.id_waybill = waybill.id and  waybill.id = " + id_waybill.ToString() +" order by production.title desc", Classes.Connection.GetConnection());
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewWarehouse.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при получении данных: " + ex.Message);
            }

            dataGridViewWarehouse.Columns[0].Visible = false;
            dataGridViewWarehouse.Columns[1].HeaderText = "Наименование продукции";
            dataGridViewWarehouse.Columns[2].HeaderText = "Стоимость единицы (руб.)";
            dataGridViewWarehouse.Columns[3].HeaderText = "Количество";
            dataGridViewWarehouse.Columns[4].HeaderText = "Стоимость, итого (руб.)";
            dataGridViewWarehouse.Columns[5].HeaderText = "Единица измерения";
            dataGridViewWarehouse.Columns[6].HeaderText = "Категория продукции";
            dataGridViewWarehouse.Columns[7].HeaderText = "Дата поставки";
            dataGridViewWarehouse.Columns[8].HeaderText = "Годен до";
            dataGridViewWarehouse.Columns[9].HeaderText = "Наличие дефектов";

            dataGridViewWarehouse.Columns[10].Visible = false;
            dataGridViewWarehouse.Columns[11].Visible = false;
            dataGridViewWarehouse.Columns[12].Visible = false;
            dataGridViewWarehouse.Columns[13].Visible = false;
            dataGridViewWarehouse.Columns[14].Visible = false;
        }

        private void dataGridViewWaybill_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewWaybill.SelectedRows.Count != 1)
            {
                return;
            }
            groupBox2.Text = "Товары в накладной № " + dataGridViewWaybill.SelectedRows[0].Cells[0].Value +
                " от " + ((DateTime)dataGridViewWaybill.SelectedRows[0].Cells[1].Value).ToString("dd.MM.yyyy") + " ( поставщик " +
                dataGridViewWaybill.SelectedRows[0].Cells[2].Value + ")";

            loadWarehouseData(dataGridViewWaybill.SelectedRows[0].Cells[0].Value);
        }

        private void buttonCreateWarehouse_Click(object sender, EventArgs e)
        {
            if (dataGridViewWaybill.SelectedRows.Count != 1)
            {
                return;
            }
            (new WarehouseSaveForm(new Action(() => { loadWarehouseData(dataGridViewWaybill.SelectedRows[0].Cells[0].Value); loadWarehouseFullData(); }), (int)dataGridViewWaybill.SelectedRows[0].Cells[0].Value, (DateTime)dataGridViewWaybill.SelectedRows[0].Cells[1].Value)).ShowDialog();
        }

        private void buttonUpdateWarehouse_Click(object sender, EventArgs e)
        {
            if (dataGridViewWarehouse.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите редактируемую запись!");
                return;
            }
            (new WarehouseSaveForm(
                new Dictionary<string, object>()
                {
                    ["id"] = dataGridViewWarehouse.SelectedRows[0].Cells[0].Value,
                    ["amount"] = dataGridViewWarehouse.SelectedRows[0].Cells[3].Value,
                    ["shelf_life"] = (dataGridViewWarehouse.SelectedRows[0].Cells[8].Value is DBNull) ? null : dataGridViewWarehouse.SelectedRows[0].Cells[8].Value,
                    ["is_defective"] = dataGridViewWarehouse.SelectedRows[0].Cells[10].Value,

                    ["id_waybill"] = dataGridViewWarehouse.SelectedRows[0].Cells[11].Value,
                    ["id_production_type"] = dataGridViewWarehouse.SelectedRows[0].Cells[12].Value,
                    ["id_production"] = dataGridViewWarehouse.SelectedRows[0].Cells[13].Value,
                    ["waybill_date_created"] = dataGridViewWarehouse.SelectedRows[0].Cells[14].Value,

                },
                new Action(() => { loadWarehouseData(dataGridViewWaybill.SelectedRows[0].Cells[0].Value); loadWarehouseFullData(); }))
            ).ShowDialog();
        }

        private void buttonDeleteWarehouse_Click(object sender, EventArgs e)
        {
            if (dataGridViewWarehouse.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите удаляемую запись!");
                return;
            }
            if (MessageBox.Show("Удалить выбранную запись", "Удаление...", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            MySqlCommand command = new MySqlCommand("delete from warehouse where id = @id", Classes.Connection.GetConnection());
            command.Parameters.AddWithValue("@id", dataGridViewWarehouse.SelectedRows[0].Cells[0].Value.ToString());
            try
            {
                command.ExecuteNonQuery();
                loadWarehouseData(dataGridViewWaybill.SelectedRows[0].Cells[0].Value);
                loadWarehouseFullData();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
            }
        }

        private void buttonShowWaybill_Click(object sender, EventArgs e)
        {
            if (dataGridViewWaybill.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите накладную для просмотра!");
                return;
            }
            (new WaybillViewForm(
                new Dictionary<string, object>()
                {
                    ["id"] = dataGridViewWaybill.SelectedRows[0].Cells[0].Value,
                    ["date_created"] = dataGridViewWaybill.SelectedRows[0].Cells[1].Value,
                    ["provider_title"] = dataGridViewWaybill.SelectedRows[0].Cells[2].Value,
                    ["provider_phone"] = dataGridViewWaybill.SelectedRows[0].Cells[3].Value,
                    ["provider_adress"] = dataGridViewWaybill.SelectedRows[0].Cells[4].Value,
                })
            ).ShowDialog();
        }

        void loadWarehouseFullData()
        {
            if (!Classes.Connection.IsConnected())
            {
                MessageBox.Show("Connection Error: " + Classes.Connection.ConnectionError);
                return;
            }

            MySqlCommand command = new MySqlCommand("select production.title as p_title, concat_ws(' ', sum(warehouse.amount), unit.title) as f_amount, production_type.title as pt_title " +
                "from warehouse, production, unit, production_type where warehouse.id_production = production.id and unit.id = production.id_unit and production_type.id = production.id_production_type group by production.id, production.title, unit.title, production_type.title order by production.title asc", Classes.Connection.GetConnection());
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewFullWarehouse.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при получении данных: " + ex.Message);
            }

            dataGridViewFullWarehouse.Columns[0].HeaderText = "Наименование продукции";
            dataGridViewFullWarehouse.Columns[1].HeaderText = "Количество на складе";
            dataGridViewFullWarehouse.Columns[2].HeaderText = "Тип продукции";
        }

        private void buttonWarehouseClear_Click(object sender, EventArgs e)
        {
            textBoxWarehouseSearch.Text = "";
        }

        private void textBoxWarehouseSearch_TextChanged(object sender, EventArgs e)
        {
            (dataGridViewFullWarehouse.DataSource as DataTable).DefaultView.RowFilter = string.Format("p_title like '%{0}%' OR pt_title like '%{0}%'", textBoxWarehouseSearch.Text);
        }

        protected void loadFDData()
        {
            if (!Classes.Connection.IsConnected())
            {
                MessageBox.Show("Connection Error: " + Classes.Connection.ConnectionError);
                return;
            }

            MySqlCommand command = new MySqlCommand("select future_deliveries.id, future_deliveries.id_provider, future_deliveries.id_production, future_deliveries.amount, production_type.id,  provider.title, provider.phone, provider.address, production_type.title, production.title, concat_ws(' ', future_deliveries.amount, unit.title),  future_deliveries.amount * production.price" + 
                " from provider, production, future_deliveries, production_type, unit " +
                " where provider.id = future_deliveries.id_provider and production.id = future_deliveries.id_production and production_type.id = production.id_production_type and production.id_unit = unit.id", Classes.Connection.GetConnection());
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewFutureDeliveries.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при получении данных: " + ex.Message);
            }

            dataGridViewFutureDeliveries.Columns[0].Visible = false;
            dataGridViewFutureDeliveries.Columns[1].Visible = false;
            dataGridViewFutureDeliveries.Columns[2].Visible = false;
            dataGridViewFutureDeliveries.Columns[3].Visible = false;
            dataGridViewFutureDeliveries.Columns[4].Visible = false;
            dataGridViewFutureDeliveries.Columns[5].HeaderText = "Наименование поставщика";
            dataGridViewFutureDeliveries.Columns[6].HeaderText = "Телефон поставщика";
            dataGridViewFutureDeliveries.Columns[7].HeaderText = "Адрес поставщика";
            dataGridViewFutureDeliveries.Columns[8].HeaderText = "Категория продукции";
            dataGridViewFutureDeliveries.Columns[9].HeaderText = "Наименование продукции";
            dataGridViewFutureDeliveries.Columns[10].HeaderText = "Количество";
            dataGridViewFutureDeliveries.Columns[11].HeaderText = "Итого, руб.";
        }



        private void sQLЗапросыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new CustomQueryForm()).ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCreateFD_Click(object sender, EventArgs e)
        {
            (new FutureDeliviriesSaveForm(new Action(() => { loadFDData(); }))).ShowDialog();
        }

        private void buttonUpdateFD_Click(object sender, EventArgs e)
        {
            if (dataGridViewFutureDeliveries.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите редактируемую запись!");
                return;
            }
            (new FutureDeliviriesSaveForm(
                new Dictionary<string, object>()
                {
                    ["id"] = dataGridViewFutureDeliveries.SelectedRows[0].Cells[0].Value,
                    ["id_provider"] = dataGridViewFutureDeliveries.SelectedRows[0].Cells[1].Value,
                    ["id_production"] = dataGridViewFutureDeliveries.SelectedRows[0].Cells[2].Value,
                    ["amount"] = dataGridViewFutureDeliveries.SelectedRows[0].Cells[3].Value,
                    ["id_production_type"] = dataGridViewFutureDeliveries.SelectedRows[0].Cells[4].Value,
                },
                new Action(() => { loadFDData(); }))
            ).ShowDialog();
        }

        private void buttonDeleteFD_Click(object sender, EventArgs e)
        {
            if (dataGridViewFutureDeliveries.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите удаляемую запись!");
                return;
            }
            if (MessageBox.Show("Удалить выбранную запись", "Удаление...", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            MySqlCommand command = new MySqlCommand("delete from future_deliveries where id = @id", Classes.Connection.GetConnection());
            command.Parameters.AddWithValue("@id", dataGridViewFutureDeliveries.SelectedRows[0].Cells[0].Value.ToString());
            try
            {
                command.ExecuteNonQuery();
                loadFDData();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
            }
        }
    }
}
