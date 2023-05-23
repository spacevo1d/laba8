using System.Text;
using System.Text.RegularExpressions;

public delegate double MyFunction(double x);
public delegate int StringFun(string x);
public delegate string StringFun1(string x);
class Program
{
    static string Reverse(string str)
    {
        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
    static void TabFunct(double a, double b, double c, MyFunction f)
    {
        for (double i = a; i <= b; i += c)
        {
            Console.WriteLine($"x={i} f(x)= {f(i)}");
        }
    }
    static double var(double a)
    {
        return 2 * Math.Sqrt(Math.Abs(a - 1)) + 1;
    }
    static int[] Tabul(double a, double b, double c, MyFunction f)
    {
        int[] arr = new int[2];
        arr[0] = 0;
        arr[1] = 0; 
        for (double i = a; i <= b; i += c)
        {
            if (f(i) < 0)
            {
                arr[0]++;
            }
            if(f(i) >=-1 && f(i) <= 1)
            {
                arr[1]++;
            }
        }
        return arr;
    }
    static void Rnd(int q,MyFunction f)
    {
        Console.WriteLine("Function:" + f.Method);
        Random rnd = new Random();
        double[] arr = new double[q];
        double max = double.NegativeInfinity;
        double min = double.PositiveInfinity;
        for(int i = 0; i < q; i++)
        {
            arr[i] = f(rnd.Next(-10,10));
            if (arr[i]>max) max= arr[i];
            if (arr[i]<min) min= arr[i];
        }
        Console.WriteLine("Max:" + max);
        Console.WriteLine("Min:" + min);
        Console.WriteLine();
    }
    
    static void Cnt(string[] arr,StringFun f)
    {
        int cnt = 0;
        for( int i = 0; i < arr.Length; i++)
        {
            cnt += f(arr[i]);
        }
        Console.WriteLine("Кол-во искомых строк:" + cnt);
    }
    static void Print(string[] arr,StringFun1 f)
    {
        StringBuilder res = new StringBuilder("");
        for (int i = 0; i < arr.Length; i++)
        {
            res.Append(f(arr[i]));
        }
        Console.WriteLine(res.ToString());
    }
    static double Del(double a, double b, MyFunction f, double eps = 0.0001)
    {
        double ksi = (a + b) / 2;
        if (Math.Abs(f(a) - f(b)) <= eps || Math.Abs(f(ksi)) <= eps) ;
            return ksi;
        if (f(a) * f(ksi) <= 0)
            return Del(a, ksi, f);
        else
            return Del(ksi, b, f);
    }
    static void Main(string[] args)
    {
        MyFunction y;
        y = (double x) => (-1) * Math.Pow(x / Math.PI, 2) - 2 * x + 5 * Math.PI;
        MyFunction t = (double a) =>
        {
            int k = 1;
            double sum = 0;
            while (k <= 100)
            {
                sum += Math.Pow((a / Math.PI / k - 1), 2);
                k++;
            }
            return sum;
        };
        MyFunction r;
        r = delegate (double x)
        {
            if (x < 0)
            {
                return 1.0 / 4 * Math.Pow(Math.Sin(x), 2) + 1;
            }
            else
            {
                return 1.0 / 2 * Math.Cos(x) - 1;
            }
        };
        MyFunction a3 = (double x) =>
        {
            return x * Math.Sin(x) - 0.5;
        };
        MyFunction b3 = (double x) =>
        {
            return Math.Log(x*x-3*x+2);
        };
        MyFunction d3 = (double x) =>
        {
            return 0.5 * Math.Tan(2.0 / 3 * (x + Math.PI / 4)) - 1;
        };
        StringFun stra1 = (string a) =>
        {
            if (a == a.ToLower()) { return 1; }
            return 0;
        };
        StringFun stra2 = (string a) =>
        {
            int cnt = 0;
            string[] qwe = a.Split();
            for(int i = 0; i < qwe.Length; i++)
            {
                if (qwe[i] == Reverse(qwe[i]))
                {
                    cnt++;
                }
            }
            return cnt;
        };
        StringFun strb1 = (string a) =>
        {
            if (a.Length == 10) { return 1; }
            return 0;
        };
        StringFun strb2 = (string a) =>
        {
            int cnt = 0;
            string[] qwe = a.Split();
            for (int i = 0; i < qwe.Length; i++)
            {
                if (qwe[i].Length == 5)
                {
                    cnt++;
                }
            }
            return cnt;
        };
        StringFun1 strc1 = (string a) =>
        {
            string[] qwe = a.Split();
            StringBuilder res = new StringBuilder("");
            for(int i = 0; i < qwe.Length; i++)
            {
                if (qwe[i][0].ToString() == "W")
                {
                    res.Append(qwe[i]);
                    res.Append(" ");
                }
            }
            return res.ToString();
        };
        StringFun1 strc2 = (string a) =>
        {
            Regex temp = new Regex(@"[a-zA-zа-яА-я]{1,}[-]{1}[a-zA-zа-яА-я]{1,}");
            MatchCollection qwe = temp.Matches(a);
            StringBuilder res = new StringBuilder("");
            for(int i = 0; i < qwe.Count; i++)
            {
                res.Append(qwe[i].Value);
            }
            return res.ToString();
        };
        //Задание 1.а
        //TabFunct(-2 * Math.PI, 2 * Math.PI, Math.PI / 6, Math.Cos);
        //TabFunct(-2 * Math.PI, 2 * Math.PI, Math.PI / 6, var);
        //TabFunct(-2 * Math.PI, 2 * Math.PI, Math.PI / 6, y);
        //TabFunct(-2 * Math.PI, 2 * Math.PI, Math.PI / 6, t);
        //TabFunct(-2 * Math.PI, 2 * Math.PI, Math.PI / 6, r);


        //Задание 1.б
        //Func<double, double> function = delegate (double a) { return Math.Cos(a); };
        //Action<double, double, double> printfunc = delegate (double a, double b, double c)
        //{
        //    for (double i = a; i <= b; i += c)
        //    {
        //        Console.WriteLine($"x={i} f(x)= {function(i)}");
        //    }
        //};
        //printfunc(-2 * Math.PI, 2 * Math.PI, Math.PI / 6);


        //Задание 1.в
        //MyFunction[] arr = new MyFunction[5];
        //arr[0]= Math.Cos;
        //arr[1] = var;
        //arr[2] = y;
        //arr[3] = t;
        //arr[4]= r;
        //for(int i = 0; i < 5; i++)
        //{
        //    TabFunct(-2 * Math.PI, 2 * Math.PI, Math.PI / 6, arr[i]);
        //    Console.WriteLine();
        //    Console.WriteLine();
        //}


        //Задание 1.г
        //int[] f1=Tabul(-2 * Math.PI, 2 * Math.PI, Math.PI / 6, Math.Cos);
        //Console.WriteLine("Kоличество отрицательных значений функции пункта 1.a.a:  "+f1[0]);
        //Console.WriteLine("Kоличество значений из [-1; 1] функции пункта 1.a.a:  " + f1[1]);
        //Console.WriteLine();
        //int[] f2 = Tabul(-2 * Math.PI, 2 * Math.PI, Math.PI / 6, var);
        //Console.WriteLine("Kоличество отрицательных значений функции пункта 1.a.b:  " + f2[0]);
        //Console.WriteLine("Kоличество значений из [-1; 1] функции пункта 1.a.b:  " + f2[1]);
        //Console.WriteLine();
        //int[] f3 = Tabul(-2 * Math.PI, 2 * Math.PI, Math.PI / 6, y);
        //Console.WriteLine("Kоличество отрицательных значений функции пункта 1.a.c:  " + f3[0]);
        //Console.WriteLine("Kоличество значений из [-1; 1] функции пункта 1.a.c:  " + f3[1]);
        //Console.WriteLine();
        //int[] f4 = Tabul(-2 * Math.PI, 2 * Math.PI, Math.PI / 6, t);
        //Console.WriteLine("Kоличество отрицательных значений функции пункта 1.a.d:  " + f4[0]);
        //Console.WriteLine("Kоличество значений из [-1; 1] функции пункта 1.a.d:  " + f4[1]);
        //Console.WriteLine();
        //int[] f5 = Tabul(-2 * Math.PI, 2 * Math.PI, Math.PI / 6, r);
        //Console.WriteLine("Kоличество отрицательных значений функции пункта 1.a.e:  " + f5[0]);
        //Console.WriteLine("Kоличество значений из [-1; 1] функции пункта 1.a.e:  " + f5[1]);


        //Задание 1.д
        //Rnd(5,Math.Cos);
        //Rnd(5, var);
        //Rnd(5, y);
        //Rnd(5, t);
        //Rnd(5, r);


        ////Задание 2
        //string[] arr = new string[5];
        //for(int i = 0; i < arr.Length; i++)
        //{
        //    Console.WriteLine("Введите строку:");
        //    arr[i]=Console.ReadLine();
        //}
        ////Задание 2.а
        //Cnt(arr, stra1);
        //Cnt(arr, stra2);
        ////Задание 2.b
        //Cnt(arr, strb1);
        //Cnt(arr, strb2);
        ////Задание 2.c
        //Print(arr, strc1);
        //Print(arr, strc2);


        //Задание 3
        Console.WriteLine(Del(0, Math.PI, a3, 0.0001));
        Console.WriteLine(Del(0, 0.9, b3, 0.0001));
        Console.WriteLine(Del(2.1, 5, b3, 0.0001));
        Console.WriteLine(Del(Math.PI, 2*Math.PI, d3, 0.0001));
    }
}
