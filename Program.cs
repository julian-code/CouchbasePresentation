using System;
using System.Threading.Tasks;
using Couchbase;
using Newtonsoft.Json;

namespace Fremlæggelse
{

    // Make sure you initialize a docker instance of couchbase to run this presentation, and initialize beer-sample test data: https://hub.docker.com/_/couchbase
    class Program
    {
        private const string SimpleJoin = @"SELECT beer.name beer_name, brewery.name brewery_name 
                                                FROM `beer-sample` beer
                                                JOIN `beer-sample` brewery 
                                                ON beer.brewery_id = META(brewery).id
                                                AND brewery.type = ""brewery""";
        static async Task Main(string[] args)
        {
            var cluster = await Cluster.ConnectAsync("couchbase://localhost", "admin", "123456");

            var rows = await cluster.QueryAsync<dynamic>(SimpleJoin);

            await foreach (var item in rows)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
