using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaClassLibrary
{
    public class SocialNetwork
    {
        
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
        //public Dictionary<> AllPandasInTheNetwork { get; set; }


        public void AddPanda(Panda panda)
        {

        }
        //public bool HasPanda(Panda panda)
        //{

        //}
        public void MakeFriends(Panda panda1 , Panda panda2)
        {

        }





    }
}
