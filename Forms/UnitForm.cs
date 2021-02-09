using System;
using System.Collections.Generic;

namespace WarehouseApp.Forms
{
    public partial class UnitForm : Templates.TemplateDataForm
    {
        public UnitForm(bool deletion_allowed) : base(deletion_allowed)
        {
            InitializeComponent();
        }

        protected override void gridColumnView()
        {
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "Наименование единицы измерения";
        }

        protected override string selectDataQuery()
        {
            return "select id, title from unit order by title asc";
        }

        protected override string deleteQuery()
        {
            return "delete from unit where id = @id";
        }


        protected override string likeString()
        {
            return "title like '%{0}%'";
        }

        protected override void openCreateForm()
        {
            (new UnitSaveForm(new Action(() => { loadData(); }))).ShowDialog();
        }

        protected override void openUpdateForm()
        {
            (new UnitSaveForm(
                new Dictionary<string, object>() { ["id"] = dataGridView.SelectedRows[0].Cells[0].Value.ToString(), ["title"] = dataGridView.SelectedRows[0].Cells[1].Value.ToString() },
                new Action(() => { loadData(); }))
            ).ShowDialog();
        }

    }
}
