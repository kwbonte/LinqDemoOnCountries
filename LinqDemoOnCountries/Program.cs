using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemoOnCountries
{
    class Program
    {
        // Write a console application and make CRUD (Create, Read, Update and Delete) along with Search function. Take Countries as a Data Source (with its properties) and perform LINQ queries on this.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            List<Country> countries = new List<Country> { new Country { Name = "China", Population = 7500 }, new Country { Name = "India", Population = 1400 }, new Country { Name = "USA", Population = 322 } };
            // Create Operation
            // as far as i can tell there is no linq function for create, it is more of an iterate, filter, or surmise and sort query not a creator
            // Read Operation
            var list = from c in countries
                       where c.Population > 0
                       select c.Name;
            foreach(var n in list)
                Console.WriteLine(n);
            // Update Operation
            countries = (from c in countries
                         select new Country
                         {
                             Name = c.Name,
                             Population = (c.Name == "China" ? 1 : c.Population)
                         }).ToList();
            foreach (var c in countries)
                Console.WriteLine("{0} has a population of: {1} million.", c.Name, c.Population);
            // Delete Operation
            Console.WriteLine("Delete China");
            countries.RemoveAll(x => x.Name == "China");
            foreach(var c in countries)
                Console.WriteLine("{0} has a population of: {1} million.",c.Name, c.Population);
            Console.ReadLine();
        }

        public class Country
        {
            public string Name { get; set; }
            public int Population { get; set; }
        }

    }
}
