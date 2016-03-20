using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    public class BlackHole : IBlackHole
    {

        void AddAge(StarShip s)
        {
            foreach (Person p in s.Crew)
            {
                p.Age += 20;
            }
        }

        public StarShip PullStarship(StarShip s)
        {
            if (s.Captain.Age < 40)
            {
                AddAge(s);
            }
            return s;
        }

        public string UltimateAnswer()
        {
            return 42.ToString();
        }
    }
}
