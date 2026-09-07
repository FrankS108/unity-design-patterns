using UnityEngine;

namespace Patterns.Adapter
{
    public class Consumer : MonoBehaviour
    {
        private DataStore dataStore;
        private void Awake()
        {
            dataStore = GetDataStore();
            var data = new Data("Dato1", 123);
            dataStore.SetData(data, "Data1");
        }

        private DataStore GetDataStore()
        {
            var isEven = Random.Range(0, 99) % 2 == 0;
            if (isEven)
            {
                return new PlayerPrefsDataStoreAdapter();
            }

            return new FileDataStoreAdapter();
        }

        private void Start()
        {
            var data = dataStore.GetData<Data>("Data1");
            Debug.Log(data.Dato1);
            Debug.Log(data.Dato2);
        }
    }
}


