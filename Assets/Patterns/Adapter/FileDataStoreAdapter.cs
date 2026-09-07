using System.IO;
using UnityEngine;

namespace Patterns.Adapter
{

    public class FileDataStoreAdapter : DataStore
    {
        public void SetData<T>(T data, string name)
        {
            string json = JsonUtility.ToJson(data);
            string path = Path.Combine(Application.dataPath, name);
            File.WriteAllText(path, json);
        }

        public T GetData<T>(string name)
        {
            string path = Path.Combine(Application.dataPath, name);
            string json = File.ReadAllText(path);
            Debug.Log(json);
            return JsonUtility.FromJson<T>(json);
        }

    }
}


