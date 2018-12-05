using System;
using System.Threading;// библиотека для функции задержки

namespace Magazin
{
  

    class Program
    {
        
        enum Operation //создание списка
        {
            Reg=1 ,
            Exit
            
        }
       static void PerviyVibor(Operation op) //объявление метода
        {


            switch (op)
            {
                case Operation.Reg: // если из списка выбрана Reg
                    ClassA.Class1.Reg();// вызов соответсвующего метода в отдельном классу
                    break;
                case Operation.Exit:
                    Environment.Exit(0); // закрытие консоли
                    break;
                
            }
        }
       public static int  Boot(int x) // впихнул необходимую керкурсию....
        {
            if (x > 0)
            {
                Console.WriteLine($"{x}");// вывод значения
                Thread.Sleep(100); //задержка
                return Boot(x - 1);// рекурсивный вызов функции с инкрементом текущего значения
            }
            else return 0;
        }
        public static  void Main(string[] args)
        {
            Boot(10); // вызов рекурсивный функции 
            Console.Clear();// очистка консоли
            Console.WriteLine("Приветствуем в нашем Магазине! Выберите действие" + "\n");  //вывод текста на экран
            Console.WriteLine("1-Регистрация;" + "\r\n" +  "2-Выход" );
            int res = Convert.ToInt16(Console.ReadLine()); //запись значения выбора в переменную типа инт
            switch (res)
            {
                case 1:
                    PerviyVibor(Operation.Reg);// вызов метода с параметром списка
                   

                    break;
                case 2:

                    Environment.Exit(0);// закрытие консоли

                    break;
                
            }

                
                Console.ReadLine();// ожидание нажатия клавиши для выхода из консоли
        }
        
            }
        }





    
        

    
