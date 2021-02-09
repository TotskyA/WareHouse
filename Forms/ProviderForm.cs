using System;
using System.Collections.Generic;

namespace WarehouseApp.Forms
{
    public partial class ProviderForm : Templates.TemplateDataForm
    {
        public ProviderForm(bool deletion_allowed) : base(deletion_allowed)
        {
            InitializeComponent();
            Text = "Поставщики продукции";
        }

        protected override void gridColumnView()
        {
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "Наименование поставщика";
            dataGridView.Columns[2].HeaderText = "Номер телефона";
            dataGridView.Columns[3].HeaderText = "Адрес";
        }

        protected override string selectDataQuery()
        {
            return "select id, title, phone, address from provider order by title asc";
        }

        protected override string deleteQuery()
        {
            return "delete from provider where id = @id";
        }


        protected override string likeString()
        {
            return "title like '%{0}%'";
        }

        protected override void openCreateForm()
        {
            (new ProviderSaveForm(new Action(() => { loadData(); }))).ShowDialog();
        }

        protected override void openUpdateForm()
        {
            (new ProviderSaveForm(
                new Dictionary<string, object>() {
                    ["id"] = dataGridView.SelectedRows[0].Cells[0].Value,
                    ["title"] = dataGridView.SelectedRows[0].Cells[1].Value,
                    ["phone"] = dataGridView.SelectedRows[0].Cells[2].Value,
                    ["address"] = dataGridView.SelectedRows[0].Cells[3].Value
                },
                new Action(() => { loadData(); }))
            ).ShowDialog();
        }
    }
}
