using System;

namespace DelegateTester
{
    class Program
    {
        public delegate void MyDelegate(string msg);
        public delegate int IntDelegate();
        public delegate T add<T>(T a, T b);
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            MyDelegate del = ClassA.MethodA;
            del("Hello");

            del = ClassB.MethodB;
            del("World");

            del = (string msg) => Console.WriteLine("Called ambda expression: " + msg);
            del("Hello World");


            del = ClassA.MethodA;
            InvokeDelegate(del);

            del = ClassB.MethodB;
            InvokeDelegate(del);

            del = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
            InvokeDelegate(del);

            MyDelegate del1 = ClassA.MethodA;
            MyDelegate del2 = ClassB.MethodB;

            del = del1 + del2;
            del("Combined Delegate: Hello World");

            MyDelegate del3 = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
            del += del3;
            del("Combined with del3 Hello World");

            IntDelegate del4 = ClassA.MethodA;
            IntDelegate del5 = ClassB.MethodB;
            del4 += del5;
            Console.WriteLine(del4()); //return ClassB.MethodB

            add<int> sum = Sum;
            Console.WriteLine(sum(10, 20));

            add<string> concat = Concat;
            Console.WriteLine(concat("Hello ", "World "));
        }

        static int Sum(int a, int b)
        {
            return a + b;
        }

        static string Concat(string a, string b)
        {
            return a + b;
        }

        static void InvokeDelegate(MyDelegate del)
        {
            del("Hello World");
        }
        class ClassA
        {
            public static void MethodA(string msg)
            {
                Console.WriteLine("This is ClassA.MethodA(): " + msg);
            }
            public static int MethodA()
            {
                return 100;
            }
        }

        class ClassB
        {
            public static void MethodB(string msg)
            {
                Console.WriteLine("This is ClassB.MethodB(): " + msg);
            }
            public static int MethodB()
            {
                return 200;
            }
        }
    }
}
