using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExpirationNotification
{
    class Program
    {
        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                // TODO - Send HTTP requests
            }
        }
    }
}
