namespace WarehouseApp.Forms
{
    partial class FutureDeliviriesSaveForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxProductionType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxProduction = new System.Windows.Forms.ComboBox();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelFullprice = new System.Windows.Forms.Label();
            this.labelUnit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxProvider = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип продукции";
            // 
            // comboBoxProductionType
            // 
            this.comboBoxProductionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxProductionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProductionType.FormattingEnabled = true;
            this.comboBoxProductionType.Location = new System.Drawing.Point(120, 40);
            this.comboBoxProductionType.Name = "comboBoxProductionType";
            this.comboBoxProductionType.Size = new System.Drawing.Size(332, 21);
            this.comboBoxProductionType.TabIndex = 1;
            this.comboBoxProductionType.SelectedIndexChanged += new System.EventHandler(this.comboBoxProductionType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Продукция";
            // 
            // comboBoxProduction
            // 
            this.comboBoxProduction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxProduction.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxProduction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProduction.FormattingEnabled = true;
            this.comboBoxProduction.Location = new System.Drawing.Point(120, 67);
            this.comboBoxProduction.Name = "comboBoxProduction";
            this.comboBoxProduction.Size = new System.Drawing.Size(332, 21);
            this.comboBoxProduction.TabIndex = 3;
            this.comboBoxProduction.SelectedIndexChanged += new System.EventHandler(this.comboBoxProduction_SelectedIndexChanged);
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAmount.Location = new System.Drawing.Point(120, 94);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(306, 20);
            this.textBoxAmount.TabIndex = 4;
            this.textBoxAmount.TextChanged += new System.EventHandler(this.textBoxAmount_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Количество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Общая стоимость:";
            // 
            // labelFullprice
            // 
            this.labelFullprice.AutoSize = true;
            this.labelFullprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFullprice.Location = new System.Drawing.Point(117, 123);
            this.labelFullprice.Name = "labelFullprice";
            this.labelFullprice.Size = new System.Drawing.Size(14, 13);
            this.labelFullprice.TabIndex = 7;
            this.labelFullprice.Text = "0";
            // 
            // labelUnit
            // 
            this.labelUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUnit.AutoSize = true;
            this.labelUnit.Location = new System.Drawing.Point(432, 97);
            this.labelUnit.Name = "labelUnit";
            this.labelUnit.Size = new System.Drawing.Size(0, 13);
            this.labelUnit.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Поставщик";
            // 
            // comboBoxProvider
            // 
            this.comboBoxProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProvider.FormattingEnabled = true;
            this.comboBoxProvider.Location = new System.Drawing.Point(120, 12);
            this.comboBoxProvider.Name = "comboBoxProvider";
            this.comboBoxProvider.Size = new System.Drawing.Size(332, 21);
            this.comboBoxProvider.TabIndex = 10;
            // 
            // FutureDeliviriesSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 212);
            this.Controls.Add(this.comboBoxProvider);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelUnit);
            this.Controls.Add(this.labelFullprice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.comboBoxProduction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxProductionType);
            this.Controls.Add(this.label1);
            this.Name = "FutureDeliviriesSaveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxProductionType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxProduction;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelFullprice;
        private System.Windows.Forms.Label labelUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxProvider;
    }
}