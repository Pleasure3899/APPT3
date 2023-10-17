using APPT3.Materials;
using APPT3.Enums;

namespace APPT3.Members
{
    public abstract class Member
    {
        public string PhoneNumber;
        public string Name;
        public DateOnly Birthday;
        public Gender Sex;
        public bool isEmployee;
        public List<Material> TakenMaterials = new List<Material>();
        public delegate void MemberHandler(Material material, Member member);
        public event MemberHandler? OnUsedMaterialReturn;
        public Magazine? MagazinesSubscription { get; set; }
        public Member(string phoneNumber, string name, DateOnly birthday, Gender sex)
        {
            if ((phoneNumber is null) || (phoneNumber.Length!=10) || (!phoneNumber.StartsWith("0")) || (!phoneNumber.All(char.IsDigit))) {
                throw new ArgumentNullException("Incorrect phone number format");
            }
            if (name is null)
                throw new ArgumentNullException("Name of the member is null");

            PhoneNumber = phoneNumber;
            Name = name;
            Birthday = birthday;
            Sex = sex;
        }
        public abstract void AddMaterial(Material material);
        public List<Material> GetMaterials()
        {
            return TakenMaterials;
        }
        public abstract Material CopyMaterial(Material material);
        public void AddMagazinesSubscription(Magazine magazine)
        {
            MagazinesSubscription = magazine;
        }
        public void ReturnMaterial(Material? material)
        {
            if (material is null)
            {
                throw new ArgumentNullException("Unable to find material in the storage");
            }
            if (!TakenMaterials.Contains(material))
            {
                throw new Exception("Visitor didn't take this material!");
            }
            TakenMaterials.Remove(material);
            material.SetAvailable();
            if (material.Wearity > 3)
            {
                OnUsedMaterialReturn?.Invoke(material, this);
            }
        }
    }
}