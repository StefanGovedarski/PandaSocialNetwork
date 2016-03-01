using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaClassLibrary
{
    public interface IPandaSocialNetworkStorageProvider
    {
        void Save(SocialNetwork network);

        SocialNetwork Load();
    }
}
