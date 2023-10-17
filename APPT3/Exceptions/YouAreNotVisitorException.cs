using APPT3.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPT3.Exceptions
{
    public class YouAreNotVisitorException : LibraryException
    {
        public YouAreNotVisitorException(Employee employee) : base(employee)
        {
            Console.WriteLine("You are not a Visitor.");
        }
    }
}
