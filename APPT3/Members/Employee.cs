using APPT3.Enums;
using APPT3.Exceptions;
using APPT3.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPT3.Members
{
    public class Employee : Member
    {
        public Employee(string phoneNumber, string name, DateOnly birthday, Gender sex) : base(phoneNumber, name, birthday, sex)
        {
            isEmployee = true;
        }
        public override void AddMaterial(Material material)
        {
            if (material is Book)
            throw new YouAreNotVisitorException(this);
            TakenMaterials.Add(material);
        }
        public override Material CopyMaterial(Material material)
        {
            return (Material)material.Clone();
        }
    }
}
