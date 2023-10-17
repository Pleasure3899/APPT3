using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPT3.Members;

namespace APPT3.Exceptions
{
    public class LibraryException : Exception
    {
        public LibraryException(Member member)
        {
            Console.Write($"{member.Name} is {member.GetType().ToString().Split('.').Last()}");
        }
    }
}
