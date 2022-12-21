using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            Regex r1 = new Regex(@"^a$"); // a
            Regex r2 = new Regex(@"^a{6}$"); // aaaaaa
            Regex r3 = new Regex(@"^a aa a$"); // a aa a
            Regex r4 = new Regex(@"^[\w]{5,}$"); // Не менее 5 алфавитно-цифровых символов
            Regex r5 = new Regex(@"^[\w\-]+@((\w+)|(\w[\w-]+))\.\w+$"); // Email
            Regex r6 = new Regex(@"^(?:[уУ][лЛ]\.\s+)?([а-яА-яёЁ]+(\-[а-яА-ЯёЁ]+)?)\,?\s+(?:[дД]\.\s+)?(\d+(?:[\-\/]\d+)?)$"); // Ул.строка д.число/число
            for(int i = 0; i<input.Length; i++)
            {
                if (r1.IsMatch(input[i]))
                {
                    Console.WriteLine("1)"+input[i]);
                }
                if (r2.IsMatch(input[i]))
                {
                    Console.WriteLine("2)" + input[i]);
                }
                if (r3.IsMatch(input[i]))
                {
                    Console.WriteLine("3)" + input[i]);
                }
                if (r4.IsMatch(input[i]))
                {
                    Console.WriteLine("4)" + input[i]);
                }
                if (r5.IsMatch(input[i]))
                {
                    Console.WriteLine("5)" + input[i]);
                }
                if (r6.IsMatch(input[i]))
                {
                    Console.WriteLine("6)" + input[i]);
                }
            }
            var Street = Console.ReadLine();
            if (r6.IsMatch(Street))
            {
                var Groups = r6.Split(Street); 
                Console.WriteLine($"Улица: {Groups[1]}\nДом: {Groups[2]}");

            }
            else
            {
                Console.WriteLine("Не найдено");
            }
            string text = "Добро пожаловать в наш магазин, вот наши цены: 1 кг. яблоки - 90 руб., 2 кг. апельсины - 130 руб. Также в ассортименте орехи в следующей фасовке: 0.5 кг. миндаль - 500 руб";
            Regex rd1 = new Regex(@"((?:\d+)?\.?\d+)?\sкг\.\s(\w+)\s\-\s(\d+)\sруб\.?"); // доп задани 1
            var RawProducts = rd1.Matches(text);
            foreach (Match RawProduct in RawProducts)
            {
                foreach (Match ProductString in rd1.Matches(RawProduct.Value))
                {
                    var SplitProduct = ProductString.Groups;
                    Console.WriteLine($"{SplitProduct[2]} - {Convert.ToDouble(SplitProduct[3].Value) / Convert.ToDouble(SplitProduct[1].Value.Replace('.', ','))} руб/кг");
                }

            }
            Regex rd2 = new Regex(@"(\s|^)((https://)|(http://)|(ftp://))?(www\.)?([^-\s][\w_-]+\.){1,4}\w+"); // доп задание 2
            string[] input2 = File.ReadAllLines(@"input2.txt");
            for (int i = 0; i < input2.Length; i++)
            {
                if(rd2.IsMatch(input2[i]))
                {
                    Console.WriteLine("2.dop)"+input2[i]);
                }
            }
        }
    }
}
