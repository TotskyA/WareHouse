using System;
using System.Collections.Generic;

namespace WarehouseApp.Forms
{
    public partial class ProductionTypeForm : Templates.TemplateDataForm
    {
        public ProductionTypeForm(bool deletion_allowed) : base(deletion_allowed)
        {
            InitializeComponent();
            Text = "Типы продукции";
        }

        protected override void gridColumnView()
        {
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "Наименование типа продукции";
        }

        protected override string selectDataQuery()
        {
            return "select id, title from production_type order by title asc";
        }

        protected override string deleteQuery()
        {
            return "delete from production_type where id = @id";
        }


        protected override string likeString()
        {
            return "title like '%{0}%'";
        }

        protected override void openCreateForm()
        {
            (new ProductionTypeSaveForm(new Action(() => { loadData(); }))).ShowDialog();
        }

        protected override void openUpdateForm()
        {
            (new ProductionTypeSaveForm(
                new Dictionary<string, object>() { ["id"] = dataGridView.SelectedRows[0].Cells[0].Value.ToString(), ["title"] = dataGridView.SelectedRows[0].Cells[1].Value.ToString() },
                new Action(() => { loadData(); }))
            ).ShowDialog();
        }

    }
}
