using Minor.Dag19.AutoRestClient.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag19.AutoRestClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IMonumentService agent = new MonumentService();
            agent.BaseUri = new Uri(@"http://localhost:5581/");
            var list = agent.ApiMonumentenGet();
            foreach (var item in list)
            {
                Console.WriteLine(item.Naam);
            }

            agent.ApiMonumentenByIdPut(id, new Agents.Models.Monument())

            Console.WriteLine();
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}
