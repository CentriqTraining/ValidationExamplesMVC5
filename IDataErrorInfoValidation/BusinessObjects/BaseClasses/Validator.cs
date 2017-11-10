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

        //  Simple utility method to add errors
        protected void AddError(string propertyName, string errorMessage)
        {
            if (!_Errors.ContainsKey(propertyName))
            {
                _Errors.Add(propertyName, errorMessage);
            }
        }
        //  Simple utility method to remove errors
        protected void RemoveError(string propertyName)
        {
            if (_Errors.ContainsKey(propertyName))
            {
                _Errors.Remove(propertyName);
            }
        }

        //  This is the validator portion of the IDataErrorInfo
        //  interface that the Entities will implement
        //  When the indexer is called on the entity, it will simply
        //  forward that call to this indexer which will actually 
        //  do the work of looking up the error.
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
