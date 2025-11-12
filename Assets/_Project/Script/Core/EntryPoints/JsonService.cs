using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Script.Core.EntryPoints
{
    public class JsonService : IJsonService
    {
        public T ParseJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}