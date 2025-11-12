using Newtonsoft.Json;

namespace _Project.Script.Core
{
    public class JsonService : IJsonService
    {
        public T ParseJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}