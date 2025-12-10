using DataGrisView.Services.Contracts;
using DataGridView.Entities.Models;

namespace DataGridView.App.UI
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
            dataGridView.DataSource = bindingSource;
        }

        private async Task InitializeDataAsync()
        {
            // Проверяем, есть ли уже данные в сервисе
            var existingCars = await carService.GetAllCars();
            if (!existingCars.Any())
            {
                // Добавляем тестовые данные в сервис
                var initialCars = new List<CarModel>
            {
                new CarModel
                {
                    Id = Guid.NewGuid(),
                    CarName = CarType.Lada,
                    GosNumber = "ПР678Н",
                    Mileage = 50,
                    FuelConsumption = 50,
                    FuelVolume = 5,
                    CostPerMinute = 60
                },
                new CarModel
                {
                    Id = Guid.NewGuid(),
                    CarName = CarType.Mitsubishi,
                    GosNumber = "АО666О",
                    Mileage = 100,
                    FuelConsumption = 40,
                    FuelVolume = 100,
                    CostPerMinute = 90
                },
                new CarModel
                {
                    Id = Guid.NewGuid(),
                    CarName = CarType.Hyundai,
                    GosNumber = "УУ777С",
                    Mileage = 90,
                    FuelConsumption = 50,
                    CostPerMinute = 100
                }
            };

                foreach (var car in initialCars)
                {
                    await carService.AddCar(car, CancellationToken.None);
                }
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            await InitializeDataAsync();
            var cars = await carService.GetAllCars();
            bindingSource.DataSource = cars.ToList();
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
            var statistics = await carService.GetStatistics();

            toolStripStatusLabelLowAmount.Text = $"Автомобили с критически низким уровнем запаса хода: {statistics.GetCarWithFuelVolume}";
            toolStripStatusLabelAmount.Text = $"Количество автомобилей: {statistics.GetCarCount}";
        }

        /// <summary>
        /// Обработчик события форматирования ячеек DataGridView
        /// </summary>
        private async void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

                e.Value = Math.Round(car.FuelVolume / car.FuelConsumption, 2);
            }

            if (col == SumRent)
            {
                double fuelReserveHours = car.FuelVolume / car.FuelConsumption;
                double rentAmount = fuelReserveHours * 60 * car.CostPerMinute;
                e.Value = Math.Round(rentAmount, 2);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Добавить
        /// </summary>
        private async void ToolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var add = new AddCar();

            if (add.ShowDialog() == DialogResult.OK)
            {
                await carService.AddCar(add.CurrentCar, CancellationToken.None);
                MessageBox.Show("Автомобиль успешно добавлен!");
                await OnUpdate();
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Редактировать
        /// </summary>
        private async void ToolStripButtonEdit_Click(object sender, EventArgs e)
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
                await carService.UpdateCar(editForm.CurrentCar, CancellationToken.None);
                await OnUpdate();
                MessageBox.Show("Автомобиль успешно обновлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Удалить
        /// </summary>
        private async void ToolStripButtonDelete_Click(object sender, EventArgs e)
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
                await carService.DeleteCar(car.Id, CancellationToken.None);
                await OnUpdate();
            }
        }

        private async void toolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            bindingSource.DataSource = await carService.GetAllCars();
            bindingSource.ResetBindings(false);
            await SetStatistic();
        }
    }
}
