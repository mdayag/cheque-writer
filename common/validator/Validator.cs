using System;
using System.Collections.Generic;
using System.Reflection;

namespace common
{
    public class Validator
    {
        #region "ValidateResult ValidateOnce<T>(T obj)"

        public ValidationResult ValidateOnce<T>(T obj)
        {

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo item in properties)
            {
                Validate attribute = Attribute.GetCustomAttribute(item, typeof(Validate)) as Validate;

                if (attribute != null)
                {
                    if (!this.IsValid<T>(obj, attribute, item.Name))
                    {
                        return new ValidationResult(this.IsValid<T>(obj, attribute, item.Name), attribute.ErrorMessage, item.Name);
                    }
                }
            }

            return new ValidationResult(true);
        }

        #endregion

        #region "List<ValidateResult> ValidateAll<T>(T obj)"

        public List<ValidationResult> ValidateAll<T>(T obj)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            PropertyInfo[] properties = properties = typeof(T).GetProperties();

            foreach (PropertyInfo item in properties)
            {
                Validate attribute = Attribute.GetCustomAttribute(item, typeof(Validate)) as Validate;

                if (attribute != null)
                {
                    if (!this.IsValid<T>(obj, attribute, item.Name))
                    {
                        result.Add(new ValidationResult(this.IsValid<T>(obj, attribute, item.Name), attribute.ErrorMessage, item.Name));
                    }
                }
            }

            return result;
        }

        #endregion

        #region "bool IsValid<T>(T obj, Validate validate, string property)"

        private bool IsValid<T>(T obj, Validate validate, string property)
        {
            object value = obj.GetType().GetProperty(property).GetValue(obj, null);
            decimal num = 0;

            if (value == null)
                return false;

            switch (validate.Validation)
            {
                case Validate.ValidationType.String:
                    if (value.ToString().Trim().Length == 0)
                    {
                        return false;
                    }
                    break;
                case Validate.ValidationType.Number:
                    return decimal.TryParse(value.ToString(), out num);
                    break;
                case Validate.ValidationType.Date:
                    DateTime date;
                    return DateTime.TryParse(value.ToString(), out date);
                    break;
                case Validate.ValidationType.Email:
                    break;
                case Validate.ValidationType.ReferenceId:
                    if (!decimal.TryParse(value.ToString(), out num) || num <= 0)
                        return false;
                    break;
                default:
                    break;
            }

            return true;
        }

        #endregion
    }
}
