using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryIoCSample
{
    public class TestClient : IClient
    {
        public TestClient()
        {

        }

        public void Print()
        {
            Console.WriteLine("Hello from the TestClient");
        }
    }
}
