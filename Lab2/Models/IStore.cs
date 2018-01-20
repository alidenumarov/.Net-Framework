using System.Collections.Generic;

namespace Lab2.Models
{
    public interface IStore<T>
    {
        string Path { get; set; }
        List<T> GetCollection();

        T ConvertItem(string item);
    }
}