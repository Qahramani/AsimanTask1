namespace _27_06.Task2;

public class Program
{
    static void Main(string[] args)
    {
        Library[] libraries = new Library[0];
        Category[] categories = new Category[0];
        Book[] books = new Book[0];


    restartMainMenu:

        Console.WriteLine("==============\n  Ana menu\n==============");
        Console.WriteLine("[1]Yeni kitabxana yarat.");
        Console.WriteLine("[2]Yeni kateqoriya yarat.");
        Console.WriteLine("[3]Yeni kitab yarat.");
        Console.WriteLine("[4]Kitabxanaya daxil ol.");
        Console.WriteLine("[0]Proqramdan cxih.");
        Console.Write(">>>");

        string opt = Console.ReadLine();
        switch (opt)
        {
            case "1":
                Console.Write("Kitabxana adini daxil ediniz: ");
                string libraryname = Console.ReadLine();

                Array.Resize(ref libraries, libraries.Length + 1);
                Library library = new Library(libraryname);
                libraries[^1] = library;

                Colored.WriteLine($"{libraryname} adli kitabxana yaradildi", "green");

                break;
            case "2":
                Console.Write("Kateqoriyanın adını daxil edirsiniz: ");
                string categoryname = Console.ReadLine();

                Array.Resize(ref categories, categories.Length + 1);
                Category category = new Category(categoryname);
                categories[^1] = category;

                Colored.WriteLine($"{categoryname} adli category yaradildi", "green");
                break;
            case "3":
                Console.WriteLine("====================\n  Yeni kitab yarat\n====================");
                Console.Write("Kitabin adini daxil et: ");
                string bookname = Console.ReadLine();

                Console.Write("Author daxil et: ");
                string authorname = Console.ReadLine();

            restartAddingCategoryId:
                Console.WriteLine("Kategory sec:");

                foreach (var item in categories)
                {
                    Console.WriteLine(item);
                }

                Console.Write("Id daxil edin: ");
                int categoryId = int.Parse(Console.ReadLine());

                bool DoesCategoryExist = false;
                foreach (var item in categories)
                {
                    if (categoryId == item.Id)
                    {
                        Array.Resize(ref books, books.Length + 1);
                        books[^1] = new(bookname, authorname, item);

                        Colored.WriteLine("Kitab elave olundu", "green");
                        DoesCategoryExist = true;
                        break;
                    }
                }
                if (!DoesCategoryExist)
                {
                    Colored.WriteLine("Movcud olan categoriya Idsi elave ediniz", "red");
                    goto restartAddingCategoryId;
                }
                break;
            case "4":
                EnterLibrary(libraries, books);
                break;
            case "0":
                Colored.WriteLine("Programdan cixis etdiniz", "yellow");
                return;
            default:
                Colored.WriteLine("Duzgun deyer daxil ediniz", "red");
                break;
        }
        goto restartMainMenu;
    }

    private static void EnterLibrary(Library[] libraries, Book[] books)
    {
    restartAddingBookToLibrary:
        Console.WriteLine("Kitabxana sec:");
        foreach (var item in libraries)
        {
            Console.WriteLine(item);
        }

        Console.Write("Id daxil edin: ");
        int libraryId = int.Parse(Console.ReadLine());

        bool DoesLibraryExist = false;
        foreach (var item in libraries)
        {
            if (libraryId == item.Id)
            {
                DoesLibraryExist = true;
            restartLibraryMenu:
                Console.WriteLine("=======================\n Kitabxanan Menusu\n======================");
                Console.WriteLine("" +
                    "[1]Kitab elave et\n" +
                    "[2]Kitablari goster\n" +
                    "[0]Kitabxanadan cix\n>>>");
                string opt2 = Console.ReadLine();
                switch (opt2)
                {
                    case "1":
                        Console.WriteLine("======== Movcud Kitablar =========");
                        foreach (var book in books)
                        {
                            Console.WriteLine(book);
                        }

                        Console.Write("Kitabin Idsin elave ediniz: ");
                        int bookId = int.Parse(Console.ReadLine());

                        bool doesBookExist = false;
                        foreach (var book in books)
                        {
                            if (bookId == book.Id)
                            {
                                doesBookExist = true;
                                break;
                            }
                        }
                        if (!doesBookExist)
                        {
                            Colored.WriteLine("Bu IDli kitab tapilmadi", "red");
                            goto restartLibraryMenu;
                        }
                        bool DoesLibraryContainTheBook = false;

                        if (item._books != null)
                        {
                            foreach (var book in item._books)
                            {
                                if (book.Id == bookId)
                                {
                                    Colored.WriteLine("Bu kitab artiq kitabxanada movcuddur", "red");
                                    DoesLibraryContainTheBook = true;
                                    break;
                                }
                            }

                            if (!DoesLibraryContainTheBook)
                            {
                                foreach (var book in books)
                                {
                                    if (book.Id == bookId)
                                    {
                                        item.AddBook(book);
                                        break;
                                    }
                                }
                                Colored.WriteLine("Kitab elave olundu", "green");
                            }
                        }
                        else
                        {
                            foreach (var book in books)
                            {
                                if (book.Id == bookId)
                                {
                                    item.AddBook(book);
                                    break;
                                }
                            }
                            Colored.WriteLine("Kitab elave olundu", "green");
                        }


                        break;
                    case "2":
                        Console.WriteLine($"====== {item.Name} kitabxanasinda olan butun kitablar ======");
                        item.ListAllBooks();
                        break;
                    case "0":
                        Colored.WriteLine("Kitabxanadan cixis etdiniz", "yellow");
                        return;
                    default:
                        Colored.WriteLine("Duzgun deyer daxil ediniz", "red");
                        break;
                }
                goto restartLibraryMenu;

            }
        }
        if (!DoesLibraryExist)
        {
            Colored.WriteLine("Kitabxana ucun duzgun Id daxil ediniz", "red");
            goto restartAddingBookToLibrary;
        }
    }
}
