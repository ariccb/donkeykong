using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyKong
{
    [Serializable]
    class Level
    {
        public string name;
        public static List<LevelObject> LevelObjectList = new List<LevelObject>();
        public bool saved = false;

        public void Serialize() // exporting to the harddrive as a file
        {
            Stream stream = File.Open((name + ".lvl"), FileMode.Create);
            try 
            {
                BinaryFormatter binaryformatter = new BinaryFormatter();
                binaryformatter.Serialize(stream, this);
            }
            catch(SerializationException e){ }
        }

        /*public static Level Deserialize()
        {

        }*/

        public void Update()
        {
            if (Editor.keys.Contains("s") && !saved)
            {
                saved = true;
                Serialize();
            }
        }
    }
    
}
