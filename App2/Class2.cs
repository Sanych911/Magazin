using System;
using System.Collections;




namespace User11
{

   
public class Tovar : ClassA.Class1 //класс товар
    {
        public string name ;// название
        public int price;// цена
        public int count;//количество
        public int id;// айди товара



        public Tovar(string Name, int Price, int Count, int Id) //конструктор для добавления товара
        {
            this.name = Name;

            this.price = Price;
            this.count = Count;
            this.id = Id;
        }
         



        public void ShowInfo() // метод выводит информацию о товаре
        {

            Console.WriteLine("Наименование: {0}\nЦена: {1}\nКоличество: {2}\nId:{3}\n", name, price, count, id);
        }

        


            static public void CountToLower(Tovar item, int res2)// метод уменьшения количества товара
        {
            if (item.count >= res2)// если количество товара больше, количества необходимого клиенту
            {
                item.count -= res2;// количество товара уменьшается на количество необходимого покупателю

            }
            else// если клиент ввел количество товара больше,чем есть в наличии
            {
                Console.WriteLine("В нашем Магазине нет достаточного количества товара");
                Console.ReadLine();
                return;
            }

        }


        public static void Ma(ClassA.Class1.User Client)// метод реализации магазина,передаются параметры покупателя
        {
            ArrayList objectList = new ArrayList() { };// объявляем пустой массив списков


            Tovar Tovar1 = new Tovar("Книга", 1000, 2, 254641);// добавляем через конструктор товар
            Tovar Tovar2 = new Tovar("Планшет", 2000, 3, 254642);
            Tovar Tovar3 = new Tovar("Пиво", 78, 3, 254643);

            void pokuk()// метод вывода покупок
            {
                
                
               
                
                if (objectList.Count > 0)// если список пне пустой
            {
                foreach (object o in objectList)// в цикле выводим объекты списка
                {
                    Console.WriteLine(o);
                }
            }
                else// если в списке еще нет покупок...
                {
                    Console.WriteLine("Вы еще не совершили покупку!");
                    Console.ReadLine();
                    Magazin();
                }
            }
            void udalen(object s, int k)// метод удаляет покупки,на входе объект с именем и переменная количества для удаления
            {
             
                
                    
               int m = objectList.IndexOf(s);// ищем индекс вхождения в список нашего товара
               int tec = Convert.ToInt16(objectList[m + 1]);// получаем значение сколько куплено данного товара
                tec = tec - k;// получаем сколько товара остается в корзине
                if (tec >= 0)//если остаток товара в корзине больше или равен нулю
                {

                    objectList.Insert(m + 1, tec);// вставляем в список остаток товара
                    objectList.RemoveAt(m + 2);// удаляем след.объект списка,т.к. при инсерте список сдвинулся а не заменился
                    
                   
                }
                else// если удаляем больше товара чем купили
                {
                    Console.WriteLine("Вы хотите удалить больше товара чем купили!");
                    Console.ReadLine();
                    Magazin();
                }


            }
            void Korzinka()// метод для работы с корзиной
            {
                Console.Clear();//очистка консоли
                
                Console.WriteLine("1.Удалить покупку 2. Добавить покупку");
                int res = Convert.ToInt16(Console.ReadLine());
                switch (res)
                {
                    case 1:
                        Console.Clear();
                        pokuk();// выводим список покупок на экран
                        Console.WriteLine("Введите номер товара для удаления: 1.Книга 2.Планшет 3.Пиво");
                        int tov = Convert.ToInt16(Console.ReadLine());
                       
                        switch(tov)
                        {
                            case 1:
                                Console.WriteLine("Введите необходимое количество для удаления");
                                int kolich = Convert.ToInt16(Console.ReadLine());
                                
                                object o = Tovar1.name;// создаем объект с именем товара
                               

                                udalen(o, kolich);// вызов метода удаления,куда передаем имя товара и количество для удаления
                                Client.sum += Tovar1.price * kolich;// возвращаем средства клиенту
                                Magazin();// вызываем метод для запроса действия клиента
                                break;
                            
                            case 2:// аналогично первому кейсу
                                Console.WriteLine("Введите необходимое количество для удаления");
                                int kolich2 = Convert.ToInt16(Console.ReadLine());

                                object b = Tovar2.name;// создаем объект с именем товара
                                

                                udalen(b, kolich2);// вызов метода удаления товара из корзины,передаем объект товар и количество для удаления
                                Client.sum += Tovar2.price * kolich2;// возвращение денег за покупку клиенту
                                Magazin();
                                break;
                            case 3:// аналогично первому кейсу
                                Console.WriteLine("Введите необходимое количество для удаления");
                                int kolich3 = Convert.ToInt16(Console.ReadLine());

                                object c = Tovar3.name;


                                udalen(c, kolich3);
                                Client.sum += Tovar3.price * kolich3;
                                Magazin();
                                break;
                            default:// если пользователь ввел отличную от нужной клавиши
                                Console.WriteLine("Ошибка ввода");
                                Console.ReadLine();
                                Magazin();
                                break;
                        }
                        
                        
                        break;
                    case 2:
                        Dey();
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода!");
                        break;
                }

            }


            Tovar1.ShowInfo();// вывод на экран информации и товарах
            Tovar2.ShowInfo();
            Tovar3.ShowInfo();


            Dey();// вызов функции покупки


            void Magazin()// метод магазина(создана чтоб вывести покупателя из функции рангом выше.т.к. конструктор сново создал бы товары с прежним количеством)
            {
               
                
                Console.Clear();//очистка консоли
                Console.WriteLine("1-Покупка;" + "\r\n" + "2-Пополнение счета" + "\r\n" + "3-Список покупок;" + "\r\n" + "4-Мой профиль;" + "\r\n"+ "5-Работа с корзиной;" + "\r\n" + "6-Выход");
                int res = Convert.ToInt16(Console.ReadLine());
                switch (res)
                {
                    case 1:
                        
                        Dey();// вызов метода для покупки

                        break;
                    case 2:
                        Client.Pop();// вызов метода пополнения баланса клиента
                        Console.ReadLine();
                       
                         Magazin();// вызов метода магазин
                        break;
                    case 3:
                        pokuk();
                        //Showw(List<people>);
                        //Pokupka.ShowInfoPokupki();// вывод информации о покупках каждого товара

                        Console.ReadLine();
                        Magazin();
                        break;
                    case 4:
                        Client.GetInfo();// вызов метода дающего информацию о клиенте
                        Console.ReadLine();
                        
                        Magazin();
                        break;
                    case 5:
                        Korzinka();
                        break;
                    case 6:
                        Environment.Exit(0);// закрытие консоли
                        break;

                    default:// проверка на нажатие другой цифры отличной от 1,2,3,4
                        Console.WriteLine("Вы нажали неизвестную клавишу");
                      
                        break;
                }

            }
                void Dey()// метод покупки товара
            {

               
                Console.Clear();
                Tovar1.ShowInfo();// вывод информации о товаре
                Tovar2.ShowInfo();
                Tovar3.ShowInfo();
                Console.WriteLine("1-Выберите номер нужного товара"+ "\r\n");
                int res = Convert.ToInt16(Console.ReadLine());

                switch (res)
                {
                    case 1:
                        Console.Clear();// очистка консоли
                        Tovar1.ShowInfo();// вывод информации о товаре
                        Console.WriteLine("Введите необходимое Вам количество");//запрос 
                        int res2 = Convert.ToInt16(Console.ReadLine());

                        while (res2 == 0)
                        {

                            Console.WriteLine("Введите необходимое Вам количество");
                            res2 = Convert.ToInt16(Console.ReadLine());
                        };




                        if (Client.sum * res2 < Tovar1.price * res2)// проверка хватает ли средств на покупку
                        {
                            Console.WriteLine("Ваших средств не достаточно для покупки,пополните баланс ");
                            Console.ReadLine();


                            Magazin();
                            break;
                        }
                        else
                        {


                            CountToLower(Tovar1, res2);// вызов метода уменьшающего количества товара
                            Client.sum -= Tovar1.price * res2;// вычет суммы покупки с баланса клиента
                            int prov = objectList.IndexOf(Tovar1.name);//получаем индекс вхождения имени товара в список покупок,если еще не купили возвращает -1
                            if (prov == -1)//если товара нет в списке покупок
                            {
                                objectList.Add(Tovar1.name);//добавляем в список товар с именем 
                                objectList.Add(res2);//добавляем количество в список
                            }
                            else// если товар в списке уже есть
                            {
                               
                              
                                
                                int tec = Convert.ToInt16(objectList[prov + 1]);//получаем значение купленного товара
                                tec += res2;//прибавляем к значению корзины,значение новой покупки
                                objectList.Insert(prov + 1, tec);//вставляем
                                objectList.RemoveAt(prov + 2);//удаляем
                            }
                           

                            Magazin();//вызов метода магазина
                            
                        }

                        break;
                    case 2:// аналогично первому методу

                        Console.Clear();// очистка консоли
                        Tovar2.ShowInfo();// вывод информации о товаре
                        Console.WriteLine("Введите необходимое Вам количество");//запрос 
                        int res3 = Convert.ToInt16(Console.ReadLine());

                        while (res3 == 0)
                        {

                            Console.WriteLine("Введите необходимое Вам количество");
                            res3 = Convert.ToInt16(Console.ReadLine());
                        };




                        if (Client.sum * res3 < Tovar1.price * res3)// проверка хватает ли средств на покупку
                        {
                            Console.WriteLine("Ваших средств не достаточно для покупки,пополните баланс ");
                            Console.ReadLine();


                            Magazin();
                            break;
                        }
                        else
                        {


                            CountToLower(Tovar2, res3);// вызов метода уменьшающего количества товара
                            Client.sum -= Tovar2.price * res3;// вычет суммы покупки с баланса клиента
                            int prov = objectList.IndexOf(Tovar2.name);
                            if (prov == -1)
                            {
                                objectList.Add(Tovar2.name);
                                objectList.Add(res3);
                            }
                            else
                            {

                                object z = objectList[prov + 1];
                                // var  tec= objectList[m + 1];
                                int tec = Convert.ToInt16(objectList[prov + 1]);
                                tec += res3;
                                objectList.Insert(prov + 1, tec);
                                objectList.RemoveAt(prov + 2);
                            }


                            Magazin();//вызов метода магазина

                        }

                        break;
                    case 3:
                        Console.Clear();// очистка консоли
                        Tovar3.ShowInfo();// вывод информации о товаре
                        Console.WriteLine("Введите необходимое Вам количество");//запрос 
                        int res4 = Convert.ToInt16(Console.ReadLine());

                        while (res4 == 0)
                        {

                            Console.WriteLine("Введите необходимое Вам количество");
                            res4 = Convert.ToInt16(Console.ReadLine());
                        };




                        if (Client.sum * res4 < Tovar1.price * res4)// проверка хватает ли средств на покупку
                        {
                            Console.WriteLine("Ваших средств не достаточно для покупки,пополните баланс ");
                            Console.ReadLine();


                            Magazin();
                            break;
                        }
                        else
                        {


                            CountToLower(Tovar3, res4);// вызов метода уменьшающего количества товара
                            Client.sum -= Tovar3.price * res4;// вычет суммы покупки с баланса клиента
                            int prov = objectList.IndexOf(Tovar3.name);
                            if (prov == -1)
                            {
                                objectList.Add(Tovar3.name);
                                objectList.Add(res4);
                            }
                            else
                            {

                                object z = objectList[prov + 1];
                                // var  tec= objectList[m + 1];
                                int tec = Convert.ToInt16(objectList[prov + 1]);
                                tec += res4;
                                objectList.Insert(prov + 1, tec);
                                objectList.RemoveAt(prov + 2);
                            }


                            Magazin();//вызов метода магазина

                        }

                        break;


                    default:// проверка на нажатие другой цифры отличной от 1,2,3,4
                        Console.WriteLine("Вы нажали неизвестную клавишу");
                        Dey();
                        break;

                }
            }
        }
        
        

    }
    
}






























