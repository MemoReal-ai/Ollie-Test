namespace _Project.Script.Core.EntryPoints
{
    public interface IJsonService
    {
        T ParseJson<T>(string json);
    }
}