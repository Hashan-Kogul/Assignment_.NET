using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICosmosDbService
{
    Task AddItemAsync<T>(T item);
    Task UpdateItemAsync<T>(string id, T item);
    Task<List<T>> GetItemsAsync<T>();
}