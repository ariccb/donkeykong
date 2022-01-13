using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DonkeyKong
{
    [Serializable]
    public class Level
    {
        public string name;
        public List<LevelObject> LevelObjectList = new List<LevelObject>();
        public bool saved = false;

        public Level()
        {

        } 

        public void Serialize() // exporting to the harddrive as a file
        {
            Stream stream = File.Open((name + ".xml"), FileMode.Create);
            try 
            {                
                XmlSerializer xmlS = new XmlSerializer(this.GetType());
                xmlS.Serialize(stream, this);                
            }
            catch(SerializationException e){ }
        }

        public static Level Deserialize(String path)
        {
            Level level = new Level();            
            Stream loadStream = File.Open(path, FileMode.Open);

            XmlSerializer xmlS = new XmlSerializer(level.GetType());
            xmlS.Deserialize(loadStream); // causing errer at this line:
                                          // System.Runtime.Serialization.SerializationException: 'End of Stream encountered before parsing was completed.'
            return level;            
        }

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
