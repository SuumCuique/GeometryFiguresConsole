using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace GeometryFigures
{
    class Program
    {
        public static List<Figure> list = new List<Figure>();
        static void Main(string[] args)
        {
            for(; ; )
            {
                Console.WriteLine("Select action:");
                Console.WriteLine("1.Add figure.");
                Console.WriteLine("2.Remove figure.");
                Console.WriteLine("3.Create random data.");
                Console.WriteLine("4.Find figures.");
                Console.WriteLine("5.Save.");
                Console.WriteLine("6.Load.");
                Console.WriteLine("7.View.");
                Console.WriteLine("8.Exit.");

                var Action = Console.ReadKey().Key;
                Console.WriteLine();
                if (Action == ConsoleKey.D8 || Action == ConsoleKey.NumPad8) Environment.Exit(0);
                else if (Action == ConsoleKey.D6 || Action == ConsoleKey.NumPad6) Load();
                else if (Action == ConsoleKey.D5 || Action == ConsoleKey.NumPad5) Save();
                else if (Action == ConsoleKey.D4 || Action == ConsoleKey.NumPad4) FindFigures();
                else if (Action == ConsoleKey.D3 || Action == ConsoleKey.NumPad3) CreateRandomData();
                else if (Action == ConsoleKey.D2 || Action == ConsoleKey.NumPad2) RemoveFigure();
                else if (Action == ConsoleKey.D1 || Action == ConsoleKey.NumPad1) AddFigure();
                else if (Action == ConsoleKey.D7 || Action == ConsoleKey.NumPad7) View();
            }

            void AddFigure()
            {
                Console.WriteLine("Select type figure:");
                Console.WriteLine("1.Circle");
                Console.WriteLine("2.Triangle");
                Console.WriteLine("3.Rectangle");
                var TypeKey = Console.ReadKey().Key;

                if (TypeKey == ConsoleKey.D1 || TypeKey == ConsoleKey.NumPad1)
                {
                    Console.WriteLine("Input radius:");
                    int Radius = Convert.ToInt32(Parser(Console.ReadLine()));
                    Circle circle = new Circle(Radius);
                    list.Add(circle);
                }
                else if (TypeKey == ConsoleKey.D2 || TypeKey == ConsoleKey.NumPad2)
                {
                    Console.WriteLine("Input side A:");
                    int SideA = Convert.ToInt32(Parser(Console.ReadLine()));
                    Console.WriteLine("Input side B:");
                    int SideB = Convert.ToInt32(Parser(Console.ReadLine()));
                    Console.WriteLine("Input side C:");
                    int SideC = Convert.ToInt32(Parser(Console.ReadLine()));
                    Triangle triangle = new Triangle(SideA, SideB, SideC);
                    list.Add(triangle);
                }
                else if (TypeKey == ConsoleKey.D3 || TypeKey == ConsoleKey.NumPad3)
                {
                    Console.WriteLine("Input side A:");
                    int SideA = Convert.ToInt32(Parser(Console.ReadLine()));
                    Console.WriteLine("Input side B:");
                    int SideB = Convert.ToInt32(Parser(Console.ReadLine()));
                    Rectangle rectangle = new Rectangle(SideA, SideB);
                    list.Add(rectangle);
                }
            }
            void RemoveFigure()
            {
                Console.WriteLine("Enter index remove element: ");
                int Index = 0;
                try { Index = Convert.ToInt32(Console.ReadLine()); }
                catch { };

                if (Index < list.Count()) list.RemoveAt(Index);
            }
            void CreateRandomData()
            {
                list.Clear();
                Random rand = new Random();
                Figure figure = new Circle();
                for (int i = 0; i < 10; i++)
                {
                    int x = rand.Next(1, 4);
                    switch (x)
                    {
                        case 1:
                            Circle circle = new Circle(rand.Next(1, 11));
                            circle.CalculateArea();
                            figure = circle;
                            break;
                        case 2:
                            Triangle triangle = new Triangle(rand.Next(1, 11), rand.Next(1, 11), rand.Next(1, 11));
                            triangle.CalculateArea();
                            figure = triangle;
                            break;
                        case 3:
                            Rectangle rectangle = new Rectangle(rand.Next(1, 11), rand.Next(1, 11));
                            rectangle.CalculateArea();
                            figure = rectangle;
                            break;
                    }
                    list.Add(figure);
                }
            }
            void FindFigures()
            {
                if (list.Count == 0) Console.WriteLine("List of Figures is empty!");
                else
                {
                    Console.WriteLine("Select type figures:");
                    Console.WriteLine("1.All");
                    Console.WriteLine("2.Circle");
                    Console.WriteLine("3.Triangle");
                    Console.WriteLine("4.Rectangle");
                    var TypeKey = Console.ReadKey().Key;
                    string Item;

                    if (TypeKey == ConsoleKey.D1 || TypeKey == ConsoleKey.NumPad1) Item = "All";
                    else if (TypeKey == ConsoleKey.D2 || TypeKey == ConsoleKey.NumPad2) Item = "Circle";
                    else if (TypeKey == ConsoleKey.D3 || TypeKey == ConsoleKey.NumPad3) Item = "Triangle";
                    else if (TypeKey == ConsoleKey.D4 || TypeKey == ConsoleKey.NumPad4) Item = "Rectangle";
                    else
                    {
                        FindFigures();
                        return;
                    }

                    Console.WriteLine("Select type filter size:");
                    Console.WriteLine("1.Greater than");
                    Console.WriteLine("2.Equal");
                    Console.WriteLine("3.Less than");
                    var FilterKey = Console.ReadKey().Key;
                    int FilterType = 0, FilterValue = 0;
                    Console.WriteLine("Input filter value:");

                    string temp = Console.ReadLine();
                    string temp2 = "";
                    foreach (var symbol in temp)
                        if (char.IsDigit(symbol)) temp2 += symbol;

                    FilterValue = Convert.ToInt32(temp2);

                    if (FilterKey == ConsoleKey.D1 || FilterKey == ConsoleKey.NumPad1) FilterType = 1;
                    else if (FilterKey == ConsoleKey.D2 || FilterKey == ConsoleKey.NumPad2) FilterType = 2;
                    else if (FilterKey == ConsoleKey.D3 || FilterKey == ConsoleKey.NumPad3) FilterType = 3;
                    else
                    {
                        FindFigures();
                        return;
                    }

                    for (int i = 0; i < list.Count(); i++)
                    {
                        int FlagType = 0;
                        if (Item == "All") FlagType = 1;
                        else if (list[i].GetType().ToString().Split('.')[1] == Item) FlagType = 1;
                        if (FlagType == 1)
                        {
                            if (((FilterType == 1) && (Convert.ToInt32(list[i].ReturnArea()) > FilterValue))
                            || ((FilterType == 2) && (Convert.ToInt32(list[i].ReturnArea()) == FilterValue))
                            || ((FilterType == 3) && (Convert.ToInt32(list[i].ReturnArea()) < FilterValue)))
                                Console.Write("{0}\t\t{1}\t\t{2}\n", i, list[i].GetType().ToString().Split('.')[1], list[i].ReturnArea());
                        }
                    }
                }
            }
            void Save()
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Figure>));
                using (FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\save.figures", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, list);
                }
            }
            void Load()
            {
                if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\save.figures"))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<Figure>));
                    using (FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\save.figures", FileMode.OpenOrCreate))
                    {
                        list = (List<Figure>)formatter.Deserialize(fs);
                    }
                }
            }
            string Parser(string str)
            {
                string temp = "";
                int separator = 0;
                foreach (var symbol in str)
                {
                    if (char.IsDigit(symbol) || ((symbol == '.' || symbol == ',') && separator == 0)) temp += symbol;
                    if (symbol == '.' || symbol == ',') separator++;
                }
                return temp;
            }
            void View()
            {
                if (list.Count() == 0)
                {
                    Console.WriteLine("List of figures is empty!");
                }
                else for (int i = 0; i < list.Count(); i++)
                    {
                        if(list[i].GetType().ToString().Split('.')[1] == "Circle")
                            Console.Write("{0}\t\t{1}\t\t\t{2}\n", i, list[i].GetType().ToString().Split('.')[1], list[i].ReturnArea());
                        else
                            Console.Write("{0}\t\t{1}\t\t{2}\n", i, list[i].GetType().ToString().Split('.')[1], list[i].ReturnArea());
                    }
            }
        }
    }
}