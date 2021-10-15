using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection; // lets you do meta-programming 

namespace DonkeyKong
{
    public class Toolbar
    {
        public Toolbar()
        {
            IEnumerable<Type> objectType = GetEnumerableOfType<LevelObject>();
            int spacer = 15;
            for (int i = 0; i < objectType.Count(); i++)
            {
                LevelObject levelObject = (LevelObject)Activator.CreateInstance(objectType.ElementAt(i));
                levelObject.x = 10;
                levelObject.y = spacer;
                int oldSpacer = spacer;
                Type type = objectType.ElementAt(i);
                EventHandler releasedHandler = null;
                levelObject.Released += releasedHandler = (sender, e) => {
                    levelObject.Released -= releasedHandler;
                    LevelObject_Released(sender, e, type, oldSpacer); 
                };
                spacer += levelObject.Height + 20;
            }
        }

        private void LevelObject_Released(object sender, EventArgs e, Type type, int spacer)
        {
            LevelObject levelObject = (LevelObject)Activator.CreateInstance(type);
            levelObject.x = 10;
            levelObject.y = spacer;
            int oldSpacer = spacer;
            EventHandler releasedHandler = null;
            levelObject.Released += releasedHandler = (sender2, e2) => {
                levelObject.Released -= releasedHandler;
                LevelObject_Released(sender2, e2, type, oldSpacer);
            };
        }

        public static IEnumerable<Type> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
        {
            List<Type> types = new List<Type>();
            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes().Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(T)) && !myType.IsAbstract))
            {
                types.Add(type);
            }
            return types;
        }
    }
}
