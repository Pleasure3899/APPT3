using System.Xml.Linq;

namespace APPT3.Materials
{
    public class Magazine : Material
    {
        public byte Issue;
        public Magazine(string title, ushort year, ushort pages, byte wearity, byte issue) : base(title, year, pages, wearity)
        {
            if ((issue > 0) || (issue < 13))
            {
                Issue = issue;
            } else
            {
                Issue = (byte)(issue < 1 ? 1 : 12);
            }     
        }
        public override object Clone()
        {
            return new Magazine(Title + "-copy", Year, Pages, Wearity, Issue);
        }
        public static Magazine operator +(Magazine m1, Magazine m2)
        {
            return new Magazine($"{m1.Title}/{m2.Title}", Math.Max(m1.Year, m2.Year),
                (ushort)(m1.Pages + m2.Pages), (byte)Math.Ceiling((double)(m1.Wearity + m2.Wearity) / 2),
                (byte)Math.Ceiling((double)(m1.Issue + m2.Issue) / 2));
        }
    }
}