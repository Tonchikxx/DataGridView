namespace DataGridView.App.UI
{
    partial class AddCar
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            comboBoxCarName = new ComboBox();
            textBoxGosNumber = new TextBox();
            numericUpDownMileage = new NumericUpDown();
            numericUpDownFuelConsumption = new NumericUpDown();
            numericUpDownFuelVolume = new NumericUpDown();
            numericUpDownCostPerMinute = new NumericUpDown();
            buttonSave = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)numericUpDownMileage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFuelConsumption).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFuelVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCostPerMinute).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 46);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 0;
            label1.Text = "Марка автомобиля";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 94);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 1;
            label2.Text = "Гос. номер";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 146);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 2;
            label3.Text = "Пробег";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 206);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 3;
            label4.Text = "Расход топлива";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 262);
            label5.Name = "label5";
            label5.Size = new Size(143, 15);
            label5.TabIndex = 4;
            label5.Text = "Текущий объём топлива";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 316);
            label6.Name = "label6";
            label6.Size = new Size(171, 15);
            label6.TabIndex = 5;
            label6.Text = "Стоимость аренды (в минуту)";
            // 
            // comboBoxCarName
            // 
            comboBoxCarName.FormattingEnabled = true;
            comboBoxCarName.Location = new Point(216, 38);
            comboBoxCarName.Name = "comboBoxCarName";
            comboBoxCarName.Size = new Size(121, 23);
            comboBoxCarName.TabIndex = 6;
            // 
            // textBoxGosNumber
            // 
            textBoxGosNumber.Location = new Point(215, 91);
            textBoxGosNumber.Name = "textBoxGosNumber";
            textBoxGosNumber.Size = new Size(121, 23);
            textBoxGosNumber.TabIndex = 7;
            // 
            // numericUpDownMileage
            // 
            numericUpDownMileage.Location = new Point(216, 146);
            numericUpDownMileage.Name = "numericUpDownMileage";
            numericUpDownMileage.Size = new Size(120, 23);
            numericUpDownMileage.TabIndex = 8;
            // 
            // numericUpDownFuelConsumption
            // 
            numericUpDownFuelConsumption.Location = new Point(216, 198);
            numericUpDownFuelConsumption.Name = "numericUpDownFuelConsumption";
            numericUpDownFuelConsumption.Size = new Size(120, 23);
            numericUpDownFuelConsumption.TabIndex = 9;
            // 
            // numericUpDownFuelVolume
            // 
            numericUpDownFuelVolume.Location = new Point(216, 254);
            numericUpDownFuelVolume.Name = "numericUpDownFuelVolume";
            numericUpDownFuelVolume.Size = new Size(120, 23);
            numericUpDownFuelVolume.TabIndex = 10;
            // 
            // numericUpDownCostPerMinute
            // 
            numericUpDownCostPerMinute.Location = new Point(216, 314);
            numericUpDownCostPerMinute.Name = "numericUpDownCostPerMinute";
            numericUpDownCostPerMinute.Size = new Size(120, 23);
            numericUpDownCostPerMinute.TabIndex = 11;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(138, 384);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // AddCar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 453);
            Controls.Add(buttonSave);
            Controls.Add(numericUpDownCostPerMinute);
            Controls.Add(numericUpDownFuelVolume);
            Controls.Add(numericUpDownFuelConsumption);
            Controls.Add(numericUpDownMileage);
            Controls.Add(textBoxGosNumber);
            Controls.Add(comboBoxCarName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddCar";
            Text = "Добавить автомобиль";
            ((System.ComponentModel.ISupportInitialize)numericUpDownMileage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFuelConsumption).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFuelVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCostPerMinute).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox comboBoxCarName;
        private TextBox textBoxGosNumber;
        private NumericUpDown numericUpDownMileage;
        private NumericUpDown numericUpDownFuelConsumption;
        private NumericUpDown numericUpDownFuelVolume;
        private NumericUpDown numericUpDownCostPerMinute;
        private Button buttonSave;
        private ErrorProvider errorProvider;
    }
}