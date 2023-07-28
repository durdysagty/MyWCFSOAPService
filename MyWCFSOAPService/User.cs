using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyWCFSOAPService
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OperationContext OperationContext { get; set; }

        public override string ToString()
        {
            return $"Name - {Name}, Id - {Id}";
        }
    }
}
