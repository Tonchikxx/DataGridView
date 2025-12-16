using System.Diagnostics;
using DataGridView.Entities.Models;
using DataGrisView.Services.Contracts;
using DataGridView.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataGridView.Web.Controllers
{
    /// <summary>
    /// Контроллер для управления проактом автомобилей
    /// </summary>
    public class HomeController(ICarService car) : Controller
    {
        private ICarService Service { get; set; } = car;

        /// <summary>
        /// Отображает главную страницу со списком всех автомобилей и статистикой
        /// </summary>
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var cars = await Service.GetAllCars(cancellationToken);
            var statistics = await Service.GetStatistics(cancellationToken);

            var viewModel = new IndexViewModel
            {
                Cars = cars,
                Statistics = statistics
            };

            return View(viewModel);
        }

        /// <summary>
        /// Отображает форму для создания нового автомобиля
        /// </summary>

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CarEditViewModel());
        }

        /// <summary>
        /// Обрабатывает отправку формы создания нового автомобиля
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> Create(CarEditViewModel carEditViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(carEditViewModel);
            }

            var car = new CarModel
            {
                Id = Guid.NewGuid(),
                CarName = carEditViewModel.CarName,
                GosNumber = carEditViewModel.GosNumber,
                Mileage = carEditViewModel.Mileage,
                FuelConsumption = carEditViewModel.FuelConsumption,
                FuelVolume = carEditViewModel.FuelVolume,
                CostPerMinute = carEditViewModel.CostPerMinute
            };

            await Service.AddCar(car, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает форму для редактирования существующего автомобиля по его идентификатору
        /// </summary>

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken) 
        {
            var cars = await Service.GetAllCars(cancellationToken);
            var car = cars.FirstOrDefault(p => p.Id == id); 

            if (car == null)
            {
                return NotFound();
            }

            var carEditViewModel = new CarEditViewModel
            {
                Id = car.Id, 
                CarName = car.CarName,
                GosNumber = car.GosNumber,
                Mileage = car.Mileage,
                FuelConsumption = car.FuelConsumption,
                FuelVolume = car.FuelVolume,
                CostPerMinute = car.CostPerMinute
            };

            return View(carEditViewModel);
        }

        /// <summary>
        /// Обрабатывает отправку формы редактирования автомобиля
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(CarEditViewModel carEditViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(carEditViewModel);
            }

            var cars = await Service.GetAllCars(cancellationToken);
            var car = cars.FirstOrDefault(p => p.Id == carEditViewModel.Id);

            if (car == null)
            {
                return NotFound();
            }

            car.CarName = carEditViewModel.CarName;
            car.GosNumber = carEditViewModel.GosNumber;
            car.Mileage = carEditViewModel.Mileage;
            car.FuelConsumption = carEditViewModel.FuelConsumption;
            car.FuelVolume = carEditViewModel.FuelVolume;
            car.CostPerMinute = carEditViewModel.CostPerMinute;

            await Service.UpdateCar(car, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу подтверждения удаления автомобиля
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var cars = await Service.GetAllCars(cancellationToken);
            var car = cars.FirstOrDefault(p => p.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        /// <summary>
        /// Выполняет удаление автомобиля после подтверждения
        /// </summary>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
        {
            var cars = await Service.GetAllCars(cancellationToken);
            var car = cars.FirstOrDefault(p => p.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            await Service.DeleteCar(car.Id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу "Политика конфиденциальности".
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Отображает страницу ошибки с информацией о текущем запросе.
        /// </summary>
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
            });

        }
    }
}
