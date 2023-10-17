using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPT3.Members;
using APPT3.DataStorage;
using APPT3.Materials;
using APPT3.Enums;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace APPT3.Library
{
    public class Library
    {
        public Storage Storage { get; set; }
        public Member[] Members { get; set; }
        public Member[] LibraryMembers
        {
            get
            {
                return Members.OrderBy(m => m.Name).ToArray();
            }
        }

        public Library(Storage storage, Member[] members)
        {
            Storage = storage;
            Members = members;
        }
        public void TakeMaterial(string textForSearch, string phoneNumber, MaterialType materialType)
        {
            if (phoneNumber is null)
            {
                throw new ArgumentException("Phone number can't be null");
            }
            if (textForSearch is null)
            {
                throw new ArgumentException("Search value to find materials can't be null");
            }

            Member? member = FindMemberByPhoneNumber(phoneNumber);

            if (member is null)
            {
                throw new Exception("There are no members with the '"+ phoneNumber +"' phone number");
            }

            Material? material = FindMaterial(textForSearch, materialType);

            if (material is null)
            {
                throw new Exception("Storage doesn't contain any materials by '" + textForSearch + "' search value");
            }
            if (material.isTaken)
            {
                throw new Exception(material.Title + " is not available now!");
            }
            member.AddMaterial(material);
            material.SetUnavailable();
            material.IncreaseWearity();
        }
        public Member? FindMemberByPhoneNumber(string phoneNumber)
        {
            Member? member = Members.FirstOrDefault(s => s.PhoneNumber == phoneNumber);
            return member;
        }
        public Material? FindMaterial(string textForSearch, MaterialType materialType)
        {
            Material? material = null;

            //Find by title
            switch (materialType)
            {
                case MaterialType.Book:
                    material = Storage.FindBookByTitle(textForSearch);
                    break;
                case MaterialType.Magazine:
                    material = Storage.FindMagazineByTitle(textForSearch);
                    break;
            }

            //Find by Id if null after previous search by title
            if (material is null)
            {
                switch (materialType)
                {
                    case MaterialType.Book:
                        material = Storage.FindBookById(textForSearch);
                        break;
                    case MaterialType.Magazine:
                        material = Storage.FindMagazineById(textForSearch);
                        break;
                }
            }
            return material;
        }
        public void SubscribeToMagazines(Magazine magazines, string phoneNumber)
        {
            if (phoneNumber is null)
            {
                throw new ArgumentException("Phone number can't be null");
            }
            
            Member? member = FindMemberByPhoneNumber(phoneNumber);
            
            if (member is null)
            {
                throw new Exception("There are no members with the '" + phoneNumber + "' phone number");
            }
            
            List<Magazine> magazinesList = new List<Magazine>();

            foreach (string title in magazines.Title.Split("/").ToArray())
            {
                Magazine? magazine = (Magazine?)FindMaterial(title, MaterialType.Magazine);
                if (magazine.isTaken)
                {
                    throw new Exception($"Magazine {magazine.Title} is unavailable");
                }
                magazinesList.Add(magazine);
            }

            member.AddMagazinesSubscription(magazines);
            
            foreach(Magazine magazine in magazinesList)
            {
                magazine.SetUnavailable();
                magazine.IncreaseWearity();
            }
        }
        public ushort GetNonTakenBooks()
        {
            return (ushort)Storage.Books.Where(b => !b.isTaken).Count();
        }
        public ushort GetNonTakenMagazines()
        {
            return (ushort)Storage.Magazines.Where(m => !m.isTaken).Count();
        }
    }  
}