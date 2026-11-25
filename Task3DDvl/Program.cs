
namespace Task3DDvl
{
    internal class Program
    {
        static void Main()
        {
            Book[] books = new Book[]
            {
                new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, 10.99),
                new Book("To Kill a Mockingbird", "Harper Lee", 1960, 12.99),
                new Book("1984", "George Orwell", 1949, 9.99),
                new Book("Pride and Prejudice", "Jane Austen", 1813, 8.99),
                new Book("The Catcher in the Rye", "J.D. Salinger", 1951, 11.99),
                new Book("The Hobbit", "J.R.R. Tolkien", 1937, 14.99),
                new Book("Moby-Dick", "Herman Melville", 1851, 13.99),
                new Book("War and Peace", "Leo Tolstoy", 1869, 15.99),
                new Book("The Odyssey", "Homer", -800, 7.99),
                new Book("Crime and Punishment", "Fyodor Dostoevsky", 1866, 12.49)
            };
            ArrayHelper.Sort(books);

            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine(books[i]);
            }

            // ახლა სორტირდება წიგნები მათი გამოშვების წლის მიხედვით (Year).
            // გადავაკეთოთ ისე რომ ჯერ დასორტირდეს წლებით (Year) და შემდეგ ფასით (Price).




            Car[] cars =
                    {
                        new Car { Brand = "Toyota", Model = "Camry", Year = 2020, Price = 18500m },
                        new Car { Brand = "Honda", Model = "Civic", Year = 2019, Price = 15200m },
                        new Car { Brand = "BMW", Model = "320i", Year = 2021, Price = 32000m },
                        new Car { Brand = "Mercedes-Benz", Model = "C 200", Year = 2018, Price = 24500m },
                        new Car { Brand = "Hyundai", Model = "Elantra", Year = 2022, Price = 19800m },
                        new Car { Brand = "Ford", Model = "Focus", Year = 2017, Price = 11000m },
                        new Car { Brand = "Volkswagen", Model = "Golf", Year = 2020, Price = 17500m },
                        new Car { Brand = "Kia", Model = "Sportage", Year = 2023, Price = 27000m },
                        new Car { Brand = "Nissan", Model = "Altima", Year = 2019, Price = 16000m },
                        new Car { Brand = "Mazda", Model = "CX-5", Year = 2021, Price = 25500m }
                    };

            ArrayHelper.Sort(cars);

            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine(cars[i].ToString());
            }
        }
    }

    class Book : IMyComparable
    {
        public Book(string title, string author, int year, double price)
        {
            Title = title;
            Author = author;
            Year = year;
            Price = price;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Year: {Year}, Price: {Price:0.00}";
        }

        public int CompareTo(object other)
        {
            if (other is not Book otherBook)
                throw new InvalidOperationException("Object is not a Book.");

            // Compare by Year
            if (this.Year > otherBook.Year) return 1;
            if (this.Year < otherBook.Year) return -1;
            return 0;
        }
    }

    // შევქმნათ მანქანების 10 ელემენტიანი მასივი და დავასორტიროთ ფასების მიხედვით კლებადობით.
    class Car : IMyComparable
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Brand: {Brand}, Model: {Model}, Year: {Year}, Price: {Price:0.00}";
        }
        public int CompareTo(object other)
        {
            if (other is not Car otherCar)
                throw new InvalidOperationException("Object is not a Car.");

            // Compare by Year
            if (this.Price > otherCar.Price) return -1;
            if (this.Price < otherCar.Price) return 1;
            return 0;
        }
    }

    // ---------------------------------------

    interface IMyComparable
    {
        // This method should compare the current object with another object of the same type.
        // It should return -1 number if the current object is less than the other object,
        // 0 if they are equal, and 1 if the current object is greater than the other object.
        int CompareTo(object other);
    }

    static class ArrayHelper
    {
        //We need to implement the Sort method for the array of unknown type.
        //Sorting logic will be the same we just need to solve
        //the problem of comparing two objects of unknown type.
        public static void Sort(object[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] is not IMyComparable item)
                        throw new InvalidOperationException("Array element does not implement IMyComparable.");

                    if (item.CompareTo(array[j + 1]) > 0)
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}