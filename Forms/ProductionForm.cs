using System;
using System.Collections.Generic;

namespace WarehouseApp.Forms
{
    public partial class ProductionForm : Templates.TemplateDataForm
    {
        public ProductionForm(bool deletion_allowed) : base(deletion_allowed)
        {
            InitializeComponent();
            Text = "Продукция";
        }

        protected override void gridColumnView()
        {
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "Наименование продукции";
            dataGridView.Columns[2].HeaderText = "Стоимость, руб.";
            dataGridView.Columns[3].Visible = false;
            dataGridView.Columns[4].Visible = false;
            dataGridView.Columns[5].HeaderText = "Тип продукции";
            dataGridView.Columns[6].HeaderText = "Единица измерения";
        }

        protected override string selectDataQuery()
        {
            return "select production.id, production.title, production.price, production.id_production_type, production.id_unit, production_type.title, unit.title " +
                "from production, production_type, unit where production.id_production_type = production_type.id and production.id_unit = unit.id order by production.title asc";
        }

        protected override string deleteQuery()
        {
            return "delete from production where id = @id";
        }


        protected override string likeString()
        {
            return "production.title like '%{0}%' or production_type.title like '%{0}%'";
        }

        protected override void openCreateForm()
        {
            (new ProductionSaveForm(new Action(() => { loadData(); }))).ShowDialog();
        }

        protected override void openUpdateForm()
        {
            (new ProductionSaveForm(
                new Dictionary<string, object>()
                {
                    ["id"] = dataGridView.SelectedRows[0].Cells[0].Value,
                    ["title"] = dataGridView.SelectedRows[0].Cells[1].Value,
                    ["price"] = dataGridView.SelectedRows[0].Cells[2].Value,
                    ["id_production_type"] = dataGridView.SelectedRows[0].Cells[3].Value,
                    ["id_unit"] = dataGridView.SelectedRows[0].Cells[4].Value,
                },
                new Action(() => { loadData(); }))
            ).ShowDialog();
        }
    }
}
