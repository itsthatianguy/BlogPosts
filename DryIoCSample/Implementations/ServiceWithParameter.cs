using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryIoCSample
{
    public class ServiceWithParameter : IServiceWithParameter
    {
        private string _parameter;
        public ServiceWithParameter(string param)
        {
            _parameter = param;
        }

        public void PrintParameter()
        {
            Console.WriteLine(_parameter);
        }
    }
}
