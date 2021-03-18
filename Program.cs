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

            Console.WriteLine("1st. I5.5");
            int value;
            string output;
            string name = "suit"; //тут храним описание существительного

            new UserInput(1, 4, name, out value);
            new GetFromEnum(value - 1, out output); //инициализируем(??) экземпляр и кидаем туда ввод от пользователя
            Console.WriteLine($"\nCorresponding to index {value} {name} is {output}");
            Console.ReadKey();
        }
        public class GetFromEnum
        {
            private enum Suits // инкапсулируем
            {
                Spades = 1, // иначе индекс будет с 0  НО ПОЧЕМУ ТО НЕ РАБОТАЕТ ТАК, ПРИШЛОСЬ -1 ДЕЛАТЬ В ПЕРЕДАЧЕ ЗНАЧЕНИЯ
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
        public class UserInput 
            {
            int _minValue = 0;
            int _maxValue = 9;
            string _name = "";
        public UserInput(int minValue, int maxValue, string name, out int UserInput)// принимаем лимиты ввода и возвращаем проверенный ввод
        {
                _minValue = minValue;
                _maxValue = maxValue;
                _name = name;
                int UserInput2;

                Console.Write($"\nEnter number ({minValue}-{maxValue}) to search the corresponded {_name}: ");
                for (; ; )
                {
                    var inputKey = Console.ReadKey();
                    if (char.IsDigit(inputKey.KeyChar)) //проверяем чар на циферность
                    {
                        UserInput2 = int.Parse(inputKey.KeyChar.ToString());//кастуем к инту
                        if ((UserInput2 >= _minValue) && (UserInput2 <= _maxValue))
                            { break; }
                    }
                    Console.WriteLine("\nError. Retype please");
                }
                UserInput = UserInput2;
                return;
            }
    }
}
}
