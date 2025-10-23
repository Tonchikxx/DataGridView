using DataGridView.Classes;
using DataGridView.Infrastructure;
using DataGridView.Models;
using System.ComponentModel.DataAnnotations;


namespace DataGridView.Forms
{
    public partial class AddCar : Form
    {
        private readonly CarModel targetCar;
        private readonly ErrorProvider errorProvider = new ErrorProvider();

        public AddCar(CarModel? sourceCar = null)
        {
            InitializeComponent();

            if (sourceCar != null)
            {
                targetCar = sourceCar.Clone();
                buttonSave.Text = "Сохранить";
                Text = "Редактирование автомобиля";
            }
            else
            {
                targetCar = new CarModel();
                buttonSave.Text = "Добавить";
                Text = "Добавить Авто";
            }

            comboBoxCarName.DataSource = Enum.GetValues(typeof(CarName));

            comboBoxCarName.AddBinding(x => x.SelectedItem!, targetCar, x => x.CarName);
            textBoxGosNumber.AddBinding(x => x.Text, targetCar, x => x.GosNumber);
            numericUpDownMileage.AddBinding(x => x.Value, targetCar, x => x.Mileage);
            numericUpDownFuelConsumption.AddBinding(x => x.Value, targetCar, x => x.FuelConsumption);
            numericUpDownFuelVolume.AddBinding(x => x.Value, targetCar, x => x.FuelVolume);
            numericUpDownCostPerMinute.AddBinding(x => x.Value, targetCar, x => x.CostPerMinute);

            ConfigureErrorProvider();
        }

        private void ConfigureErrorProvider()
        {
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
        }

        /// <summary>
        /// Текущий авто
        /// </summary>
        public CarModel CurrentCar => targetCar;


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
