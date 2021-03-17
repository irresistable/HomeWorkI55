using System;

namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            //I5.5.Мастям игральных карт условно присвоены следующие порядковые номера:
            //масти «пики» — 1, масти «трефы» — 2, масти «бубны» — 3, масти «червы» — 4.
            //По заданному номеру масти m(1 <= m <= 4) определить название соответствующей масти.

            int correctInput = 0;
            string output;

            Console.WriteLine("1st. I5.5");
            Console.Write("\nEnter number (1-4) to search the corresponded suit: ");

            for (; ; )
            {
                var userInput = Console.ReadKey();
                if (char.IsDigit(userInput.KeyChar)) //проверяем чар на циферность
                {
                    correctInput = int.Parse(userInput.KeyChar.ToString());//кастуем к инту
                    if(correctInput is >0 and <5)// если не выставить совместимость с Net.5 не работает
                    { break; }
                }
                Console.WriteLine("\nError. Retype please");
            }
            new TaskI55(correctInput-1, out output); //инициализируем(??) экземпляр и кидаем туда ввод от пользователя
            Console.WriteLine($"\nCorresponding to index {correctInput} suit is {output}");
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
                //output = ((Suits)input).ToString; не хочет
                var suit = (Suits)Enum.GetValues(typeof(Suits)).GetValue(input); //спиздил кусок кода
                output = suit.ToString();
                return;
            }
        }
    }
}
