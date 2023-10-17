using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPT3.Enums;
using APPT3.Exceptions;
using APPT3.Materials;

namespace APPT3.Members
{
    public class Visitor : Member
    {
        public Visitor(string phoneNumber, string name, DateOnly birthday, Gender sex) : base(phoneNumber, name, birthday, sex)
        {
            isEmployee = false;
        }
        public override void AddMaterial(Material material)
        {
            TakenMaterials.Add(material);
        }
        public override Material CopyMaterial(Material material)
        {
            throw new YouAreNotEmployeeException(this);
        }
    }
}
