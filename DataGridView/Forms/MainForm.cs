using DataGridView.Models;
using DataGridView.Forms;
using DataGrisView.Services.Contracts;
using System.Threading.Tasks;
using DataGridView.Entities.Models;

namespace DataGridView.Forms
{
    /// <summary>
    /// Класс главной формы
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly ICarService carService;
        private readonly BindingSource bindingSource = [];

        /// <summary>
        /// Констуркутор класса главной формы
        /// </summary>
        public MainForm(ICarService carService)
        {
            InitializeComponent();
            this.carService = carService;
            dataGridView.AutoGenerateColumns = false;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var cars = await carService.GetAllCars();
            bindingSource.DataSource = cars.ToList();
            dataGridView.DataSource = bindingSource;
            await SetStatistic();
        }

        private async Task OnUpdate()
        {
            var cars = await carService.GetAllCars();
            bindingSource.DataSource = cars.ToList();
            bindingSource.ResetBindings(false);
            await SetStatistic();
        }

        private async Task SetStatistic()
        {
            var lowFuelCars = await carService.GetCarWithFuelVolume();
            var carCount = await carService.GetCarCount();

            toolStripStatusLabelLowAmount.Text = $"Автомобили с критически низким уровнем запаса хода: {lowFuelCars}";
            toolStripStatusLabelAmount.Text = $"Количество автомобилей: {carCount}";
        }

        /// <summary>
        /// Обработчик события форматирования ячеек DataGridView
        /// </summary>
        private async void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridView.Columns[e.ColumnIndex];
            var car = (CarModel)dataGridView.Rows[e.RowIndex].DataBoundItem;

            if (car == null)
            {
                return;
            }
                
            if (col.DataPropertyName == nameof(CarModel.CarName))
            {
                switch (car.CarName)
                {
                    case CarType.Lada:
                        e.Value = "Лада Веста";
                        break;
                    case CarType.Mitsubishi:
                        e.Value = "Митсубиши";
                        break;
                    case CarType.Hyundai:
                        e.Value = "Хёндай Крета";
                        break;
                    default:
                        e.Value = CarType.Unknow;
                        break;
                }
            }

            if (col == FuelReserveHours)
            {

                e.Value = await carService.GetFuelReserveHours(car.Id);
            }

            if (col == SumRent)
            {
                e.Value = await carService.GetSumRent(car.Id);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Добавить
        /// </summary>
        private async void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var add = new AddCar();

            if (add.ShowDialog() == DialogResult.OK)
            {
                await carService.AddCar(add.CurrentCar);
                MessageBox.Show("Автомобиль успешно добавлен!");
                await OnUpdate();
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Редактировать
        /// </summary>
        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите автомобиль для редактирования!", "Внимание",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var car = (CarModel)dataGridView.SelectedRows[0].DataBoundItem;

            var editForm = new AddCar(car);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                    await carService.UpdateCar(editForm.CurrentCar);
                    await OnUpdate();
                    MessageBox.Show("Автомобиль успешно обновлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Удалить
        /// </summary>
        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите автомобиль для удаления!", "Внимание",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var car = (CarModel)dataGridView.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Вы действительно желаете удалить автомобиль с номерами '{car.GosNumber}'?",
                "Удаление продукта",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await carService.DeleteCar(car.Id);
                await OnUpdate();
            }
        }
    }
}
