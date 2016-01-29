using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace PandaClassLibrary
{
    public class PandaSocialNetworkSerializer : IPandaSocialNetworkStorageProvider
    {
        private string fileName;

        public PandaSocialNetworkSerializer(string file)
        {
            fileName = file;
        }
        
        public SocialNetwork Load()
        {
            using (FileStream streamReader = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (SocialNetwork)bf.Deserialize(streamReader);
            }
        }

        public void Save(SocialNetwork network)
        {
            using (FileStream streamWriter = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(streamWriter, network);
            }
        }
    }
}