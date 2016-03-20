using SpaceClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SpaceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BlackHoleClient bhClient = new BlackHoleClient();

                StarShip st = new StarShip();

                st.Crew = new Person[] { new Person() { Name = "John", Age = 20 }, new Person() { Name = "Paul", Age = 30 }, new Person() { Name = "Max", Age = 25 }, new Person() { Name = "James", Age = 40 }, new Person { Name = "Peter", Age = 45 } };
                st.Captain = new Person() { Name = "Captain Yolo", Age = 20 };
                PresentCrew(st);
                Console.WriteLine(bhClient.UltimateAnswer());
                StarShip st2 = bhClient.PullStarship(st);
                PresentCrew(st2);
                Console.ReadLine();
            }
            catch (CommunicationException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public static void PresentCrew(StarShip st)
        {
            Console.WriteLine("Captain's name: " + st.Captain.Name + ", Age: " + st.Captain.Age);
            Console.WriteLine("Crew:");
            foreach (var P in st.Crew)
            {
                Console.WriteLine(P.Name + ", Age: " + P.Age);
            }
        }
    }
}
