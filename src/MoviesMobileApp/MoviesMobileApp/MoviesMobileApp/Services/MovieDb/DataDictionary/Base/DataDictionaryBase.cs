using System.Collections.Generic;
using System.Linq;

namespace MoviesMobileApp.Services.MovieDb
{
    public abstract class DataDictionaryBase
    {
        private Dictionary<int, string> _dataDictionary { get; set; } = new Dictionary<int, string>();

        public virtual void Save(IList<IDataDictionary> modelList)
        {
            if (modelList is null)
                return;

            foreach (var model in modelList)
                _dataDictionary.Add(model.Id, model.Name);
        }

        public virtual string GetValue(int key)
        {
            if (_dataDictionary is null)
                return string.Empty;

            var value = string.Empty;
            _dataDictionary.TryGetValue(key, out value);

            return value;
        }

        public virtual string GetAllValuesSeparatedByComma()
        {
            if (_dataDictionary is null)
                return string.Empty;

            return string.Join(",", _dataDictionary.Select(c => c.Value));
        }

        public virtual string GetSpecificValuesSeparatedByComma(IList<int> keys)
        {
            if (_dataDictionary is null)
                return string.Empty;

            IList<string> valuesString = keys.Where(k => _dataDictionary.ContainsKey(k)).Select(k => _dataDictionary[k]).ToList();

            return string.Join(", ", valuesString);
        }
    }
}
