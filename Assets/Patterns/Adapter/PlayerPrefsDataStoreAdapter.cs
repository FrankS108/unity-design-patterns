
using UnityEngine;

namespace Patterns.Adapter
{
    class PlayerPrefsDataStoreAdapter : DataStore
    {
        public void SetData<T>(T data, string name)
        {
            string json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(name, json);
            Debug.Log(json);
            PlayerPrefs.Save();
        }

        public T GetData<T>(string name)
        {
            string json = PlayerPrefs.GetString(name);
            Debug.Log(json);
            return JsonUtility.FromJson<T>(json);
        }


    }

}