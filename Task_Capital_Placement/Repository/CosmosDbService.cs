using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CosmosDbService : ICosmosDbService
{
    private Container _container;

    public CosmosDbService(CosmosClient dbClient, string databaseName, string containerName)
    {
        _container = dbClient.GetContainer(databaseName, containerName);
    }

    public async Task AddItemAsync<T>(T item)
    {
        await _container.CreateItemAsync(item);
    }

    public async Task UpdateItemAsync<T>(string id, T item)
    {
        await _container.UpsertItemAsync(item, new PartitionKey(id));
    }

    public async Task<List<T>> GetItemsAsync<T>()
    {
        var query = _container.GetItemQueryIterator<T>();
        var results = new List<T>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response.ToList());
        }
        return results;
    }
}