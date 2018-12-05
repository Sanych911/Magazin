using System;

namespace ClassA
{




    public class Class1 //объявление класса
    {



        public struct User //объявление структуры 
        {

            public string name; // публичная переменная имени клиента
            public int age;// публичная переменная возроста клиента
            public int sum;// публичная переменная суммы на счету клиента




            public User(string n, int a, int s ) //конструктор пользователя
            { this.name = n; this.age = a; this.sum = s; }

            public void GetInfo() // метод вывода на экран информации о пользователе
            {
                Console.WriteLine($"Имя: {name}  Возраст: {age} Баланс: { sum}");

            }
            public void Pop()// метод реализующий пополнение счета клиента
            {
                Magazin.Program.Boot(5);
                Console.Clear();
                try  // обработка исключения на переполнение суммы
                {
                    Console.WriteLine("Введите ссуму для пополнения:");
                    sum += Convert.ToInt16(Console.ReadLine());
                }
                catch   //если введеная сумма не помещается в тип инт ,выполняется блок catch
                {
                    Console.WriteLine("Введите сумму поменьше");
                    Console.ReadLine();
                    Pop();
                }
            }

        }

    
        public static void Reg()// метод реализующий регистрацию клиента
        {
            Magazin.Program.Boot(5);
            Console.Clear();
            Console.WriteLine("Введите Ваш логин:");
            string n = Console.ReadLine();
            try // обработка ошибки
            {
                Console.WriteLine("Введите Ваш возрост,18+:");

                int a = Convert.ToInt16(Console.ReadLine());
                while (a<18|a>100) //ограничение по возросту от 18 до 100
                {
                    Console.WriteLine("Введите Ваш возрост:"); //запрос на ввод нужного числа
                    a = Convert.ToInt16(Console.ReadLine());

                }
                int s = 0;
                User Client = new User(n, a, s);// создание нового пользователя
                Pokupatel(Client); // вызов метода с передачей структуры клиент

            }
            catch
            {
                Console.WriteLine("Не корректные данные? 1- Регистрация; 2- Выход");
                int res = Convert.ToInt16(Console.ReadLine()); //запись значения выбора в переменную типа инт
                switch (res)
                {
                    case 1:
                        Reg();// вызов метода регистрации
                        break;
                    case 2:
                        Environment.Exit(0);// закрытие консоли
                        break;
                    default:
                        Console.WriteLine("Не верный ввод");// другой ввод пользователя
                        Environment.Exit(0);
                        break;
                }
            }  
        }

    public static void Pokupatel(User Client)// объявление метода (передается структура клиента)
        {
            Magazin.Program.Boot(5);
           
            Console.Clear();//очистка консоли
            Console.WriteLine("1-Покупка;" + "\r\n" + "2-Пополнение счета" + "\r\n" + "3-Мой профиль;" + "\r\n"   + "4-Выход");
            int res = Convert.ToInt16(Console.ReadLine()); //запись в переменную выбора
            switch (res)
            {
                case 1:// если нажата кнопка 1 
                    User11.Tovar.Ma(Client);// вызов метода реализующего покупку
                   
                    
                    break;
                case 2:

                   Client.Pop();// вызов метода реализующего пополнение суммы
                    Pokupatel(Client);// перевызов данного метода
                    break;
                case 3:

                    Client.GetInfo();// вызов метода реализующего вывод информации о клиенте
                    Console.ReadLine();
                    Pokupatel(Client);// перевызов данного метода
                    break;

                case 4:
                    Environment.Exit(0);// закрытие консоли
                    break;

                default:// проверка на нажатие другой цифры отличной от 1,2,3,4
                    Console.WriteLine("Вы нажали неизвестную клавишу");
                    break;
            }
            
        }
    }
    

}


            







