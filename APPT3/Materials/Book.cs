namespace APPT3.Materials
{
    public class Book : Material
    {
        public Book(string title, ushort year, ushort pages, byte wearity) : base(title, year, pages, wearity)
        {
        }
        public override object Clone()
        {
            return new Book(Title + "-copy", Year, Pages, Wearity);
        }
    }
}