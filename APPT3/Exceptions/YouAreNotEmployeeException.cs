using APPT3.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPT3.Exceptions
{
    public class YouAreNotEmployeeException : LibraryException
    {
        public YouAreNotEmployeeException(Visitor visitor) : base(visitor)
        {
            Console.WriteLine("You are not an Employee.");
        }
    }
}
