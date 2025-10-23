using DataGridView.Classes;
using DataGridView.Forms;
using DataGridView.Models;

namespace DataGridView
{
    public partial class MainForm : Form
    {
        private readonly List<CarModel> items;
        private readonly BindingSource bindingSource = new();

        public MainForm()
        {
            InitializeComponent();

            items = new List<CarModel>();
            items.Add(new CarModel
            {
                Id = Guid.NewGuid(),
                CarName = CarName.Hyundai,
                GosNumber = "��777�",
                Mileage = 100,
                FuelConsumption = 50,
                CostPerMinute = 100

            });

            items.Add(new CarModel
            {
                Id = Guid.NewGuid(),
                CarName = CarName.Lada,
                GosNumber = "��678�",
                Mileage = 300,
                FuelConsumption = 50,
                FuelVolume = 5,
                CostPerMinute = 120

            });

            items.Add(new CarModel
            {
                Id = Guid.NewGuid(),
                CarName = CarName.Mitsubishi,
                GosNumber = "��666�",
                Mileage = 150,
                FuelConsumption = 40,
                FuelVolume = 100,
                CostPerMinute = 90

            });

            SetStatistic();

            �arNameCol.DataPropertyName = nameof(CarModel.CarName); 
            GosNumber.DataPropertyName = nameof(CarModel.GosNumber);
            Mileage.DataPropertyName = nameof(CarModel.Mileage);
            Fuel�onsumption.DataPropertyName = nameof(CarModel.FuelConsumption);
            FuelVolume.DataPropertyName = nameof(CarModel.FuelVolume);
            CostPerMinute.DataPropertyName = nameof(CarModel.CostPerMinute);
            FuelReserveHours.DataPropertyName = nameof(CarModel.FuelReserveHours);
            SumRent.DataPropertyName = nameof(CarModel.RentAmount);

            dataGridView.AutoGenerateColumns = false;
            �arNameCol.DataSource = Enum.GetValues(typeof(CarName));

            bindingSource.DataSource = items;
            dataGridView.DataSource = bindingSource;
        }

        /// <summary>
        /// ���������� ������� �������������� ����� DataGridView
        /// </summary>
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridView.Columns[e.ColumnIndex];
            var car = (CarModel)dataGridView.Rows[e.RowIndex].DataBoundItem;

            if (car == null)
                return;

            if (col.DataPropertyName == nameof(CarModel.CarName))
            {
                switch (car.CarName)
                {
                    case CarName.Lada:
                        e.Value = "���� �����";
                        break;
                    case CarName.Mitsubishi:
                        e.Value = "���������";
                        break;
                    case CarName.Hyundai:
                        e.Value = "ո���� �����";
                        break;
                    default:
                        e.Value = CarName.Unknow;
                        break;
                }
            }
        }

        /// <summary>
        /// ���������� ������� ������ �������� �����
        /// </summary>
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var add = new AddCar();

            if (add.ShowDialog(this) == DialogResult.OK)
            {
                items.Add(add.CurrentCar);
                bindingSource.ResetBindings(false);
                MessageBox.Show("���������� ������� ��������!");
                OnUpdate();
            }
        }

        /// <summary>
        /// ����� ���������� ����� ������ � �������
        /// </summary>
        private void SetStatistic()
        {
            var lowFuelCars = items.Count(car => car.FuelVolume < 7);
            toolStripStatusLabelLowAmount.Text = $"���������� � ���������� ������ ������� ������ ����: {lowFuelCars}";
            toolStripStatusLabelAmount.Text = $"���������� �����������: {items.Count}";
        }

        /// <summary>
        /// ���������� ������� ������ ������������� �����
        /// </summary>
        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("�������� ���������� ��� ��������������!", "��������",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCar = (CarModel)dataGridView.SelectedRows[0].DataBoundItem;
            var selectedIndex = items.IndexOf(selectedCar);

            var editForm = new AddCar(selectedCar);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                if (selectedIndex >= 0 && selectedIndex < items.Count)
                {
                    items[selectedIndex] = editForm.CurrentCar;
                    OnUpdate();
                    MessageBox.Show("���������� ������� ��������!", "�����",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// ���������� ������� ������ ������� �����
        /// </summary>
        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("�������� ���������� ��� ��������!", "��������",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var car = (CarModel)dataGridView.SelectedRows[0].DataBoundItem;
            var target = items.FirstOrDefault(x => x.Id == car.Id);

            if (target != null &&
                MessageBox.Show($"�� ������������� ������� ������� ���������� � �������� '{target.GosNumber}'?",
                "�������� ��������",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                items.Remove(target);
                OnUpdate();
            }
        }

        /// <summary>
        /// ����� ���������� ���� ������ �� �����
        /// </summary>
        public void OnUpdate()
        {
            bindingSource.ResetBindings(false);
            dataGridView.Refresh();
            SetStatistic();
        }
    }
}
