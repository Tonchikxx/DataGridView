using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace DataGridView.App.Infrastructure
{
    /// <summary>
    /// Класс расширений для работы с привязкой данных и валидацией
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Создает двухстороннюю привязку данных между свойством элемента управления и свойством модели данных
        /// </summary>
        public static void AddBinding<TControl, TSource>(
            this TControl control,
            Expression<Func<TControl, object>> destinationProperty,
            TSource source,
            Expression<Func<TSource, object>> sourceProperty,
             ErrorProvider? errorProvider = null)
            where TControl : Control
            where TSource : class
        {
            var controlPropName = GetPropertyName(destinationProperty);
            var sourcePropName = GetPropertyName(sourceProperty);

            var existing = control.DataBindings[controlPropName];
            if (existing != null)
                control.DataBindings.Remove(existing);

            var binding = new Binding(controlPropName, source, sourcePropName, true)
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };

            control.DataBindings.Add(binding);

            if (errorProvider != null)
            {
                var sourcePropertyInfo = source.GetType().GetProperty(sourcePropName);
                var validationAttributes = sourcePropertyInfo?.GetCustomAttributes<ValidationAttribute>();

                if (validationAttributes?.Any() == true)
                {
                    control.Validating += (_, _) =>
                    {
                        var context = new ValidationContext(source)
                        {
                            MemberName = sourcePropName,
                        };
                        var results = new List<ValidationResult>();

                        errorProvider.SetError(control, string.Empty);

                        var propertyValue = sourcePropertyInfo?.GetValue(source);
                        var isValid = Validator.TryValidateProperty(propertyValue, context, results);

                        if (!isValid)
                        {
                            foreach (var error in results)
                            {
                                errorProvider.SetError(control, error.ErrorMessage);
                            }
                        }
                    };
                }
            }
    
        }
        /// <summary>
        /// Метод извлечения имени свойства из лямбда-выражения
        /// </summary>
        private static string GetPropertyName<TType>(Expression<Func<TType, object>> expression)
        {
            Expression body = expression.Body;
            if (body is UnaryExpression unary && unary.Operand is MemberExpression memberExp)
            {
                return memberExp.Member.Name;
            }


            if (body is MemberExpression member)
            {
                return member.Member.Name;
            }

            throw new ArgumentException("Expression is not a property", nameof(expression));
        }

    }
}
