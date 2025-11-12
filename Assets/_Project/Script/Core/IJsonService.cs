namespace _Project.Script.Core
{
    public interface IJsonService
    {
        T ParseJson<T>(string json);
    }
}