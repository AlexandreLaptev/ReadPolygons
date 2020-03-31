using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace ReadPolygons
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Get the current directory and make it a DirectoryInfo object.
                // Do not use Environment.CurrentDirectory, vistual studio 
                // and visual studio code will return different result:
                // Visual studio will return @"projectDir\bin\Release\netcoreapp2.0\", yet 
                // vs code will return @"projectDir\"
                var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

                // On windows, the current directory is the compiled binary sits,
                // so string like @"bin\Release\netcoreapp2.0\" will follow the project directory. 
                // Hense, the project directory is the great grand-father of the current directory.
                string projectDirectory = currentDirectory.Parent.Parent.Parent.FullName;

                string polygonPath = Path.Combine(projectDirectory, "Polygons.xml");

                var polygons = new List<Polygon>();

                var xelement = XElement.Load(polygonPath);
                var xelements = xelement.Elements();

                foreach (var e in xelements)
                {
                    var polygon = new Polygon
                        (
                            double.Parse(e.Element("UpperLeftLongitude").Value),
                            double.Parse(e.Element("UpperLeftLatitude").Value),
                            double.Parse(e.Element("LowerRightLongitude").Value),
                            double.Parse(e.Element("LowerRightLatitude").Value)
                        );

                    polygons.Add(polygon);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{polygons.Count} loaded from '{polygonPath}' file.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}