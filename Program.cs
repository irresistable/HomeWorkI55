using System;

namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {

            int correctInput = 0;
            string output;

            Console.WriteLine("1st. I5.5");
            Console.Write("\nEnter number (1-4) to search the corresponded suit: ");

            for (; ; )
            {
                var userInput = Console.ReadKey();
                if (char.IsDigit(userInput.KeyChar))
                {
                    correctInput = int.Parse(userInput.KeyChar.ToString());
                    if ((correctInput > 0) && (correctInput < 5))
                    { break; }
                }
            }
            TaskI55 query = new TaskI55(correctInput-1, out output); //создаем экземпляр и кидаем туда ввод от пользователя

            Console.WriteLine($"\nCorresponding to {correctInput} suit is {output}");
            Console.ReadKey();
    }
    public class TaskI55 
        {
            private enum Suits // инкапсулируем
            {
                Spades=1, // иначе индекс будет с 0  НО ПОЧЕМУ ТО НЕ РАБОТАЕТ ТАК, ПРИШЛОСЬ -1 ДЕЛАТЬ В ПЕРЕДАЧЕ ЗНАЧЕНИЯ
                Clubs,
                Diamonds,
                Hearts,
            }
            public TaskI55(int input, out string output) //принимаем инт и выкидываем стринг из перечисления
            {
                var suit = (Suits)Enum.GetValues(typeof(Suits)).GetValue(input); //спиздил кусок кода
                output = suit.ToString();
                return;
            }
        }
    }
}
