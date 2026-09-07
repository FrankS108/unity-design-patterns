using UnityEngine;
using Patterns.Adapter;

namespace Patterns.Strategy
{
    public class Consumer
    {
        private DataStore dataStore;

        public Consumer(DataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public void Save()
        {
            var data = new Data("Hola", 125);
            dataStore.SetData(data, "data2");
        }

        public void Load()
        {
            var data = dataStore.GetData<Data>("data2");
            Debug.Log(data.Dato1);
            Debug.Log(data.Dato2);
        }
    }
}