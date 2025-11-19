using DataGridView.Entities.Models;
using DataGridView.Infrastructure;
using DataGridView.Models;
using System.ComponentModel.DataAnnotations;


namespace DataGridView.Forms
{
    /// <summary>
    /// Класс формы добавления машин
    /// </summary>
    public partial class AddCar : Form
    {
        private readonly CarModel targetCar;

        /// <summary>
        /// Текущий авто
        /// </summary>
        public CarModel CurrentCar => targetCar;

        /// <summary>
        /// Конструктор класса формы добавления машин
        /// </summary>
        /// <param name="sourceCar">Данные о уже существующей машине</param>
        public AddCar(CarModel? sourceCar = null)
        {
            InitializeComponent();

            if (sourceCar != null)
            {
                targetCar = new CarModel
                {
                    Id = sourceCar.Id,
                    CarName = sourceCar.CarName,
                    GosNumber = sourceCar.GosNumber,
                    Mileage = sourceCar.Mileage,
                    FuelConsumption = sourceCar.FuelConsumption,
                    FuelVolume = sourceCar.FuelVolume,
                    CostPerMinute = sourceCar.CostPerMinute
                };
                buttonSave.Text = "Сохранить";
                Text = "Редактирование автомобиля";
            }
            else
            {
                targetCar = new CarModel();
                buttonSave.Text = "Добавить";
                Text = "Добавить Авто";
            }

            comboBoxCarName.DataSource = Enum.GetValues(typeof(CarType));

            comboBoxCarName.AddBinding(x => x.SelectedItem!, targetCar, x => x.CarName, errorProvider);
            textBoxGosNumber.AddBinding(x => x.Text, targetCar, x => x.GosNumber, errorProvider);
            numericUpDownMileage.AddBinding(x => x.Value, targetCar, x => x.Mileage, errorProvider);
            numericUpDownFuelConsumption.AddBinding(x => x.Value, targetCar, x => x.FuelConsumption, errorProvider);
            numericUpDownFuelVolume.AddBinding(x => x.Value, targetCar, x => x.FuelVolume, errorProvider);
            numericUpDownCostPerMinute.AddBinding(x => x.Value, targetCar, x => x.CostPerMinute);

        }

        /// <summary>
        /// Метод обработки клика кнопки "Добавить" или "Сохранить"
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            var context = new ValidationContext(targetCar);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(targetCar, context, results, true);

            if (isValid)
            {
                DialogResult = DialogResult.OK;
                Close();
            }

            else
            {
                foreach (var validationResult in results)
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        Control? control = memberName switch
                        {
                            nameof(CarModel.CarName) => comboBoxCarName,
                            nameof(CarModel.GosNumber) => textBoxGosNumber,
                            nameof(CarModel.Mileage) => numericUpDownMileage,
                            nameof(CarModel.FuelConsumption) => numericUpDownFuelConsumption,
                            nameof(CarModel.CostPerMinute) => numericUpDownCostPerMinute,
                            _ => null
                        };

                        if (control != null)
                        {
                            errorProvider.SetError(control, validationResult.ErrorMessage);
                        }

                    }
                }
                MessageBox.Show("Пожалуйста, исправьте ошибки в форме перед сохранением.",
               "Ошибки валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
