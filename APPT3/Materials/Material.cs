using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APPT3.Materials
{
    public abstract class Material : IComparable<Material>, ICloneable
    {
        public readonly string Id;
        public readonly string Title;
        public readonly ushort Year;
        public readonly ushort Pages;
        public bool isTaken { get; set; }
        public byte Wearity { get; set; }
        public Material(string title, ushort year, ushort pages, byte wearity)
        {
            if (title is null)
                throw new ArgumentNullException("Title of the material is null");

            if ((year < 800) || (year > DateTime.Now.Year))
            {
                throw new ArgumentException("The year argument should not be less than 800 and greater than " + DateTime.Now.Year.ToString());
            }

            if (pages < 1)
            {
                throw new ArgumentException("The pages argument should not be less than 1");
            }

            if ((wearity < 0) || (wearity > 5))
            {
                throw new ArgumentException("The wear argument should not be less than 0 and greater than 1");
            }

            Guid guid = Guid.NewGuid();
            Id = guid.ToString();
            Title = title;
            Year = year;
            Pages = pages;
            Wearity = wearity;
            isTaken = false;
        }
        public int CompareTo(Material? material)
        {
            if (material is null) throw new ArgumentNullException("Passed null argument");
            return string.Compare(Title, material.Title);
        }
        public void SetAvailable()
        {
            isTaken = false;
        }
        public void SetUnavailable()
        {
            isTaken = true;
        }
        public void IncreaseWearity()
        {
            Wearity = Wearity < 5 ? Wearity=(byte)(Wearity+1) : Wearity;
        }
        public abstract object Clone();
    }
}
