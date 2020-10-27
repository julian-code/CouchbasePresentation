using System;
using System.Threading.Tasks;
using Couchbase;

namespace Fremlæggelse
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cluster = await Cluster.ConnectAsync("couchbase://localhost", "admin", "123456");

            var rows = await cluster.QueryAsync<dynamic>("select * from `beer-sample`");

            await foreach (var item in rows)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
