using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaClassLibrary
{
    public class SocialNetwork
    {
        private Dictionary<Panda, List<Panda>> allPandasInTheNetwork = new Dictionary<Panda, List<Panda>>();
        private static SocialNetwork pandaNetwork;

        private SocialNetwork() { }

        public static SocialNetwork PandaNetwork
        {
            get
            {
                if (pandaNetwork == null)
                {
                    pandaNetwork = new SocialNetwork();
                }
                return pandaNetwork;
            }

        }
        public static Dictionary<Panda,List<Panda>> AllPandasInTheNetwork { get; set; }

        
        public void AddPanda(Panda panda)
        {

            allPandasInTheNetwork.Add(panda, new List<Panda>());
        }

        public bool HasPanda(Panda panda)
        {
            if (AllPandasInTheNetwork.Keys.Contains<Panda>(panda))
            {
                return true;
            }
            else
                return false;
        }

        public void MakeFriends(Panda panda1, Panda panda2)
        {
            if (AreFriends(panda1, panda2))
            {
                throw new PandasAlreadyFriendsException();
            }
            if (!(allPandasInTheNetwork.ContainsKey(panda1)))
            {
                allPandasInTheNetwork.Add(panda1, new List<Panda>());
            }
            if (!(allPandasInTheNetwork.ContainsKey(panda2)))
            {
                allPandasInTheNetwork.Add(panda2, new List<Panda>());
            }
            if (!(allPandasInTheNetwork[panda1].Contains(panda2)))
            {
                allPandasInTheNetwork[panda1].Add(panda2);
            }
            if (!(allPandasInTheNetwork[panda2].Contains(panda1)))
            {
                allPandasInTheNetwork[panda2].Add(panda1);
            }
        }

        public bool AreFriends(Panda panda1, Panda panda2)
        {
            if (allPandasInTheNetwork[panda1].Contains(panda2)&&allPandasInTheNetwork[panda2].Contains(panda1))
                return true;
            else
                return false;
        }

        public List<Panda> FriendsOf(Panda panda)
        {
            List<Panda> friendsOfThisPanda = allPandasInTheNetwork[panda];
            return friendsOfThisPanda;
        }

        public int ConnectionLevel(Panda panda1 , Panda panda2)
        {
            if(AreFriends(panda1,panda2))
            {
                return 1;
            }
            //to be continued
            return 2;

        }

        public bool AreConnected(Panda panda1 , Panda panda2)
        {
            if (ConnectionLevel(panda1, panda2) == -1)
            {
                return false;
            }
            else
                return true;
        }

        public void HowManyGenderInNetwork(int level , Panda panda , GenderType gender)
        {
            int genderCounter = 0;
            if(level == 1)
            {
                foreach(var el in allPandasInTheNetwork[panda])
                {
                    if(el.Gender == gender)
                    {
                        genderCounter++;
                    }
                }
            }
            else
            {

            }
        }

    }
}