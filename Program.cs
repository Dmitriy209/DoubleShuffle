using System;

namespace DoubleShuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ButtonExit = "exit";
            const string ButtonShuffleCards = "1";
            const string ButtonShuffleNumbers = "2";

            bool isRunning = true;

            string[] cards = { "J", "2", "3", "4", "5", "6", "7", "8", "9", "10", "V", "Q", "K", "A" };

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            while (isRunning)
            {
                Console.WriteLine($"Введите {ButtonExit}, чтобы выйти.\n" +
                    $"Введите {ButtonShuffleCards}, чтобы перемешать колоду.\n" +
                    $"Введите {ButtonShuffleNumbers}, чтобы перемешать числа.");
                string userInput = Console.ReadLine();

                Console.Clear();

                switch (userInput)
                {
                    case ButtonExit:
                        isRunning = false;
                        break;

                    case ButtonShuffleCards:
                        ShuffleCards(cards);
                        break;

                    case ButtonShuffleNumbers:
                        ShuffleNumbers(numbers);
                        break;

                    default:
                        Console.WriteLine("Вы ввели что-то другое.");
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Вы вышли из программы.");
        }

        static string[] Shuffle(string[] symbols)
        {
            Random random = new Random();

            int minLimitRandom = 0;
            int maxLimitRandom = symbols.Length;

            string tempElement;

            for (int i = 0; i < symbols.Length; i++)
            {
                int indexRandom = random.Next(minLimitRandom, maxLimitRandom);

                tempElement = symbols[i];
                symbols[i] = symbols[indexRandom];
                symbols[indexRandom] = tempElement;
            }

            return symbols;
        }

        static void ShuffleCards(string[] cards)
        {
            string space = " ";

            string[] cardsMix = new string[cards.Length];

            for (int i = 0; i < cards.Length; i++)
                cardsMix[i] = cards[i];

            Console.WriteLine($"Изначальная колода:");
            ShowArray(cards, space);

            cardsMix = Shuffle(cardsMix);

            Console.WriteLine("Ваша колода, сэр.");
            ShowArray(cardsMix, space);
        }

        static void ShowArray(string[] array, string separator = "")
        {
            foreach (string element in array)
                Console.Write(element + separator);

            Console.WriteLine();
        }

        static int[] ShuffleInteger(int[] numbers)
        {
            Random random = new Random();

            int minLimitRandom = 0;
            int maxLimitRandom = numbers.Length;

            int tempElement;

            for (int i = 0; i < numbers.Length; i++)
            {
                int indexRandom = random.Next(minLimitRandom, maxLimitRandom);

                tempElement = numbers[i];
                numbers[i] = numbers[indexRandom];
                numbers[indexRandom] = tempElement;
            }

            return numbers;
        }

        static void ShuffleNumbers(int[] numbers)
        {
            string space = " ";

            int[] numbersMix = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
                numbersMix[i] = numbers[i];

            Console.WriteLine($"Изначальная колода:");
            ShowArrayInteger(numbers, space);

            numbersMix = ShuffleInteger(numbersMix);

            Console.WriteLine("Ваша колода, сэр.");
            ShowArrayInteger(numbersMix, space);
        }

        static void ShowArrayInteger(int[] array, string separator = "")
        {
            foreach (int element in array)
                Console.Write(element + separator);

            Console.WriteLine();
        }
    }
}