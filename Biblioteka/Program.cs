using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class Program
    {
        static List<Ksiazka> ksiazki = new List<Ksiazka>();
        static int currentId = 1;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Wyświetl wszystkie książki");
                Console.WriteLine("2. Dodaj książkę");
                Console.WriteLine("3. Usuń książkę");
                Console.WriteLine("4. Aktualizuj książkę");
                Console.WriteLine("5. Wyjście");

                Console.Write("Wybierz opcję: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListBooks();
                        break;
                    case "2":
                        AddBook();
                        break;
                    case "3":
                        DeleteBook();
                        break;
                    case "4":
                        UpdateBook();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Niepoprawny wybór, spróbuj ponownie.");
                        break;
                }
            }

        }
        static void ListBooks()
        {
            Console.WriteLine("\nLista książek:");
            foreach (var ksiazka in ksiazki)
            {
                Console.WriteLine($"ID: {ksiazka.ID}, Tytuł: {ksiazka.Tytul}, Autor: {ksiazka.Autor}, Rok Wydania: {ksiazka.RokWydania}, ISBN: {ksiazka.ISBN}");
            }
        }

        static void AddBook()
        {
            Ksiazka newKsiazka = new Ksiazka();
            newKsiazka.ID = currentId++;

            Console.Write("Podaj tytuł: ");
            newKsiazka.Tytul = Console.ReadLine();

            Console.Write("Podaj autora: ");
            newKsiazka.Autor = Console.ReadLine();
            while (1==1)
            {
                Console.Write("Podaj rok wydania: ");
                try
                { 
                    newKsiazka.RokWydania = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.Write("Podaj ISBN: ");
            newKsiazka.ISBN = Console.ReadLine();

            ksiazki.Add(newKsiazka);
            Console.WriteLine("Książka została dodana.");
        }

        static void DeleteBook()
        {
            Console.Write("Podaj ID książki do usunięcia: ");
            int id = int.Parse(Console.ReadLine());

            Ksiazka ksiazka = ksiazki.FirstOrDefault(k => k.ID == id);
            if (ksiazka != null)
            {
                ksiazki.Remove(ksiazka);
                Console.WriteLine("Książka została usunięta.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono książki o podanym ID.");
            }
        }

        static void UpdateBook()
        {
            Console.Write("Podaj ID książki do aktualizacji: ");
            int id = int.Parse(Console.ReadLine());

            Ksiazka ksiazka = ksiazki.FirstOrDefault(k => k.ID == id);
            if (ksiazka != null)
            {
                Console.Write("Podaj nowy tytuł: ");
                ksiazka.Tytul = Console.ReadLine();

                Console.Write("Podaj nowego autora: ");
                ksiazka.Autor = Console.ReadLine();

                while (1 == 1)
                {
                    Console.Write("Podaj rok wydania: ");
                    try
                    {
                        ksiazka.RokWydania = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                Console.Write("Podaj nowy ISBN: ");
                ksiazka.ISBN = Console.ReadLine();

                Console.WriteLine("Książka została zaktualizowana.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono książki o podanym ID.");
            }
        }
    }
}
