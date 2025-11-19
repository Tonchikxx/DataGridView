namespace DataGridView.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusStrip = new StatusStrip();
            toolStripStatusLabelAmount = new ToolStripStatusLabel();
            toolStripStatusLabelLowAmount = new ToolStripStatusLabel();
            toolStrip = new ToolStrip();
            toolStripButtonAdd = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            dataGridView = new System.Windows.Forms.DataGridView();
            СarNameCol = new DataGridViewComboBoxColumn();
            GosNumber = new DataGridViewTextBoxColumn();
            Mileage = new DataGridViewTextBoxColumn();
            FuelСonsumption = new DataGridViewTextBoxColumn();
            FuelVolume = new DataGridViewTextBoxColumn();
            CostPerMinute = new DataGridViewTextBoxColumn();
            FuelReserveHours = new DataGridViewTextBoxColumn();
            SumRent = new DataGridViewTextBoxColumn();
            statusStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelAmount, toolStripStatusLabelLowAmount });
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(843, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelAmount
            // 
            toolStripStatusLabelAmount.Name = "toolStripStatusLabelAmount";
            toolStripStatusLabelAmount.Size = new Size(0, 17);
            // 
            // toolStripStatusLabelLowAmount
            // 
            toolStripStatusLabelLowAmount.Name = "toolStripStatusLabelLowAmount";
            toolStripStatusLabelLowAmount.Size = new Size(0, 17);
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripButtonAdd, toolStripButtonEdit, toolStripButtonDelete });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(843, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonAdd.Image = (Image)resources.GetObject("toolStripButtonAdd.Image");
            toolStripButtonAdd.ImageTransparentColor = Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new Size(63, 22);
            toolStripButtonAdd.Text = "Добавить";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonEdit.Image = (Image)resources.GetObject("toolStripButtonEdit.Image");
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(65, 22);
            toolStripButtonEdit.Text = "Изменить";
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonDelete.Image = (Image)resources.GetObject("toolStripButtonDelete.Image");
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(55, 22);
            toolStripButtonDelete.Text = "Удалить";
            toolStripButtonDelete.TextImageRelation = TextImageRelation.TextBeforeImage;
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { СarNameCol, GosNumber, Mileage, FuelСonsumption, FuelVolume, CostPerMinute, FuelReserveHours, SumRent });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 25);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.Size = new Size(843, 403);
            dataGridView.TabIndex = 2;
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            // 
            // СarNameCol
            // 
            СarNameCol.HeaderText = "Марка автомобиля";
            СarNameCol.Name = "СarNameCol";
            СarNameCol.ReadOnly = true;
            // 
            // GosNumber
            // 
            GosNumber.HeaderText = "Гос. номер";
            GosNumber.Name = "GosNumber";
            GosNumber.ReadOnly = true;
            // 
            // Mileage
            // 
            Mileage.HeaderText = "Пробег";
            Mileage.Name = "Mileage";
            Mileage.ReadOnly = true;
            // 
            // FuelСonsumption
            // 
            FuelСonsumption.HeaderText = "Расход тплива";
            FuelСonsumption.Name = "FuelСonsumption";
            FuelСonsumption.ReadOnly = true;
            // 
            // FuelVolume
            // 
            FuelVolume.HeaderText = "Объём топлива";
            FuelVolume.Name = "FuelVolume";
            FuelVolume.ReadOnly = true;
            // 
            // CostPerMinute
            // 
            CostPerMinute.HeaderText = "Стоимость аренды (за минуту)";
            CostPerMinute.Name = "CostPerMinute";
            CostPerMinute.ReadOnly = true;
            // 
            // FuelReserveHours
            // 
            FuelReserveHours.HeaderText = "Запас хода топлива";
            FuelReserveHours.Name = "FuelReserveHours";
            FuelReserveHours.ReadOnly = true;
            // 
            // SumRent
            // 
            SumRent.HeaderText = "Сумма аренды";
            SumRent.Name = "SumRent";
            SumRent.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 450);
            Controls.Add(dataGridView);
            Controls.Add(toolStrip);
            Controls.Add(statusStrip);
            Name = "MainForm";
            Text = "Прокат автомобиля";
            Load += MainForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private ToolStrip toolStrip;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripStatusLabel toolStripStatusLabelAmount;
        private ToolStripStatusLabel toolStripStatusLabelLowAmount;
        private System.Windows.Forms.DataGridView dataGridView;
        private DataGridViewComboBoxColumn СarNameCol;
        private DataGridViewTextBoxColumn GosNumber;
        private DataGridViewTextBoxColumn Mileage;
        private DataGridViewTextBoxColumn FuelСonsumption;
        private DataGridViewTextBoxColumn FuelVolume;
        private DataGridViewTextBoxColumn CostPerMinute;
        private DataGridViewTextBoxColumn FuelReserveHours;
        private DataGridViewTextBoxColumn SumRent;
    }
}
