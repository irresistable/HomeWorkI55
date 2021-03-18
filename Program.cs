using System;

namespace HomeWork5
{
    class Program
    {
        //public interface ITask
        //{

        //}
        static void Main(string[] args)
        {
            //I5.5.Мастям игральных карт условно присвоены следующие порядковые номера:
            //масти «пики» — 1, масти «трефы» — 2, масти «бубны» — 3, масти «червы» — 4.
            //По заданному номеру масти m(1 <= m <= 4) определить название соответствующей масти.

            Console.WriteLine("1st. I5.5");
            
            string output;
            int correctInput = KeyInput();
            new GetFromEnum(correctInput - 1, out output); //инициализируем(??) экземпляр и кидаем туда ввод от пользователя
            Console.WriteLine($"\nCorresponding to index {correctInput} suit is {output}");
            Console.ReadKey();
        }
            public static int KeyInput()
            {
            int correctInput2;
            Console.Write("\nEnter number (1-4) to search the corresponded suit: ");
            for (; ; )
            {
                var inputKey = Console.ReadKey();
                if (char.IsDigit(inputKey.KeyChar)) //проверяем чар на циферность
                {
                    correctInput2 = int.Parse(inputKey.KeyChar.ToString());//кастуем к инту
                    if (correctInput2 is (> 0 and < 5))
                    { break; }
                }
                Console.WriteLine("\nError. Retype please");
            }
            return correctInput2;
            }

        public class GetFromEnum 
        {
            private enum Suits // инкапсулируем
            {
                Spades=1, // иначе индекс будет с 0  НО ПОЧЕМУ ТО НЕ РАБОТАЕТ ТАК, ПРИШЛОСЬ -1 ДЕЛАТЬ В ПЕРЕДАЧЕ ЗНАЧЕНИЯ
                Clubs,
                Diamonds,
                Hearts,
            }
            public GetFromEnum(int input, out string output) //принимаем инт и выкидываем стринг из перечисления
            {
                var suit = (Suits)Enum.GetValues(typeof(Suits)).GetValue(input); //спиздил кусок кода
                output = suit.ToString();
                return;
            }
        }
        
    }
}
