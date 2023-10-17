using APPT3.Materials;
using APPT3.Members;
using System;
using System.Collections;
using System.Xml.Linq;

namespace APPT3.DataStorage
{
    public class Storage
    {
        public Book[] Books { get; set; }
        public Magazine[] Magazines { get; set; }
        public Storage(Book[] books, Magazine[] magazines)
        {
            Books = books;
            Magazines = magazines;
        }
        public void SortBooks(bool isASC)
        {
            if (isASC)
            {
                Array.Sort(Books);
            } else
            {
                Array.Reverse(Books);
            }
        }
        public void SortMagazines(bool isASC)
        {
            if (isASC)
            {
                Array.Sort(Magazines);
            }
            else
            {
                Array.Reverse(Magazines);
            }
        }
        public Book? FindBookByTitle(string title)
        {
            Book? book = Books.FirstOrDefault(s => s.Title == title);
            return book;
        }
        public Book? FindBookById(string id)
        {
            Book? book = Books.FirstOrDefault(s => s.Id == id);
            return book;
        }
        public Magazine? FindMagazineByTitle(string title)
        {
            Magazine? magazine = Magazines.FirstOrDefault(s => s.Title == title);
            return magazine;
        }
        public Magazine? FindMagazineById(string id)
        {
            Magazine? magazine = Magazines.FirstOrDefault(s => s.Id == id);
            return magazine;
        }
    }
}