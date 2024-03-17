using ClassLibraryLab10;
using Lab9;
using System.ComponentModel.Design;

namespace Lab10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создание случайного массива из 20 случайных экземпляров
            Random random = new Random();
            BankCard[] array = new BankCard[20];

            for (int i = 0; i < 20; i++)
            {
                int p = random.Next(0, 4);
                if (p == 0)
                {
                    array[i] = new BankCard();
                }
                else if (p == 1)
                {
                    array[i] = new DebitCard();
                }
                else if (p == 2)
                {
                    array[i] = new YouthCard();
                }
                else
                {
                    array[i] = new CreditCard();
                }
                array[i].RandomInit();
            }

            Console.WriteLine("Использование виртуальной функции:");
            foreach (BankCard item in array)
            {
                item.ShowVirtual();
            }

            //Нахождение элемента в массиве после сортировки по имени
            BankCard c = new BankCard("3456345667894561", "DENIS IVANOV", new DateTime(2024,01,01));
            array[0] = c;
            Array.Sort(array);
            Console.WriteLine("Использование виртуальной функции + отсортированный по имени :");
            int pos = Array.BinarySearch(array, new BankCard("3456345667894561", "DENIS IVANOV", new DateTime(2024, 01, 01)));
            if (pos < 0)
                Console.WriteLine("Нет такого элемента");
            else
                Console.WriteLine($"Элемент находится на {pos+1} позиции");
            foreach (BankCard item in array)
            {
                item.ShowVirtual();
            }

            //Нахождение элемента в массиве после сортировки по дате
            Array.Sort(array, new SortByDate());
            Console.WriteLine("Использование виртуальной функции + отсортированный по дате :");
            pos = Array.BinarySearch(array, new BankCard("3456345667894561", "DENIS IVANOV", new DateTime(2024, 01, 01)), new SortByDate());
            if (pos < 0)
                Console.WriteLine("Нет такого элемента");
            else
                Console.WriteLine($"Элемент находится на {pos + 1} позиции");
            foreach (BankCard item in array)
            {
                item.ShowVirtual();
            }

            Console.WriteLine("Использование обычной функции:");
            foreach (BankCard item in array)
            {
                item.Show();
            }

            //Нахождение общего баланса всех дебетовых карт через ДИТ
            double sum = 0;
            foreach (BankCard item in array)
            {
                if (item is DebitCard dc)
                {
                    sum += dc.Balance;
                }
            }
            Console.WriteLine($"Общий баланс всех дебетовых карт: {sum} руб.");

            //Нахождения среднего процента кэшбэка молодежных карт через ДИТ
            int countYouthCardNumber = 0;
            int sumCashback = 0;
            foreach (BankCard item in array)
            {
                YouthCard card = item as YouthCard;
                if (card != null)
                {
                    sumCashback += card.Cashback;
                    countYouthCardNumber++;
                }
            }
            double averageCashbackPercent = (double)sumCashback / countYouthCardNumber;
            Console.WriteLine($"Средний процент кэшбека молодежных карт: {averageCashbackPercent}%");

            //Нахождение самого большого лимита из всех кредитных карт
            int maxLimit = 0;
            foreach (BankCard item in array)
            {
                if (item is CreditCard cd)
                {
                    if (cd.Limit > maxLimit)
                    {
                        maxLimit = cd.Limit;
                    }
                }
            }
            Console.WriteLine($"Самый большой лимит из всех кредитных карт: {maxLimit}\n");

            //Использование интерфейся IInit для создания массива разных иерархий классов
            IInit[] array2 = new IInit[15];
            for (int i = 0; i < 15; i++)
            {
                int p = random.Next(0, 5);
                if (p == 0)
                {
                    array2[i] = new BankCard();
                }
                else if (p == 1)
                {
                    array2[i] = new DebitCard();
                }
                else if (p == 2)
                {
                    array2[i] = new YouthCard();
                }
                else if (i == 3)
                {
                    array2[i] = new CreditCard();
                }
                else
                {
                    array2[i] = new GeoCoordinates();
                }
                array2[i].RandomInit();
            }

            foreach (IInit item in array2)
            {
                Console.WriteLine(item);
            }

            //Вывод работы с копией и клоном
            GeoCoordinates gc = new GeoCoordinates();
            gc.RandomInit();
            Console.WriteLine(gc);
            GeoCoordinates copy = (GeoCoordinates)gc.ShallowCopy();
            Console.WriteLine(copy);
            GeoCoordinates clon = (GeoCoordinates)gc.Clone();
            Console.WriteLine(clon);
            Console.WriteLine("После изменения");
            copy.Latitude = gc.Latitude;
            copy.id.number = 100;
            clon.Latitude = gc.Latitude;
            clon.id.number = 200;
            Console.WriteLine(gc);
            Console.WriteLine(copy);
            Console.WriteLine(clon);
        }
    }
}
