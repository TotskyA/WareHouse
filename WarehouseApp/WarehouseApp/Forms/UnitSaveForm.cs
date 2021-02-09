using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WarehouseApp.Templates;
using MySql.Data.MySqlClient;

namespace WarehouseApp.Forms
{
    public partial class UnitSaveForm : TemplateSaveForm
    {
        Action callback;

        public UnitSaveForm(Action callback)
        {
            InitializeComponent();
            this.callback = callback;
            Text = "Добавление единицы измерения";
        }

        public UnitSaveForm(Dictionary<string, object> data, Action callback)
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
            Text = "Редактирование единицы измерения '" + title.ToString() + "'";
        }

        protected override bool validateData()
        {
            if(textBoxTitle.Text.Length == 0)
            {
                MessageBox.Show("Заполните наименование единицы измерения!");
                return false;
            }
            return true;
        }

        protected override string createQuery()
        {
            return "insert into unit(title) values(@title)";
        }

        protected override string updateQuery()
        {
            return "update unit set title = @title where id = @id";
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
