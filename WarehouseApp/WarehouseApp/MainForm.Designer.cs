namespace WarehouseApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.единицыИзмеренияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типыПродукцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.продукцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поставщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLЗапросыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteWarehouse = new System.Windows.Forms.Button();
            this.buttonUpdateWarehouse = new System.Windows.Forms.Button();
            this.buttonCreateWarehouse = new System.Windows.Forms.Button();
            this.dataGridViewWarehouse = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonShowWaybill = new System.Windows.Forms.Button();
            this.buttonDeleteWaybill = new System.Windows.Forms.Button();
            this.buttonUpdateWaybill = new System.Windows.Forms.Button();
            this.buttonCreateWaybill = new System.Windows.Forms.Button();
            this.dataGridViewWaybill = new System.Windows.Forms.DataGridView();
            this.textBoxSearchWaybill = new System.Windows.Forms.TextBox();
            this.buttonClearWaybill = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewFullWarehouse = new System.Windows.Forms.DataGridView();
            this.buttonWarehouseClear = new System.Windows.Forms.Button();
            this.textBoxWarehouseSearch = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonDeleteFD = new System.Windows.Forms.Button();
            this.buttonUpdateFD = new System.Windows.Forms.Button();
            this.buttonCreateFD = new System.Windows.Forms.Button();
            this.dataGridViewFutureDeliveries = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWaybill)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFullWarehouse)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFutureDeliveries)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справочникToolStripMenuItem,
            this.sQLЗапросыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(993, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.единицыИзмеренияToolStripMenuItem,
            this.типыПродукцииToolStripMenuItem,
            this.продукцияToolStripMenuItem,
            this.поставщикиToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // единицыИзмеренияToolStripMenuItem
            // 
            this.единицыИзмеренияToolStripMenuItem.Name = "единицыИзмеренияToolStripMenuItem";
            this.единицыИзмеренияToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.единицыИзмеренияToolStripMenuItem.Text = "Единицы измерения";
            this.единицыИзмеренияToolStripMenuItem.Click += new System.EventHandler(this.единицыИзмеренияToolStripMenuItem_Click);
            // 
            // типыПродукцииToolStripMenuItem
            // 
            this.типыПродукцииToolStripMenuItem.Name = "типыПродукцииToolStripMenuItem";
            this.типыПродукцииToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.типыПродукцииToolStripMenuItem.Text = "Типы продукции";
            this.типыПродукцииToolStripMenuItem.Click += new System.EventHandler(this.типыПродукцииToolStripMenuItem_Click);
            // 
            // продукцияToolStripMenuItem
            // 
            this.продукцияToolStripMenuItem.Name = "продукцияToolStripMenuItem";
            this.продукцияToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.продукцияToolStripMenuItem.Text = "Продукция";
            this.продукцияToolStripMenuItem.Click += new System.EventHandler(this.продукцияToolStripMenuItem_Click);
            // 
            // поставщикиToolStripMenuItem
            // 
            this.поставщикиToolStripMenuItem.Name = "поставщикиToolStripMenuItem";
            this.поставщикиToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.поставщикиToolStripMenuItem.Text = "Поставщики";
            this.поставщикиToolStripMenuItem.Click += new System.EventHandler(this.поставщикиToolStripMenuItem_Click);
            // 
            // sQLЗапросыToolStripMenuItem
            // 
            this.sQLЗапросыToolStripMenuItem.Name = "sQLЗапросыToolStripMenuItem";
            this.sQLЗапросыToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.sQLЗапросыToolStripMenuItem.Text = "SQL запросы";
            this.sQLЗапросыToolStripMenuItem.Click += new System.EventHandler(this.sQLЗапросыToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(969, 482);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(961, 456);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Накладные";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonDeleteWarehouse);
            this.groupBox2.Controls.Add(this.buttonUpdateWarehouse);
            this.groupBox2.Controls.Add(this.buttonCreateWarehouse);
            this.groupBox2.Controls.Add(this.dataGridViewWarehouse);
            this.groupBox2.Location = new System.Drawing.Point(6, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(949, 231);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Товары в накладной";
            // 
            // buttonDeleteWarehouse
            // 
            this.buttonDeleteWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteWarehouse.Location = new System.Drawing.Point(847, 77);
            this.buttonDeleteWarehouse.Name = "buttonDeleteWarehouse";
            this.buttonDeleteWarehouse.Size = new System.Drawing.Size(96, 23);
            this.buttonDeleteWarehouse.TabIndex = 10;
            this.buttonDeleteWarehouse.Text = "Удалить";
            this.buttonDeleteWarehouse.UseVisualStyleBackColor = true;
            this.buttonDeleteWarehouse.Click += new System.EventHandler(this.buttonDeleteWarehouse_Click);
            // 
            // buttonUpdateWarehouse
            // 
            this.buttonUpdateWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateWarehouse.Location = new System.Drawing.Point(847, 48);
            this.buttonUpdateWarehouse.Name = "buttonUpdateWarehouse";
            this.buttonUpdateWarehouse.Size = new System.Drawing.Size(96, 23);
            this.buttonUpdateWarehouse.TabIndex = 9;
            this.buttonUpdateWarehouse.Text = "Редактировать";
            this.buttonUpdateWarehouse.UseVisualStyleBackColor = true;
            this.buttonUpdateWarehouse.Click += new System.EventHandler(this.buttonUpdateWarehouse_Click);
            // 
            // buttonCreateWarehouse
            // 
            this.buttonCreateWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateWarehouse.Location = new System.Drawing.Point(847, 19);
            this.buttonCreateWarehouse.Name = "buttonCreateWarehouse";
            this.buttonCreateWarehouse.Size = new System.Drawing.Size(96, 23);
            this.buttonCreateWarehouse.TabIndex = 8;
            this.buttonCreateWarehouse.Text = "Добавить";
            this.buttonCreateWarehouse.UseVisualStyleBackColor = true;
            this.buttonCreateWarehouse.Click += new System.EventHandler(this.buttonCreateWarehouse_Click);
            // 
            // dataGridViewWarehouse
            // 
            this.dataGridViewWarehouse.AllowUserToAddRows = false;
            this.dataGridViewWarehouse.AllowUserToDeleteRows = false;
            this.dataGridViewWarehouse.AllowUserToResizeColumns = false;
            this.dataGridViewWarehouse.AllowUserToResizeRows = false;
            this.dataGridViewWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWarehouse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWarehouse.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarehouse.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewWarehouse.MultiSelect = false;
            this.dataGridViewWarehouse.Name = "dataGridViewWarehouse";
            this.dataGridViewWarehouse.ReadOnly = true;
            this.dataGridViewWarehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWarehouse.Size = new System.Drawing.Size(834, 205);
            this.dataGridViewWarehouse.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonShowWaybill);
            this.groupBox1.Controls.Add(this.buttonDeleteWaybill);
            this.groupBox1.Controls.Add(this.buttonUpdateWaybill);
            this.groupBox1.Controls.Add(this.buttonCreateWaybill);
            this.groupBox1.Controls.Add(this.dataGridViewWaybill);
            this.groupBox1.Controls.Add(this.textBoxSearchWaybill);
            this.groupBox1.Controls.Add(this.buttonClearWaybill);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(949, 207);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Накладные";
            // 
            // buttonShowWaybill
            // 
            this.buttonShowWaybill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowWaybill.Location = new System.Drawing.Point(848, 136);
            this.buttonShowWaybill.Name = "buttonShowWaybill";
            this.buttonShowWaybill.Size = new System.Drawing.Size(95, 62);
            this.buttonShowWaybill.TabIndex = 8;
            this.buttonShowWaybill.Text = "Просмотр выбранной накладной";
            this.buttonShowWaybill.UseVisualStyleBackColor = true;
            this.buttonShowWaybill.Click += new System.EventHandler(this.buttonShowWaybill_Click);
            // 
            // buttonDeleteWaybill
            // 
            this.buttonDeleteWaybill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteWaybill.Location = new System.Drawing.Point(847, 106);
            this.buttonDeleteWaybill.Name = "buttonDeleteWaybill";
            this.buttonDeleteWaybill.Size = new System.Drawing.Size(96, 23);
            this.buttonDeleteWaybill.TabIndex = 7;
            this.buttonDeleteWaybill.Text = "Удалить";
            this.buttonDeleteWaybill.UseVisualStyleBackColor = true;
            this.buttonDeleteWaybill.Click += new System.EventHandler(this.buttonDeleteWaybill_Click);
            // 
            // buttonUpdateWaybill
            // 
            this.buttonUpdateWaybill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateWaybill.Location = new System.Drawing.Point(847, 77);
            this.buttonUpdateWaybill.Name = "buttonUpdateWaybill";
            this.buttonUpdateWaybill.Size = new System.Drawing.Size(96, 23);
            this.buttonUpdateWaybill.TabIndex = 6;
            this.buttonUpdateWaybill.Text = "Редактировать";
            this.buttonUpdateWaybill.UseVisualStyleBackColor = true;
            this.buttonUpdateWaybill.Click += new System.EventHandler(this.buttonUpdateWaybill_Click);
            // 
            // buttonCreateWaybill
            // 
            this.buttonCreateWaybill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateWaybill.Location = new System.Drawing.Point(847, 48);
            this.buttonCreateWaybill.Name = "buttonCreateWaybill";
            this.buttonCreateWaybill.Size = new System.Drawing.Size(96, 23);
            this.buttonCreateWaybill.TabIndex = 5;
            this.buttonCreateWaybill.Text = "Добавить";
            this.buttonCreateWaybill.UseVisualStyleBackColor = true;
            this.buttonCreateWaybill.Click += new System.EventHandler(this.buttonCreateWaybill_Click);
            // 
            // dataGridViewWaybill
            // 
            this.dataGridViewWaybill.AllowUserToAddRows = false;
            this.dataGridViewWaybill.AllowUserToDeleteRows = false;
            this.dataGridViewWaybill.AllowUserToResizeColumns = false;
            this.dataGridViewWaybill.AllowUserToResizeRows = false;
            this.dataGridViewWaybill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWaybill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWaybill.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewWaybill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWaybill.Location = new System.Drawing.Point(7, 48);
            this.dataGridViewWaybill.MultiSelect = false;
            this.dataGridViewWaybill.Name = "dataGridViewWaybill";
            this.dataGridViewWaybill.ReadOnly = true;
            this.dataGridViewWaybill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWaybill.Size = new System.Drawing.Size(834, 150);
            this.dataGridViewWaybill.TabIndex = 4;
            this.dataGridViewWaybill.SelectionChanged += new System.EventHandler(this.dataGridViewWaybill_SelectionChanged);
            // 
            // textBoxSearchWaybill
            // 
            this.textBoxSearchWaybill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchWaybill.Location = new System.Drawing.Point(6, 21);
            this.textBoxSearchWaybill.Name = "textBoxSearchWaybill";
            this.textBoxSearchWaybill.Size = new System.Drawing.Size(835, 20);
            this.textBoxSearchWaybill.TabIndex = 3;
            this.textBoxSearchWaybill.TextChanged += new System.EventHandler(this.textBoxSearchWaybill_TextChanged);
            // 
            // buttonClearWaybill
            // 
            this.buttonClearWaybill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearWaybill.Location = new System.Drawing.Point(847, 19);
            this.buttonClearWaybill.Name = "buttonClearWaybill";
            this.buttonClearWaybill.Size = new System.Drawing.Size(96, 23);
            this.buttonClearWaybill.TabIndex = 2;
            this.buttonClearWaybill.Text = "Очистить";
            this.buttonClearWaybill.UseVisualStyleBackColor = true;
            this.buttonClearWaybill.Click += new System.EventHandler(this.buttonClearWaybill_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewFullWarehouse);
            this.tabPage2.Controls.Add(this.buttonWarehouseClear);
            this.tabPage2.Controls.Add(this.textBoxWarehouseSearch);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(961, 456);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Склад";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFullWarehouse
            // 
            this.dataGridViewFullWarehouse.AllowUserToAddRows = false;
            this.dataGridViewFullWarehouse.AllowUserToDeleteRows = false;
            this.dataGridViewFullWarehouse.AllowUserToResizeColumns = false;
            this.dataGridViewFullWarehouse.AllowUserToResizeRows = false;
            this.dataGridViewFullWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFullWarehouse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFullWarehouse.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewFullWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFullWarehouse.Location = new System.Drawing.Point(6, 34);
            this.dataGridViewFullWarehouse.MultiSelect = false;
            this.dataGridViewFullWarehouse.Name = "dataGridViewFullWarehouse";
            this.dataGridViewFullWarehouse.ReadOnly = true;
            this.dataGridViewFullWarehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFullWarehouse.Size = new System.Drawing.Size(949, 416);
            this.dataGridViewFullWarehouse.TabIndex = 2;
            // 
            // buttonWarehouseClear
            // 
            this.buttonWarehouseClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWarehouseClear.Location = new System.Drawing.Point(858, 6);
            this.buttonWarehouseClear.Name = "buttonWarehouseClear";
            this.buttonWarehouseClear.Size = new System.Drawing.Size(97, 23);
            this.buttonWarehouseClear.TabIndex = 1;
            this.buttonWarehouseClear.Text = "Очистить";
            this.buttonWarehouseClear.UseVisualStyleBackColor = true;
            this.buttonWarehouseClear.Click += new System.EventHandler(this.buttonWarehouseClear_Click);
            // 
            // textBoxWarehouseSearch
            // 
            this.textBoxWarehouseSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWarehouseSearch.Location = new System.Drawing.Point(6, 8);
            this.textBoxWarehouseSearch.Name = "textBoxWarehouseSearch";
            this.textBoxWarehouseSearch.Size = new System.Drawing.Size(846, 20);
            this.textBoxWarehouseSearch.TabIndex = 0;
            this.textBoxWarehouseSearch.TextChanged += new System.EventHandler(this.textBoxWarehouseSearch_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonDeleteFD);
            this.tabPage3.Controls.Add(this.buttonUpdateFD);
            this.tabPage3.Controls.Add(this.buttonCreateFD);
            this.tabPage3.Controls.Add(this.dataGridViewFutureDeliveries);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(961, 456);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Будущие поставки";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteFD
            // 
            this.buttonDeleteFD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteFD.Location = new System.Drawing.Point(859, 64);
            this.buttonDeleteFD.Name = "buttonDeleteFD";
            this.buttonDeleteFD.Size = new System.Drawing.Size(96, 23);
            this.buttonDeleteFD.TabIndex = 10;
            this.buttonDeleteFD.Text = "Удалить";
            this.buttonDeleteFD.UseVisualStyleBackColor = true;
            this.buttonDeleteFD.Click += new System.EventHandler(this.buttonDeleteFD_Click);
            // 
            // buttonUpdateFD
            // 
            this.buttonUpdateFD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateFD.Location = new System.Drawing.Point(859, 35);
            this.buttonUpdateFD.Name = "buttonUpdateFD";
            this.buttonUpdateFD.Size = new System.Drawing.Size(96, 23);
            this.buttonUpdateFD.TabIndex = 9;
            this.buttonUpdateFD.Text = "Редактировать";
            this.buttonUpdateFD.UseVisualStyleBackColor = true;
            this.buttonUpdateFD.Click += new System.EventHandler(this.buttonUpdateFD_Click);
            // 
            // buttonCreateFD
            // 
            this.buttonCreateFD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateFD.Location = new System.Drawing.Point(859, 6);
            this.buttonCreateFD.Name = "buttonCreateFD";
            this.buttonCreateFD.Size = new System.Drawing.Size(96, 23);
            this.buttonCreateFD.TabIndex = 8;
            this.buttonCreateFD.Text = "Добавить";
            this.buttonCreateFD.UseVisualStyleBackColor = true;
            this.buttonCreateFD.Click += new System.EventHandler(this.buttonCreateFD_Click);
            // 
            // dataGridViewFutureDeliveries
            // 
            this.dataGridViewFutureDeliveries.AllowUserToAddRows = false;
            this.dataGridViewFutureDeliveries.AllowUserToDeleteRows = false;
            this.dataGridViewFutureDeliveries.AllowUserToResizeColumns = false;
            this.dataGridViewFutureDeliveries.AllowUserToResizeRows = false;
            this.dataGridViewFutureDeliveries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFutureDeliveries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFutureDeliveries.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewFutureDeliveries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFutureDeliveries.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewFutureDeliveries.MultiSelect = false;
            this.dataGridViewFutureDeliveries.Name = "dataGridViewFutureDeliveries";
            this.dataGridViewFutureDeliveries.ReadOnly = true;
            this.dataGridViewFutureDeliveries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFutureDeliveries.Size = new System.Drawing.Size(847, 444);
            this.dataGridViewFutureDeliveries.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 521);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных \"Склад\"";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWaybill)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFullWarehouse)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFutureDeliveries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem единицыИзмеренияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыПродукцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem продукцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поставщикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLЗапросыToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewWarehouse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSearchWaybill;
        private System.Windows.Forms.Button buttonClearWaybill;
        private System.Windows.Forms.Button buttonDeleteWaybill;
        private System.Windows.Forms.Button buttonUpdateWaybill;
        private System.Windows.Forms.Button buttonCreateWaybill;
        private System.Windows.Forms.DataGridView dataGridViewWaybill;
        private System.Windows.Forms.Button buttonDeleteWarehouse;
        private System.Windows.Forms.Button buttonUpdateWarehouse;
        private System.Windows.Forms.Button buttonCreateWarehouse;
        private System.Windows.Forms.Button buttonShowWaybill;
        private System.Windows.Forms.Button buttonWarehouseClear;
        private System.Windows.Forms.TextBox textBoxWarehouseSearch;
        private System.Windows.Forms.DataGridView dataGridViewFullWarehouse;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonDeleteFD;
        private System.Windows.Forms.Button buttonUpdateFD;
        private System.Windows.Forms.Button buttonCreateFD;
        private System.Windows.Forms.DataGridView dataGridViewFutureDeliveries;
    }
}