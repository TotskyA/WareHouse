using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    public partial class ProductionTypeSaveForm : Templates.TemplateSaveForm
    {
        Action callback;

        public ProductionTypeSaveForm(Action callback)
        {
            InitializeComponent();
            this.callback = callback;
            Text = "Добавление типа продукции";
        }

        public ProductionTypeSaveForm(Dictionary<string, object> data, Action callback)
        {
            InitializeComponent();
            this.callback = callback;
            object id, title;
            if (!data.TryGetValue("id", out id) || !data.TryGetValue("title", out title))
            {
                MessageBox.Show("Получены некорректные входные данные!");
                return;
            }
            textBoxTitle.Text = title.ToString();
            Id = id;
            Text = "Редактирование типа продукции '" + title.ToString() + "'";
        }

        protected override bool validateData()
        {
            if (textBoxTitle.Text.Length == 0)
            {
                MessageBox.Show("Заполните наименование типа продукции!");
                return false;
            }
            return true;
        }

        protected override string createQuery()
        {
            return "insert into production_type(title) values(@title)";
        }

        protected override string updateQuery()
        {
            return "update production_type set title = @title where id = @id";
        }

        protected override void prepareCreateParams(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@title", textBoxTitle.Text);
        }
        protected override void prepareUpdateParams(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@title", textBoxTitle.Text);
            command.Parameters.AddWithValue("@id", Id);
        }
        protected override void Callback()
        {
            callback();
        }
    }
}
