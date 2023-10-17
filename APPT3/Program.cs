using APPT3.DataStorage;
using APPT3.Library;
using APPT3.Materials;
using APPT3.Members;
using APPT3.Enums;

void OnReturnInfo(Material material, Member member)
{
    Console.WriteLine($"Material '{material.Title}' with id '{material.Id}' has been returned with {material.Wearity} wear level by visitor {member.Name} with {member.PhoneNumber} phone number!");
}

Member[] members = new Member[5]; 
members[0] = new Employee("0996469593", "Vitalii", new DateOnly(1999, 8, 3), Gender.Male);
members[1] = new Visitor("0639342514", "Vlada", new DateOnly(1996, 6, 6), Gender.Female);
members[2] = new Employee("0999876543", "Oleksandr", new DateOnly(1992, 3, 8), Gender.Male);
members[3] = new Visitor("0505234321", "Yana", new DateOnly(1995, 2, 5), Gender.Female);
members[4] = new Employee("0663268074", "Maksym", new DateOnly(1989, 1, 1), Gender.Male);

Book[] books = new Book[3];
Magazine[] magazines = new Magazine[3];

books[0] = new Book("just book", 2023, 242, 4);
books[1] = new Book("a book", 2022, 244, 3);
books[2] = new Book("bbook", 2012, 12, 3);

magazines[0] = new Magazine("just mag", 2023, 242, 4, 3);
magazines[1] = new Magazine("a mag", 2022, 244, 3, 5);
magazines[2] = new Magazine("mmag", 2012, 12, 3, 7);

Storage storage = new Storage(books, magazines);

Console.WriteLine("Boks without sorting:");
foreach (Book book in storage.Books)
{
    Console.WriteLine(book.Title);
}

storage.SortBooks(true);
Console.WriteLine("Sorted books:");
foreach (Book book in storage.Books)
{
    Console.WriteLine(book.Title);
}

Library library = new Library(storage, members);

foreach (Member member in library.Members)
{
    if (member is Visitor)
    {
        ((Visitor)member).OnUsedMaterialReturn += OnReturnInfo;
    }
}

Material? testMaterial = library.FindMaterial("bbook", MaterialType.Book);

Console.WriteLine("Check wearity of book before taking:");
Console.WriteLine(testMaterial?.Wearity);

Console.WriteLine("Try to take book from storage.");
library.TakeMaterial("bbook", "0639342514", MaterialType.Book);

Console.WriteLine("Check if book became unavailable:");
Console.WriteLine(testMaterial?.isTaken);

List<Material> taken = ((Visitor)members[1]).GetMaterials();

Console.WriteLine("Check if book is presented in the list of taken books of visitor:");
foreach (Material material in taken)
{
    Console.WriteLine(material.Title);
}

Console.WriteLine("Try to return the book to storage.");
((Visitor)members[1]).ReturnMaterial(testMaterial);

Console.WriteLine("Check wearity of book after taking:");
Console.WriteLine(testMaterial?.Wearity);

Console.WriteLine("Try to subscribe to magazines.");
var magazinesToSubscribe = storage.Magazines[0] + storage.Magazines[1] + storage.Magazines[2];
library.SubscribeToMagazines(magazinesToSubscribe, "0996469593");

Console.WriteLine("Check subscriptions to magazine:");
Console.WriteLine(library.Members[0].MagazinesSubscription?.Title);

Console.WriteLine("Check how many books are nontaken:");
Console.WriteLine(library.GetNonTakenBooks());

Console.WriteLine("Get sorted members:");
var sortedMembers = library.LibraryMembers;

foreach (Member member in sortedMembers)
{
    Console.WriteLine($"{member.Name}");
}

Console.WriteLine("Get all members:");
foreach (Member member in library.Members)
{
    Console.WriteLine($"{member.Name}");
}