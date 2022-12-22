namespace OOP_Labs_3;

interface IRateAndCopy
{
    double Rating { get; }
    object DeepCopy();
}
enum Frequency { Weekly, Monthly, Yearly };

public static class Shifter
{
    public static int ShiftAndWrap(int value, int positions)
    {
        positions &= 0x1F;
        uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
        uint wrapped = number >> (32 - positions);
        return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
    }
}

class Program
{
    static void Main()
    {
        Person per1 = new Person("Коля", "Кто-то", new DateTime(2004, 02, 14));
        Article art1 = new Article(per1, "QQ", 11);
        Article art2 = new Article(per1, "QQ", 100);
        Article art3 = new Article(per1, "QQ", 1);
        Magazine mag1 = new Magazine("Nike", Frequency.Monthly, new DateTime(2004, 02, 14), 20);
        Magazine mag2 = new Magazine("Adidas", Frequency.Weekly, new DateTime(1993, 03, 5), 10);
        Magazine mag3 = new Magazine("Puma", Frequency.Weekly, new DateTime(1801, 01, 17), 30);
        
        mag1.AddArticles(new Article[1]{ art1});
        mag2.AddArticles(new Article[2]{ art1, art2});
        mag3.AddArticles(new Article[3]{ art1, art2, art3});
        MagazineCollection mc = new MagazineCollection();
        mc.AddMagazines(
            new Magazine[3]
            {
                mag1,
                mag2,
                mag3
            }
        );
    
        Console.WriteLine("Задание №1\n" + "Вывод всех элементов\n" + mc.ToShortString());

        
        mc.SortByName();
        Console.WriteLine("Задание №2\n" + "Соритировка по имени\n" + mc.ToShortString());

        mc.SortByRelease();
        Console.WriteLine("Соритировка по дате выхода\n" + mc.ToShortString());

        mc.SortByCirculation();
        Console.WriteLine("Соритировка по тиражу\n" + mc.ToShortString());

        Console.WriteLine("Задание №3\n" + "Максимальный рейтинг: " + mc.MaxRaiting);

        Console.WriteLine("\nОтбор журналов с переодичностью выхода Monthly");
        foreach (Magazine magazine in mc.MonthlyMagazines)
            Console.WriteLine(magazine.ToString());
        
        Console.WriteLine("\nГруппировка элементов по среднему рейтингу");
        foreach (Magazine magazine in mc.RaitingGroup(11))
            Console.WriteLine(magazine.ToShortString());

        Console.WriteLine("\nЗадание №4");
        TestCollections test = new TestCollections(100);
        int[] a = test.Test(0);
        Console.WriteLine("начало:");
        for (int i = 0; i < 4; ++i)
        {
            Console.Write(a[i].ToString() + ' ');
        }
        Console.WriteLine();
        a = test.Test(49);
        Console.WriteLine("середина:");
        for (int i = 0; i < 4; ++i)
        {
            Console.Write(a[i].ToString() + ' ');
        }
        Console.WriteLine();
        a = test.Test(99);

        Console.WriteLine("конец:");
        for (int i = 0; i < 4; ++i)
        {
            Console.Write(a[i].ToString() + ' ');
        }
        Console.WriteLine();
        a = test.Test(-1);
        Console.WriteLine("не входит:");
        for (int i = 0; i < 4; ++i)
        {
            Console.Write(a[i].ToString() + ' ');
        }
        Console.ReadKey();
    }
}

