using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.BaseClasses
{
    public abstract class Validator<T>
    {
        private Dictionary<string, string> _Errors;

        public Validator()
        {
            _Errors = new Dictionary<string, string>();
        }

        protected void AddError(string propertyName, string errorMessage)
        {
            if (!_Errors.ContainsKey(propertyName))
            {
                _Errors.Add(propertyName, errorMessage);
            }
        }
        protected void RemoveError(string propertyName)
        {
            if (_Errors.ContainsKey(propertyName))
            {
                _Errors.Remove(propertyName);
            }
        }

        public string this[string propertyName]
        {
            get
            {
                if (_Errors.ContainsKey(propertyName))
                    return _Errors[propertyName];
                else
                    return string.Empty;
            }
        }
        public abstract void ValidateProperty(string propertyName, T obj);
    }

}
