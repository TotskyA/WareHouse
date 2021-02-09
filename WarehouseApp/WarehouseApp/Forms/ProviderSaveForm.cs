using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WarehouseApp.Forms
{
    public partial class ProviderSaveForm : Templates.TemplateSaveForm
    {
        Action callback;

        public ProviderSaveForm(Action callback)
        {
            InitializeComponent();
            this.callback = callback;
            Text = "Добавление поставщика";
        }

        public ProviderSaveForm(Dictionary<string, object> data, Action callback)
        {
            InitializeComponent();
            this.callback = callback;
            object id, title, phone, address;
            if (!data.TryGetValue("id", out id) || !data.TryGetValue("title", out title) ||
                !data.TryGetValue("phone", out phone) || !data.TryGetValue("address", out address))
            {
                MessageBox.Show("Получены некорректные входные данные!");
                return;
            }
            textBoxTitle.Text = title.ToString();
            textBoxPhone.Text = phone.ToString();
            textBoxAddress.Text = address.ToString();
            Id = id;
            Text = "Редактирование поставщика '" + title.ToString() + "'";
        }

        protected override bool validateData()
        {
            if (textBoxTitle.Text.Length == 0)
            {
                MessageBox.Show("Заполните наименование поставщика!");
                return false;
            }
            return true;
        }

        protected override string createQuery()
        {
            return "insert into provider(title, phone, address) values(@title, @phone, @address)";
        }

        protected override string updateQuery()
        {
            return "update provider set title = @title, phone = @phone, address = @address where id = @id";
        }

        protected override void prepareCreateParams(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@title", textBoxTitle.Text);
            command.Parameters.AddWithValue("@phone", textBoxPhone.Text);
            command.Parameters.AddWithValue("@address", textBoxAddress.Text);
        }
        protected override void prepareUpdateParams(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@title", textBoxTitle.Text);
            command.Parameters.AddWithValue("@phone", textBoxPhone.Text);
            command.Parameters.AddWithValue("@address", textBoxAddress.Text);
            command.Parameters.AddWithValue("@id", Id);
        }
        protected override void Callback()
        {
            callback();
        }
    }
}
