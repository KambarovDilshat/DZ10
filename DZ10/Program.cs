using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ10
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    namespace Module10.Homework
    {
        public interface ICalculatable
        {
            double Add(double a, double b);
            double Subtract(double a, double b);
            double Multiply(double a, double b);
            double Divide(double a, double b);
        }

       

       

        public class AdvancedCalculator : SimpleCalculator, ICalculatable, IStorable
        {
            public double Power(double a, double exponent) => Math.Pow(a, exponent);
            public double SquareRoot(double a) => Math.Sqrt(a);

            public void DisplayPowerResult(double a, double exponent)
            {
                double result = Power(a, exponent);
                Console.WriteLine($"{a} ^ {exponent} = {result}");
            }

            public void DisplaySquareRootResult(double a)
            {
                double result = SquareRoot(a);
                Console.WriteLine($"√{a} = {result}");
            }

            public void SaveState(string filePath)
            {
               
                string content = "Калькулятор сохранен";
                File.WriteAllText(filePath, content);
            }

            public void LoadState(string filePath)
            {
              
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    Console.WriteLine($"Загружено состояние: {content}");
                }
                else
                {
                    Console.WriteLine("Файл состояния не найден.");
                }
            }
        }
        public interface IStorable
        {
            void SaveState(string filePath);
            void LoadState(string filePath);
        }
        public class SimpleCalculator : ICalculatable
        {
            public double Add(double a, double b) => a + b;
            public double Subtract(double a, double b) => a - b;
            public double Multiply(double a, double b) => a * b;
            public double Divide(double a, double b) => a / b;

            public void DisplayResult(double result)
            {
                Console.WriteLine($"Результат: {result}");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var simpleCalc = new SimpleCalculator();
                simpleCalc.DisplayResult(simpleCalc.Add(7, 15));

                var advancedCalc = new AdvancedCalculator();
                advancedCalc.DisplayPowerResult(2, 4);
                advancedCalc.DisplaySquareRootResult(25);

             
                string filePath = "calculatorState.txt";
                advancedCalc.SaveState(filePath);
                advancedCalc.LoadState(filePath);
            }
        }
    }
}
